﻿using Core.CommonModel;
using Core.Utility.Filters;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/type")]
    [ApiController]
    [Authentication]
    public class TrainingTypeController : ControllerBase
    {
        private readonly ITrainingTypeService _trainingTypeService;

        public TrainingTypeController(ITrainingTypeService trainingTypeService)
        {
            _trainingTypeService = trainingTypeService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList([FromBody] FilterModel filter)
        {
            var response = await _trainingTypeService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _trainingTypeService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _trainingTypeService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] TrainingTypeModel model)
        {
            var response = await _trainingTypeService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] TrainingTypeModel model)
        {
            var response = await _trainingTypeService.Update(model);
            return response;
        }

        [HttpDelete, Route("delete")]
        public async Task<ResponseModel> Delete([FromQuery] int id)
        {
            var response = await _trainingTypeService.Delete(id);
            return response;
        }
    }
}
