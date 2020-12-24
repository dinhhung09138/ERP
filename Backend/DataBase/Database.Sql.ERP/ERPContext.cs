using Database.Sql.ERP.Entities.HR;
using Database.Sql.ERP.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Database.Sql.ERP.Entities.Training;
using Database.Sql.ERP.Entities.Security;
using System;
using Database.Sql.ERP.Creation;

namespace Database.Sql.ERP
{
    public class ERPContext : DbContext
    {
        #region " [ Common ] "

        public virtual DbSet<Certificated> Certificated { get; set; }

        public virtual DbSet<District> District { get; set; }

        public virtual DbSet<Major> MajorType { get; set; }

        public virtual DbSet<ProfessionalQualification> ProfessionalQualification { get; set; }

        public virtual DbSet<Province> Province { get; set; }

        public virtual DbSet<School> School { get; set; }

        public virtual DbSet<Ward> Ward { get; set; }

        public virtual DbSet<File> File { get; set; }

        public virtual DbSet<CommonCodeType> CodeType { get; set; }

        public virtual DbSet<CommonCode> Code { get; set; }

        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }

        #endregion

        #region " [ HR ] "

        public virtual DbSet<Education> AcademicLevel { get; set; }

        public virtual DbSet<ApproveStatus> ApproveStatus { get; set; }

        public virtual DbSet<Bank> Bank { get; set; }

        public virtual DbSet<Commendation> Commendation { get; set; }

        public virtual DbSet<ContractType> ContractType { get; set; }

        public virtual DbSet<ContractType> Discipline { get; set; }

        public virtual DbSet<Employee> Employee { get; set; }

        public virtual DbSet<EmployeeBank> EmployeeBank { get; set; }

        public virtual DbSet<EmployeeCommendation> EmployeeCommendation { get; set; }

        public virtual DbSet<EmployeeContact> EmployeeContact { get; set; }

        public virtual DbSet<EmployeeContract> EmployeeContract { get; set; }

        public virtual DbSet<EmployeeContractStatusHistory> EmployeeContractStatusHistory { get; set; }

        public virtual DbSet<EmployeeDiscipline> EmployeeDiscipline { get; set; }

        public virtual DbSet<EmployeeDependency> EmployeeDependency { get; set; }

        public virtual DbSet<EmployeeEducation> EmployeeEducation { get; set; }

        public virtual DbSet<EmployeeCertificate> EmployeeCertificate { get; set; }

        public virtual DbSet<EmployeeIdentification> EmployeeIdentification { get; set; }

        public virtual DbSet<EmployeeInfo> EmployeeInfo { get; set; }

        public virtual DbSet<EmployeeLeave> EmployeeLeave { get; set; }

        public virtual DbSet<EmployeeLeaveConfiguration> EmployeeLeaveConfiguration { get; set; }

        public virtual DbSet<EmployeeLeaveStatus> EmployeeLeaveStatus { get; set; }

        public virtual DbSet<EmployeeRelationship> EmployeeRelationship { get; set; }

        public virtual DbSet<EmployeeWorkingStatus> EmployeeWorkingStatus { get; set; }

        public virtual DbSet<IdentificationType> IdentificationType { get; set; }

        public virtual DbSet<LeaveStatus> LeaveStatus { get; set; }

        public virtual DbSet<LeaveType> LeaveType { get; set; }

        public virtual DbSet<ModelOfStudy> ModelOfStudy { get; set; }

        public virtual DbSet<Ethnicity> Nation { get; set; }

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

        public virtual DbSet<Function> Function { get; set; }
        public virtual DbSet<FunctionCommand> FunctionCommand { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleDetail> RoleDetail { get; set; }
        public virtual DbSet<SessionLog> SessionLog { get; set; }
        public virtual DbSet<SystemLog> SystemLog { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserModule> UserModule { get; set; }


        #endregion

        public ERPContext(DbContextOptions<ERPContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.1.2");
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.CommonModelCreating();
            modelBuilder.HRModelCreating();
            modelBuilder.TrainingModelCreating();
            modelBuilder.SecutiryModelCreating();

            CreateDefaultModule(modelBuilder);

            modelBuilder.CreateDefaultFunctionModuleHR();
            modelBuilder.CreateDefaultFunctionModuleSystem();

            modelBuilder.CreateSystemDefaultCommand();
            modelBuilder.CreateHumanResourceDefaultCommand();

            modelBuilder.CreateDefaultSystemData();
            modelBuilder.CreateDefaultHRData();

            //FunctionCommand MaxId = 171
        }

        private void CreateDefaultModule(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>().HasData(
                new Module()
                {
                    Code = "DASHBOARD",
                    Name = "DASHBOARD",
                    Url = "/dashboard",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 1
                }
            );
            modelBuilder.Entity<Module>().HasData(
                new Module()
                {
                    Code = "HR",
                    Name = "HR",
                    Url = "/hr",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 2
                }
            );
            modelBuilder.Entity<Module>().HasData(
                new Module()
                {
                    Code = "SYSTEM",
                    Name = "SYSTEM",
                    Url = "/system",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 5
                }
            );
        }


    }
}
