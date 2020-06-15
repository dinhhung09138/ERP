using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/education")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _accademicLevelService;

        public EducationController(IEducationService accademicLevelService)
        {
            _accademicLevelService = accademicLevelService;
        }

        [HttpPost, Route("getlist")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _accademicLevelService.GetList(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _accademicLevelService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(EducationModel model)
        {
            var response = await _accademicLevelService.Save(model);
            return response;
        }
    }
}
