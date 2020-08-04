using Core.CommonModel;
using Core.Utility.Filters;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/center")]
    [ApiController]
    [Authentication]
    public class TrainingCenterController : ControllerBase
    {
        private readonly ITrainingCenterService _trainingCenterService;

        public TrainingCenterController(ITrainingCenterService trainingCenterService)
        {
            _trainingCenterService = trainingCenterService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList([FromBody] FilterModel filter)
        {
            var response = await _trainingCenterService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _trainingCenterService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _trainingCenterService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] TrainingCenterModel model)
        {
            var response = await _trainingCenterService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] TrainingCenterModel model)
        {
            var response = await _trainingCenterService.Update(model);
            return response;
        }

        [HttpDelete, Route("delete")]
        public async Task<ResponseModel> Delete([FromQuery] int id)
        {
            var response = await _trainingCenterService.Delete(id);
            return response;
        }

    }
}
