using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Database.Sql.HR;
using DataBase.Sql.HR.Entities;
using Microsoft.EntityFrameworkCore;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.HR
{
    public class WardService : IWardService
    {
        private readonly IHRUnitOfWork _context;
        public WardService(IHRUnitOfWork context)
        {
            _context = context;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
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
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text)
                                            || m.DistrictName.ToLower().Contains(filter.Text)
                                            || m.ProvinceName.ToLower().Contains(filter.Text));
                }
                
                BaseListModel<WardModel> listItems = new BaseListModel<WardModel>();
                listItems.TotalItems = await _context.WardRepository.Query().CountAsync();
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

                response.Result = await query.ToListAsync();
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
                var query = from m in _context.WardRepository.Query()
                            where m.Id == id
                            select new WardModel
                            {
                                Id = m.Id,
                                DistrictId = m.DistrictId,
                                ProvinceId = m.ProvinceId,
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

        public async Task<ResponseModel> Save(WardModel model)
        {
            ResponseModel response = new ResponseModel();
            switch (model.Action)
            {
                case Core.CommonModel.Enums.FormActionStatus.Insert:
                    response = await Insert(model);
                    break;
                case Core.CommonModel.Enums.FormActionStatus.Update:
                    response = await Update(model);
                    break;
                case Core.CommonModel.Enums.FormActionStatus.Delete:
                    response = await Delete(model);
                    break;
            }
            return response;
        }


        private async Task<ResponseModel> Insert(WardModel model)
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
                md.CreateBy = 1; // TODO
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.WardRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        private async Task<ResponseModel> Update(WardModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Ward md = await _context.WardRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Name = model.Name;
                md.DistrictId = model.DistrictId;
                md.ProvinceId = model.ProvinceId;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.WardRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        private async Task<ResponseModel> Delete(WardModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Ward md = await _context.WardRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Deleted = true;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.WardRepository.Update(md);

                await _context.SaveChangesAsync();
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
