using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Database.Sql.Training;
using Database.Sql.Training.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Training.Interfaces;
using Service.Training.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Training
{
    public class AppraiseService : IAppraiseService
    {
        private readonly ITrainingUnitOfWork _context;
        public AppraiseService(ITrainingUnitOfWork context)
        {
            _context = context;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.AppraiseRepository.Query()
                            where !m.Deleted
                            orderby m.Name ascending
                            select new AppraiseModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Description = m.Description,
                                IsActive = m.IsActive
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text)
                                            || m.Description.ToLower().Contains(filter.Text));
                }

                BaseListModel<AppraiseModel> listItems = new BaseListModel<AppraiseModel>();
                listItems.TotalItems = await _context.AppraiseRepository.Query().Where(m => !m.Deleted).CountAsync();
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
                var query = from m in _context.AppraiseRepository.Query()
                            where !m.Deleted
                            orderby m.Name ascending
                            select new AppraiseModel()
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
                Appraise md = await _context.AppraiseRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                AppraiseModel model = new AppraiseModel()
                {
                    Id = md.Id,
                    Name = md.Name,
                    Description = md.Description,
                    IsActive = md.IsActive,
                };

                response.Result = model;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Save(AppraiseModel model)
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

        private async Task<ResponseModel> Insert(AppraiseModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Appraise md = new Appraise();

                md.Name = model.Name;
                md.Description = model.Description;
                md.IsActive = model.IsActive;
                md.CreateBy = 1; // TODO
                md.CreateDate = DateTime.Now;

                await _context.AppraiseRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        private async Task<ResponseModel> Update(AppraiseModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Appraise md = await _context.AppraiseRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Name = model.Name;
                md.Description = model.Description;
                md.IsActive = model.IsActive;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.AppraiseRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        private async Task<ResponseModel> Delete(AppraiseModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Appraise md = await _context.AppraiseRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Deleted = true;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.AppraiseRepository.Update(md);

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
