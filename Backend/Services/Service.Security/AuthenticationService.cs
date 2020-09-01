using Core.CommonModel;
using Core.Services.Interfaces;
using Core.Utility.Security;
using Database.Sql.ERP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Common.Interfaces;
using Service.Common.Models;
using Service.Security.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Security
{
    public class AuthenticationService : IAuthenticationService
    {
        private IJwtTokenSecurityService _tokenService;
        private IERPUnitOfWork _context;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IImageServerService _imageServerService;

        public AuthenticationService(
            IJwtTokenSecurityService tokenService,
            IERPUnitOfWork context,
            ILogger<AuthenticationService> logger,
            IImageServerService imageServerService)
        {
            _tokenService = tokenService;
            _context = context;
            _logger = logger;
            _imageServerService = imageServerService;
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
                    UserModel user = await GetUserInfo(md.EmployeeId);
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
                    UserModel user = await GetUserInfo(md.EmployeeId);
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

        private async Task<UserModel> GetUserInfo(int employeeId)
        {
            var employeeInfo = await(from m in _context.EmployeeRepository.Query()
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

            UserModel user = new UserModel()
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
