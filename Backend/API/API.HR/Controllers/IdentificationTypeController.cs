using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/identification-type")]
    [ApiController]
    public class IdentificationTypeController : ControllerBase
    {
        private readonly IIdentificationTypeService _identificationTypeService;

        public IdentificationTypeController(IIdentificationTypeService identificationTypeService)
        {
            _identificationTypeService = identificationTypeService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _identificationTypeService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _identificationTypeService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _identificationTypeService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(IdentificationTypeModel model)
        {
            var response = await _identificationTypeService.Save(model);
            return response;
        }
    }
}
