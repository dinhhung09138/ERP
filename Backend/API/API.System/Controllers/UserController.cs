using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.System.Interfaces;
using Service.System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace API.System.Controllers
{
    [Route("api/system/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList([FromBody] FilterModel filter)
        {
            var response = await _userService.GetList(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _userService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] Service.System.Models.UserModel model)
        {
            var response = await _userService.Insert(model);
            return response;
        }

        [HttpPut, Route("change-role")]
        public async Task<ResponseModel> ChangeRole([FromBody] Service.System.Models.UserModel model)
        {
            var response = await _userService.ChangeRole(model);
            return response;
        }

        [HttpPut, Route("active-or-deactivation")]
        public async Task<ResponseModel> ActiveOrDeactivation([FromBody] Service.System.Models.UserModel model)
        {
            var response = await _userService.ActiveOrDeactivation(model);
            return response;
        }

        [HttpPost, Route("admin-change-password")]
        public async Task<ResponseModel> AdminChangepassword([FromBody] Service.System.Models.UserModel model)
        {
            var response = await _userService.AdminChangepassword(model);
            return response;
        }

        [HttpPost, Route("user-change-password")]
        public async Task<ResponseModel> UserChangepassword([FromBody] ChangePasswordModel model)
        {
            var response = await _userService.UserChangepassword(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] Service.System.Models.UserModel model)
        {
            var response = await _userService.Delete(model);
            return response;
        }
    }
}
