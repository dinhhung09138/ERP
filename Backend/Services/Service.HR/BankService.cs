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
    public class BankService : BaseService, IBankService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<BankService> _logger;
        private readonly IMemoryCachingService _memoryCachingService;

        private readonly string CacheKey = "bank_data";

        public BankService(
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
                var query = from m in _context.BankRepository.Query()
                            where !m.Deleted
                            orderby m.Precedence
                            select new BankModel()
                            {
                                Id = m.Id,
                                Code = m.Code,
                                Name = m.Name,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Code.ToLower().Contains(filter.Text)
                                            || m.Name.ToLower().Contains(filter.Text));
                }

                BaseListModel<BankModel> listItems = new BaseListModel<BankModel>();
                listItems.TotalItems = await _context.BankRepository.Query().Where(m => !m.Deleted).CountAsync();
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
                var cacheData = _memoryCachingService.List<BankModel>(CacheKey);

                if (cacheData != null)
                {
                    response.Result = cacheData;
                }
                else
                {
                    var query = from m in _context.BankRepository.Query()
                                where !m.Deleted
                                orderby m.Precedence
                                select new BankModel()
                                {
                                    Id = m.Id,
                                    Name = m.Name,
                                };

                    var list = await query.ToListAsync();
                    response.Result = list;

                    _memoryCachingService.Set<BankModel>(list, CacheKey, 60, 0, 0);
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
                Bank md = await _context.BankRepository.FirstOrDefaultAsync(m => m.Id == id);

                BankModel model = new BankModel()
                {
                    Id = md.Id,
                    Code = md.Code,
                    Name = md.Name,
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

        public async Task<ResponseModel> Insert(BankModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                if (await _context.BankRepository.CountAsync(m => m.Code == model.Code) > 0)
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.CodeExists;
                    return response;
                }

                Bank md = new Bank();

                md.Code = model.Code;
                md.Name = model.Name;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;

                await _context.BankRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();

                _memoryCachingService.Remove(CacheKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(BankModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Bank md = await _context.BankRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Code = model.Code;
                md.Name = model.Name;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.BankRepository.Update(md);

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
                Bank md = await _context.BankRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.BankRepository.Update(md);

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
