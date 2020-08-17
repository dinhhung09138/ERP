using Core.CommonMessage;
using Core.CommonModel;
using Core.CommonModel.Exceptions;
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
    public class EducationService : BaseService, IEducationService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<EducationService> _logger;

        private readonly string ErrorDropdown = "Không thể lấy danh sách trình độ học vấn";

        public EducationService(
            IERPUnitOfWork context,
            ILogger<EducationService> logger,
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
                var query = from m in _context.EducationRepository.Query()
                            where !m.Deleted
                            orderby m.Precedence ascending
                            select new EducationModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                IsActive = m.IsActive,
                                Precedence = m.Precedence,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text));
                }

                BaseListModel<EducationModel> listItems = new BaseListModel<EducationModel>();
                listItems.TotalItems = await _context.EducationRepository.Query().Where(m => !m.Deleted).CountAsync();
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
                var query = from m in _context.EducationRepository.Query()
                            where m.IsActive && !m.Deleted
                            orderby m.Precedence ascending
                            select new EducationModel
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
                Education md = await _context.EducationRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                EducationModel model = new EducationModel()
                {
                    Id = md.Id,
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

        public async Task<ResponseModel> Insert(EducationModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Education md = new Education();

                md.Name = model.Name;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.EducationRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(EducationModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Education md = await _context.EducationRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

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
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EducationRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(EducationModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Education md = await _context.EducationRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

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

                _context.EducationRepository.Update(md);

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
