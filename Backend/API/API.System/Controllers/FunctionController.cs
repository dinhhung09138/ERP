﻿using API.System.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.System.Interfaces;
using Service.System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.System.Controllers
{
    [Route("api/system/function")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class FunctionController : ControllerBase
    {
        private readonly IFunctionService _functionService;

        public FunctionController(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        [HttpGet, Route("get-all-function")]
        [AllowAnonymous]
        public async Task<ResponseModel> GetAllFunctions()
        {
            var response = await _functionService.GetAllFunctions();
            return response;
        }

    }
}
