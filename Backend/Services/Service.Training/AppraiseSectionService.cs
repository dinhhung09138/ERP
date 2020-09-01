using Core.CommonModel;
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
    public class AppraiseSectionService : BaseService, IAppraiseSectionService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<AppraiseSectionService> _logger;
        public AppraiseSectionService(
            IERPUnitOfWork context,
            ILogger<AppraiseSectionService> logger,
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
                var query = from m in _context.AppraiseSectionRepository.Query()
                            where !m.Deleted
                            orderby m.CreateDate descending
                            select new AppraiseSectionModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Description = m.Description,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
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
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                AppraiseSection md = await _context.AppraiseSectionRepository.FirstOrDefaultAsync(m => m.Id == id);

                AppraiseSectionModel model = new AppraiseSectionModel()
                {
                    Id = md.Id,
                    AppraiseId = md.AppraiseId,
                    Name = md.Name,
                    Description = md.Description,
                    Precedence = md.Precedence,
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

        public async Task<ResponseModel> Insert(AppraiseSectionModel model)
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
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;

                await _context.AppraiseSectionRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(AppraiseSectionModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                AppraiseSection md = await _context.AppraiseSectionRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.AppraiseId = model.AppraiseId;
                md.Name = model.Name;
                md.Description = model.Description;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.AppraiseSectionRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(AppraiseSectionModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                AppraiseSection md = await _context.AppraiseSectionRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.AppraiseSectionRepository.Update(md);

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
