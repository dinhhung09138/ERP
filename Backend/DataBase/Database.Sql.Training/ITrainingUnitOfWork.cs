using Core.DataAccess;
using Database.Sql.Training.Entities;

namespace Database.Sql.Training
{
    public interface ITrainingUnitOfWork : IGenericUnitOfWork
    {
        ITableGenericRepository<TrainingCenter> TrainingCenterRepository { get; }
        ITableGenericRepository<TrainingType> TrainingTypeRepository { get; }
        ITableGenericRepository<SpecializedTraining> SpecializedTrainingRepository { get; }
    }
}
