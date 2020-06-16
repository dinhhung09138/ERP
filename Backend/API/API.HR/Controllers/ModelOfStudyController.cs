using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/model-of-study")]
    [ApiController]
    public class ModelOfStudyController : ControllerBase
    {
        private readonly IModelOfStudyService _modelOfStudyService;

        public ModelOfStudyController(IModelOfStudyService modelOfStudyService)
        {
            _modelOfStudyService = modelOfStudyService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _modelOfStudyService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _modelOfStudyService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _modelOfStudyService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(ModelOfStudyModel model)
        {
            var response = await _modelOfStudyService.Save(model);
            return response;
        }
    }
}
