using Core.CommonModel;
using Core.Services.Interfaces;
using Core.Utility.Security;
using Database.Sql.ERP;
using Service.Security.Interfaces;
using System;
using System.Threading.Tasks;

namespace Service.Security
{
    public class AuthenticationService : IAuthenticationService
    {
        private IJwtTokenSecurityService _tokenService;
        private IERPUnitOfWork _context;
        public AuthenticationService(IJwtTokenSecurityService tokenService, IERPUnitOfWork context)
        {
            _tokenService = tokenService;
            _context = context;
        }

        public async Task<ResponseModel> AuthencitateUser(LoginModel model)
        {
            ResponseModel response = new ResponseModel();
            response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Warning;
            //
            var password = PasswordSecurityHelper.GetHashedPassword(model.Password);
            //
            var md = await _context.UserRepository.FirstOrDefaultAsync(m => m.UserName == model.UserName && m.Password == password).ConfigureAwait(false);
            if (md != null)
            {
                UserModel user = new UserModel()
                {
                    Id = md.Id,
                    UserName = md.UserName,
                    FullName = string.Empty,
                    Email = string.Empty
                };
                JwtTokenModel token = _tokenService.CreateToken(user);
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Success;
                response.Result = token;
            }
            return response;
        }
    }
}
