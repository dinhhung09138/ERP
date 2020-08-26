using Core.CommonMessage;
using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Core.Services;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Training;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Training.Interfaces;
using Service.Training.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Training
{
    public class AppraiseQuestionService : BaseService, IAppraiseQuestionService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<AppraiseQuestionService> _logger;
        public AppraiseQuestionService(
            IERPUnitOfWork context,
            ILogger<AppraiseQuestionService> logger,
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
                var query = from m in _context.AppraiseQuestionRepository.Query()
                            where !m.Deleted
                            orderby m.CreateDate descending
                            select new AppraiseQuestionModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Description = m.Description,
                                IsInputAnswer = m.IsInputAnswer,
                                AppraiseSectionId = m.AppraiseSectionId,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text)
                                            || m.Description.ToLower().Contains(filter.Text));
                }

                BaseListModel<AppraiseQuestionModel> listItems = new BaseListModel<AppraiseQuestionModel>();
                listItems.TotalItems = await _context.AppraiseQuestionRepository.Query().Where(m => !m.Deleted).CountAsync();
                listItems.Items = await query.Skip(filter.Paging.PageIndex * filter.Paging.PageSize).Take(filter.Paging.PageSize).ToListAsync().ConfigureAwait(false);

                response.Result = listItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                AppraiseQuestion md = await _context.AppraiseQuestionRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                AppraiseQuestionModel model = new AppraiseQuestionModel()
                {
                    Id = md.Id,
                    Name = md.Name,
                    Description = md.Description,
                    IsInputAnswer = md.IsInputAnswer,
                    AppraiseSectionId = md.AppraiseSectionId,
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

        public async Task<ResponseModel> Insert(AppraiseQuestionModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                AppraiseQuestion md = new AppraiseQuestion();

                md.Name = model.Name;
                md.Description = model.Description;
                md.IsInputAnswer = model.IsInputAnswer;
                md.AppraiseSectionId = model.AppraiseSectionId;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;

                await _context.AppraiseQuestionRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(AppraiseQuestionModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                AppraiseQuestion md = await _context.AppraiseQuestionRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Name = model.Name;
                md.Description = model.Description;
                md.IsInputAnswer = model.IsInputAnswer;
                md.AppraiseSectionId = model.AppraiseSectionId;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.AppraiseQuestionRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(AppraiseQuestionModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                AppraiseQuestion md = await _context.AppraiseQuestionRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.AppraiseQuestionRepository.Update(md);

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
