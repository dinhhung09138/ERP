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
    public class LeaveTypeService : BaseService, ILeaveTypeService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<BankService> _logger;
        private readonly IMemoryCachingService _memoryCachingService;

        private readonly string CacheKey = "leave_data";

        public LeaveTypeService(
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
                var query = from m in _context.LeaveTypeRepository.Query()
                            where !m.Deleted
                            orderby m.Precedence
                            select new LeaveTypeModel()
                            {
                                Id = m.Id,
                                Code = m.Code,
                                Name = m.Name,
                                NumOfDay = m.NumOfDay,
                                Description = m.Description,
                                StartDate = m.StartDate,
                                ExpirationDate = m.ExpirationDate,
                                IsDeductible = m.IsDeductible,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Code.ToLower().Contains(filter.Text)
                                            || m.Name.ToLower().Contains(filter.Text));
                }

                BaseListModel<LeaveTypeModel> listItems = new BaseListModel<LeaveTypeModel>();
                listItems.TotalItems = await _context.LeaveTypeRepository.Query().Where(m => !m.Deleted).CountAsync();
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
                var cacheData = _memoryCachingService.List<LeaveTypeModel>(CacheKey);

                if (cacheData != null)
                {
                    response.Result = cacheData;
                }
                else
                {
                    var query = from m in _context.LeaveTypeRepository.Query()
                                where !m.Deleted
                                orderby m.Precedence
                                select new LeaveTypeModel()
                                {
                                    Id = m.Id,
                                    Name = m.Name,
                                    NumOfDay = m.NumOfDay
                                };

                    var list = await query.ToListAsync();
                    response.Result = list;

                    _memoryCachingService.Set<LeaveTypeModel>(list, CacheKey, 60, 0, 0);
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
                LeaveType md = await _context.LeaveTypeRepository.FirstOrDefaultAsync(m => m.Id == id);

                LeaveTypeModel model = new LeaveTypeModel()
                {
                    Id = md.Id,
                    Code = md.Code,
                    Name = md.Name,
                    Description = md.Description,
                    IsDeductible =md.IsDeductible,
                    ExpirationDate =md.ExpirationDate,
                    NumOfDay = md.NumOfDay,
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

        public async Task<ResponseModel> Insert(LeaveTypeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                if (await _context.LeaveTypeRepository.CountAsync(m => m.Code == model.Code) > 0)
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.CodeExists;
                    return response;
                }

                LeaveType md = new LeaveType();

                md.Code = model.Code;
                md.Name = model.Name;
                md.Description = model.Description;
                md.NumOfDay = model.NumOfDay;
                md.IsDeductible = model.IsDeductible;
                md.ExpirationDate = model.ExpirationDate;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;

                await _context.LeaveTypeRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();

                _memoryCachingService.Remove(CacheKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(LeaveTypeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                LeaveType md = await _context.LeaveTypeRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Code = model.Code;
                md.Name = model.Name;
                md.Description = model.Description;
                md.NumOfDay = model.NumOfDay;
                md.IsDeductible = model.IsDeductible;
                md.ExpirationDate = model.ExpirationDate;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.LeaveTypeRepository.Update(md);

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
                LeaveType md = await _context.LeaveTypeRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.LeaveTypeRepository.Update(md);

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
