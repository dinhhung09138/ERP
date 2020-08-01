﻿using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/professional-qualification")]
    [ApiController]
    public class ProfessionalQualificationController : ControllerBase
    {
        private readonly IProfessionalQualificationService _professionalQualificationService;

        public ProfessionalQualificationController(IProfessionalQualificationService professionalQualificationService)
        {
            _professionalQualificationService = professionalQualificationService;
        }

        [HttpPost, Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _professionalQualificationService.GetList(filter);
            return response;
        }

        [HttpGet, Route("dropdown")]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _professionalQualificationService.DropDownSelection();
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _professionalQualificationService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert(ProfessionalQualificationModel model)
        {
            var response = await _professionalQualificationService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update(ProfessionalQualificationModel model)
        {
            var response = await _professionalQualificationService.Update(model);
            return response;
        }

        [HttpDelete, Route("delete")]
        public async Task<ResponseModel> Delete(int id)
        {
            var response = await _professionalQualificationService.Item(id);
            return response;
        }
    }
}
