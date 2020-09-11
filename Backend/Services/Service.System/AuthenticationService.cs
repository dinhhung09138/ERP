using Core.CommonModel;
using Core.Services.Interfaces;
using Core.Utility.Security;
using Database.Sql.ERP;
using Microsoft.Extensions.Logging;
using Service.Common.Interfaces;
using Service.Common.Models;
using Service.System.Interfaces;
using Service.System.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Service.System
{
    public class AuthenticationService : IAuthenticationService
    {
        private IJwtTokenSecurityService _tokenService;
        private IERPUnitOfWork _context;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IImageServerService _imageServerService;
        private readonly IFunctionService _functionService;

        public AuthenticationService(
            IJwtTokenSecurityService tokenService,
            IERPUnitOfWork context,
            ILogger<AuthenticationService> logger,
            IImageServerService imageServerService,
            IFunctionService functionService)
        {
            _tokenService = tokenService;
            _context = context;
            _logger = logger;
            _imageServerService = imageServerService;
            _functionService = functionService;
        }

        public async Task<ResponseModel> AuthencitateUser(LoginModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                var password = PasswordSecurityHelper.GetHashedPassword(model.Password);
                //
                var md = await _context.UserRepository.FirstOrDefaultAsync(m => m.UserName == model.UserName
                                                                            && m.Password == password
                                                                            && m.IsActive
                                                                            && !m.Deleted).ConfigureAwait(false);

                if (md != null)
                {
                    Core.CommonModel.UserModel user = await GetUserInfo(md.EmployeeId);
                    user.Id = md.Id;
                    user.UserName = md.UserName;
                    JwtTokenModel token = _tokenService.CreateToken(user);
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Success;
                    response.Result = token;
                    response.Extra.Add(await _functionService.GetListPageUserCanAccess(user.Id));


                    md.LastLogin = DateTime.Now;
                    _context.UserRepository.Update(md);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<ResponseModel> RefreshToken(TokenModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                var refreshToken = _tokenService.CheckRefreshToken(model);

                if (refreshToken != null)
                {
                    var md = await _context.UserRepository.FirstOrDefaultAsync(m => m.Id == model.UserId
                                                                                && m.IsActive
                                                                                && !m.Deleted).ConfigureAwait(false);
                    Core.CommonModel.UserModel user = await GetUserInfo(md.EmployeeId);
                    user.UserName = md.UserName;

                    JwtTokenModel token = _tokenService.CreateToken(user);
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Success;
                    response.Result = token;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public ResponseModel RevokeToken(TokenModel model)
        {
            ResponseModel response = new ResponseModel();

            _tokenService.RevokeToken(model);

            return response;
        }

        public async Task<bool> CheckAuthorization(string moduleName, string controllerName, string actionName)
        {
            try
            {
                var query = from m in _context.UserRoleRepository.Query()
                            join u in _context.UserRepository.Query() on m.UserId equals u.Id
                            join r in _context.RoleRepository.Query() on m.RoleId equals r.Id
                            join rdt in _context.RoleDetailRepository.Query() on m.RoleId equals rdt.RoleId
                            join c in _context.FunctionCommandRepository.Query() on rdt.CommandId equals c.Id
                            where m.UserId == 0 
                                    && c.ModuleName == moduleName
                                    && c.ControllerName == controllerName
                                    && c.ActionName == actionName
                                    && !u.Deleted && u.IsActive
                                    && !r.Deleted && r.IsActive
                            select new
                            {
                                m.UserId
                            };
                if (await query.AnyAsync() == false)
                {
                    return false;
                }
                            
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        private async Task<Core.CommonModel.UserModel> GetUserInfo(int employeeId)
        {
            var employeeInfo = await (from m in _context.EmployeeRepository.Query()
                                      join inf in _context.EmployeeInfoRepository.Query() on m.Id equals inf.EmployeeId
                                      join file in _context.FileRepository.Query() on m.AvatarFileId equals file.Id into files
                                      from f in files.DefaultIfEmpty()
                                      where m.Id == employeeId
                                      select new
                                      {
                                          m.Id,
                                          m.WorkingEmail,
                                          m.AvatarFileId,
                                          m.EmployeeCode,
                                          inf.FirstName,
                                          inf.LastName,
                                      }).FirstOrDefaultAsync();


            string avatarPath = string.Empty;
            if (employeeInfo != null && employeeInfo.AvatarFileId.HasValue)
            {
                var fileResponse = await _imageServerService.Item(employeeInfo.AvatarFileId.Value);

                if (fileResponse.ResponseStatus == Core.CommonModel.Enums.ResponseStatus.Success && fileResponse.Result != null)
                {
                    var fileInfo = fileResponse.Result as FileModel;
                    avatarPath = fileInfo.FilePath;
                }
            }

            Core.CommonModel.UserModel user = new Core.CommonModel.UserModel()
            {
                Id = 0,
                EmployeeId = employeeInfo.Id,
                UserName = string.Empty,
                FullName = $"{employeeInfo.FirstName} {employeeInfo.LastName}",
                Email = employeeInfo.WorkingEmail,
                Avatar = avatarPath
            };

            return user;
        }

    }
}
