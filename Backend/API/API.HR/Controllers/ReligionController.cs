using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/religion")]
    [ApiController]
    public class ReligionController : ControllerBase
    {
        private readonly IReligionService _religionService;

        public ReligionController(IReligionService religionService)
        {
            _religionService = religionService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _religionService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _religionService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _religionService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(ReligionModel model)
        {
            var response = await _religionService.Save(model);
            return response;
        }
    }
}
