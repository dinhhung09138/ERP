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
        public virtual DbSet<UserModule> UserModule { get; set; }


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
                entity.Property(m => m.IsView).HasDefaultValue(false);
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

            modelBuilder.Entity<UserModule>();
            modelBuilder.Entity<UserModule>()
                        .HasOne(p => p.User)
                        .WithMany(b => b.UserModules)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserModule>()
                        .HasOne(p => p.Module)
                        .WithMany(b => b.UserModules)
                        .OnDelete(DeleteBehavior.Cascade);

            #endregion

            CreateDefaultModule(modelBuilder);
            CreateDefaultFunction(modelBuilder);
            CreateDefaultCommand(modelBuilder);
            CreateDefaultRole(modelBuilder);
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
                },
                new Function()
                {
                    Code = "HR_DEPARTMENT",
                    Name = "DASHBOARD",
                    Url = "/department",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 2,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_TEAM",
                    Name = "TEAM",
                    Url = "/team",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 3,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_POSITION",
                    Name = "POSITION",
                    Url = "/position",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 4,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_COMMENDATION",
                    Name = "COMMENDATION",
                    Url = "/commendation",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 5,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_DISCIPLINE",
                    Name = "DISCIPLINE",
                    Url = "/discipline",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 6,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_EMPLOYEE",
                    Name = "EMPLOYEE",
                    Url = "/employee",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 6,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_LEAVE_MNT",
                    Name = "LEAVE_MANAGEMENT",
                    Url = "/leave-management",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 7,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_LEAVE_CALENDAR",
                    Name = "CALENDAR",
                    Url = "/leave-management/calendar",
                    Icon = string.Empty,
                    ParentCode = "HR_LEAVE_MNT",
                    Precedence = 1,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_LEAVE_SUMMARY",
                    Name = "SUMMARY",
                    Url = "/leave-management/summary",
                    Icon = string.Empty,
                    ParentCode = "HR_LEAVE_MNT",
                    Precedence = 2,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_LEAVE_NEW",
                    Name = "NEW",
                    Url = "/leave-management/new",
                    Icon = string.Empty,
                    ParentCode = "HR_LEAVE_MNT",
                    Precedence = 3,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_LEAVE_APPROVE_ST",
                    Name = "APPROVE_STATUS",
                    Url = "/leave-management/approve-status",
                    Icon = string.Empty,
                    ParentCode = "HR_LEAVE_MNT",
                    Precedence = 4,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_HOLIDAY",
                    Name = "HOLIDAY",
                    Url = "/holiday",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 8,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONFIGURATION",
                    Name = "CONFIGURATION",
                    Url = "/configuration",
                    Icon = string.Empty,
                    ParentCode = string.Empty,
                    Precedence = 9,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_PROVINCE",
                    Name = "PROVINCE",
                    Url = "/configuration/province",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 1,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_DISTRICT",
                    Name = "DISTRICT",
                    Url = "/configuration/district",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 2,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_WARD",
                    Name = "WARD",
                    Url = "/configuration/ward",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 3,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_RELIGION",
                    Name = "RELIGION",
                    Url = "/configuration/religion",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 4,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_ETHNICITY",
                    Name = "ETHNICITY",
                    Url = "/configuration/ethnicity",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 5,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_NATIONALITY",
                    Name = "NATIONALITY",
                    Url = "/configuration/nationality",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 6,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_EDUCATION",
                    Name = "EDUCATION",
                    Url = "/configuration/education",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 7,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_QUALIFICATION",
                    Name = "QUALIFICATION",
                    Url = "/configuration/qualification",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 8,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_MODEL_OF_STUDY",
                    Name = "MODEL_OF_STUDY",
                    Url = "/configuration/model-of-study",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 9,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_RANKING",
                    Name = "RANKING",
                    Url = "/configuration/ranking",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 10,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_RELATIONSHIP",
                    Name = "RELATIONSHIP_TYPE",
                    Url = "/configuration/relationship-type",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 11,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_CONTRACT",
                    Name = "CONTRACT_TYPE",
                    Url = "/configuration/contract-type",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 12,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_WORKING",
                    Name = "WORKING_STATUS",
                    Url = "/configuration/working-status",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 13,
                    ModuleCode = "HR"
                },
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
               },
               new Function()
               {
                   Code = "SYS_ROLE",
                   Name = "ROLE",
                   Url = "/role",
                   Icon = string.Empty,
                   ParentCode = string.Empty,
                   Precedence = 2,
                   ModuleCode = "SYSTEM"
               },
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

        private void CreateDefaultRole(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
               new Role()
               {
                   Id = 1,
                   Name = "Sys",
                   IsActive = true,
                   CreateBy = 1,
                   CreateDate = DateTime.Now,
                   Description = "Sys",
               }
           );
            modelBuilder.Entity<RoleDetail>().HasData(
                new RoleDetail()
                {
                    Id = 1,
                    RoleId = 1,
                    CommandId = 1
                },
                new RoleDetail()
                {
                    Id = 2,
                    RoleId = 1,
                    CommandId = 2
                },
                new RoleDetail()
                {
                    Id = 3,
                    RoleId = 1,
                    CommandId = 3
                },
                new RoleDetail()
                {
                    Id = 4,
                    RoleId = 1,
                    CommandId = 4
                },
                new RoleDetail()
                {
                    Id = 5,
                    RoleId = 1,
                    CommandId = 5
                },
                new RoleDetail()
                {
                    Id = 6,
                    RoleId = 1,
                    CommandId = 6
                },
                new RoleDetail()
                {
                    Id = 7,
                    RoleId = 1,
                    CommandId = 7
                },
                new RoleDetail()
                {
                    Id = 8,
                    RoleId = 1,
                    CommandId = 8
                },
                new RoleDetail()
                {
                    Id = 9,
                    RoleId = 1,
                    CommandId = 9
                },
                new RoleDetail()
                {
                    Id = 10,
                    RoleId = 1,
                    CommandId = 10
                },
                new RoleDetail()
                {
                    Id = 11,
                    RoleId = 1,
                    CommandId = 11
                });
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
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole()
                {
                    Id = 1,
                    UserId = 1,
                    RoleId = 1
                }
            );
        }

        private void CreateDefaultCommand(ModelBuilder modelBuilder)
        {
            #region " System Command "
            // SYS_ACCOUNT
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 1,
                    FunctionCode = "SYS_ACCOUNT",
                    Name = "VIEW",
                    ModuleName = "System",
                    ControllerName = "User",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 2,
                    FunctionCode = "SYS_ACCOUNT",
                    Name = "INSERT",
                    ModuleName = "System",
                    ControllerName = "User",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 3,
                    FunctionCode = "SYS_ACCOUNT",
                    Name = "UPDATE",
                    ModuleName = "System",
                    ControllerName = "User",
                    ActionName = "ChangeRole",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 4,
                    FunctionCode = "SYS_ACCOUNT",
                    Name = "ACTIVE_OR_DEACTIVATION",
                    ModuleName = "System",
                    ControllerName = "User",
                    ActionName = "ActiveOrDeactivation",
                    Precedence = 4,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 5,
                    FunctionCode = "SYS_ACCOUNT",
                    Name = "ADMIN_CHANGE_PASSWORD",
                    ModuleName = "System",
                    ControllerName = "User",
                    ActionName = "AdminChangepassword",
                    Precedence = 5,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 6,
                    FunctionCode = "SYS_ACCOUNT",
                    Name = "USER_CHANGE_PASSWORD",
                    ModuleName = "System",
                    ControllerName = "User",
                    ActionName = "UserChangepassword",
                    Precedence = 6,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 7,
                    FunctionCode = "SYS_ACCOUNT",
                    Name = "DELETE",
                    ModuleName = "System",
                    ControllerName = "User",
                    ActionName = "Delete",
                    Precedence = 7,
                    IsView = false,
                }
            );
            // SYS_ROLE
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 8,
                    FunctionCode = "SYS_ROLE",
                    Name = "VIEW",
                    ModuleName = "System",
                    ControllerName = "Role",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 9,
                    FunctionCode = "SYS_ROLE",
                    Name = "INSERT",
                    ModuleName = "System",
                    ControllerName = "Role",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 10,
                    FunctionCode = "SYS_ROLE",
                    Name = "UPDATE",
                    ModuleName = "System",
                    ControllerName = "Role",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 11,
                    FunctionCode = "SYS_ROLE",
                    Name = "DELETE",
                    ModuleName = "System",
                    ControllerName = "Role",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );

            #endregion

            #region " HR "
            // HR_DASHBOARD
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_DASHBOARD",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Dashboard",
                    ActionName = "Index",
                    Precedence = 1,
                    IsView = true,
                }
            );
            // HR_DEPARTMENT
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_DEPARTMENT",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Department",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_DEPARTMENT",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "Department",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_DEPARTMENT",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "Department",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_DEPARTMENT",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Department",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_TEAM
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_TEAM",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Team",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_TEAM",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "Team",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_TEAM",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "Team",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_TEAM",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Team",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_POSITION
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_POSITION",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Position",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_POSITION",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "Position",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_POSITION",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "Position",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_POSITION",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Position",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_COMMENDATION
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_COMMENDATION",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Commendation",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_COMMENDATION",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "Commendation",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_COMMENDATION",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "Commendation",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_COMMENDATION",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Commendation",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_DISCIPLINE
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_DISCIPLINE",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Discipline",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_DISCIPLINE",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "Discipline",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_DISCIPLINE",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "Discipline",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_DISCIPLINE",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Discipline",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_CONF_PROVINCE
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_PROVINCE",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Province",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_PROVINCE",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "Province",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_PROVINCE",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "Province",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_PROVINCE",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Province",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_CONF_DISTRICT
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_DISTRICT",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "District",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_DISTRICT",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "District",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_DISTRICT",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "District",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_DISTRICT",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "District",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_CONF_WARD
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_WARD",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Ward",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_WARD",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "Ward",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_WARD",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "Ward",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_WARD",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Ward",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_CONF_RELIGION
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_RELIGION",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Religion",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_RELIGION",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "Religion",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_RELIGION",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "Religion",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_RELIGION",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Religion",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_CONF_ETHNICITY
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_ETHNICITY",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Ethnicity",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_ETHNICITY",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "Ethnicity",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_ETHNICITY",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "Ethnicity",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_ETHNICITY",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Ethnicity",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_CONF_NATIONALITY
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_NATIONALITY",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Nationality",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_NATIONALITY",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "Nationality",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_NATIONALITY",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "Nationality",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_NATIONALITY",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Nationality",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_CONF_EDUCATION
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_EDUCATION",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Education",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_EDUCATION",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "Education",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_EDUCATION",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "Education",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_EDUCATION",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Education",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_CONF_QUALIFICATION
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_QUALIFICATION",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "ProfessionalQualification",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_QUALIFICATION",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "ProfessionalQualification",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_QUALIFICATION",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "ProfessionalQualification",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_QUALIFICATION",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "ProfessionalQualification",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_CONF_MODEL_OF_STUDY
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_MODEL_OF_STUDY",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "ModelOfStudy",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_MODEL_OF_STUDY",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "ModelOfStudy",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_MODEL_OF_STUDY",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "ModelOfStudy",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_MODEL_OF_STUDY",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "ModelOfStudy",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_CONF_RANKING
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_RANKING",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Ranking",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_RANKING",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "Ranking",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_RANKING",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "Ranking",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_RANKING",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Ranking",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_CONF_RELATIONSHIP
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_RELATIONSHIP",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "RelationshipType",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_RELATIONSHIP",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "RelationshipType",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_RELATIONSHIP",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "RelationshipType",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_RELATIONSHIP",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "RelationshipType",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_CONF_CONTRACT
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_CONTRACT",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "ContractType",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_CONTRACT",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "ContractType",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_CONTRACT",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "ContractType",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_CONTRACT",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "ContractType",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_CONF_WORKING
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_WORKING",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "EmployeeWorkingStatus",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_WORKING",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "EmployeeWorkingStatus",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_WORKING",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeWorkingStatus",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_CONF_WORKING",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeWorkingStatus",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            // HR_EMPLOYEE
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    FunctionCode = "HR_EMPLOYEE",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Employee",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_EMPLOYEE",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "Employee",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_EMPLOYEE",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "Employee",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    FunctionCode = "HR_EMPLOYEE",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Employee",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );



            #endregion
        }
    }
}
