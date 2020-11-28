using API.Common.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Interfaces;
using Service.Common.Models;
using System.Threading.Tasks;

namespace API.Common.Controllers
{
    [Route("api/common/ward")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class WardController : ControllerBase
    {
        private readonly IWardService _wardService;

        public WardController(IWardService wardService)
        {
            _wardService = wardService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _wardService.List(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        [AllowAnonymous]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _wardService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _wardService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] WardModel model)
        {
            var response = await _wardService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] WardModel model)
        {
            var response = await _wardService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _wardService.Delete(model);
            return response;
        }
    }
}
