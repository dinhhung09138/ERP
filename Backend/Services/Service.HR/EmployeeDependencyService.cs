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
    public class EmployeeDependencyService : BaseService, IEmployeeDependencyService
    {
        private readonly IERPUnitOfWork _context;

        public EmployeeDependencyService(
            IERPUnitOfWork context,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            base._httpContext = httpContext;
        }

        public async Task<ResponseModel> List(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.EmployeeDependencyRepository.Query()
                            join r in _context.RelationshipTypeRepository.Query() on m.RelationshipTypeId equals r.Id
                            where !m.Deleted && m.EmployeeId == filter.EmployeeId
                            orderby m.CreateDate
                            select new EmployeeDependencyModel()
                            {
                                Id = m.Id,
                                RelationshipTypeName = r.Name,
                                FullName = m.FullName,
                                DateOfBirth = m.DateOfBirth,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.RelationshipTypeName.ToLower().Contains(filter.Text)
                                            || m.FullName.ToLower().Contains(filter.Text)
                                            || m.DateOfBirth.ToShortDateString().Contains(filter.Text));
                }

                BaseListModel<EmployeeDependencyModel> listItems = new BaseListModel<EmployeeDependencyModel>();
                listItems.TotalItems = await _context.EmployeeDependencyRepository.Query().Where(m => !m.Deleted && m.EmployeeId == filter.EmployeeId).CountAsync();
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
                var query = from m in _context.EmployeeDependencyRepository.Query()
                            where m.Id == id
                            select new EmployeeDependencyModel
                            {
                                Id = m.Id,
                                EmployeeId = m.EmployeeId,
                                FullName = m.FullName,
                                RelationshipTypeId = m.RelationshipTypeId,
                                DateOfBirth = m.DateOfBirth,
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

        public async Task<ResponseModel> Insert(EmployeeDependencyModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeDependency md = new EmployeeDependency();

                md.EmployeeId = model.EmployeeId;
                md.FullName = model.FullName;
                md.RelationshipTypeId = model.RelationshipTypeId;
                md.DateOfBirth = model.DateOfBirth;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.EmployeeDependencyRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Update(EmployeeDependencyModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeDependency md = await _context.EmployeeDependencyRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.EmployeeId = model.EmployeeId;
                md.FullName = model.FullName;
                md.RelationshipTypeId = model.RelationshipTypeId;
                md.DateOfBirth = model.DateOfBirth;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeDependencyRepository.Update(md);

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
                EmployeeDependency md = await _context.EmployeeDependencyRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeDependencyRepository.Update(md);

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
