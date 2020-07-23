using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/specialized-training")]
    [ApiController]
    public class SpecializedTrainingController : ControllerBase
    {
        private readonly ISpecializedTrainingService _SpecializedTrainingService;

        public SpecializedTrainingController(ISpecializedTrainingService SpecializedTrainingService)
        {
            _SpecializedTrainingService = SpecializedTrainingService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _SpecializedTrainingService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _SpecializedTrainingService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _SpecializedTrainingService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(SpecializedTrainingModel model)
        {
            var response = await _SpecializedTrainingService.Save(model);
            return response;
        }
    }
}
