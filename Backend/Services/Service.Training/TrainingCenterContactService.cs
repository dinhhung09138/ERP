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
    public class TrainingCenterContactService : BaseService, ITrainingCenterContactService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<TrainingCenterContactService> _logger;

        public TrainingCenterContactService(
            IERPUnitOfWork context, 
            ILogger<TrainingCenterContactService> logger,
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
                var query = from m in _context.TrainingCenterContactRepository.Query()
                            where !m.Deleted
                            orderby m.CreateDate descending
                            select new TrainingCenterContactModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Position = m.Position,
                                Phone = m.Phone,
                                Fax = m.Fax,
                                Email = m.Email,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text)
                                            || m.Position.ToLower().Contains(filter.Text)
                                            || m.Phone.ToLower().Contains(filter.Text)
                                            || m.Fax.ToLower().Contains(filter.Text)
                                            || m.Email.ToLower().Contains(filter.Text));
                }

                BaseListModel<TrainingCenterContactModel> listItems = new BaseListModel<TrainingCenterContactModel>();
                listItems.TotalItems = await _context.TrainingCenterContactRepository.Query().Where(m => !m.Deleted).CountAsync();
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
                TrainingCenterContact md = await _context.TrainingCenterContactRepository.FirstOrDefaultAsync(m => m.Id == id);

                TrainingCenterContactModel model = new TrainingCenterContactModel()
                {
                    Id = md.Id,
                    Name = md.Name,
                    Position = md.Position,
                    Phone = md.Phone,
                    Fax = md.Fax,
                    Email = md.Email,
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

        public async Task<ResponseModel> Insert(TrainingCenterContactModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                TrainingCenterContact md = new TrainingCenterContact();

                md.Name = model.Name;
                md.Position = model.Position;
                md.Phone = model.Phone;
                md.Fax = model.Fax;
                md.Email = model.Email;
                md.TrainingCenterId = model.TrainingCenterId;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;
                md.CreateDate = DateTime.Now;

                await _context.TrainingCenterContactRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(TrainingCenterContactModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                TrainingCenterContact md = await _context.TrainingCenterContactRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Name = model.Name;
                md.Position = model.Position;
                md.Phone = model.Phone;
                md.Fax = model.Fax;
                md.Email = model.Email;
                md.TrainingCenterId = model.TrainingCenterId;
                md.IsActive = model.IsActive;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.TrainingCenterContactRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(TrainingCenterContactModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                TrainingCenterContact md = await _context.TrainingCenterContactRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.TrainingCenterContactRepository.Update(md);

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
