using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Core.Services.Interfaces;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.HR
{
    public class ProfessionalQualificationService : IProfessionalQualificationService
    {

        private readonly IERPUnitOfWork _context;
        private readonly IMemoryCachingService _memoryCachingService;
        private readonly ILogger<ProfessionalQualificationService> _logger;

        private readonly string CacheKey = "qualification_data";
        private readonly string ErrorDropdown = "Không thể lấy danh sách trình độ chuyên môn";

        public ProfessionalQualificationService(IERPUnitOfWork context, IMemoryCachingService memoryCachingService, ILogger<ProfessionalQualificationService> logger)
        {
            _context = context;
            _logger = logger;
            _memoryCachingService = memoryCachingService;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.ProfessionalQualificationRepository.Query()
                            where !m.Deleted
                            orderby m.Precedence ascending
                            select new ProfessionalQualificationModel
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive,
                                CreateBy = m.CreateBy.ToString(),
                                CreateDate = m.CreateDate
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text));
                }

                BaseListModel<ProfessionalQualificationModel> listItems = new BaseListModel<ProfessionalQualificationModel>();
                listItems.TotalItems = await _context.ProfessionalQualificationRepository.Query().Where(m => !m.Deleted).CountAsync();
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
                var cacheData = _memoryCachingService.GetList<ProfessionalQualificationModel>(CacheKey);

                if (cacheData != null)
                {
                    response.Result = cacheData;
                }
                else
                {
                    var query = from m in _context.ProfessionalQualificationRepository.Query()
                                where m.IsActive && !m.Deleted
                                orderby m.Precedence ascending
                                select new ProfessionalQualificationModel
                                {
                                    Id = m.Id,
                                    Name = m.Name,
                                };

                    var list = await query.ToListAsync();
                    response.Result = list;

                    _memoryCachingService.Set<ProfessionalQualificationModel>(list, CacheKey, 60, 0, 0);
                }
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
                var query = from m in _context.ProfessionalQualificationRepository.Query()
                            where m.Id == id
                            select new ProfessionalQualificationModel
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive
                            };

                response.Result = await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(ProfessionalQualificationModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                ProfessionalQualification md = new ProfessionalQualification();

                md.Name = model.Name;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.CreateBy = 1; // TODO
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.ProfessionalQualificationRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();

                _memoryCachingService.Remove(CacheKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(ProfessionalQualificationModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                ProfessionalQualification md = await _context.ProfessionalQualificationRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Name = model.Name;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.ProfessionalQualificationRepository.Update(md);

                await _context.SaveChangesAsync();

                _memoryCachingService.Remove(CacheKey);
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
                ProfessionalQualification md = await _context.ProfessionalQualificationRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Deleted = true;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.ProfessionalQualificationRepository.Update(md);

                await _context.SaveChangesAsync();

                _memoryCachingService.Remove(CacheKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
