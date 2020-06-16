using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace API.HR.Controllers
{
    [Route("api/hr/commendation")]
    [ApiController]
    public class CommendationController : ControllerBase
    {
        private readonly ICommendationService _commendationService;

        public CommendationController(ICommendationService commendationService)
        {
            _commendationService = commendationService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _commendationService.GetList(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _commendationService.Item(id);
            return response;
        }

        [HttpPost, Route("save")]
        public async Task<ResponseModel> Save(CommendationModel model)
        {
            var response = await _commendationService.Save(model);
            return response;
        }
    }
}
