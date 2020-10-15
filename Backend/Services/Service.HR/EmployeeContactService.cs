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
    public class EmployeeContactService : BaseService, IEmployeeContactService
    {
        private readonly IERPUnitOfWork _context;

        public EmployeeContactService(
            IERPUnitOfWork context,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            base._httpContext = httpContext;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            await Task.Delay(0);
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.EmployeeContactRepository.Query()
                            where m.Id == id
                            select new EmployeeContactModel
                            {
                                Id = m.Id,
                                EmployeeId = m.EmployeeId,
                                Phone = m.Phone,
                                Mobile = m.Mobile,
                                Email = m.Email,
                                Skyper = m.Skyper,
                                Zalo = m.Zalo,
                                Facebook = m.Facebook,
                                LinkedIn = m.LinkedIn,
                                Twitter = m.Twitter,
                                Github = m.Github,
                                TemporaryAddress = m.TemporaryAddress,
                                TemporaryWardId = m.TemporaryWardId,
                                TemporaryDistrictId = m.TemporaryDistrictId,
                                TemporaryProvinceId = m.TemporaryProvinceId,
                                PermanentAddress = m.PermanentAddress,
                                PermanentWardId = m.PermanentWardId,
                                PermanentDistrictId = m.PermanentDistrictId,
                                PermanentProvinceId = m.PermanentProvinceId,
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

        public async Task<ResponseModel> ItemByEmployeeId(int employeeId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.EmployeeContactRepository.Query()
                            where m.EmployeeId == employeeId
                            select new EmployeeContactModel
                            {
                                Id = m.Id,
                                EmployeeId = m.EmployeeId,
                                Phone = m.Phone,
                                Mobile = m.Mobile,
                                Email = m.Email,
                                Skyper = m.Skyper,
                                Zalo = m.Zalo,
                                Facebook = m.Facebook,
                                LinkedIn = m.LinkedIn,
                                Twitter = m.Twitter,
                                Github = m.Github,
                                TemporaryAddress = m.TemporaryAddress,
                                TemporaryWardId = m.TemporaryWardId,
                                TemporaryDistrictId = m.TemporaryDistrictId,
                                TemporaryProvinceId = m.TemporaryProvinceId,
                                PermanentAddress = m.PermanentAddress,
                                PermanentWardId = m.PermanentWardId,
                                PermanentDistrictId = m.PermanentDistrictId,
                                PermanentProvinceId = m.PermanentProvinceId,
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

        public async Task<ResponseModel> Insert(EmployeeContactModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeContact md = new EmployeeContact();

                md.EmployeeId = model.EmployeeId;
                md.Phone = model.Phone;
                md.Mobile = model.Mobile;
                md.Email = model.Email;
                md.Skyper = model.Skyper;
                md.Zalo = model.Zalo;
                md.Facebook = model.Facebook;
                md.LinkedIn = model.LinkedIn;
                md.Twitter = model.Twitter;
                md.Github = model.Github;
                md.TemporaryAddress = model.TemporaryAddress;
                md.TemporaryWardId = model.TemporaryWardId;
                md.TemporaryDistrictId = model.TemporaryDistrictId;
                md.TemporaryProvinceId = model.TemporaryProvinceId;
                md.PermanentAddress = model.PermanentAddress;
                md.PermanentWardId = model.PermanentWardId;
                md.PermanentDistrictId = model.PermanentDistrictId;
                md.PermanentProvinceId = model.PermanentProvinceId;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.EmployeeContactRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Update(EmployeeContactModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeContact md = await _context.EmployeeContactRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.EmployeeId = model.EmployeeId;
                md.Phone = model.Phone;
                md.Mobile = model.Mobile;
                md.Email = model.Email;
                md.Skyper = model.Skyper;
                md.Zalo = model.Zalo;
                md.Facebook = model.Facebook;
                md.LinkedIn = model.LinkedIn;
                md.Twitter = model.Twitter;
                md.Github = model.Github;
                md.TemporaryAddress = model.TemporaryAddress;
                md.TemporaryWardId = model.TemporaryWardId;
                md.TemporaryDistrictId = model.TemporaryDistrictId;
                md.TemporaryProvinceId = model.TemporaryProvinceId;
                md.PermanentAddress = model.PermanentAddress;
                md.PermanentWardId = model.PermanentWardId;
                md.PermanentDistrictId = model.PermanentDistrictId;
                md.PermanentProvinceId = model.PermanentProvinceId;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeContactRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(EmployeeContactModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeContact md = await _context.EmployeeContactRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeContactRepository.Update(md);

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
