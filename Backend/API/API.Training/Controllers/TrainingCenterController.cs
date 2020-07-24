using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/center")]
    [ApiController]
    public class TrainingCenterController : ControllerBase
    {
        private readonly ITrainingCenterService _TrainingCenterService;

        public TrainingCenterController(ITrainingCenterService TrainingCenterService)
        {
            _TrainingCenterService = TrainingCenterService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _TrainingCenterService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _TrainingCenterService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _TrainingCenterService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(TrainingCenterModel model)
        {
            var response = await _TrainingCenterService.Save(model);
            return response;
        }
    }
}
