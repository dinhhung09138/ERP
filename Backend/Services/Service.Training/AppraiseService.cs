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
    public class AppraiseService : BaseService, IAppraiseService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<AppraiseService> _logger;

        private readonly string ErrorDropdown = "Không thể lấy danh sách đánh giá";
        public AppraiseService(
            IERPUnitOfWork context,
            ILogger<AppraiseService> logger,
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
                var query = from m in _context.AppraiseRepository.Query()
                            where !m.Deleted
                            orderby m.Name ascending
                            select new AppraiseModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Description = m.Description,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
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
                throw ex;
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

        public async Task<ResponseModel> Insert(AppraiseModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Appraise md = new Appraise();

                md.Name = model.Name;
                md.Description = model.Description;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;

                await _context.AppraiseRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(AppraiseModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Appraise md = await _context.AppraiseRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

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
                md.Description = model.Description;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.AppraiseRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(AppraiseModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Appraise md = await _context.AppraiseRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

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

                _context.AppraiseRepository.Update(md);

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
