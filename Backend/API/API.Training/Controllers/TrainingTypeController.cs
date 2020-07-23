using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/type")]
    [ApiController]
    public class TrainingTypeController : ControllerBase
    {
        private readonly ITrainingTypeService _TrainingTypeService;

        public TrainingTypeController(ITrainingTypeService TrainingTypeService)
        {
            _TrainingTypeService = TrainingTypeService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _TrainingTypeService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _TrainingTypeService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _TrainingTypeService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(TrainingTypeModel model)
        {
            var response = await _TrainingTypeService.Save(model);
            return response;
        }
    }
}
