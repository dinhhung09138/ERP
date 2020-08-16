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
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IERPUnitOfWork _context;
        private readonly IEmployeeInfoService _employeeInfoService;
        private readonly ILogger<EmployeeService> _logger;

        private readonly string ErrorDropdown = "Không thể lấy danh sách nhân viên";
        private readonly string CodeExist = "Mã nhân viên đã tồn tại";

        public EmployeeService(
            IERPUnitOfWork context,
            IEmployeeInfoService employeeInfoService,
            ILogger<EmployeeService> logger,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            _employeeInfoService = employeeInfoService;
            _logger = logger;
            base._httpContext = httpContext;
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
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
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
                throw ex;
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
                var md = from m in _context.EmployeeRepository.Query()
                                      join info in _context.EmployeeInfoRepository.Query() on m.Id equals info.EmployeeId
                                      join status in _context.EmployeeWorkingStatusRepository.Query() on m.EmployeeWorkingStatusId equals status.Id
                                      where m.IsActive && !m.Deleted && m.Id == id
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
                                          RowVersion = m.RowVersion,
                                      };

                if (md == null)
                {
                    throw new NullParameterException();
                }

                response.Result = await md.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(EmployeeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                if (await _context.EmployeeRepository.CountAsync(m => m.EmployeeCode == model.EmployeeCode) > 0)
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Warning;
                    response.Errors.Add(CodeExist);
                    return response;
                }

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
                md.CreateBy = base.UserId;
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

                response = await Item(md.Id);
            }
            catch (Exception ex)
            {
                await _context.RollbackTransactionAsync();
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(EmployeeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                await _context.BeginTransactionAsync().ConfigureAwait(true);

                Employee md = await _context.EmployeeRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

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
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeRepository.Update(md);

                await _context.SaveChangesAsync();

                response = await _employeeInfoService.UpdateName(model.Id, model.FirstName, model.LastName);

                if (response.ResponseStatus != Core.CommonModel.Enums.ResponseStatus.Success)
                {
                    await _context.RollbackTransactionAsync();
                    return response;
                }

                response = await Item(model.Id);

                await _context.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _context.RollbackTransactionAsync();
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(EmployeeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Employee md = await _context.EmployeeRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

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

                _context.EmployeeRepository.Update(md);

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
