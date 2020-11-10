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
    public class EmployeeRelationshipService : BaseService, IEmployeeRelationshipService
    {
        private readonly IERPUnitOfWork _context;

        public EmployeeRelationshipService(
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
                var query = from m in _context.EmployeeRelationshipRepository.Query()
                            join r in _context.RelationshipTypeRepository.Query() on m.RelationshipTypeId equals r.Id
                            where !m.Deleted && m.EmployeeId == filter.EmployeeId
                            orderby r.Precedence
                            select new EmployeeRelationshipModel()
                            {
                                Id = m.Id,
                                FullName = m.FullName,
                                Address = m.Address,
                                Mobile = m.Mobile,
                                RelationshipTypeName = r.Name,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.FullName.ToLower().Contains(filter.Text)
                                            || m.RelationshipTypeName.ToLower().Contains(filter.Text)
                                            || m.Address.ToLower().Contains(filter.Text)
                                            || m.Mobile.ToLower().Contains(filter.Text));
                }

                BaseListModel<EmployeeRelationshipModel> listItems = new BaseListModel<EmployeeRelationshipModel>();
                listItems.TotalItems = await _context.EmployeeRelationshipRepository.Query().Where(m => !m.Deleted && m.EmployeeId == filter.EmployeeId).CountAsync();
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
                var query = from m in _context.EmployeeRelationshipRepository.Query()
                            where m.Id == id
                            select new EmployeeRelationshipModel
                            {
                                Id = m.Id,
                                EmployeeId = m.EmployeeId,
                                FullName = m.FullName,
                                RelationshipTypeId = m.RelationshipTypeId,
                                Address = m.Address,
                                Mobile = m.Mobile,
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

        public async Task<ResponseModel> Insert(EmployeeRelationshipModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeRelationship md = new EmployeeRelationship();

                md.EmployeeId = model.EmployeeId;
                md.FullName = model.FullName;
                md.RelationshipTypeId = model.RelationshipTypeId;
                md.Address = model.Address;
                md.Mobile = model.Mobile;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.EmployeeRelationshipRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Update(EmployeeRelationshipModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeRelationship md = await _context.EmployeeRelationshipRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.EmployeeId = model.EmployeeId;
                md.FullName = model.FullName;
                md.RelationshipTypeId = model.RelationshipTypeId;
                md.Address = model.Address;
                md.Mobile = model.Mobile;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeRelationshipRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(DeleteModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeRelationship md = await _context.EmployeeRelationshipRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeRelationshipRepository.Update(md);

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
