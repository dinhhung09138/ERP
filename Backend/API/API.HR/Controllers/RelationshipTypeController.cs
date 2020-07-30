using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/relationship-type")]
    [ApiController]
    public class RelationshipTypeController : ControllerBase
    {
        private readonly IRelationshipTypeService _RelationshipTypeService;

        public RelationshipTypeController(IRelationshipTypeService RelationshipTypeService)
        {
            _RelationshipTypeService = RelationshipTypeService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _RelationshipTypeService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _RelationshipTypeService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _RelationshipTypeService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(RelationshipTypeModel model)
        {
            var response = await _RelationshipTypeService.Save(model);
            return response;
        }
    }
}
