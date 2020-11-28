using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;
namespace API.HR.Controllers
{
    [Route("api/hr/commendation")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class CommendationController : ControllerBase
    {
        private readonly ICommendationService _commendationService;

        public CommendationController(ICommendationService commendationService)
        {
            _commendationService = commendationService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _commendationService.List(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        [AllowAnonymous]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _commendationService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _commendationService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] CommendationModel model)
        {
            var response = await _commendationService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] CommendationModel model)
        {
            var response = await _commendationService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _commendationService.Delete(model);
            return response;
        }

    }
}
