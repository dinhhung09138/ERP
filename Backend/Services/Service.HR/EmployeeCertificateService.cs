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
    public class EmployeeCertificateService : BaseService, IEmployeeCertificateService
    {
        private readonly IERPUnitOfWork _context;

        public EmployeeCertificateService(
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
                var query = from m in _context.EmployeeCertificateRepository.Query()
                            join t in _context.CertificatedRepository.Query() on m.CertificateId equals t.Id
                            join s in _context.SchoolRepository.Query() on m.SchoolId equals s.Id
                            where !m.Deleted && m.EmployeeId == filter.EmployeeId
                            orderby m.CreateDate
                            select new EmployeeCertificateModel()
                            {
                                Id = m.Id,
                                CertificateId = m.CertificateId,
                                CertificateName = t.Name,
                                SchoolId = m.SchoolId,
                                SchoolName = s.Name,
                                year = m.year,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.CertificateName.ToLower().Contains(filter.Text));
                }

                BaseListModel<EmployeeCertificateModel> listItems = new BaseListModel<EmployeeCertificateModel>();
                listItems.TotalItems = await _context.EmployeeCertificateRepository.Query().Where(m => !m.Deleted && m.EmployeeId == filter.EmployeeId).CountAsync();
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
                var query = from m in _context.EmployeeCertificateRepository.Query()
                            where m.Id == id
                            select new EmployeeCertificateModel
                            {
                                Id = m.Id,
                                EmployeeId = m.EmployeeId,
                                CertificateId = m.CertificateId,
                                SchoolId = m.SchoolId,
                                year = m.year,
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

        public async Task<ResponseModel> Insert(EmployeeCertificateModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeCertificate md = new EmployeeCertificate();

                md.EmployeeId = model.EmployeeId;
                md.CertificateId = model.CertificateId;
                md.SchoolId = model.SchoolId;
                md.year = model.year;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.EmployeeCertificateRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Update(EmployeeCertificateModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeCertificate md = await _context.EmployeeCertificateRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.EmployeeId = model.EmployeeId;
                md.CertificateId = model.CertificateId;
                md.SchoolId = model.SchoolId;
                md.year = model.year;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeCertificateRepository.Update(md);

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
                EmployeeCertificate md = await _context.EmployeeCertificateRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeCertificateRepository.Update(md);

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
