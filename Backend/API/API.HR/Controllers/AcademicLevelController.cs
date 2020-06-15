using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/academic-level")]
    [ApiController]
    public class AcademicLevelController : ControllerBase
    {
        private readonly IAcademicLevelService _accademicLevelService;

        public AcademicLevelController(IAcademicLevelService accademicLevelService)
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
        public async Task<ResponseModel> Save(AcademicLevelModel model)
        {
            var response = await _accademicLevelService.Save(model);
            return response;
        }
    }
}
