using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/appraise-answer")]
    [ApiController]
    public class AppraiseAnswerController : ControllerBase
    {
        private readonly IAppraiseAnswerService _appraiseAnswerService;

        public AppraiseAnswerController(IAppraiseAnswerService appraiseAnswerService)
        {
            _appraiseAnswerService = appraiseAnswerService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _appraiseAnswerService.List(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _appraiseAnswerService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] AppraiseAnswerModel model)
        {
            var response = await _appraiseAnswerService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] AppraiseAnswerModel model)
        {
            var response = await _appraiseAnswerService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _appraiseAnswerService.Delete(model);
            return response;
        }
    }
}
