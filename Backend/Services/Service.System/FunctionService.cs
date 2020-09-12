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
        private readonly string CacheScreenByUser = "screen_data";

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
                        Name = m.Name,
                        Precedence = m.Precedence,
                        Functions = m.Functions.OrderBy(m => m.Precedence).Select(m => new FunctionModel
                        {
                            Name = m.Name,
                            ModuleCode = m.ModuleCode,
                            Precedence = m.Precedence,
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
                var userData = _memoryCachingService.GetList<ModuleModel>($"{CacheScreenByUser}-{userId}");

                if (userData != null)
                {
                    return userData;
                }
                else
                {
                    var listData = await (from userRole in _context.UserRoleRepository.Query()
                                          join roleDetail in _context.RoleDetailRepository.Query() on userRole.RoleId equals roleDetail.RoleId
                                          join fCommand in _context.FunctionCommandRepository.Query() on roleDetail.CommandId equals fCommand.Id
                                          join function in _context.FunctionRepository.Query() on fCommand.FunctionCode equals function.Code
                                          join module in _context.ModuleRepository.Query() on function.ModuleCode equals module.Code
                                          where userRole.UserId == userId && fCommand.IsView == true
                                          orderby module.Precedence, function.Precedence
                                          select new
                                          {
                                              ModuleName = module.Name,
                                              ModuleUrl = module.Url,
                                              ModuleIcon = module.Icon,
                                              ModulePrecedence = module.Precedence,
                                              FunctionName = function.Name,
                                              FunctionUrl = function.Url,
                                              FunctionIcon = function.Icon,
                                              FunctionPrecedence = function.Precedence,
                                          }).ToListAsync();

                    List<ModuleModel> listModule = new List<ModuleModel>();

                    listModule = listData.OrderBy(m => m.ModulePrecedence)
                                         .Select(m => new ModuleModel
                                         {
                                             Name = m.ModuleName,
                                             Url = m.ModuleUrl,
                                             Icon = m.ModuleIcon
                                         }).Distinct().ToList();

                    foreach (var m in listModule)
                    {
                        m.Functions = new List<FunctionModel>();
                        m.Functions = listData.OrderBy(f => f.FunctionPrecedence)
                                              .Select(f => new FunctionModel()
                                              {
                                                  Name = f.FunctionName,
                                                  Url = $"{m.Url}{f.FunctionUrl}",
                                                  Icon = f.FunctionIcon,
                                              })
                                              .Distinct().ToList();
                    }

                    _memoryCachingService.Set<ModuleModel>(listModule, $"{CacheScreenByUser}-{userId}", 10);

                    return listModule;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
            return null;
        }
    }
}
