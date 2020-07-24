using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/lecturer")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        private readonly ILecturerService _LecturerService;

        public LecturerController(ILecturerService LecturerService)
        {
            _LecturerService = LecturerService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _LecturerService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _LecturerService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _LecturerService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(LecturerModel model)
        {
            var response = await _LecturerService.Save(model);
            return response;
        }
    }
}
