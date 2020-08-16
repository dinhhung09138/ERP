using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.HR;
using Microsoft.Extensions.Logging;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Core.CommonMessage;

namespace Service.HR
{
    public class EmployeeInfoService : BaseService, IEmployeeInfoService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<EmployeeInfoService> _logger;

        public EmployeeInfoService(
            IERPUnitOfWork context,
            ILogger<EmployeeInfoService> logger,
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
                var query = from m in _context.EmployeeInfoRepository.Query()
                            where !m.Deleted
                            orderby m.FirstName ascending
                            select new EmployeeInfoModel
                            {
                                Id = m.Id,
                                FirstName = m.FirstName,
                                LastName = m.LastName,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.FirstName.ToLower().Contains(filter.Text)
                                            || m.LastName.ToLower().Contains(filter.Text));
                }

                BaseListModel<EmployeeInfoModel> listItems = new BaseListModel<EmployeeInfoModel>();
                listItems.TotalItems = await _context.EmployeeInfoRepository.Query().Where(m => !m.Deleted).CountAsync();
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
                var query = from m in _context.EmployeeInfoRepository.Query()
                            where m.Id == id
                            select new EmployeeInfoModel
                            {
                                Id = m.Id,
                                EmployeeId = m.EmployeeId,
                                FirstName = m.FirstName,
                                LastName = m.LastName,
                                Gender = m.Gender,
                                DateOfBirth = m.DateOfBirth,
                                ReligionId = m.ReligionId,
                                MaterialStatusId = m.MaterialStatusId,
                                NationId = m.NationId,
                                NationalityId = m.NationalityId,
                                AcademicLevelId = m.AcademicLevelId,
                                ProfessionalQualificationId = m.ProfessionalQualificationId,
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

        public async Task<ResponseModel> Insert(EmployeeInfoModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeInfo md = new EmployeeInfo();

                md.EmployeeId = model.EmployeeId;
                md.FirstName = model.FirstName.Trim();
                md.LastName = model.LastName.Trim();
                md.Gender = model.Gender;
                md.DateOfBirth = model.DateOfBirth;
                md.MaterialStatusId = model.MaterialStatusId;
                md.ReligionId = model.ReligionId;
                md.NationId = model.NationId;
                md.NationalityId = model.NationalityId;
                md.AcademicLevelId = model.AcademicLevelId;
                md.ProfessionalQualificationId = model.ProfessionalQualificationId;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.EmployeeInfoRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Update(EmployeeInfoModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeInfo md = await _context.EmployeeInfoRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

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

                md.EmployeeId = model.EmployeeId;
                md.Gender = model.Gender;
                md.DateOfBirth = model.DateOfBirth;
                md.MaterialStatusId = model.MaterialStatusId;
                md.ReligionId = model.ReligionId;
                md.NationId = model.NationId;
                md.NationalityId = model.NationalityId;
                md.AcademicLevelId = model.AcademicLevelId;
                md.ProfessionalQualificationId = model.ProfessionalQualificationId;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeInfoRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> UpdateName(int employeeId, string firstName, string lastName)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeInfo md = await _context.EmployeeInfoRepository.FirstOrDefaultAsync(m => m.EmployeeId == employeeId);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.FirstName = firstName;
                md.LastName = lastName;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeInfoRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
                _logger.LogError(ex.Message, ex);
            }
            return response;
        }

        public async Task<ResponseModel> Delete(EmployeeInfoModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeInfo md = await _context.EmployeeInfoRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

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

                _context.EmployeeInfoRepository.Update(md);

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
