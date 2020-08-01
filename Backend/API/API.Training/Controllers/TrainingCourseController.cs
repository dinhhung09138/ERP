﻿using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.Training.Interfaces;
using Service.Training.Models;
using System.Threading.Tasks;

namespace API.Training.Controllers
{
    [Route("api/training/course")]
    [ApiController]
    public class TrainingCourseController : ControllerBase
    {
        private readonly ITrainingCourseService _trainingCourseService;

        public TrainingCourseController(ITrainingCourseService trainingCourseService)
        {
            _trainingCourseService = trainingCourseService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _trainingCourseService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _trainingCourseService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _trainingCourseService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert(TrainingCourseModel model)
        {
            var response = await _trainingCourseService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update(TrainingCourseModel model)
        {
            var response = await _trainingCourseService.Update(model);
            return response;
        }

        [HttpDelete, Route("delete")]
        public async Task<ResponseModel> Delete(int id)
        {
            var response = await _trainingCourseService.Item(id);
            return response;
        }
    }
}
