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

        public virtual DbSet<CodeType> CodeType { get; set; }

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

        public virtual DbSet<EmployeeEducation> EmployeeEducation { get; set; }

        public virtual DbSet<EmployeeCertificate> EmployeeCertificate { get; set; }

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

            modelBuilder.CommonModelCreating();
            modelBuilder.HRModelCreating();
            modelBuilder.TrainingModelCreating();
            modelBuilder.SecutiryModelCreating();

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
            modelBuilder.CreateDefaultFunctionModuleHR();
            modelBuilder.CreateDefaultFunctionModuleSystem();
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
                    BadgeCardNumber = string.Empty,
                    FingerSignNumber = string.Empty,
                    WorkingEmail = string.Empty,
                    WorkingPhone = string.Empty
                }
            );
            modelBuilder.Entity<EmployeeInfo>().HasData(
                new EmployeeInfo()
                {
                    Id = 1,
                    EmployeeId = 1,
                    FirstName = "Sys",
                    LastName = "Admin",
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

            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 1,
                    FunctionCode = "SYS_ACCOUNT",
                    Name = "VIEW",
                    ModuleName = "System",
                    ControllerName = "User",
                    ActionName = "List",
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
            modelBuilder.CreateSystemDefaultCommand();

            #endregion

            #region " HR "

            modelBuilder.CreateHumanResourceDefaultCommand();

            //FunctionCommand MaxId = 153

            #endregion
        }

    }
}
