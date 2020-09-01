using Core.CommonModel;
using Core.Services;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.HR
{
    public class ApproveStatusService : BaseService, IApproveStatusService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<ApproveStatusService> _logger;

        public ApproveStatusService(
            IERPUnitOfWork context,
            ILogger<ApproveStatusService> logger,
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
                var query = from m in _context.ApproveStatusRepository.Query()
                            where !m.Deleted
                            orderby m.Precedence
                            select new ApproveStatusModel()
                            {
                                Id = m.Id,
                                Code = m.Code,
                                Name = m.Name,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Code.ToLower().Contains(filter.Text)
                                            || m.Name.ToLower().Contains(filter.Text));
                }

                BaseListModel<ApproveStatusModel> listItems = new BaseListModel<ApproveStatusModel>();
                listItems.TotalItems = await _context.ApproveStatusRepository.Query().Where(m => !m.Deleted).CountAsync();
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
                var query = from m in _context.ApproveStatusRepository.Query()
                            where !m.Deleted
                            orderby m.Precedence
                            select new ApproveStatusModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                            };


                response.Result = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.GetDropDownError;
                _logger.LogError(ex.Message, ex);
            }
            return response;
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                ApproveStatus md = await _context.ApproveStatusRepository.FirstOrDefaultAsync(m => m.Id == id);

                ApproveStatusModel model = new ApproveStatusModel()
                {
                    Id = md.Id,
                    Code = md.Code,
                    Name = md.Name,
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

        public async Task<ResponseModel> Insert(ApproveStatusModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                if (await _context.ApproveStatusRepository.CountAsync(m => m.Code == model.Code) > 0)
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.CodeExists;
                    return response;
                }

                ApproveStatus md = new ApproveStatus();

                md.Code = model.Code;
                md.Name = model.Name;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;

                await _context.ApproveStatusRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(ApproveStatusModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                ApproveStatus md = await _context.ApproveStatusRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Code = model.Code;
                md.Name = model.Name;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;
                
                _context.ApproveStatusRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(ApproveStatusModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                ApproveStatus md = await _context.ApproveStatusRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.ApproveStatusRepository.Update(md);

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
