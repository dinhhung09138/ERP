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
    public class AppraiseAnswerService : BaseService, IAppraiseAnswerService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<AppraiseAnswerService> _logger;
        public AppraiseAnswerService(
            IERPUnitOfWork context,
            ILogger<AppraiseAnswerService> logger,
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
                var query = from m in _context.AppraiseAnswerRepository.Query()
                            where !m.Deleted
                            orderby m.CreateDate descending
                            select new AppraiseAnswerModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Description = m.Description,
                                Point = m.Point,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text)
                                            || m.Description.ToLower().Contains(filter.Text));
                }

                BaseListModel<AppraiseAnswerModel> listItems = new BaseListModel<AppraiseAnswerModel>();
                listItems.TotalItems = await _context.AppraiseAnswerRepository.Query().Where(m => !m.Deleted).CountAsync();
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
                AppraiseAnswer md = await _context.AppraiseAnswerRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                AppraiseAnswerModel model = new AppraiseAnswerModel()
                {
                    Id = md.Id,
                    AppraiseQuestionId = md.AppraiseQuestionId,
                    Name = md.Name,
                    Description = md.Description,
                    Point = md.Point,
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

        public async Task<ResponseModel> Insert(AppraiseAnswerModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                AppraiseAnswer md = new AppraiseAnswer();

                md.AppraiseQuestionId = model.AppraiseQuestionId;
                md.Name = model.Name;
                md.Description = model.Description;
                md.Point = model.Point;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;

                await _context.AppraiseAnswerRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(AppraiseAnswerModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                AppraiseAnswer md = await _context.AppraiseAnswerRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }
                if (md.RowVersion != model.RowVersion)
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Warning;
                    response.Errors.Add(ParameterMsg.OutOfDateData);
                    return response;
                }

                md.AppraiseQuestionId = model.AppraiseQuestionId;
                md.Name = model.Name;
                md.Description = model.Description;
                md.Point = model.Point;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.AppraiseAnswerRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(AppraiseAnswerModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                AppraiseAnswer md = await _context.AppraiseAnswerRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }
                if (md.RowVersion != model.RowVersion)
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Warning;
                    response.Errors.Add(ParameterMsg.OutOfDateData);
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.AppraiseAnswerRepository.Update(md);

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
