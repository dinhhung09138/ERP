using Core.DataAccess;
using Database.Sql.ERP.Entities.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Sql.ERP.Entities
{
    public interface ISecurityUnitOfWork
    {
        ITableGenericRepository<User> UserRepository { get; }
        ITableGenericRepository<SessionLog> SessionLogRepository { get; }
    }
}
