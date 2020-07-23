using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/course-document")]
    [ApiController]
    public class TrainingCourseDocumentController : ControllerBase
    {
        private readonly ITrainingCourseDocumentService _TrainingCourseDocumentService;

        public TrainingCourseDocumentController(ITrainingCourseDocumentService TrainingCourseDocumentService)
        {
            _TrainingCourseDocumentService = TrainingCourseDocumentService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _TrainingCourseDocumentService.GetList(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _TrainingCourseDocumentService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(TrainingCourseDocumentModel model)
        {
            var response = await _TrainingCourseDocumentService.Save(model);
            return response;
        }
    }
}
