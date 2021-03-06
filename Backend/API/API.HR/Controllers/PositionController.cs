﻿using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;
namespace API.HR.Controllers
{
    [Route("api/hr/position")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List(FilterModel filter)
        {
            var response = await _positionService.List(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        [AllowAnonymous]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _positionService.DropDownData();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _positionService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] PositionModel model)
        {
            var response = await _positionService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] PositionModel model)
        {
            var response = await _positionService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _positionService.Delete(model);
            return response;
        }
    }
}
