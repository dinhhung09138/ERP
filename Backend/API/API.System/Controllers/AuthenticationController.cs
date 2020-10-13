using API.System.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.System.Interfaces;
using System.Threading.Tasks;

namespace API.System.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenService;

        public AuthenticationController(IAuthenticationService authenService)
        {
            _authenService = authenService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ResponseModel> Login([FromBody] LoginModel login)
        {
            var response = await _authenService.AuthencitateUser(login);
            return response;
        }


    }
}
