using API.Common.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Interfaces;
using Service.Common.Models;
using System.Threading.Tasks;

namespace API.Common.Controllers
{
    [Route("api/common/district")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _districtService.List(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        [AllowAnonymous]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _districtService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _districtService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] DistrictModel model)
        {
            var response = await _districtService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] DistrictModel model)
        {
            var response = await _districtService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _districtService.Delete(model);
            return response;
        }
    }
}
