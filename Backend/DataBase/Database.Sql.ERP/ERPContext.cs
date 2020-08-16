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
        public virtual DbSet<Position> Position { get; set; }

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

            modelBuilder.Entity<District>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<ProfessionalQualification>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<Province>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<Ward>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            #endregion

            #region " [ HR ] "

            modelBuilder.Entity<Education>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<ApproveStatus>(entity => {
                entity.HasIndex(m => m.Code).IsUnique(true);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<CodeType>();
            modelBuilder.Entity<Commendation>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<ContractType>(entity => {
                entity.HasIndex(m => m.Code).IsUnique(true);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<Discipline>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<Employee>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<EmployeeCommendation>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<EmployeeContact>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<EmployeeContract>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<EmployeeContractStatusHistory>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<EmployeeDiscipline>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<EmployeeEducation>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<EmployeeIdentification>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<EmployeeInfo>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<EmployeeRelationship>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<EmployeeWorkingStatus>(entity => {
                entity.HasIndex(m => m.Code).IsUnique(true);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<IdentificationType>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<ModelOfStudy>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<Nation>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<Nationality>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<Ranking>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<RelationshipType>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<Religion>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<Position>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            #endregion

            #region " [ Training ]

            modelBuilder.Entity<Appraise>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<AppraiseAnswer>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<AppraiseQuestion>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<AppraiseSection>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<Lecturer>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<SpecializedTraining>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<TrainingCenter>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<TrainingCenterContact>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<TrainingCourse>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<TrainingCourseDocument>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
            modelBuilder.Entity<TrainingType>(entity => {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            #endregion

            #region " [ Security ]

            modelBuilder.Entity<User>();
            modelBuilder.Entity<SessionLog>();

            #endregion

        }
    }
}
