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
        private readonly ITrainingCenterContactService _TrainingCenterContactService;

        public TrainingCenterContactController(ITrainingCenterContactService TrainingCenterContactService)
        {
            _TrainingCenterContactService = TrainingCenterContactService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _TrainingCenterContactService.GetList(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _TrainingCenterContactService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(TrainingCenterContactModel model)
        {
            var response = await _TrainingCenterContactService.Save(model);
            return response;
        }
    }
}
