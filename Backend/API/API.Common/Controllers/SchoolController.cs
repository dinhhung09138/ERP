using API.Common.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Interfaces;
using Service.Common.Models;
using System.Threading.Tasks;

namespace API.Common.Controllers
{
    [Route("api/common/school")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _schoolService.List(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        [AllowAnonymous]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _schoolService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _schoolService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] SchoolModel model)
        {
            var response = await _schoolService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] SchoolModel model)
        {
            var response = await _schoolService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _schoolService.Delete(model);
            return response;
        }
    }
}
