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
                            join t in _context.EducationRepository.Query() on m.EducationTypeId equals t.Id
                            join rk in _context.RankingRepository.Query() on m.RankingId equals rk.Id
                            join md in _context.ModelOfStudyRepository.Query() on m.ModelOfStudyId equals md.Id
                            where !m.Deleted && m.EmployeeId == filter.EmployeeId
                            orderby m.CreateDate
                            select new EmployeeEducationModel()
                            {
                                Id = m.Id,
                                EducationTypeId = m.EducationTypeId,
                                EducationTypeName = t.Name,
                                School = m.School,
                                MajorId = m.MajorId,
                                MajorName = string.Empty,
                                Year = m.Year,
                                RankingId = m.RankingId,
                                RankingName = rk.Name,
                                ModelOfStudyId = m.ModelOfStudyId,
                                ModelOfStudyName = md.Name,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.School.ToLower().Contains(filter.Text)
                                            || m.EducationTypeName.ToLower().Contains(filter.Text)
                                            || m.MajorName.ToLower().Contains(filter.Text)
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
                                EducationTypeId = m.EducationTypeId,
                                School = m.School,
                                MajorId = m.MajorId,
                                Year = m.Year,
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
                md.EducationTypeId = model.EducationTypeId;
                md.School = model.School;
                md.MajorId = model.MajorId;
                md.Year = model.Year;
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
                md.EducationTypeId = model.EducationTypeId;
                md.School = model.School;
                md.MajorId = model.MajorId;
                md.Year = model.Year;
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
