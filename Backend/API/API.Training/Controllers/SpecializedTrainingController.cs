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
        private readonly ISpecializedTrainingService _specializedTrainingService;

        public SpecializedTrainingController(ISpecializedTrainingService specializedTrainingService)
        {
            _specializedTrainingService = specializedTrainingService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _specializedTrainingService.List(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _specializedTrainingService.DropDownData();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _specializedTrainingService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] SpecializedTrainingModel model)
        {
            var response = await _specializedTrainingService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] SpecializedTrainingModel model)
        {
            var response = await _specializedTrainingService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _specializedTrainingService.Delete(model);
            return response;
        }
    }
}
