using Core.DataAccess;
using Database.Sql.Training.Entities;

namespace Database.Sql.Training
{
    public interface ITrainingUnitOfWork : IGenericUnitOfWork
    {
        ITableGenericRepository<Appraise> AppraiseRepository { get; }
        ITableGenericRepository<AppraiseAnswer> AppraiseAnswerRepository { get; }
        ITableGenericRepository<AppraiseQuestion> AppraiseQuestionRepository { get; }
        ITableGenericRepository<AppraiseSection> AppraiseSectionRepository { get; }
        ITableGenericRepository<Lecturer> LecturerRepository { get; }
        ITableGenericRepository<SpecializedTraining> SpecializedTrainingRepository { get; }
        ITableGenericRepository<TrainingCenter> TrainingCenterRepository { get; }
        ITableGenericRepository<TrainingCenterContact> TrainingCenterContactRepository { get; }
        ITableGenericRepository<TrainingCourse> TrainingCourseRepository { get; }
        ITableGenericRepository<TrainingCourseDocument> TrainingCourseDocumentRepository { get; }
        ITableGenericRepository<TrainingType> TrainingTypeRepository { get; }
    }
}
