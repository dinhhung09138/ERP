using Core.CommonModel;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.HR;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Core.CommonMessage;

namespace Service.HR
{
    public class EmployeeWorkingStatusService : BaseService, IEmployeeWorkingStatusService
    {

        private readonly IERPUnitOfWork _context;
        private readonly IMemoryCachingService _memoryCachingService;
        private readonly ILogger<EmployeeWorkingStatusService> _logger;

        private readonly string CacheKey = "working_status_data";

        public EmployeeWorkingStatusService(
            IERPUnitOfWork context, 
            IMemoryCachingService memoryCachingService, 
            ILogger<EmployeeWorkingStatusService> logger, 
            IHttpContextAccessor httpContext)
        {
            _context = context;
            _memoryCachingService = memoryCachingService;
            _logger = logger;
            base._httpContext = httpContext;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.EmployeeWorkingStatusRepository.Query()
                            where !m.Deleted
                            orderby m.Precedence ascending
                            select new EmployeeWorkingStatusModel
                            {
                                Id = m.Id,
                                Code = m.Code,
                                Name = m.Name,
                                Description = m.Description,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Code.ToLower().Contains(filter.Text)
                                            || m.Name.ToLower().Contains(filter.Text)
                                            || m.Description.ToLower().Contains(filter.Text));
                }

                BaseListModel<EmployeeWorkingStatusModel> listItems = new BaseListModel<EmployeeWorkingStatusModel>();
                listItems.TotalItems = await _context.EmployeeWorkingStatusRepository.Query().Where(m => !m.Deleted).CountAsync();
                listItems.Items = await query.Skip(filter.Paging.PageIndex * filter.Paging.PageSize).Take(filter.Paging.PageSize).ToListAsync().ConfigureAwait(false);

                response.Result = listItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> DropDownSelection()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var cacheData = _memoryCachingService.GetList<EmployeeWorkingStatusModel>(CacheKey);

                if (cacheData != null)
                {
                    response.Result = cacheData;
                }
                else
                {
                    var query = from m in _context.EmployeeWorkingStatusRepository.Query()
                                where m.IsActive && !m.Deleted
                                orderby m.Precedence ascending
                                select new EmployeeWorkingStatusModel
                                {
                                    Id = m.Id,
                                    Name = m.Name
                                };

                    var list = await query.ToListAsync();

                    _memoryCachingService.Set<EmployeeWorkingStatusModel>(list, CacheKey, 30, 0, 0);

                    response.Result = list;
                }
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.GetDropDownError;
                _logger.LogError(ex.Message, ex);
            }
            return response;
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.EmployeeWorkingStatusRepository.Query()
                            where m.Id == id
                            select new EmployeeWorkingStatusModel
                            {
                                Id = m.Id,
                                Code = m.Code,
                                Name = m.Name,
                                Description = m.Description,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                response.Result = await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(EmployeeWorkingStatusModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeWorkingStatus md = new EmployeeWorkingStatus();

                md.Code = model.Code;
                md.Name = model.Name;
                md.Description = model.Description;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.EmployeeWorkingStatusRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();

                _memoryCachingService.Remove(CacheKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(EmployeeWorkingStatusModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeWorkingStatus md = await _context.EmployeeWorkingStatusRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Name = model.Name;
                md.Description = model.Description;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeWorkingStatusRepository.Update(md);

                await _context.SaveChangesAsync();

                _memoryCachingService.Remove(CacheKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(DeleteModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeWorkingStatus md = await _context.EmployeeWorkingStatusRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeWorkingStatusRepository.Update(md);

                await _context.SaveChangesAsync();

                _memoryCachingService.Remove(CacheKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
