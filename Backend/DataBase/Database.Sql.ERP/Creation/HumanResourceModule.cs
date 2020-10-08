using Database.Sql.ERP.Entities.HR;
using Database.Sql.ERP.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Sql.ERP.Creation
{
    public static class HumanResourceModule
    {
        #region " [ Model Creating ] "

        public static void HRModelCreating(this ModelBuilder modelBuilder)
        {
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
        }

        #endregion

        #region " [ Default Command ] "

        public static void CreateHumanResourceDefaultCommand(this ModelBuilder modelBuilder)
        {
            modelBuilder.CreateDefaultCommandDepartment();
            modelBuilder.CreateDefaultCommandTeam();
            modelBuilder.CreateDefaultCommandPosition();
            modelBuilder.CreateDefaultCommandCommandation();
            modelBuilder.CreateDefaultCommandDiscipline();
            modelBuilder.CreateDefaultCommandConfProvince();
            modelBuilder.CreateDefaultCommandConfDistrict();
            modelBuilder.CreateDefaultCommandConfWard();
            modelBuilder.CreateDefaultCommandConfReligion();
            modelBuilder.CreateDefaultCommandConfEthnicity();
            modelBuilder.CreateDefaultCommandConfNationality();
            modelBuilder.CreateDefaultCommandConfIdentification();
            modelBuilder.CreateDefaultCommandConfEducation();
            modelBuilder.CreateDefaultCommandConfQualification();
            modelBuilder.CreateDefaultCommandConfModelOfStudy();
            modelBuilder.CreateDefaultCommandConfRanking();
            modelBuilder.CreateDefaultCommandConfRelationShip();
            modelBuilder.CreateDefaultCommandConfContract();
            modelBuilder.CreateDefaultCommandConfWorkingStatus();
            modelBuilder.CreateDefaultCommandConfApproveStatus();
        }

        private static void CreateDefaultCommandDepartment(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 12,
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
                    Id = 13,
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
                    Id = 14,
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
                    Id = 15,
                    FunctionCode = "HR_DEPARTMENT",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Department",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandTeam(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 16,
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
                    Id = 17,
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
                    Id = 18,
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
                    Id = 19,
                    FunctionCode = "HR_TEAM",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Team",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandPosition(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 20,
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
                    Id = 21,
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
                    Id = 22,
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
                    Id = 23,
                    FunctionCode = "HR_POSITION",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Position",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandCommandation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 24,
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
                    Id = 25,
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
                    Id = 26,
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
                    Id = 27,
                    FunctionCode = "HR_COMMENDATION",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Commendation",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandDiscipline(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 28,
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
                    Id = 29,
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
                    Id = 30,
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
                    Id = 31,
                    FunctionCode = "HR_DISCIPLINE",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Discipline",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        #region " [ Configuration ] "

        private static void CreateDefaultCommandConfProvince(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 32,
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
                    Id = 33,
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
                    Id = 34,
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
                    Id = 35,
                    FunctionCode = "HR_CONF_PROVINCE",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Province",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfDistrict(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 36,
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
                    Id = 37,
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
                    Id = 38,
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
                    Id = 39,
                    FunctionCode = "HR_CONF_DISTRICT",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "District",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfWard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 40,
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
                    Id = 41,
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
                    Id = 42,
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
                    Id = 43,
                    FunctionCode = "HR_CONF_WARD",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Ward",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfReligion(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 44,
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
                    Id = 45,
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
                    Id = 46,
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
                    Id = 47,
                    FunctionCode = "HR_CONF_RELIGION",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Religion",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfEthnicity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 48,
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
                    Id = 49,
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
                    Id = 50,
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
                    Id = 51,
                    FunctionCode = "HR_CONF_ETHNICITY",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Ethnicity",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfNationality(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 52,
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
                    Id = 53,
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
                    Id = 54,
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
                    Id = 55,
                    FunctionCode = "HR_CONF_NATIONALITY",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Nationality",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfIdentification(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 92,
                    FunctionCode = "HR_CONF_IDENTIFICATION",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "IdentificationType",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 93,
                    FunctionCode = "HR_CONF_IDENTIFICATION",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "IdentificationType",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 94,
                    FunctionCode = "HR_CONF_IDENTIFICATION",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "IdentificationType",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 95,
                    FunctionCode = "HR_CONF_IDENTIFICATION",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "IdentificationType",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfEducation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 56,
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
                    Id = 57,
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
                    Id = 58,
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
                    Id = 59,
                    FunctionCode = "HR_CONF_EDUCATION",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Education",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfQualification(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 60,
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
                    Id = 61,
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
                    Id = 62,
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
                    Id = 63,
                    FunctionCode = "HR_CONF_QUALIFICATION",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "ProfessionalQualification",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfModelOfStudy(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 64,
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
                    Id = 65,
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
                    Id = 66,
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
                    Id = 67,
                    FunctionCode = "HR_CONF_MODEL_OF_STUDY",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "ModelOfStudy",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfRanking(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 68,
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
                    Id = 69,
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
                    Id = 70,
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
                    Id = 71,
                    FunctionCode = "HR_CONF_RANKING",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Ranking",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfRelationShip(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 72,
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
                    Id = 73,
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
                    Id = 74,
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
                    Id = 75,
                    FunctionCode = "HR_CONF_RELATIONSHIP",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "RelationshipType",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfContract(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 76,
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
                    Id = 77,
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
                    Id = 78,
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
                    Id = 79,
                    FunctionCode = "HR_CONF_CONTRACT",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "ContractType",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfWorkingStatus(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 80,
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
                    Id = 81,
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
                    Id = 82,
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
                    Id = 83,
                    FunctionCode = "HR_CONF_WORKING",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeWorkingStatus",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfApproveStatus(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 88,
                    FunctionCode = "HR_CONF_APPROVE_ST",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "ApproveStatus",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 89,
                    FunctionCode = "HR_CONF_APPROVE_ST",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "ApproveStatus",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 90,
                    FunctionCode = "HR_CONF_APPROVE_ST",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "ApproveStatus",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 91,
                    FunctionCode = "HR_CONF_APPROVE_ST",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "ApproveStatus",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        #endregion

        #region " [ Leave Management ] "

        #endregion

        #endregion

        public static void CreateDefaultFunctionModuleHR(this ModelBuilder modelBuilder)
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
                    Code = "HR_CONF_IDENTIFICATION",
                    Name = "IDENTIFICATION",
                    Url = "/configuration/identification",
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
                    Url = "/configuration/employee-status",
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
                },
                new Function()
                {
                    Code = "HR_CONF_APPROVE_ST",
                    Name = "APPROVE_STATUS",
                    Url = "/configuration/approve-status",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 14,
                    ModuleCode = "HR"
                }
            );

        }

    }
}
