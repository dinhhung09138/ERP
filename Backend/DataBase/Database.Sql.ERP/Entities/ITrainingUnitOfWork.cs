using Core.DataAccess;
using Database.Sql.ERP.Entities.Training;

namespace Database.Sql.ERP.Entities
{
    public interface ITrainingUnitOfWork
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
