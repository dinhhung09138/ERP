using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.DataAccess.Sql;
using Database.Sql.Gym.Enitties;
using Microsoft.EntityFrameworkCore.Storage;

namespace Database.Sql.Gym
{
    public class GymUnitOfWork : IGymUnitOfWork, IDisposable
    {
        private readonly GymContext _context;

        private IDbContextTransaction _transaction;

        private ITableGenericRepository<Muscle> _muscleRepository;

        public ITableGenericRepository<Muscle> MuscleRepository
        {
            get
            {
                return _muscleRepository = _muscleRepository ?? new TableGenericRepository<Muscle>(_context);
            }
        }

        private ITableGenericRepository<Exercise> _exerciseRepository;

        public ITableGenericRepository<Exercise> ExerciseRepository
        {
            get
            {
                return _exerciseRepository = _exerciseRepository ?? new TableGenericRepository<Exercise>(_context);
            }
        }

        private ITableGenericRepository<ExerciseLevel> _exerciseLevelRepository;

        public ITableGenericRepository<ExerciseLevel> ExerciseLevelRepository
        {
            get
            {
                return _exerciseLevelRepository = _exerciseLevelRepository ?? new TableGenericRepository<ExerciseLevel>(_context);
            }
        }

        private ITableGenericRepository<ExerciseResource> _exerciseResourceRepository;

        public ITableGenericRepository<ExerciseResource> ExerciseResourceRepository
        {
            get
            {
                return _exerciseResourceRepository = _exerciseResourceRepository ?? new TableGenericRepository<ExerciseResource>(_context);
            }
        }

        public GymUnitOfWork(GymContext context)
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
