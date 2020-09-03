using Core.CommonModel;
using Core.Services;
using Services.System.Models;
using Database.Sql.ERP;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Services.System.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Database.Sql.ERP.Entities.Security;
using Core.Utility.Security;

namespace Services.System
{
    public class UserService : BaseService, IUserService
    {
        private readonly IERPUnitOfWork _context;
        private readonly ILogger<UserService> _logger;

        public UserService(
            IERPUnitOfWork context,
            ILogger<UserService> logger,
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
                var query = from m in _context.UserRepository.Query()
                            join em in _context.EmployeeRepository.Query() on m.EmployeeId equals em.Id
                            join inf in _context.EmployeeInfoRepository.Query() on m.EmployeeId equals inf.EmployeeId
                            where !m.Deleted
                            orderby m.UserName
                            select new Models.UserModel()
                            {
                                Id = m.Id,
                                EmployeeId = m.EmployeeId,
                                EmployeeName = $"{inf.FirstName} {inf.LastName}",
                                UserName = m.UserName,
                                LastLogin = m.LastLogin,
                                IsActive = m.IsActive,
                                RowVersion = m.RowVersion
                            };
                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(m => m.EmployeeName.ToLower().Contains(filter.Text.ToLower())
                                            || m.UserName.ToLower().Contains(filter.Text.ToLower()));
                }
                BaseListModel<Models.UserModel> listItems = new BaseListModel<Models.UserModel>();
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

        public Task<ResponseModel> DropDownSelection()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Item(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> Insert(Models.UserModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (await _context.UserRepository.AnyAsync(m => m.UserName == model.UserName && m.Deleted == false))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.UserNameExists;
                    return response;
                }

                await _context.BeginTransactionAsync();

                var password = PasswordSecurityHelper.GetHashedPassword(model.Password);

                User md = new User();

                md.UserName = model.UserName;
                md.Password = password;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;
                md.IsActive = model.IsActive;
                md.CreateBy = base.UserId;

                await _context.UserRepository.AddAsync(md).ConfigureAwait(false);

                foreach (var item in model.Roles)
                {
                    UserRole role = new UserRole()
                    {
                        UserId = md.Id,
                        RoleId = item.RoleId
                    };
                    await _context.UserRoleRepository.AddAsync(role);
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

        public Task<ResponseModel> Update(Models.UserModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> ChangeRole(Models.UserModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                await _context.BeginTransactionAsync();

                var listRole = await _context.UserRoleRepository.Query().Where(m => m.UserId == model.Id).ToArrayAsync();

                _context.UserRoleRepository.DeleteRange(listRole);

                foreach (var item in model.Roles)
                {
                    UserRole md = new UserRole()
                    {
                        UserId = model.Id,
                        RoleId = item.RoleId
                    };
                    await _context.UserRoleRepository.AddAsync(md).ConfigureAwait(false);
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

        public async Task<ResponseModel> ActiveOrDeactivation(Models.UserModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                User md = await _context.UserRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.IsActive = model.IsActive;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = base.UserId;

                _context.UserRepository.Update(md);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> AdminChangepassword(Models.UserModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var password = PasswordSecurityHelper.GetHashedPassword(model.Password);

                User md = await _context.UserRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                md.Password = password;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = base.UserId;

                _context.UserRepository.Update(md);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> UserChangepassword(ChangePasswordModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var currentPassword = PasswordSecurityHelper.GetHashedPassword(model.CurrentPassword);

                if (await _context.UserRepository.AnyAsync(m => m.Id == model.UserId && m.Password == currentPassword))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.CurrentPasswordNotMatch;
                    return response;
                }

                User md = await _context.UserRepository.FirstOrDefaultAsync(m => m.Id == model.UserId);

                var newPassword = PasswordSecurityHelper.GetHashedPassword(model.NewPassword);

                md.Password = newPassword;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = base.UserId;

                _context.UserRepository.Update(md);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<bool> Authorization(string moduleName, string controllerName, string actionName)
        {
            if (
                await (from userRole in _context.UserRoleRepository.Query()
                       join roleDetail in _context.RoleDetailRepository.Query() on userRole.RoleId equals roleDetail.RoleId
                       join fCommand in _context.FunctionCommandRepository.Query() on roleDetail.CommandId equals fCommand.Id
                       where userRole.UserId == UserId
                              && fCommand.ModuleName == moduleName
                              && fCommand.ControllerName == controllerName
                              && fCommand.ActionName == actionName
                       select new
                       {
                           fCommand.Id
                       }).AnyAsync()
                )
            {
                return true;
            };
            return false;
        }

        public async Task<ResponseModel> Delete(Models.UserModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                User md = await _context.UserRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (!md.RowVersion.SequenceEqual(model.RowVersion))
                {
                    response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.OutOfDateData;
                    return response;
                }

                md.Deleted = true;
                md.UpdateBy = base.UserId;
                md.UpdateDate = DateTime.Now;

                _context.UserRepository.Update(md);

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
