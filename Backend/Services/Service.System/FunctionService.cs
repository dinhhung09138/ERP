using Core.CommonModel;
using Core.Services;
using Database.Sql.ERP;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Service.System.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Service.System.Models;
using Microsoft.EntityFrameworkCore;
using Core.Services.Interfaces;

namespace Service.System
{
    public class FunctionService : BaseService, IFunctionService
    {
        private readonly IERPUnitOfWork _context;
        private readonly IMemoryCachingService _memoryCachingService;
        private readonly ILogger<RoleService> _logger;

        private readonly string CacheKey = "all_function_data";

        public FunctionService(
            IERPUnitOfWork context,
            ILogger<RoleService> logger,
            IHttpContextAccessor httpContext,
            IMemoryCachingService memoryCachingService)
        {
            _context = context;
            _logger = logger;
            base._httpContext = httpContext;
            _memoryCachingService = memoryCachingService;
        }

        public async Task<ResponseModel> GetAllFunctions()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var cacheData = _memoryCachingService.GetList<ModuleModel>(CacheKey);

                if (cacheData != null)
                {
                    response.Result = cacheData;
                }
                else
                {
                    var list = await _context.ModuleRepository.Query().Include(m => m.Functions).ThenInclude(t => t.Commands)
                    .OrderBy(m => m.Precedence)
                    .Select(m => new ModuleModel
                    {
                        Code = m.Code,
                        Name = m.Name,
                        Precedence = m.Precedence,
                        Functions = m.Functions.OrderBy(m => m.Precedence).Select(m => new FunctionModel
                        {
                            Code = m.Code,
                            Name = m.Name,
                            ModuleCode = m.ModuleCode,
                            Precedence = m.Precedence,
                            ParentCode = m.ParentCode,
                            Commands = m.Commands.OrderBy(m => m.Precedence).Select(m => new FunctionCommandModel
                            {
                                Id = m.Id,
                                Name = m.Name,
                                IsView = m.IsView,
                                Selected = false,
                            }).ToList()
                        }).ToList()
                    }).ToListAsync();

                    response.Result = list;

                    _memoryCachingService.Set<ModuleModel>(list, CacheKey, 10);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public async Task<List<ModuleModel>> GetListPageUserCanAccess(int userId)
        {
            try
            {
                var listData = await (from userRole in _context.UserRoleRepository.Query()
                                      join roleDetail in _context.RoleDetailRepository.Query() on userRole.RoleId equals roleDetail.RoleId
                                      join fCommand in _context.FunctionCommandRepository.Query() on roleDetail.CommandId equals fCommand.Id
                                      join function in _context.FunctionRepository.Query() on fCommand.FunctionCode equals function.Code
                                      join module in _context.ModuleRepository.Query() on function.ModuleCode equals module.Code
                                      where userRole.UserId == userId
                                      orderby module.Precedence, function.Precedence
                                      select new
                                      {
                                          ModuleCode = module.Code,
                                          ModuleName = module.Name,
                                          ModuleUrl = module.Url,
                                          ModuleIcon = module.Icon,
                                          ModulePrecedence = module.Precedence,
                                          FunctionCode = function.Code,
                                          FunctionName = function.Name,
                                          FunctionUrl = function.Url,
                                          FunctionIcon = function.Icon,
                                          FunctionParent = function.ParentCode,
                                          FunctionPrecedence = function.Precedence,
                                          FunctionCommand = function.Commands
                                      }).ToListAsync();

                List<ModuleModel> listModule = new List<ModuleModel>();

                var listModuleCode = listData.OrderBy(m => m.ModulePrecedence)
                                     .Select(m => new
                                     {
                                         Code = m.ModuleCode
                                     }).Distinct().ToList();

                foreach (var m in listModuleCode)
                {
                    var module = listData.FirstOrDefault(md => md.ModuleCode == m.Code);

                    var listFunc = listData.Where(md => md.ModuleCode == m.Code).Select(md => md.FunctionCode).Distinct().ToArray();

                    ModuleModel md = new ModuleModel();
                    md.Name = module.ModuleName;
                    md.Url = module.ModuleUrl;


                    md.Functions = new List<FunctionModel>();

                    foreach (var fc in listFunc)
                    {
                        var function = listData.OrderBy(f => f.FunctionPrecedence)
                                               .Where(f => f.FunctionCode == fc)
                                               .Select(f => new FunctionModel()
                                               {
                                                   Code = f.FunctionCode,
                                                   Name = f.FunctionName,
                                                   Url = $"{module.ModuleUrl}{f.FunctionUrl}",
                                                   Icon = f.FunctionIcon,
                                                   ParentCode = f.FunctionParent,
                                                   Commands = f.FunctionCommand.Select(cm => new FunctionCommandModel()
                                                   {
                                                       IsView = cm.IsView,
                                                       Name = cm.Name
                                                   }).ToList()
                                               }).FirstOrDefault();

                        md.Functions.Add(function);

                        if (!string.IsNullOrEmpty(function.ParentCode) && !md.Functions.Any(t => t.Code == function.ParentCode))
                        {
                            var prFunction = _context.FunctionRepository.Query().FirstOrDefault(m => m.Code == function.ParentCode);

                            md.Functions.Add(new FunctionModel()
                            {
                                Code = prFunction.Code,
                                Name = prFunction.Name,
                                Icon = prFunction.Icon,
                                ParentCode = string.Empty
                            });
                        }
                    }



                    listModule.Add(md);
                }
                return listModule;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;
        }
    }
}
