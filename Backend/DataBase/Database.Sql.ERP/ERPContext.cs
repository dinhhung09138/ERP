using Database.Sql.ERP.Entities.HR;
using Database.Sql.ERP.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Database.Sql.ERP.Entities.Training;
using Database.Sql.ERP.Entities.Security;
using System;

namespace Database.Sql.ERP
{
    public class ERPContext : DbContext
    {
        #region " [ Common ] "

        public virtual DbSet<District> District { get; set; }

        public virtual DbSet<ProfessionalQualification> ProfessionalQualification { get; set; }

        public virtual DbSet<Province> Province { get; set; }

        public virtual DbSet<Ward> Ward { get; set; }

        public virtual DbSet<File> File { get; set; }

        public virtual DbSet<CodeType> CodeType { get; set; }

        #endregion

        #region " [ HR ] "

        public virtual DbSet<Education> AcademicLevel { get; set; }

        public virtual DbSet<ApproveStatus> ApproveStatus { get; set; }

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


        #endregion

        public ERPContext(DbContextOptions<ERPContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.1.2");
            modelBuilder.HasDefaultSchema("dbo");

            #region " [ Common ] "

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<ProfessionalQualification>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<CodeType>(entity =>
            {
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            #endregion

            #region " [ HR ] "

            modelBuilder.Entity<Education>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<ApproveStatus>(entity =>
            {
                entity.HasIndex(m => m.Code).IsUnique(true);
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Commendation>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<ContractType>(entity =>
            {
                entity.HasIndex(m => m.Code).IsUnique(true);
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<EmployeeCommendation>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<EmployeeContact>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<EmployeeContract>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<EmployeeContractStatusHistory>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<EmployeeDiscipline>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<EmployeeEducation>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<EmployeeIdentification>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<EmployeeInfo>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<EmployeeRelationship>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<EmployeeWorkingStatus>(entity =>
            {
                entity.HasIndex(m => m.Code).IsUnique(true);
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<IdentificationType>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<ModelOfStudy>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Ethnicity>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Ranking>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<RelationshipType>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Religion>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            #endregion

            #region " [ Training ]

            modelBuilder.Entity<Appraise>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<AppraiseAnswer>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<AppraiseQuestion>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<AppraiseSection>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<SpecializedTraining>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<TrainingCenter>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<TrainingCenterContact>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<TrainingCourse>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<TrainingCourseDocument>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<TrainingType>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            #endregion

            #region " [ Security ]

            modelBuilder.Entity<Function>(entity =>
            {
                entity.Property(m => m.Precedence).HasDefaultValue(1);
            });

            modelBuilder.Entity<Function>()
                        .HasOne(p => p.Module)
                        .WithMany(b => b.Functions)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FunctionCommand>(entity =>
            {
                entity.Property(m => m.Precedence).HasDefaultValue(1);
            });

            modelBuilder.Entity<FunctionCommand>()
                        .HasOne(p => p.Function)
                        .WithMany(b => b.Commands)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Module>(entity =>
            {
                entity.Property(m => m.Precedence).HasDefaultValue(1);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<RoleDetail>();

            modelBuilder.Entity<RoleDetail>()
                        .HasOne(p => p.FunctionCommand)
                        .WithMany(b => b.RoleDetails)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RoleDetail>()
                        .HasOne(p => p.Role)
                        .WithMany(b => b.Details)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SessionLog>(entity =>
            {
                entity.Property(m => m.LoginTime).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsOnline).HasDefaultValue(true);
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<SystemLog>();

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<UserRole>();
            modelBuilder.Entity<UserRole>()
                        .HasOne(p => p.User)
                        .WithMany(b => b.UserRoles)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserRole>()
                        .HasOne(p => p.Role)
                        .WithMany(b => b.UserRoles)
                        .OnDelete(DeleteBehavior.Cascade);

            #endregion

            CreateDefaultModule(modelBuilder);
            CreateDefaultFunction(modelBuilder);
            CreateDefaultEmployeeWorkingStatus(modelBuilder);
            CreateDefaultEmployee(modelBuilder);
            CreateDefaultUser(modelBuilder);

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

        private void CreateDefaultFunction(ModelBuilder modelBuilder)
        {
            CreateDefaultFunctionModuleHR(modelBuilder);
            CreateDefaultFunctionModuleSystem(modelBuilder);
        }

        private void CreateDefaultFunctionModuleHR(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_DASHBOARD",
                    Name = "DASHBOARD",
                    Url = "/dashboard",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 1,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_DEPARTMENT",
                    Name = "DASHBOARD",
                    Url = "/department",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 2,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_TEAM",
                    Name = "TEAM",
                    Url = "/team",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 3,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_POSITION",
                    Name = "POSITION",
                    Url = "/position",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 4,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_COMMENDATION",
                    Name = "COMMENDATION",
                    Url = "/commendation",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 5,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_DISCIPLINE",
                    Name = "DISCIPLINE",
                    Url = "/discipline",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 6,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_EMPLOYEE",
                    Name = "EMPLOYEE",
                    Url = "/employee",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 6,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_LEAVE_MNT",
                    Name = "LEAVE_MANAGEMENT",
                    Url = "/leave-management",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 7,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_LEAVE_CALENDAR",
                    Name = "CALENDAR",
                    Url = "/leave-management/calendar",
                    Icon = string.Empty,
                    ParentCode = "HR_LEAVE_MNT",
                    Precedence = 1,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_LEAVE_SUMMARY",
                    Name = "SUMMARY",
                    Url = "/leave-management/summary",
                    Icon = string.Empty,
                    ParentCode = "HR_LEAVE_MNT",
                    Precedence = 2,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_LEAVE_NEW",
                    Name = "NEW",
                    Url = "/leave-management/new",
                    Icon = string.Empty,
                    ParentCode = "HR_LEAVE_MNT",
                    Precedence = 3,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_LEAVE_APPROVE_ST",
                    Name = "APPROVE_STATUS",
                    Url = "/leave-management/approve-status",
                    Icon = string.Empty,
                    ParentCode = "HR_LEAVE_MNT",
                    Precedence = 4,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_HOLIDAY",
                    Name = "HOLIDAY",
                    Url = "/holiday",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 8,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_CONFIGURATION",
                    Name = "CONFIGURATION",
                    Url = "/configuration",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 9,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_CONF_PROVINCE",
                    Name = "PROVINCE",
                    Url = "/configuration/province",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 1,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_CONF_DISTRICT",
                    Name = "DISTRICT",
                    Url = "/configuration/district",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 2,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_CONF_WARD",
                    Name = "WARD",
                    Url = "/configuration/ward",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 3,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_CONF_RELIGION",
                    Name = "RELIGION",
                    Url = "/configuration/religion",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 4,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_CONF_ETHNICITY",
                    Name = "ETHNICITY",
                    Url = "/configuration/ethnicity",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 5,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_CONF_NATIONALITY",
                    Name = "NATIONALITY",
                    Url = "/configuration/nationality",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 6,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_CONF_EDUCATION",
                    Name = "EDUCATION",
                    Url = "/configuration/education",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 7,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_CONF_QUALIFICATION",
                    Name = "QUALIFICATION",
                    Url = "/configuration/qualification",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 8,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_CONF_MODEL_OF_STUDY",
                    Name = "MODEL_OF_STUDY",
                    Url = "/configuration/model-of-study",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 9,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_CONF_RANKING",
                    Name = "RANKING",
                    Url = "/configuration/ranking",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 10,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_CONF_RELATIONSHIP",
                    Name = "RELATIONSHIP_TYPE",
                    Url = "/configuration/relationship-type",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 11,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_CONF_CONTRACT",
                    Name = "CONTRACT_TYPE",
                    Url = "/configuration/contract-type",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 12,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_CONF_WORKING",
                    Name = "WORKING_STATUS",
                    Url = "/configuration/working-status",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 13,
                    ModuleCode = "HR"
                }
            );

            modelBuilder.Entity<Function>().HasData(
                new Function()
                {
                    Code = "HR_CONF_JOB",
                    Name = "JOB_TITLE",
                    Url = "/configuration/job-title",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 14,
                    ModuleCode = "HR"
                }
            );

        }

        private void CreateDefaultFunctionModuleSystem(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Function>().HasData(
               new Function()
               {
                   Code = "SYS_ACCOUNT",
                   Name = "ACCOUNT",
                   Url = "/account",
                   Icon = string.Empty,
                   ParentCode = string.Empty,
                   Precedence = 1,
                   ModuleCode = "SYSTEM"
               }
           );

            modelBuilder.Entity<Function>().HasData(
               new Function()
               {
                   Code = "SYS_ROLE",
                   Name = "ROLE",
                   Url = "/role",
                   Icon = string.Empty,
                   ParentCode = string.Empty,
                   Precedence = 2,
                   ModuleCode = "SYSTEM"
               }
           );

            modelBuilder.Entity<Function>().HasData(
               new Function()
               {
                   Code = "SYS_SYSTEM_ERROR",
                   Name = "SYSTEM_ERROR",
                   Url = "/system-error",
                   Icon = string.Empty,
                   ParentCode = string.Empty,
                   Precedence = 2,
                   ModuleCode = "SYSTEM"
               }
           );
        }

        private void CreateDefaultEmployeeWorkingStatus(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeWorkingStatus>().HasData(
                new EmployeeWorkingStatus()
                {
                    Id = 1,
                    Code = "Sys",
                    Name = "System",
                }
            );
        }

        private void CreateDefaultEmployee(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    EmployeeCode = "SYSTEM",
                    EmployeeWorkingStatusId = 1
                }
            );
            modelBuilder.Entity<EmployeeInfo>().HasData(
                new EmployeeInfo()
                {
                    Id = 1,
                    EmployeeId = 1,
                    FirstName = "Sys",
                    LastName = "Admin"
                }
            );
        }

        private void CreateDefaultUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    EmployeeId = 1,
                    UserName = "sysadmin",
                    Password = "NTZFMjNDNTNCNjVFMjdGMjM3NDIyOTkwRTI5MjJFNzA0RkE2MTJBQzQ3OEE3NjA4NUI5QkQxMTU1OTBDNTgyMw=="
                }
            );
        }
    }
}
