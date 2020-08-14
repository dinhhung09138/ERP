using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Training.Interfaces;
using Service.Training.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Training
{
    public class TrainingCourseService : ITrainingCourseService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<TrainingCourseService> _logger;

        private readonly string ErrorDropdown = "Không thể lấy danh sách khóa đào tạo";
        public TrainingCourseService(IERPUnitOfWork context, ILogger<TrainingCourseService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.TrainingCourseRepository.Query()
                            where !m.Deleted
                            orderby m.StartDate descending
                            select new TrainingCourseModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Description = m.Description,
                                StartDate = m.StartDate,
                                CompleteDate = m.CompleteDate,
                                IsActive = m.IsActive
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text)
                                            || m.Description.ToLower().Contains(filter.Text)
                                            || m.StartDate.ToString().ToLower().Contains(filter.Text)
                                            || m.CompleteDate.ToString().ToLower().Contains(filter.Text));
                }

                BaseListModel<TrainingCourseModel> listItems = new BaseListModel<TrainingCourseModel>();
                listItems.TotalItems = await _context.TrainingCourseRepository.Query().Where(m => !m.Deleted).CountAsync();
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
                var query = from m in _context.TrainingCourseRepository.Query()
                            where !m.Deleted
                            orderby m.StartDate descending
                            select new TrainingCourseModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
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
                TrainingCourse md = await _context.TrainingCourseRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                TrainingCourseModel model = new TrainingCourseModel()
                {
                    Id = md.Id,
                    Name = md.Name,
                    Description = md.Description,
                    StartDate = md.StartDate,
                    CompleteDate = md.CompleteDate,
                    LecturerId = md.LecturerId,
                    IsActive = md.IsActive,
                };

                response.Result = model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(TrainingCourseModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                TrainingCourse md = new TrainingCourse();

                md.Name = model.Name;
                md.Description = model.Description;
                md.StartDate = model.StartDate;
                md.CompleteDate = model.CompleteDate;
                md.LecturerId = model.LecturerId;
                md.IsActive = model.IsActive;
                md.CreateBy = 1; // TODO
                md.CreateDate = DateTime.Now;

                await _context.TrainingCourseRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(TrainingCourseModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                TrainingCourse md = await _context.TrainingCourseRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Name = model.Name;
                md.Description = model.Description;
                md.StartDate = model.StartDate;
                md.CompleteDate = model.CompleteDate;
                md.LecturerId = model.LecturerId;
                md.IsActive = model.IsActive;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.TrainingCourseRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                TrainingCourse md = await _context.TrainingCourseRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Deleted = true;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.TrainingCourseRepository.Update(md);

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
