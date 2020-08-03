using Core.CommonModel;
using Core.Services.Interfaces;
using Core.Utility.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Security.Controllers
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

        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public async Task<ResponseModel> RefreshToken([FromBody] TokenModel model)
        {
            var response = await _authenService.RefreshToken(model);
            return response;
        }

        [HttpPost("revoke-token")]
        [Authorization]
        public ResponseModel RevokeToken([FromBody] TokenModel model)
        {
            var response = _authenService.RevokeToken(model);
            return response;
        }

        [HttpPost("post")]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();

            return "Welcome To: ";
        }

    }
}
