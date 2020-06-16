using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/ward")]
    [ApiController]
    public class WardController : ControllerBase
    {
        private readonly IWardService _wardService;

        public WardController(IWardService wardService)
        {
            _wardService = wardService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _wardService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _wardService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _wardService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(WardModel model)
        {
            var response = await _wardService.Save(model);
            return response;
        }
    }
}
