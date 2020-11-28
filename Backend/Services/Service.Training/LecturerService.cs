using Core.CommonModel;
using Core.Services;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Training;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Training.Interfaces;
using Service.Training.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Training
{
    public class LecturerService : BaseService, ILecturerService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<LecturerService> _logger;
        
        public LecturerService(
            IERPUnitOfWork context,
            ILogger<LecturerService> logger,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            _logger = logger;
            base._httpContext = httpContext;
        }

        public async Task<ResponseModel> List(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.LecturerRepository.Query()
                            where !m.Deleted
                            orderby m.Name ascending
                            select new LecturerModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Avatar = m.Avatar,
                                Gender = m.Gender,
                                DateOfBirth = m.DateOfBirth,
                                Phone = m.Phone,
                                Mobile = m.Mobile,
                                Fax = m.Fax,
                                Email = m.Email,
                                Rating = m.Rating,
                                IsWorkInCenter = m.IsWorkInCenter,
                                TrainingCenterId = m.TrainingCenterId,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text)
                                            || m.Phone.ToLower().Contains(filter.Text)
                                            || m.Mobile.ToString().ToLower().Contains(filter.Text)
                                            || m.Email.ToString().ToLower().Contains(filter.Text));
                }

                BaseListModel<LecturerModel> listItems = new BaseListModel<LecturerModel>();
                listItems.TotalItems = await _context.LecturerRepository.Query().Where(m => !m.Deleted).CountAsync();
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
                var query = from m in _context.LecturerRepository.Query()
                            where !m.Deleted
                            orderby m.Name ascending
                            select new LecturerModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                            };


                response.Result = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.GetDropDownError;
                _logger.LogError(ex.Message, ex);
            }
            return response;
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Lecturer md = await _context.LecturerRepository.FirstOrDefaultAsync(m => m.Id == id);

                LecturerModel model = new LecturerModel()
                {
                    Id = md.Id,
                    Name = md.Name,
                    Avatar = md.Avatar,
                    Gender = md.Gender,
                    DateOfBirth = md.DateOfBirth,
                    Phone = md.Phone,
                    Mobile = md.Mobile,
                    Fax = md.Fax,
                    Email = md.Email,
                    Rating = md.Rating,
                    IsWorkInCenter = md.IsWorkInCenter,
                    TrainingCenterId = md.TrainingCenterId,
                    IsActive = md.IsActive,
                    RowVersion = md.RowVersion,
                };

                response.Result = model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(LecturerModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Lecturer md = new Lecturer();

                md.Name = model.Name;
                md.Avatar = model.Avatar;
                md.Gender = model.Gender;
                md.DateOfBirth = model.DateOfBirth;
                md.Phone = model.Phone;
                md.Mobile = model.Mobile;
                md.Fax = model.Fax;
                md.Email = model.Email;
                md.Rating = model.Rating;
                md.IsWorkInCenter = model.IsWorkInCenter;
                md.TrainingCenterId = model.TrainingCenterId;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;

                await _context.LecturerRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(LecturerModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Lecturer md = await _context.LecturerRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Name = model.Name;
                md.Avatar = model.Avatar;
                md.Gender = model.Gender;
                md.DateOfBirth = model.DateOfBirth;
                md.Phone = model.Phone;
                md.Mobile = model.Mobile;
                md.Fax = model.Fax;
                md.Email = model.Email;
                md.Rating = model.Rating;
                md.IsWorkInCenter = model.IsWorkInCenter;
                md.TrainingCenterId = model.TrainingCenterId;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.LecturerRepository.Update(md);

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
                Lecturer md = await _context.LecturerRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.LecturerRepository.Update(md);

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
