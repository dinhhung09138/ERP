using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/center-contact")]
    [ApiController]
    public class TrainingCenterContactController : ControllerBase
    {
        private readonly ITrainingCenterContactService _trainingCenterContactService;

        public TrainingCenterContactController(ITrainingCenterContactService trainingCenterContactService)
        {
            _trainingCenterContactService = trainingCenterContactService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList([FromBody] FilterModel filter)
        {
            var response = await _trainingCenterContactService.GetList(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _trainingCenterContactService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] TrainingCenterContactModel model)
        {
            var response = await _trainingCenterContactService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] TrainingCenterContactModel model)
        {
            var response = await _trainingCenterContactService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] TrainingCenterContactModel model)
        {
            var response = await _trainingCenterContactService.Delete(model);
            return response;
        }
    }
}
