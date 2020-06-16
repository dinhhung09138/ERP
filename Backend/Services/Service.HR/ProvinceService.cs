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
    public class ProvinceService : IProvinceService
    {
        private readonly IHRUnitOfWork _context;
        public ProvinceService(IHRUnitOfWork context)
        {
            _context = context;
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
                                IsActive = m.IsActive
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text));
                }

                var list = query.OrderBy(m => m.Precedence);

                BaseListModel<ProvinceModel> listItems = new BaseListModel<ProvinceModel>();
                listItems.TotalItems = await _context.ProvinceRepository.Query().CountAsync();
                listItems.Items = await list.Skip(filter.Paging.PageIndex * filter.Paging.PageSize).Take(filter.Paging.PageSize).ToListAsync().ConfigureAwait(false);

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
                var query = from m in _context.ProvinceRepository.Query()
                            where m.IsActive && !m.Deleted
                            orderby m.Precedence ascending
                            select new ProvinceModel
                            {
                                Id = m.Id,
                                Name = m.Name,
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
                var query = from m in _context.ProvinceRepository.Query()
                            where m.Id == id
                            select new ProvinceModel
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

        public async Task<ResponseModel> Save(ProvinceModel model)
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


        private async Task<ResponseModel> Insert(ProvinceModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Province md = new Province();

                md.Name = model.Name;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.CreateBy = 1; // TODO
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.ProvinceRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        private async Task<ResponseModel> Update(ProvinceModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Province md = await _context.ProvinceRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Name = model.Name;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.ProvinceRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        private async Task<ResponseModel> Delete(ProvinceModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Province md = await _context.ProvinceRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Deleted = true;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.ProvinceRepository.Update(md);

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
