using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/relationship-type")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class RelationshipTypeController : ControllerBase
    {
        private readonly IRelationshipTypeService _relationshipTypeService;

        public RelationshipTypeController(IRelationshipTypeService relationshipTypeService)
        {
            _relationshipTypeService = relationshipTypeService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _relationshipTypeService.List(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        [AllowAnonymous]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _relationshipTypeService.DropDownData();
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

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _relationshipTypeService.Delete(model);
            return response;
        }
    }
}
