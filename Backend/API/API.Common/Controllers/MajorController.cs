using API.Common.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Interfaces;
using Service.Common.Models;
using System.Threading.Tasks;

namespace API.Common.Controllers
{
    [Route("api/common/major")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class MajorController : ControllerBase
    {
        private readonly IMajorService _majorService;

        public MajorController(IMajorService majorService)
        {
            _majorService = majorService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _majorService.List(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        [AllowAnonymous]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _majorService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _majorService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] MajorModel model)
        {
            var response = await _majorService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] MajorModel model)
        {
            var response = await _majorService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _majorService.Delete(model);
            return response;
        }
    }
}
