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
        private readonly ITrainingCourseDocumentService _trainingCourseDocumentService;

        public TrainingCourseDocumentController(ITrainingCourseDocumentService trainingCourseDocumentService)
        {
            _trainingCourseDocumentService = trainingCourseDocumentService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList([FromBody] FilterModel filter)
        {
            var response = await _trainingCourseDocumentService.GetList(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _trainingCourseDocumentService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] TrainingCourseDocumentModel model)
        {
            var response = await _trainingCourseDocumentService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] TrainingCourseDocumentModel model)
        {
            var response = await _trainingCourseDocumentService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _trainingCourseDocumentService.Delete(model);
            return response;
        }
    }
}
