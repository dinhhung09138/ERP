using API.HR.Filters;
using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Service.HR.Interfaces;
using Service.HR.Models;
using System.Threading.Tasks;

namespace API.HR.Controllers
{
    [Route("api/hr/employee-certificate")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilterAttribute))]
    public class EmployeeCertificateController : ControllerBase
    {
        private readonly IEmployeeCertificateService _emplCertificateService;

        public EmployeeCertificateController(IEmployeeCertificateService emplCertificateService)
        {
            _emplCertificateService = emplCertificateService;
        }

        /// <summary>
        /// Get list of data
        /// Including filter by employee id
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost, Route("list")]
        public async Task<ResponseModel> List([FromBody] FilterModel filter)
        {
            var response = await _emplCertificateService.List(filter);
            return response;
        }

        [HttpGet, Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _emplCertificateService.Item(id);
            return response;
        }

        [HttpPost, Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] EmployeeCertificateModel model)
        {
            var response = await _emplCertificateService.Insert(model);
            return response;
        }

        [HttpPut, Route("update")]
        public async Task<ResponseModel> Update([FromBody] EmployeeCertificateModel model)
        {
            var response = await _emplCertificateService.Update(model);
            return response;
        }

        [HttpPut, Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] DeleteModel model)
        {
            var response = await _emplCertificateService.Delete(model);
            return response;
        }
    }
}
