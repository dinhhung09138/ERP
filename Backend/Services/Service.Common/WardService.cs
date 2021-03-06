﻿using Core.CommonMessage;
using Core.CommonModel;
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
    public class WardService : BaseService, IWardService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<WardService> _logger;
        private readonly IMemoryCachingService _memoryCachingService;

        private readonly string CacheKey = "ward_data";

        public WardService(
            IERPUnitOfWork context,
            ILogger<WardService> logger,
            IMemoryCachingService memoryCachingService,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            _logger = logger;
            _memoryCachingService = memoryCachingService;
            base._httpContext = httpContext;
        }

        public async Task<ResponseModel> List(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.WardRepository.Query()
                            join d in _context.DistrictRepository.Query() on m.DistrictId equals d.Id
                            join p in _context.ProvinceRepository.Query() on m.ProvinceId equals p.Id
                            where !m.Deleted
                            orderby p.Precedence ascending, d.Precedence ascending, m.Precedence ascending
                            select new WardModel
                            {
                                Id = m.Id,
                                Name = m.Name,
                                DistrictId = m.DistrictId,
                                DistrictName = d.Name,
                                ProvinceId = m.ProvinceId,
                                ProvinceName = p.Name,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text)
                                            || m.DistrictName.ToLower().Contains(filter.Text)
                                            || m.ProvinceName.ToLower().Contains(filter.Text));
                }

                BaseListModel<WardModel> listItems = new BaseListModel<WardModel>();
                listItems.TotalItems = await _context.WardRepository.Query().Where(m => !m.Deleted).CountAsync();
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
                var cacheData = _memoryCachingService.List<WardModel>(CacheKey);

                if (cacheData != null)
                {
                    response.Result = cacheData;
                }
                else
                {
                    var query = from m in _context.WardRepository.Query()
                                join d in _context.DistrictRepository.Query() on m.DistrictId equals d.Id
                                join p in _context.ProvinceRepository.Query() on m.ProvinceId equals p.Id
                                where m.IsActive && !m.Deleted
                                orderby p.Precedence ascending, d.Precedence ascending, m.Precedence ascending
                                select new WardModel
                                {
                                    Id = m.Id,
                                    Name = m.Name,
                                    DistrictId = m.DistrictId,
                                    ProvinceId = m.ProvinceId,
                                };

                    var list = await query.ToListAsync();

                    response.Result = list;

                    _memoryCachingService.Set<WardModel>(list, CacheKey, 60, 0, 0);
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
                var query = from m in _context.WardRepository.Query()
                            where m.Id == id
                            select new WardModel
                            {
                                Id = m.Id,
                                DistrictId = m.DistrictId,
                                ProvinceId = m.ProvinceId,
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

        public async Task<ResponseModel> Insert(WardModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Ward md = new Ward();

                md.Name = model.Name;
                md.DistrictId = model.DistrictId;
                md.ProvinceId = model.ProvinceId;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.WardRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();

                _memoryCachingService.Remove(CacheKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(WardModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Ward md = await _context.WardRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Name = model.Name;
                md.DistrictId = model.DistrictId;
                md.ProvinceId = model.ProvinceId;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.WardRepository.Update(md);

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
                Ward md = await _context.WardRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.WardRepository.Update(md);

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
