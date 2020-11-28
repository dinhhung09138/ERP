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
        private readonly ITrainingTypeService _trainingTypeService;

        public TrainingTypeController(ITrainingTypeService trainingTypeService)
        {
            _trainingTypeService = trainingTypeService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _trainingTypeService.List(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _trainingTypeService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _trainingTypeService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] TrainingTypeModel model)
        {
            var response = await _trainingTypeService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] TrainingTypeModel model)
        {
            var response = await _trainingTypeService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _trainingTypeService.Delete(model);
            return response;
        }
    }
}
