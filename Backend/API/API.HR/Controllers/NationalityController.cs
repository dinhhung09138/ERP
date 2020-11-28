using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/nationality")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class NationalityController : ControllerBase
    {
        private readonly INationalityService _nationalityService;

        public NationalityController(INationalityService nationalityService)
        {
            _nationalityService = nationalityService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _nationalityService.List(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        [AllowAnonymous]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _nationalityService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _nationalityService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] NationalityModel model)
        {
            var response = await _nationalityService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] NationalityModel model)
        {
            var response = await _nationalityService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _nationalityService.Delete(model);
            return response;
        }
    }
}
