﻿using Core.CommonMessage;
using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Core.Services;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Common;
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
    public class DistrictService : BaseService, IDistrictService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<DistrictService> _logger;

        private readonly string ErrorDropdown = "Không thể lấy danh sách quận huyện";

        public DistrictService(
            IERPUnitOfWork context,
            ILogger<DistrictService> logger,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            _logger = logger;
            base._httpContext = httpContext;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.DistrictRepository.Query()
                            join p in _context.ProvinceRepository.Query() on m.ProvinceId equals p.Id
                            where !m.Deleted
                            orderby p.Precedence ascending, m.Precedence ascending
                            select new DistrictModel
                            {
                                Id = m.Id,
                                Name = m.Name,
                                ProvinceId = m.ProvinceId,
                                ProvinceName = p.Name,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text)
                                            || m.ProvinceName.ToLower().Contains(filter.Text));
                }

                BaseListModel<DistrictModel> listItems = new BaseListModel<DistrictModel>();
                listItems.TotalItems = await _context.DistrictRepository.Query().Where(m => !m.Deleted).CountAsync();
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
                var query = from m in _context.DistrictRepository.Query()
                            join p in _context.ProvinceRepository.Query() on m.ProvinceId equals p.Id
                            where m.IsActive && !m.Deleted
                            orderby p.Precedence ascending, m.Precedence ascending
                            select new DistrictModel
                            {
                                Id = m.Id,
                                Name = m.Name,
                                ProvinceId = m.ProvinceId,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive
                            };

                response.Result = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Warning;
                response.Errors.Add(ErrorDropdown);
                _logger.LogError(ex.Message, ex);
            }
            return response;
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.DistrictRepository.Query()
                            join p in _context.ProvinceRepository.Query() on m.ProvinceId equals p.Id
                            where m.Id == id
                            select new DistrictModel
                            {
                                Id = m.Id,
                                Name = m.Name,
                                ProvinceId = m.ProvinceId,
                                ProvinceName = p.Name,
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

        public async Task<ResponseModel> Insert(DistrictModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                District md = new District();

                md.Name = model.Name;
                md.ProvinceId = model.ProvinceId;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.DistrictRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(DistrictModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                District md = await _context.DistrictRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }
                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Warning;
                    response.Errors.Add(ParameterMsg.OutOfDateData);
                    return response;
                }

                md.Name = model.Name;
                md.ProvinceId = model.ProvinceId;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.DistrictRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(DistrictModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                District md = await _context.DistrictRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }
                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Warning;
                    response.Errors.Add(ParameterMsg.OutOfDateData);
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.DistrictRepository.Update(md);

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
