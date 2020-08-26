using Core.CommonMessage;
using Core.CommonModel;
using Core.CommonModel.Exceptions;
using Core.Services;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.System.Interfaces;
using Services.System.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.System
{
    public class RoleService : BaseService, IRoleService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<RoleService> _logger;

        public RoleService(
            IERPUnitOfWork context,
            ILogger<RoleService> logger,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            _logger = logger;
            base._httpContext = httpContext;
        }
        public async Task<ResponseModel> Delete(RoleModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Role md = await _context.RoleRepository.FirstOrDefaultAsync(m => m.Id == model.Id);       
                
                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    response.Errors.Add(ParameterMsg.OutOfDateData);
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.RoleRepository.Update(md);

                await _context.SaveChangesAsync();
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
                var query = from m in _context.RoleRepository.Query()
                            where !m.Deleted && m.IsActive
                            select new RoleModel()
                            {
                                Id = m.Id,
                                Name = m.Name
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

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.RoleRepository.Query()
                            where !m.Deleted
                            orderby m.Name
                            select new RoleModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Description = m.Description,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion
                            };
                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.Name.ToLower().Contains(filter.Text.ToLower())
                                || m.Description.ToLower().Contains(filter.Text.ToLower()));
                }
                BaseListModel<RoleModel> listItems = new BaseListModel<RoleModel>();
                listItems.TotalItems = await _context.ReligionRepository.Query().Where(m => !m.Deleted).CountAsync();
                listItems.Items = await query.Skip(filter.Paging.PageIndex * filter.Paging.PageSize)
                                             .Take(filter.Paging.PageSize).ToListAsync()
                                             .ConfigureAwait(false);

                response.Result = listItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(RoleModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Role md = new Role();

                md.Name = model.Name;
                md.Description = model.Description;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;

                await _context.RoleRepository.AddAsync(md).ConfigureAwait(true);

                await _context.SaveChangesAsync();
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
                Role md = await _context.RoleRepository.FirstOrDefaultAsync(m => m.Id == id);
                RoleModel model = new RoleModel()
                {
                    Id = md.Id,
                    Name = md.Name,
                    Description = md.Description,
                    IsActive = md.IsActive,
                    RowVersion = md.RowVersion
                };
                response.Result = model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(RoleModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Role md = await _context.RoleRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Name = model.Name;
                md.Description = model.Description;
                md.IsActive = model.IsActive;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = base.UserId;

                _context.RoleRepository.Update(md);

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
