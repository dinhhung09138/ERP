using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.HR;
using Microsoft.EntityFrameworkCore;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.HR
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IERPUnitOfWork _context;
        private readonly IEmployeeInfoService _employeeInfoService;
        public EmployeeService(IERPUnitOfWork context, IEmployeeInfoService employeeInfoService)
        {
            _context = context;
            _employeeInfoService = employeeInfoService;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.EmployeeRepository.Query()
                            join info in _context.EmployeeInfoRepository.Query() on m.Id equals info.EmployeeId
                            join status in _context.EmployeeWorkingStatusRepository.Query() on m.EmployeeWorkingStatusId equals status.Id
                            where !m.Deleted
                            orderby m.CreateDate
                            select new EmployeeModel()
                            {
                                Id = m.Id,
                                EmployeeCode = m.EmployeeCode,
                                FirstName = info.FirstName,
                                LastName = info.LastName,
                                Gender = info.Gender,
                                ProbationDate = m.ProbationDate,
                                StartWorkingDate = m.StartWorkingDate,
                                BadgeCardNumber = m.BadgeCardNumber,
                                FingerSignNumber = m.FingerSignNumber,
                                WorkingEmail = m.WorkingEmail,
                                WorkingPhone = m.WorkingPhone,
                                EmployeeWorkingStatusId = m.EmployeeWorkingStatusId,
                                EmployeeWorkingStatusName = status.Name,
                                IsActive = m.IsActive
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.EmployeeCode.ToLower().Contains(filter.Text)
                                            || m.FirstName.Contains(filter.Text)
                                            || m.LastName.Contains(filter.Text)
                                            || m.WorkingEmail.Contains(filter.Text)
                                            || m.WorkingPhone.Contains(filter.Text)
                                            || m.EmployeeWorkingStatusName.Contains(filter.Text));
                }
                BaseListModel<EmployeeModel> listItems = new BaseListModel<EmployeeModel>();
                listItems.TotalItems = await _context.EmployeeRepository.Query().Where(m => !m.Deleted).CountAsync();
                listItems.Items = await query.Skip(filter.Paging.PageIndex * filter.Paging.PageSize).Take(filter.Paging.PageSize).ToListAsync().ConfigureAwait(false);

                response.Result = listItems;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> DropDownSelection()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.EmployeeRepository.Query()
                            join info in _context.EmployeeInfoRepository.Query() on m.Id equals info.EmployeeId
                            where m.IsActive && !m.Deleted
                            orderby m.CreateDate ascending
                            select new EmployeeModel
                            {
                                Id = m.Id,
                                EmployeeCode = m.EmployeeCode,
                                FirstName = info.FirstName,
                                LastName = info.LastName,
                            };

                response.Result = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var md = from m in _context.EmployeeRepository.Query()
                                      join info in _context.EmployeeInfoRepository.Query() on m.Id equals info.EmployeeId
                                      join status in _context.EmployeeWorkingStatusRepository.Query() on m.EmployeeWorkingStatusId equals status.Id
                                      where m.IsActive && !m.Deleted
                                      select new EmployeeModel()
                                      {
                                          Id = m.Id,
                                          EmployeeCode = m.EmployeeCode,
                                          FirstName = info.FirstName,
                                          LastName = info.LastName,
                                          Gender = info.Gender,
                                          ProbationDate = m.ProbationDate,
                                          StartWorkingDate = m.StartWorkingDate,
                                          BadgeCardNumber = m.BadgeCardNumber,
                                          DateApplyBadge = m.DateApplyBadge,
                                          FingerSignNumber = m.FingerSignNumber,
                                          DateApplyFingerSign = m.DateApplyFingerSign,
                                          WorkingEmail = m.WorkingEmail,
                                          WorkingPhone = m.WorkingPhone,
                                          EmployeeWorkingStatusId = m.EmployeeWorkingStatusId,
                                          EmployeeWorkingStatusName = status.Name,
                                          BasicSalary = m.BasicSalary,
                                          IsActive = m.IsActive,
                                      };

                if (md == null)
                {
                    throw new NullParameterException();
                }

               

                response.Result = await md.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Insert(EmployeeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {

                await _context.BeginTransactionAsync();

                Employee md = new Employee();

                md.EmployeeCode = model.EmployeeCode.Trim();
                md.ProbationDate = model.ProbationDate;
                md.StartWorkingDate = model.StartWorkingDate;
                md.BadgeCardNumber = model.BadgeCardNumber.Trim();
                md.DateApplyBadge = model.DateApplyBadge;
                md.FingerSignNumber = model.FingerSignNumber.Trim();
                md.DateApplyFingerSign = model.DateApplyFingerSign;
                md.WorkingEmail = model.WorkingEmail.Trim();
                md.WorkingPhone = model.WorkingPhone.Trim();
                md.EmployeeWorkingStatusId = model.EmployeeWorkingStatusId;
                md.BasicSalary = model.BasicSalary;
                md.IsActive = model.IsActive;
                md.CreateBy = 1; // TODO
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.EmployeeRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();

                EmployeeInfoModel info = new EmployeeInfoModel()
                {
                    EmployeeId = md.Id,
                    FirstName = model.FirstName.Trim(),
                    LastName = model.LastName.Trim(),
                    Gender = model.Gender,
                    Action = Core.CommonModel.Enums.FormActionStatus.Insert
                };

                response = await _employeeInfoService.Insert(info);

                if (response.ResponseStatus != Core.CommonModel.Enums.ResponseStatus.Success)
                {
                    await _context.RollbackTransactionAsync();
                    return response;
                }

                await _context.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);

                await _context.RollbackTransactionAsync();
            }
            return response;
        }

        public async Task<ResponseModel> Update(EmployeeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Employee md = await _context.EmployeeRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.ProbationDate = model.ProbationDate;
                md.StartWorkingDate = model.StartWorkingDate;
                md.BadgeCardNumber = model.BadgeCardNumber;
                md.DateApplyBadge = model.DateApplyBadge;
                md.FingerSignNumber = model.FingerSignNumber;
                md.DateApplyFingerSign = model.DateApplyFingerSign;
                md.WorkingEmail = model.WorkingEmail;
                md.WorkingPhone = model.WorkingPhone;
                md.EmployeeWorkingStatusId = model.EmployeeWorkingStatusId;
                md.BasicSalary = model.BasicSalary;
                md.IsActive = model.IsActive;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.EmployeeRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Employee md = await _context.EmployeeRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Deleted = true;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.EmployeeRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }
    }
}
