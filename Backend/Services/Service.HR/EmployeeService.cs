using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Database.Sql.HR;
using DataBase.Sql.HR.Entities;
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
        private readonly IHRUnitOfWork _context;
        public EmployeeService(IHRUnitOfWork context)
        {
            _context = context;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.EmployeeRepository.Query()
                                // TODO Working status
                            where !m.Deleted
                            orderby m.CreateDate
                            select new EmployeeModel()
                            {
                                Id = m.Id,
                                EmployeeCode = m.EmployeeCode,
                                FirstName = m.FirstName,
                                LastName = m.LastName,
                                ProbationDate = m.ProbationDate,
                                StartWorkingDate = m.StartWorkingDate,
                                BadgeCardNumber = m.BadgeCardNumber,
                                FingerSignNumber = m.FingerSignNumber,
                                WorkingEmail = m.WorkingEmail,
                                WorkingPhone = m.WorkingPhone,
                                EmployeeWorkingStatusId = m.EmployeeWorkingStatusId,
                                IsActive = m.IsActive
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.EmployeeCode.ToLower().Contains(filter.Text)
                                            || m.FirstName.Contains(filter.Text)
                                            || m.LastName.Contains(filter.Text)
                                            || m.WorkingEmail.Contains(filter.Text)
                                            || m.WorkingPhone.Contains(filter.Text));
                }
                BaseListModel<EmployeeModel> listItems = new BaseListModel<EmployeeModel>();
                listItems.TotalItems = await _context.EmployeeRepository.Query().CountAsync();
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
                            where m.IsActive && !m.Deleted
                            orderby m.CreateDate ascending
                            select new EmployeeModel
                            {
                                Id = m.Id,
                                EmployeeCode = m.EmployeeCode,
                                FirstName = m.FirstName,
                                LastName = m.LastName,
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
                Employee md = await _context.EmployeeRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                EmployeeModel model = new EmployeeModel()
                {
                    Id = md.Id,
                    EmployeeCode = md.EmployeeCode,
                    FirstName = md.FirstName,
                    LastName = md.LastName,
                    ProbationDate = md.ProbationDate,
                    StartWorkingDate = md.StartWorkingDate,
                    BadgeCardNumber = md.BadgeCardNumber,
                    DateApplyBadge = md.DateApplyBadge,
                    FingerSignNumber = md.FingerSignNumber,
                    DateApplyFingerSign = md.DateApplyFingerSign,
                    WorkingEmail = md.WorkingEmail,
                    WorkingPhone = md.WorkingPhone,
                    EmployeeWorkingStatusId = md.EmployeeWorkingStatusId,
                    BasicSalary = md.BasicSalary,
                    IsActive = md.IsActive,
                };

                response.Result = model;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Save(EmployeeModel model)
        {
            ResponseModel response = new ResponseModel();
            switch (model.Action)
            {
                case Core.CommonModel.Enums.FormActionStatus.Insert:
                    response = await Insert(model);
                    break;
                case Core.CommonModel.Enums.FormActionStatus.Update:
                    response = await Update(model);
                    break;
                case Core.CommonModel.Enums.FormActionStatus.Delete:
                    response = await Delete(model);
                    break;
            }
            return response;
        }

        private async Task<ResponseModel> Insert(EmployeeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Employee md = new Employee();

                md.EmployeeCode = model.EmployeeCode;
                md.FirstName = model.FirstName;
                md.LastName = model.LastName;
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
                md.CreateBy = 1; // TODO
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.EmployeeRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        private async Task<ResponseModel> Update(EmployeeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Employee md = await _context.EmployeeRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.FirstName = model.FirstName;
                md.LastName = model.LastName;
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

        private async Task<ResponseModel> Delete(EmployeeModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Employee md = await _context.EmployeeRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

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
