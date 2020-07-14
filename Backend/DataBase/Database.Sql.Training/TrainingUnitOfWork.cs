using Core.DataAccess;
using Core.DataAccess.Sql;
using Database.Sql.Training.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Sql.Training
{
    public class TrainingUnitOfWork : ITrainingUnitOfWork, IDisposable
    {
        private readonly TrainingContext _context;
        private IDbContextTransaction _transaction;

        private ITableGenericRepository<TrainingCenter> _trainingCentorRepository;

        public ITableGenericRepository<TrainingCenter> TrainingCenterRepository
        {
            get
            {
                return _trainingCentorRepository = _trainingCentorRepository ?? new TableGenericRepository<TrainingCenter>(_context);
            }
        }

        private ITableGenericRepository<TrainingType> _trainingTypeRepository;
        public ITableGenericRepository<TrainingType> TrainingTypeRepository
        {
            get
            {
                return _trainingTypeRepository = _trainingTypeRepository ?? new TableGenericRepository<TrainingType>(_context);
            }
        }

        private ITableGenericRepository<SpecializedTraining> _specializedTrainingRepository;
        public ITableGenericRepository<SpecializedTraining> SpecializedTrainingRepository
        {
            get
            {
                return _specializedTrainingRepository = _specializedTrainingRepository ?? new TableGenericRepository<SpecializedTraining>(_context);
            }
        }

        public TrainingUnitOfWork(TrainingContext context)
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
