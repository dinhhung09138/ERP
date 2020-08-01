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
        private readonly IRelationshipTypeService _relationshipTypeService;

        public RelationshipTypeController(IRelationshipTypeService relationshipTypeService)
        {
            _relationshipTypeService = relationshipTypeService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _relationshipTypeService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _relationshipTypeService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _relationshipTypeService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert(RelationshipTypeModel model)
        {
            var response = await _relationshipTypeService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update(RelationshipTypeModel model)
        {
            var response = await _relationshipTypeService.Update(model);
            return response;
        }

        [HttpDelete, Route("delete")]
        public async Task<ResponseModel> Delete(int id)
        {
            var response = await _relationshipTypeService.Item(id);
            return response;
        }
    }
}
