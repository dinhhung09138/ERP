using Core.DataAccess;
using Database.Sql.ERP.Entities.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Sql.ERP.Entities
{
    public interface ISecurityUnitOfWork
    {
        ITableGenericRepository<Function> FunctionRepository { get; }
        ITableGenericRepository<FunctionCommand> FunctionCommandRepository { get; }
        ITableGenericRepository<Module> ModuleRepository { get; }
        ITableGenericRepository<Role> RoleRepository { get; }
        ITableGenericRepository<RoleDetail> RoleDetailRepository { get; }
        ITableGenericRepository<SessionLog> SessionLogRepository { get; }
        ITableGenericRepository<SystemLog> SystemLogRepository { get; }
        ITableGenericRepository<User> UserRepository { get; }
        ITableGenericRepository<UserRole> UserRoleRepository { get; }

    }
}
