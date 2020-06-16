using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/contract-type")]
    [ApiController]
    public class ContractTypeController : ControllerBase
    {
        private readonly IContractTypeService _contractTypeService;

        public ContractTypeController(IContractTypeService contractTypeService)
        {
            _contractTypeService = contractTypeService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _contractTypeService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _contractTypeService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _contractTypeService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(ContractTypeModel model)
        {
            var response = await _contractTypeService.Save(model);
            return response;
        }
    }
}
