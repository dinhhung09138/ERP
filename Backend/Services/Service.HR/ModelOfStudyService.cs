using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.HR.Interfaces;
using Service.HR.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.HR
{
    public class ModelOfStudyService : IModelOfStudyService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<ModelOfStudyService> _logger;

        private readonly string ErrorDropdown = "Không thể lấy danh sách hình thức đào tạo";

        public ModelOfStudyService(IERPUnitOfWork context, ILogger<ModelOfStudyService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.ModelOfStudyRepository.Query()
                            where !m.Deleted
                            orderby m.Precedence ascending
                            select new ModelOfStudyModel
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Precedence = m.Precedence,
                                IsActive = m.IsActive,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text));
                }

                BaseListModel<ModelOfStudyModel> listItems = new BaseListModel<ModelOfStudyModel>();
                listItems.TotalItems = await _context.ModelOfStudyRepository.Query().Where(m => !m.Deleted).CountAsync();
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
                var query = from m in _context.ModelOfStudyRepository.Query()
                            where m.IsActive && !m.Deleted
                            orderby m.Precedence ascending
                            select new ModelOfStudyModel
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
                var query = from m in _context.ModelOfStudyRepository.Query()
                            where m.Id == id
                            select new ModelOfStudyModel
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

        public async Task<ResponseModel> Insert(ModelOfStudyModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                ModelOfStudy md = new ModelOfStudy();

                md.Name = model.Name;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.CreateBy = 1; // TODO
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.ModelOfStudyRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(ModelOfStudyModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                ModelOfStudy md = await _context.ModelOfStudyRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Name = model.Name;
                md.Precedence = model.Precedence;
                md.IsActive = model.IsActive;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.ModelOfStudyRepository.Update(md);

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
                ModelOfStudy md = await _context.ModelOfStudyRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                md.Deleted = true;
                md.UpdateBy = 1; // TODO
                md.UpdateDate = DateTime.Now;

                _context.ModelOfStudyRepository.Update(md);

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
