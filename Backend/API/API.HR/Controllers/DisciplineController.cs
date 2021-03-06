﻿using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/discipline")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class DisciplineController : ControllerBase
    {
        private readonly IDisciplineService _disciplineService;

        public DisciplineController(IDisciplineService disciplineService)
        {
            _disciplineService = disciplineService;
        }

        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _disciplineService.List(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        [AllowAnonymous]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _disciplineService.DropDownData();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _disciplineService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] DisciplineModel model)
        {
            var response = await _disciplineService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] DisciplineModel model)
        {
            var response = await _disciplineService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _disciplineService.Delete(model);
            return response;
        }

    }
}
