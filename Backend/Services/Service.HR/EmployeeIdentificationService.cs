using Core.CommonModel;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.HR;
using Core.Services;
using Microsoft.AspNetCore.Http;

namespace Service.HR
{
    public class EmployeeIdentificationService: BaseService, IEmployeeIdentificationService
    {
        private readonly IERPUnitOfWork _context;

        public EmployeeIdentificationService(
            IERPUnitOfWork context,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            base._httpContext = httpContext;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.EmployeeIdentificationRepository.Query()
                            join i in _context.IdentificationTypeRepository.Query() on m.IdentificationTypeId equals i.Id
                            join p in _context.ProvinceRepository.Query() on m.PlaceId equals p.Id
                            where !m.Deleted && m.EmployeeId == filter.EmployeeId
                            orderby m.CreateDate
                            select new EmployeeIdentificationModel()
                            {
                                Id = m.Id,
                                Code = m.Code,
                                ApplyDate = m.ApplyDate,
                                PlaceId = m.PlaceId,
                                PlaceName = p.Name,
                                IdentificationTypeId = m.IdentificationTypeId,
                                IdentificationTypeName = i.Name,
                                Notes = m.Notes,
                                ExpirationDate = m.ExpirationDate,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Code.ToLower().Contains(filter.Text)
                                            || m.PlaceName.ToLower().Contains(filter.Text)
                                            || m.IdentificationTypeName.ToLower().Contains(filter.Text)
                                            || m.Notes.ToLower().Contains(filter.Text));
                }

                BaseListModel<EmployeeIdentificationModel> listItems = new BaseListModel<EmployeeIdentificationModel>();
                listItems.TotalItems = await _context.EmployeeIdentificationRepository.Query().Where(m => !m.Deleted && m.EmployeeId == filter.EmployeeId).CountAsync();
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
                var query = from m in _context.EmployeeIdentificationRepository.Query()
                            where m.Id == id
                            select new EmployeeIdentificationModel
                            {
                                Id = m.Id,
                                EmployeeId = m.EmployeeId,
                                Code = m.Code,
                                ApplyDate = m.ApplyDate,
                                PlaceId = m.PlaceId,
                                IdentificationTypeId = m.IdentificationTypeId,
                                Notes = m.Notes,
                                ExpirationDate = m.ExpirationDate,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                response.Result = await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(EmployeeIdentificationModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeIdentification md = new EmployeeIdentification();

                md.EmployeeId = model.EmployeeId;
                md.Code = model.Code;
                md.ApplyDate = model.ApplyDate;
                md.PlaceId = model.PlaceId;
                md.IdentificationTypeId = model.IdentificationTypeId;
                md.Notes = model.Notes;
                md.ExpirationDate = model.ExpirationDate;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.EmployeeIdentificationRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Update(EmployeeIdentificationModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeIdentification md = await _context.EmployeeIdentificationRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.EmployeeId = model.EmployeeId;
                md.Code = model.Code;
                md.ApplyDate = model.ApplyDate;
                md.PlaceId = model.PlaceId;
                md.IdentificationTypeId = model.IdentificationTypeId;
                md.Notes = model.Notes;
                md.ExpirationDate = model.ExpirationDate;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeIdentificationRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(EmployeeIdentificationModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeIdentification md = await _context.EmployeeIdentificationRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeIdentificationRepository.Update(md);

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
