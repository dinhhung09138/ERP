﻿using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Core.Services.Interfaces;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.HR;
using Microsoft.EntityFrameworkCore;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.HR
{
    public class NationalityService : INationalityService
    {
        private readonly string cacheKey = "nationality_data";

        private readonly IERPUnitOfWork _context;
        private readonly IMemoryCachingService _memoryCachingService;
        public NationalityService(IERPUnitOfWork context, IMemoryCachingService memoryCachingService)
        {
            _context = context;
            _memoryCachingService = memoryCachingService;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.NationalityRepository.Query()
                            where !m.Deleted
                            orderby m.Precedence ascending
                            select new NationalityModel
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text));
                }

                BaseListModel<NationalityModel> listItems = new BaseListModel<NationalityModel>();
                listItems.TotalItems = await _context.NationalityRepository.Query().Where(m => !m.Deleted).CountAsync();
                listItems.Items = await query.Skip(filter.Paging.PageIndex * filter.Paging.PageSize).Take(filter.Paging.PageSize).ToListAsync().ConfigureAwait(false);

                response.Result = listItems;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> DropDownSelection()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var cacheData = _memoryCachingService.GetList<NationalityModel>(cacheKey);

                if (cacheData != null)
                {
                    response.Result = cacheData;
                }
                else
                {
                    var query = from m in _context.NationalityRepository.Query()
                                where m.IsActive && !m.Deleted
                                orderby m.Precedence ascending
                                select new NationalityModel
                                {
                                    Id = m.Id,
                                    Name = m.Name,
                                };

                    var list = await query.ToListAsync();
                    response.Result = list;

                    _memoryCachingService.Set<NationalityModel>(list, cacheKey, 60, 0, 0);
                }
                
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.NationalityRepository.Query()
                            where m.Id == id
                            select new NationalityModel
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive
                            };

                response.Result = await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Insert(NationalityModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Nationality md = new Nationality();

                md.Name = model.Name;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.CreateBy = 1; // TODO
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.NationalityRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();

                _memoryCachingService.Remove(cacheKey);
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Update(NationalityModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Nationality md = await _context.NationalityRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Name = model.Name;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.NationalityRepository.Update(md);

                await _context.SaveChangesAsync();

                _memoryCachingService.Remove(cacheKey);
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Nationality md = await _context.NationalityRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Deleted = true;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.NationalityRepository.Update(md);

                await _context.SaveChangesAsync();

                _memoryCachingService.Remove(cacheKey);
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }
    }
}
