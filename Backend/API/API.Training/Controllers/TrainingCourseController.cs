using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/course")]
    [ApiController]
    public class TrainingCourseController : ControllerBase
    {
        private readonly ITrainingCourseService _TrainingCourseService;

        public TrainingCourseController(ITrainingCourseService TrainingCourseService)
        {
            _TrainingCourseService = TrainingCourseService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _TrainingCourseService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _TrainingCourseService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _TrainingCourseService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(TrainingCourseModel model)
        {
            var response = await _TrainingCourseService.Save(model);
            return response;
        }
    }
}
