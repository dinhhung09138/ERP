using Core.CommonModel;
using Core.Services;
using Database.Sql.ERP;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Services.System.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Services.System.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.System
{
    public class FunctionService : BaseService, IFunctionService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<RoleService> _logger;

        public FunctionService(
            IERPUnitOfWork context,
            ILogger<RoleService> logger,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            _logger = logger;
            base._httpContext = httpContext;
        }

        public async Task<ResponseModel> GetAllFunctions()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var list = await _context.ModuleRepository.Query().Include(m => m.Functions).ThenInclude(t => t.Commands)
                    .OrderBy(m => m.Precedence)
                    .Select(m => new ModuleModel {
                        Code = m.Code,
                        Name = m.Name,
                        Precedence = m.Precedence,
                        Functions = m.Functions.OrderBy(m => m.Precedence).Select(m => new FunctionModel
                        {
                            Code = m.Code,
                            Name = m.Name,
                            ModuleCode = m.ModuleCode,
                            Precedence = m.Precedence,
                            Commands = m.Commands.OrderBy(m => m.Precedence).Select(m => new FunctionCommandModel
                            {
                                Id = m.Id,
                                FunctionCode = m.FunctionCode,
                                Name = m.Name
                            }).ToList()
                        }).ToList()
                    }).ToListAsync();

                response.Result = list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

    }
}
