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
    class EmployeeEducationService : BaseService, IEmployeeEducationService
    {
        private readonly IERPUnitOfWork _context;

        public EmployeeEducationService(
            IERPUnitOfWork context,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            base._httpContext = httpContext;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.EmployeeEducationRepository.Query()
                            join sp in _context.SpecializedTrainingRepository.Query() on m.SpecializedTrainingId equals sp.Id
                            join rk in _context.RankingRepository.Query() on m.RankingId equals rk.Id
                            join md in _context.ModelOfStudyRepository.Query() on m.ModelOfStudyId equals md.Id
                            where !m.Deleted && m.EmployeeId == filter.EmployeeId
                            orderby m.CreateDate
                            select new EmployeeEducationModel()
                            {
                                Id = m.Id,
                                SchoolId = m.SchoolId,
                                SchoolName = string.Empty,
                                SpecializedTrainingId = m.SpecializedTrainingId,
                                SpecializedTrainingName = sp.Name,
                                Year = m.Year,
                                TrainingTypeId = m.TrainingTypeId,
                                TrainingTypeName = string.Empty,
                                RankingId = m.RankingId,
                                RankingName = rk.Name,
                                ModelOfStudyId = m.ModelOfStudyId,
                                ModelOfStudyName = md.Name,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.SchoolName.ToLower().Contains(filter.Text)
                                            || m.SpecializedTrainingName.ToLower().Contains(filter.Text)
                                            || m.TrainingTypeName.ToLower().Contains(filter.Text)
                                            || m.ModelOfStudyName.ToLower().Contains(filter.Text)
                                            || m.RankingName.ToLower().Contains(filter.Text));
                }

                BaseListModel<EmployeeEducationModel> listItems = new BaseListModel<EmployeeEducationModel>();
                listItems.TotalItems = await _context.EmployeeEducationRepository.Query().Where(m => !m.Deleted && m.EmployeeId == filter.EmployeeId).CountAsync();
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
                var query = from m in _context.EmployeeEducationRepository.Query()
                            where m.Id == id
                            select new EmployeeEducationModel
                            {
                                Id = m.Id,
                                EmployeeId = m.EmployeeId,
                                SchoolId = m.SchoolId,
                                SpecializedTrainingId = m.SpecializedTrainingId,
                                Year = m.Year,
                                TrainingTypeId = m.TrainingTypeId,
                                RankingId = m.RankingId,
                                ModelOfStudyId = m.ModelOfStudyId,
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

        public async Task<ResponseModel> Insert(EmployeeEducationModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeEducation md = new EmployeeEducation();

                md.EmployeeId = model.EmployeeId;
                md.SchoolId = model.SchoolId;
                md.SpecializedTrainingId = model.SpecializedTrainingId;
                md.Year = model.Year;
                md.TrainingTypeId = model.TrainingTypeId;
                md.RankingId = model.RankingId;
                md.ModelOfStudyId = model.ModelOfStudyId;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.EmployeeEducationRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Error;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ResponseModel> Update(EmployeeEducationModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeEducation md = await _context.EmployeeEducationRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.EmployeeId = model.EmployeeId;
                md.SchoolId = model.SchoolId;
                md.SpecializedTrainingId = model.SpecializedTrainingId;
                md.Year = model.Year;
                md.TrainingTypeId = model.TrainingTypeId;
                md.RankingId = model.RankingId;
                md.ModelOfStudyId = model.ModelOfStudyId;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeEducationRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(EmployeeEducationModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                EmployeeEducation md = await _context.EmployeeEducationRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.EmployeeEducationRepository.Update(md);

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
