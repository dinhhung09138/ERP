using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Database.Sql.HR;
using DataBase.Sql.HR.Entities;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Service.HR
{
    public class EmployeeInfoService : IEmployeeInfoService
    {
        private readonly IHRUnitOfWork _context;
        public EmployeeInfoService(IHRUnitOfWork context)
        {
            _context = context;
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
                                IsActive = m.IsActive
                            };

                response.Result = await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Save(EmployeeInfoModel model)
        {
            ResponseModel response = new ResponseModel();

            if (model.Action != Core.CommonModel.Enums.FormActionStatus.Delete)
            {
                var employeeInfo = await _context.EmployeeInfoRepository.FirstOrDefaultAsync(m => m.EmployeeId == model.EmployeeId);

                if (employeeInfo != null)
                {
                    model.Action = Core.CommonModel.Enums.FormActionStatus.Update;
                }
                else
                {
                    model.Action = Core.CommonModel.Enums.FormActionStatus.Insert;
                }
            }
            
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


        private async Task<ResponseModel> Insert(EmployeeInfoModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeInfo md = new EmployeeInfo();

                md.EmployeeId = model.EmployeeId;
                md.FirstName = model.FirstName;
                md.LastName = model.LastName;
                md.Gender = model.Gender;
                md.DateOfBirth = model.DateOfBirth;
                md.MaterialStatusId = model.MaterialStatusId;
                md.ReligionId = model.ReligionId;
                md.NationId = model.NationId;
                md.NationalityId = model.NationalityId;
                md.AcademicLevelId = model.AcademicLevelId;
                md.ProfessionalQualificationId = model.ProfessionalQualificationId;
                md.IsActive = model.IsActive;
                md.CreateBy = 1; // TODO
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

        private async Task<ResponseModel> Update(EmployeeInfoModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeInfo md = await _context.EmployeeInfoRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.EmployeeId = model.EmployeeId;
                md.FirstName = model.FirstName;
                md.LastName = model.LastName;
                md.Gender = model.Gender;
                md.DateOfBirth = model.DateOfBirth;
                md.MaterialStatusId = model.MaterialStatusId;
                md.ReligionId = model.ReligionId;
                md.NationId = model.NationId;
                md.NationalityId = model.NationalityId;
                md.AcademicLevelId = model.AcademicLevelId;
                md.ProfessionalQualificationId = model.ProfessionalQualificationId;
                md.IsActive = model.IsActive;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.EmployeeInfoRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        private async Task<ResponseModel> Delete(EmployeeInfoModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeInfo md = await _context.EmployeeInfoRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Deleted = true;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.EmployeeInfoRepository.Update(md);

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
