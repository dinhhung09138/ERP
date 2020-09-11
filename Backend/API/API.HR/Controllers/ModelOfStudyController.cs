using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/model-of-study")]
    [ApiController]
    [AuthorizationFilter]
    public class ModelOfStudyController : ControllerBase
    {
        private readonly IModelOfStudyService _modelOfStudyService;

        public ModelOfStudyController(IModelOfStudyService modelOfStudyService)
        {
            _modelOfStudyService = modelOfStudyService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList([FromBody] FilterModel filter)
        {
            var response = await _modelOfStudyService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        [AllowAnonymous]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _modelOfStudyService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _modelOfStudyService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] ModelOfStudyModel model)
        {
            var response = await _modelOfStudyService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] ModelOfStudyModel model)
        {
            var response = await _modelOfStudyService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] ModelOfStudyModel model)
        {
            var response = await _modelOfStudyService.Delete(model);
            return response;
        }
    }
}
