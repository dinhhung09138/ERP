using Core.CommonModel;
using Core.Services;
using Core.Services.Interfaces;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.HR
{
    public class LeaveStatusService : BaseService, ILeaveStatusService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<BankService> _logger;
        private readonly IMemoryCachingService _memoryCachingService;

        private readonly string CacheKey = "bank_data";

        public LeaveStatusService(
            IERPUnitOfWork context,
            ILogger<BankService> logger,
            IHttpContextAccessor httpContext,
            IMemoryCachingService memoryCachingService)
        {
            _context = context;
            _logger = logger;
            base._httpContext = httpContext;
            _memoryCachingService = memoryCachingService;
        }
        public async Task<ResponseModel> List(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.LeaveStatusRepository.Query()
                            where !m.Deleted
                            orderby m.Precedence
                            select new LeaveStatusModel()
                            {
                                Id = m.Id,
                                TypeId = m.TypeId,
                                TypeName = "",
                                Name = m.Name,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.TypeName.ToLower().Contains(filter.Text)
                                            || m.Name.ToLower().Contains(filter.Text));
                }

                BaseListModel<LeaveStatusModel> listItems = new BaseListModel<LeaveStatusModel>();
                listItems.TotalItems = await _context.LeaveStatusRepository.Query().Where(m => !m.Deleted).CountAsync();
                listItems.Items = await query.Skip(filter.Paging.PageIndex * filter.Paging.PageSize).Take(filter.Paging.PageSize).ToListAsync().ConfigureAwait(false);

                response.Result = listItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> DropDownData()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var cacheData = _memoryCachingService.List<LeaveStatusModel>(CacheKey);

                if (cacheData != null)
                {
                    response.Result = cacheData;
                }
                else
                {
                    var query = from m in _context.LeaveStatusRepository.Query()
                                where !m.Deleted
                                orderby m.Precedence
                                select new LeaveStatusModel()
                                {
                                    Id = m.Id,
                                    Name = m.Name,
                                };

                    var list = await query.ToListAsync();
                    response.Result = list;

                    _memoryCachingService.Set<LeaveStatusModel>(list, CacheKey, 60, 0, 0);
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
                LeaveStatus md = await _context.LeaveStatusRepository.FirstOrDefaultAsync(m => m.Id == id);

                LeaveStatusModel model = new LeaveStatusModel()
                {
                    Id = md.Id,
                    Name = md.Name,
                    TypeId = md.TypeId,
                    Precedence = md.Precedence,
                    IsActive = md.IsActive,
                    RowVersion = md.RowVersion,
                };

                response.Result = model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(LeaveStatusModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                LeaveStatus md = new LeaveStatus();

                md.Name = model.Name;
                md.TypeId = model.TypeId;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;

                await _context.LeaveStatusRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();

                _memoryCachingService.Remove(CacheKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(LeaveStatusModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                LeaveStatus md = await _context.LeaveStatusRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Name = model.Name;
                md.TypeId = model.TypeId;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.LeaveStatusRepository.Update(md);

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
                LeaveStatus md = await _context.LeaveStatusRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.LeaveStatusRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
