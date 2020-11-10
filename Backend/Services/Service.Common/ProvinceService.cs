﻿using Core.CommonModel;
using Core.Services;
using Core.Services.Interfaces;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Common.Interfaces;
using Service.Common.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Common
{
    public class ProvinceService : BaseService, IProvinceService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<ProvinceService> _logger;
        private readonly IMemoryCachingService _memoryCachingService;

        private readonly string CacheKey = "province_data";

        public ProvinceService(
            IERPUnitOfWork context,
            ILogger<ProvinceService> logger,
            IMemoryCachingService memoryCachingService,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            _logger = logger;
            _memoryCachingService = memoryCachingService;
            base._httpContext = httpContext;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.ProvinceRepository.Query()
                            where !m.Deleted
                            orderby m.Precedence ascending
                            select new ProvinceModel
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text));
                }

                var list = query.OrderBy(m => m.Precedence);

                BaseListModel<ProvinceModel> listItems = new BaseListModel<ProvinceModel>();
                listItems.TotalItems = await _context.ProvinceRepository.Query().Where(m => !m.Deleted).CountAsync();
                listItems.Items = await list.Skip(filter.Paging.PageIndex * filter.Paging.PageSize).Take(filter.Paging.PageSize).ToListAsync().ConfigureAwait(false);

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
                var cacheData = _memoryCachingService.GetList<ProvinceModel>(CacheKey);

                if (cacheData != null)
                {
                    response.Result = cacheData;
                }
                else
                {
                    var query = from m in _context.ProvinceRepository.Query()
                                where m.IsActive && !m.Deleted
                                orderby m.Precedence ascending
                                select new ProvinceModel
                                {
                                    Id = m.Id,
                                    Name = m.Name,
                                };

                    var list = await query.ToListAsync();
                    response.Result = list;

                    _memoryCachingService.Set<ProvinceModel>(list, CacheKey, 60, 0, 0);
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
                var query = from m in _context.ProvinceRepository.Query()
                            where m.Id == id
                            select new ProvinceModel
                            {
                                Id = m.Id,
                                Name = m.Name,
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

        public async Task<ResponseModel> Insert(ProvinceModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Province md = new Province();

                md.Name = model.Name;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.ProvinceRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();

                _memoryCachingService.Remove(CacheKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(ProvinceModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Province md = await _context.ProvinceRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Name = model.Name;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.ProvinceRepository.Update(md);

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
                Province md = await _context.ProvinceRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.ProvinceRepository.Update(md);

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
