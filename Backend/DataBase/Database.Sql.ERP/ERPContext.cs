using Database.Sql.ERP.Entities.HR;
using Database.Sql.ERP.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Database.Sql.ERP.Entities.Training;
using Database.Sql.ERP.Entities.Security;

namespace Database.Sql.ERP
{
    public class ERPContext : DbContext
    {
        #region " [ Common ] "

        public virtual DbSet<District> District { get; set; }

        public virtual DbSet<ProfessionalQualification> ProfessionalQualification { get; set; }

        public virtual DbSet<Province> Province { get; set; }

        public virtual DbSet<Ward> Ward { get; set; }

        #endregion

        #region " [ HR ] "

        public virtual DbSet<Education> AcademicLevel { get; set; }

        public virtual DbSet<ApproveStatus> ApproveStatus { get; set; }

        public virtual DbSet<CodeType> CodeType { get; set; }

        public virtual DbSet<Commendation> Commendation { get; set; }

        public virtual DbSet<ContractType> ContractType { get; set; }

        public virtual DbSet<ContractType> Discipline { get; set; }

        public virtual DbSet<Employee> Employee { get; set; }

        public virtual DbSet<EmployeeCommendation> EmployeeCommendation { get; set; }

        public virtual DbSet<EmployeeContact> EmployeeContact { get; set; }

        public virtual DbSet<EmployeeContract> EmployeeContract { get; set; }

        public virtual DbSet<EmployeeContractStatusHistory> EmployeeContractStatusHistory { get; set; }

        public virtual DbSet<EmployeeDiscipline> EmployeeDiscipline { get; set; }

        public virtual DbSet<EmployeeEducation> EmployeeEducation { get; set; }

        public virtual DbSet<EmployeeIdentification> EmployeeIdentification { get; set; }

        public virtual DbSet<EmployeeInfo> EmployeeInfo { get; set; }

        public virtual DbSet<EmployeeRelationship> EmployeeRelationship { get; set; }

        public virtual DbSet<EmployeeWorkingStatus> EmployeeWorkingStatus { get; set; }

        public virtual DbSet<IdentificationType> IdentificationType { get; set; }

        public virtual DbSet<ModelOfStudy> ModelOfStudy { get; set; }

        public virtual DbSet<Nation> Nation { get; set; }

        public virtual DbSet<Nationality> Nationality { get; set; }

        public virtual DbSet<Ranking> Ranking { get; set; }

        public virtual DbSet<RelationshipType> RelationshipType { get; set; }

        public virtual DbSet<Religion> Religion { get; set; }

        #endregion

        #region " [ Training ]

        public virtual DbSet<Appraise> Appraise { get; set; }
        public virtual DbSet<AppraiseAnswer> AppraiseAnswer { get; set; }
        public virtual DbSet<AppraiseQuestion> AppraiseQuestion { get; set; }
        public virtual DbSet<AppraiseSection> AppraiseSection { get; set; }
        public virtual DbSet<Lecturer> Lecturer { get; set; }
        public virtual DbSet<SpecializedTraining> SpecializedTraining { get; set; }
        public virtual DbSet<TrainingCenter> TrainingCenter { get; set; }
        public virtual DbSet<TrainingCenterContact> TrainingCenterContact { get; set; }
        public virtual DbSet<TrainingCourse> TrainingCourse { get; set; }
        public virtual DbSet<TrainingCourseDocument> TrainingCourseDocument { get; set; }
        public virtual DbSet<TrainingType> TrainingType { get; set; }

        #endregion

        #region " [ Security ]

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<SessionLog> SessionLog { get; set; }

        #endregion

        public ERPContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.1.2");

            #region " [ Common ] "

            modelBuilder.Entity<District>();
            modelBuilder.Entity<ProfessionalQualification>();
            modelBuilder.Entity<Province>();
            modelBuilder.Entity<Ward>();

            #endregion

            #region " [ HR ] "

            modelBuilder.Entity<Education>();
            modelBuilder.Entity<ApproveStatus>();
            modelBuilder.Entity<CodeType>();
            modelBuilder.Entity<Commendation>();
            modelBuilder.Entity<ContractType>();
            modelBuilder.Entity<Discipline>();
            modelBuilder.Entity<Employee>();
            modelBuilder.Entity<EmployeeCommendation>();
            modelBuilder.Entity<EmployeeContact>();
            modelBuilder.Entity<EmployeeContract>();
            modelBuilder.Entity<EmployeeContractStatusHistory>();
            modelBuilder.Entity<EmployeeDiscipline>();
            modelBuilder.Entity<EmployeeEducation>();
            modelBuilder.Entity<EmployeeIdentification>();
            modelBuilder.Entity<EmployeeInfo>();
            modelBuilder.Entity<EmployeeRelationship>();
            modelBuilder.Entity<EmployeeWorkingStatus>();
            modelBuilder.Entity<IdentificationType>();
            modelBuilder.Entity<ModelOfStudy>();
            modelBuilder.Entity<Nation>();
            modelBuilder.Entity<Nationality>();
            modelBuilder.Entity<Ranking>();
            modelBuilder.Entity<RelationshipType>();
            modelBuilder.Entity<Religion>();

            #endregion

            #region " [ Training ]

            modelBuilder.Entity<Appraise>();
            modelBuilder.Entity<AppraiseAnswer>();
            modelBuilder.Entity<AppraiseQuestion>();
            modelBuilder.Entity<AppraiseSection>();
            modelBuilder.Entity<Lecturer>();
            modelBuilder.Entity<SpecializedTraining>();
            modelBuilder.Entity<TrainingCenter>();
            modelBuilder.Entity<TrainingCenterContact>();
            modelBuilder.Entity<TrainingCourse>();
            modelBuilder.Entity<TrainingCourseDocument>();
            modelBuilder.Entity<TrainingType>();

            #endregion

            #region " [ Security ]

            modelBuilder.Entity<User>();
            modelBuilder.Entity<SessionLog>();

            #endregion

        }
    }
}
