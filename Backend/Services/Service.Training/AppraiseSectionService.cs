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
    public class AppraiseSectionService : IAppraiseSectionService
    {
        private readonly ITrainingUnitOfWork _context;
        public AppraiseSectionService(ITrainingUnitOfWork context)
        {
            _context = context;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.AppraiseSectionRepository.Query()
                            where !m.Deleted
                            orderby m.CreateDate descending
                            select new AppraiseSectionModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Description = m.Description,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text)
                                            || m.Description.ToLower().Contains(filter.Text));
                }

                BaseListModel<AppraiseSectionModel> listItems = new BaseListModel<AppraiseSectionModel>();
                listItems.TotalItems = await _context.AppraiseSectionRepository.Query().Where(m => !m.Deleted).CountAsync();
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

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                AppraiseSection md = await _context.AppraiseSectionRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                AppraiseSectionModel model = new AppraiseSectionModel()
                {
                    Id = md.Id,
                    AppraiseId = md.AppraiseId,
                    Name = md.Name,
                    Description = md.Description,
                    Precedence = md.Precedence,
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

        public async Task<ResponseModel> Save(AppraiseSectionModel model)
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

        private async Task<ResponseModel> Insert(AppraiseSectionModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                AppraiseSection md = new AppraiseSection();

                md.AppraiseId = model.AppraiseId;
                md.Name = model.Name;
                md.Description = model.Description;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.CreateBy = 1; // TODO
                md.CreateDate = DateTime.Now;

                await _context.AppraiseSectionRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        private async Task<ResponseModel> Update(AppraiseSectionModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                AppraiseSection md = await _context.AppraiseSectionRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.AppraiseId = model.AppraiseId;
                md.Name = model.Name;
                md.Description = model.Description;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.AppraiseSectionRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        private async Task<ResponseModel> Delete(AppraiseSectionModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                AppraiseSection md = await _context.AppraiseSectionRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Deleted = true;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.AppraiseSectionRepository.Update(md);

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
