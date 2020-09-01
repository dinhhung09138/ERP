using Core.CommonModel;
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
    public class DisciplineService : BaseService, IDisciplineService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<DisciplineService> _logger;

        public DisciplineService(
            IERPUnitOfWork context,
            ILogger<DisciplineService> logger,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            _logger = logger;
            base._httpContext = httpContext;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.DisciplineRepository.Query()
                            where !m.Deleted
                            orderby m.CreateDate
                            select new DisciplineModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Description = m.Description,
                                Money = m.Money,
                                IsActive = m.IsActive,
                                CreateBy = m.CreateBy.ToString(),
                                CreateDate = m.CreateDate,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text) || m.Description.Contains(filter.Text));
                }
                BaseListModel<DisciplineModel> listItems = new BaseListModel<DisciplineModel>();
                listItems.TotalItems = await _context.DisciplineRepository.Query().Where(m => !m.Deleted).CountAsync();
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
                var query = from m in _context.DisciplineRepository.Query()
                            where m.IsActive && !m.Deleted
                            orderby m.CreateDate ascending
                            select new DisciplineModel
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Money = m.Money,
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
                Discipline md = await _context.DisciplineRepository.FirstOrDefaultAsync(m => m.Id == id);

                DisciplineModel model = new DisciplineModel()
                {
                    Id = md.Id,
                    Name = md.Name,
                    Description = md.Description,
                    Money = md.Money,
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

        public async Task<ResponseModel> Insert(DisciplineModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Discipline md = new Discipline();

                md.Name = model.Name;
                md.Description = model.Description;
                md.Money = model.Money;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;

                await _context.DisciplineRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(DisciplineModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Discipline md = await _context.DisciplineRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Name = model.Name;
                md.Description = model.Description;
                md.Money = model.Money;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.DisciplineRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(DisciplineModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Discipline md = await _context.DisciplineRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.DisciplineRepository.Update(md);

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
