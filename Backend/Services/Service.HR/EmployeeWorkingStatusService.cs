using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.HR;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Utility.Caching.Interfaces;

namespace Service.HR
{
    public class EmployeeWorkingStatusService : IEmployeeWorkingStatusService
    {
        private readonly string cacheKey = "working_status_data";

        private readonly IERPUnitOfWork _context;
        private readonly IMemoryCachingService _memoryCachingService;
        public EmployeeWorkingStatusService(IERPUnitOfWork context, IMemoryCachingService memoryCachingService)
        {
            _context = context;
            _memoryCachingService = memoryCachingService;
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
                var cacheData = _memoryCachingService.GetList<EmployeeWorkingStatusModel>(cacheKey);

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

                    _memoryCachingService.Set<EmployeeWorkingStatusModel>(list, cacheKey, 30, 0, 0);

                    response.Result = list;
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
                var query = from m in _context.EmployeeWorkingStatusRepository.Query()
                            where m.Id == id
                            select new EmployeeWorkingStatusModel
                            {
                                Id = m.Id,
                                Code = m.Code,
                                Name = m.Name,
                                Description = m.Description,
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
                md.CreateBy = 1; // TODO
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.EmployeeWorkingStatusRepository.AddAsync(md).ConfigureAwait(true);

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

        public async Task<ResponseModel> Update(EmployeeWorkingStatusModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeWorkingStatus md = await _context.EmployeeWorkingStatusRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Name = model.Name;
                md.Description = model.Description;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.EmployeeWorkingStatusRepository.Update(md);

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
                EmployeeWorkingStatus md = await _context.EmployeeWorkingStatusRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Deleted = true;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.EmployeeWorkingStatusRepository.Update(md);

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
