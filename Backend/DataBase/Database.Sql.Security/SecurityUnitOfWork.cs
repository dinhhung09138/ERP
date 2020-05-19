using Core.DataAccess;
using Core.DataAccess.Sql;
using Database.Sql.Security.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Sql.Security
{
    /// <summary>
    /// Security Unit of Work.
    /// </summary>
    public class SecurityUnitOfWork : ISecurityUnitOfWork, IDisposable
    {
        private readonly SecurityContext _context;

        private IDbContextTransaction _transaction;

        private ITableGenericRepository<User> _userRepository;

        public ITableGenericRepository<User> UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new TableGenericRepository<User>(_context);
            }
        }

        private ITableGenericRepository<SessionLog> _sesionLogRepository;

        public ITableGenericRepository<SessionLog> SessionLogRepository
        {
            get
            {
                return _sesionLogRepository = _sesionLogRepository ?? new TableGenericRepository<SessionLog>(_context);
            }
        }

        public SecurityUnitOfWork(SecurityContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync().ConfigureAwait(true);
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
        }

        public async Task CommitTransactionAsync()
        {
            await (_transaction?.CommitAsync()).ConfigureAwait(true);
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
        }

        public async Task RollbackTransactionAsync()
        {
            await (_transaction?.RollbackAsync()).ConfigureAwait(true);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(true);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                }

                _context.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
