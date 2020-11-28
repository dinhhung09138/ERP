using API.Common.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Interfaces;
using Service.Common.Models;
using System.Threading.Tasks;

namespace API.Common.Controllers
{
    [Route("api/common/professional-qualification")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class ProfessionalQualificationController : ControllerBase
    {
        private readonly IProfessionalQualificationService _professionalQualificationService;

        public ProfessionalQualificationController(IProfessionalQualificationService professionalQualificationService)
        {
            _professionalQualificationService = professionalQualificationService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _professionalQualificationService.List(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        [AllowAnonymous]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _professionalQualificationService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _professionalQualificationService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] ProfessionalQualificationModel model)
        {
            var response = await _professionalQualificationService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] ProfessionalQualificationModel model)
        {
            var response = await _professionalQualificationService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _professionalQualificationService.Delete(model);
            return response;
        }
    }
}
