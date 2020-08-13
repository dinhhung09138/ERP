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
        public async Task<ResponseModel> GetList([FromBody] FilterModel filter)
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
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _relationshipTypeService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] RelationshipTypeModel model)
        {
            var response = await _relationshipTypeService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] RelationshipTypeModel model)
        {
            var response = await _relationshipTypeService.Update(model);
            return response;
        }

        [HttpDelete, Route("delete")]
        public async Task<ResponseModel> Delete([FromQuery] int id)
        {
            var response = await _relationshipTypeService.Delete(id);
            return response;
        }
    }
}
