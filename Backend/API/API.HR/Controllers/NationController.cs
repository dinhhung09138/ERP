﻿using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/nation")]
    [ApiController]
    public class NationController : ControllerBase
    {
        private readonly INationService _nationService;

        public NationController(INationService nationService)
        {
            _nationService = nationService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _nationService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _nationService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _nationService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(NationModel model)
        {
            var response = await _nationService.Save(model);
            return response;
        }
    }
}