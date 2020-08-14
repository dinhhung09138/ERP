using Core.CommonModel;
using Core.Services.Interfaces;
using Core.Utility.Security;
using Database.Sql.ERP;
using Microsoft.Extensions.Logging;
using Service.Security.Interfaces;
using System;
using System.Threading.Tasks;

namespace Service.Security
{
    public class AuthenticationService : IAuthenticationService
    {
        private IJwtTokenSecurityService _tokenService;
        private IERPUnitOfWork _context;
        private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(IJwtTokenSecurityService tokenService, IERPUnitOfWork context, ILogger<AuthenticationService> logger)
        {
            _tokenService = tokenService;
            _context = context;
            _logger = logger;
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
                    UserModel user = new UserModel()
                    {
                        Id = md.Id,
                        UserName = md.UserName,
                        FullName = string.Empty, // TODO
                        Email = string.Empty // TODO
                    };
                    JwtTokenModel token = _tokenService.CreateToken(user);
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Success;
                    response.Result = token;
                }
            }
            catch(Exception ex)
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
                    UserModel user = new UserModel()
                    {
                        Id = md.Id,
                        UserName = md.UserName,
                        FullName = string.Empty, // TODO
                        Email = string.Empty // TODO
                    };
                    JwtTokenModel token = _tokenService.CreateToken(user);
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Success;
                    response.Result = token;
                }
            }
            catch(Exception ex)
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
    }
}
