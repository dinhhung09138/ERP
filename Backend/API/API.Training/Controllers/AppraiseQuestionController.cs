using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/appraise-question")]
    [ApiController]
    public class AppraiseQuestionController : ControllerBase
    {
        private readonly IAppraiseQuestionService _appraiseQuestionService;

        public AppraiseQuestionController(IAppraiseQuestionService appraiseQuestionService)
        {
            _appraiseQuestionService = appraiseQuestionService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList([FromBody] FilterModel filter)
        {
            var response = await _appraiseQuestionService.GetList(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _appraiseQuestionService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] AppraiseQuestionModel model)
        {
            var response = await _appraiseQuestionService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] AppraiseQuestionModel model)
        {
            var response = await _appraiseQuestionService.Update(model);
            return response;
        }

        [HttpDelete, Route("delete")]
        public async Task<ResponseModel> Delete([FromQuery] int id)
        {
            var response = await _appraiseQuestionService.Delete(id);
            return response;
        }
    }
}
