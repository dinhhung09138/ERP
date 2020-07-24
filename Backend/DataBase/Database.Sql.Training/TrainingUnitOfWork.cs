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

        private ITableGenericRepository<Appraise> _appraiseRepository;
        public ITableGenericRepository<Appraise> AppraiseRepository
        {
            get
            {
                return _appraiseRepository = _appraiseRepository ?? new TableGenericRepository<Appraise>(_context);
            }
        }

        private ITableGenericRepository<AppraiseAnswer> _appraiseAnswerRepository;
        public ITableGenericRepository<AppraiseAnswer> AppraiseAnswerRepository
        {
            get
            {
                return _appraiseAnswerRepository = _appraiseAnswerRepository ?? new TableGenericRepository<AppraiseAnswer>(_context);
            }
        }

        private ITableGenericRepository<AppraiseQuestion> _appraiseQuestionRepository;
        public ITableGenericRepository<AppraiseQuestion> AppraiseQuestionRepository
        {
            get
            {
                return _appraiseQuestionRepository = _appraiseQuestionRepository ?? new TableGenericRepository<AppraiseQuestion>(_context);
            }
        }

        private ITableGenericRepository<AppraiseSection> _appraiseSectionRepository;
        public ITableGenericRepository<AppraiseSection> AppraiseSectionRepository
        {
            get
            {
                return _appraiseSectionRepository = _appraiseSectionRepository ?? new TableGenericRepository<AppraiseSection>(_context);
            }
        }

        private ITableGenericRepository<Lecturer> _lecturerRepository;
        public ITableGenericRepository<Lecturer> LecturerRepository
        {
            get
            {
                return _lecturerRepository = _lecturerRepository ?? new TableGenericRepository<Lecturer>(_context);
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

        private ITableGenericRepository<TrainingCenter> _trainingCenterRepository;
        public ITableGenericRepository<TrainingCenter> TrainingCenterRepository
        {
            get
            {
                return _trainingCenterRepository = _trainingCenterRepository ?? new TableGenericRepository<TrainingCenter>(_context);
            }
        }

        private ITableGenericRepository<TrainingCenterContact> _trainingCenterContactRepository;
        public ITableGenericRepository<TrainingCenterContact> TrainingCenterContactRepository
        {
            get
            {
                return _trainingCenterContactRepository = _trainingCenterContactRepository ?? new TableGenericRepository<TrainingCenterContact>(_context);
            }
        }

        private ITableGenericRepository<TrainingCourse> _trainingCourseRepository;
        public ITableGenericRepository<TrainingCourse> TrainingCourseRepository
        {
            get
            {
                return _trainingCourseRepository = _trainingCourseRepository ?? new TableGenericRepository<TrainingCourse>(_context);
            }
        }

        private ITableGenericRepository<TrainingCourseDocument> _trainingCourseDocumentRepository;
        public ITableGenericRepository<TrainingCourseDocument> TrainingCourseDocumentRepository
        {
            get
            {
                return _trainingCourseDocumentRepository = _trainingCourseDocumentRepository ?? new TableGenericRepository<TrainingCourseDocument>(_context);
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
