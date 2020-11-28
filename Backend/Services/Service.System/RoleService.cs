using Core.CommonModel;
using Core.Services;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.System.Interfaces;
using Service.System.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.System
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

        public async Task<ResponseModel> List(FilterModel filter)
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
                listItems.TotalItems = await _context.RoleRepository.Query().Where(m => !m.Deleted).CountAsync();
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

        public async Task<ResponseModel> DropDownData()
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

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                RoleModel model = await _context.RoleRepository.Query()
                                        .Include(m => m.Details)
                                        .Select(m => new RoleModel
                                        {
                                            Id = m.Id,
                                            Name = m.Name,
                                            Description = m.Description,
                                            IsActive = m.IsActive,
                                            RowVersion = m.RowVersion,
                                            Roles = m.Details.Select(r => new RoleDetailModel()
                                            {
                                                Id = r.Id,
                                                RoleId = r.RoleId,
                                                CommandId = r.CommandId
                                            }).ToList()
                                        }).FirstOrDefaultAsync(m => m.Id == id);


                response.Result = model;
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
                await _context.BeginTransactionAsync();

                Role md = new Role();

                md.Name = model.Name;
                md.Description = model.Description;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;

                await _context.RoleRepository.AddAsync(md).ConfigureAwait(true);
                await _context.SaveChangesAsync();

                if (model.Roles != null)
                {
                    foreach (var role in model.Roles)
                    {
                        RoleDetail dt = new RoleDetail()
                        {
                            RoleId = md.Id,
                            CommandId = role.CommandId
                        };

                        await _context.RoleDetailRepository.AddAsync(dt).ConfigureAwait(false);
                    }
                }


                await _context.SaveChangesAsync();
                await _context.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _context.RollbackTransactionAsync();
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(RoleModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                await _context.BeginTransactionAsync();

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

                var deleteRoles = await _context.RoleDetailRepository.Query().Where(m => m.RoleId == model.Id).ToArrayAsync();
                _context.RoleDetailRepository.DeleteRange(deleteRoles);

                if (model.Roles != null)
                {
                    foreach (var role in model.Roles)
                    {
                        RoleDetail dt = new RoleDetail()
                        {
                            RoleId = md.Id,
                            CommandId = role.CommandId
                        };

                        await _context.RoleDetailRepository.AddAsync(dt).ConfigureAwait(false);
                    }
                }

                _context.RoleRepository.Update(md);

                await _context.SaveChangesAsync();
                await _context.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _context.RollbackTransactionAsync();
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Delete(DeleteModel model)
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

    }
}
