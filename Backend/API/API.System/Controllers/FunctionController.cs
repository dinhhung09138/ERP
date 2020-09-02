using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Services.System.Interfaces;
using Services.System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.System.Controllers
{
    [Route("api/system/function")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        private readonly IFunctionService _functionService;

        public FunctionController(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        [HttpGet, Route("get-all-function")]
        public async Task<ResponseModel> GetAllFunctions()
        {
            var response = await _functionService.GetAllFunctions();
            return response;
        }

    }
}
