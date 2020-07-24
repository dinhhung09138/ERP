using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/appraise")]
    [ApiController]
    public class AppraiseController : ControllerBase
    {
        private readonly IAppraiseService _AppraiseService;

        public AppraiseController(IAppraiseService AppraiseService)
        {
            _AppraiseService = AppraiseService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _AppraiseService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _AppraiseService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _AppraiseService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(AppraiseModel model)
        {
            var response = await _AppraiseService.Save(model);
            return response;
        }
    }
}
