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
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

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

            modelBuilder.Entity<EmployeeBank>(entity =>
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

            modelBuilder.Entity<EmployeeDependency>(entity =>
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

            modelBuilder.Entity<EmployeeCertificate>(entity =>
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
            modelBuilder.CreateDefaultCommandConfMaritalStatus();
            modelBuilder.CreateDefaultCommandConfRelationShip();
            modelBuilder.CreateDefaultCommandConfContract();
            modelBuilder.CreateDefaultCommandConfWorkingStatus();
            modelBuilder.CreateDefaultCommandConfApproveStatus();
            modelBuilder.CreateDefaultCommandConfMajor();
            modelBuilder.CreateDefaultCommandConfSchool();
            modelBuilder.CreateDefaultCommandConfCertificated();
            modelBuilder.CreateDefaultCommandConfBank();
            modelBuilder.CreateDefaultCommandEmployee();
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
                    ActionName = "List",
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
                    ActionName = "List",
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
                    ActionName = "List",
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
                    ActionName = "List",
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
                    ActionName = "List",
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
                    ModuleName = "Common",
                    ControllerName = "Province",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 33,
                    FunctionCode = "HR_CONF_PROVINCE",
                    Name = "INSERT",
                    ModuleName = "Common",
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
                    ModuleName = "Common",
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
                    ModuleName = "Common",
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
                    ModuleName = "Common",
                    ControllerName = "District",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 37,
                    FunctionCode = "HR_CONF_DISTRICT",
                    Name = "INSERT",
                    ModuleName = "Common",
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
                    ModuleName = "Common",
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
                    ModuleName = "Common",
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
                    ModuleName = "Common",
                    ControllerName = "Ward",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 41,
                    FunctionCode = "HR_CONF_WARD",
                    Name = "INSERT",
                    ModuleName = "Common",
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
                    ModuleName = "Common",
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
                    ModuleName = "Common",
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
                    ActionName = "List",
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
                    ActionName = "List",
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
                    ActionName = "List",
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
                    ActionName = "List",
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
                    ActionName = "List",
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
                    ModuleName = "Common",
                    ControllerName = "ProfessionalQualification",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 61,
                    FunctionCode = "HR_CONF_QUALIFICATION",
                    Name = "INSERT",
                    ModuleName = "Common",
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
                    ModuleName = "Common",
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
                    ModuleName = "Common",
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
                    ActionName = "List",
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
                    ActionName = "List",
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

        private static void CreateDefaultCommandConfMaritalStatus(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 146,
                    FunctionCode = "HR_CONF_MARITAL",
                    Name = "VIEW",
                    ModuleName = "Common",
                    ControllerName = "MaritalStatus",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 147,
                    FunctionCode = "HR_CONF_MARITAL",
                    Name = "INSERT",
                    ModuleName = "Common",
                    ControllerName = "MaritalStatus",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 148,
                    FunctionCode = "HR_CONF_MARITAL",
                    Name = "UPDATE",
                    ModuleName = "Common",
                    ControllerName = "MaritalStatus",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 149,
                    FunctionCode = "HR_CONF_MARITAL",
                    Name = "DELETE",
                    ModuleName = "Common",
                    ControllerName = "MaritalStatus",
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
                    ActionName = "List",
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
                    ActionName = "List",
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
                    ActionName = "List",
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
                    ActionName = "List",
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

        private static void CreateDefaultCommandConfMajor(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 134,
                    FunctionCode = "HR_CONF_MAJOR",
                    Name = "VIEW",
                    ModuleName = "Common",
                    ControllerName = "Major",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 135,
                    FunctionCode = "HR_CONF_MAJOR",
                    Name = "INSERT",
                    ModuleName = "Common",
                    ControllerName = "Major",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 136,
                    FunctionCode = "HR_CONF_MAJOR",
                    Name = "UPDATE",
                    ModuleName = "Common",
                    ControllerName = "Major",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 137,
                    FunctionCode = "HR_CONF_MAJOR",
                    Name = "DELETE",
                    ModuleName = "Common",
                    ControllerName = "Major",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfSchool(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 138,
                    FunctionCode = "HR_CONF_SCHOOL",
                    Name = "VIEW",
                    ModuleName = "Common",
                    ControllerName = "School",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 139,
                    FunctionCode = "HR_CONF_SCHOOL",
                    Name = "INSERT",
                    ModuleName = "Common",
                    ControllerName = "School",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 140,
                    FunctionCode = "HR_CONF_SCHOOL",
                    Name = "UPDATE",
                    ModuleName = "Common",
                    ControllerName = "School",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 141,
                    FunctionCode = "HR_CONF_SCHOOL",
                    Name = "DELETE",
                    ModuleName = "Common",
                    ControllerName = "School",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfCertificated(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 142,
                    FunctionCode = "HR_CONF_CERTIFICATED",
                    Name = "VIEW",
                    ModuleName = "Common",
                    ControllerName = "Certificated",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 143,
                    FunctionCode = "HR_CONF_CERTIFICATED",
                    Name = "INSERT",
                    ModuleName = "Common",
                    ControllerName = "Certificated",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 144,
                    FunctionCode = "HR_CONF_CERTIFICATED",
                    Name = "UPDATE",
                    ModuleName = "Common",
                    ControllerName = "Certificated",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 145,
                    FunctionCode = "HR_CONF_CERTIFICATED",
                    Name = "DELETE",
                    ModuleName = "Common",
                    ControllerName = "Certificated",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        private static void CreateDefaultCommandConfBank(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 150,
                    FunctionCode = "HR_CONF_BANK",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Bank",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 151,
                    FunctionCode = "HR_CONF_BANK",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "Bank",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 152,
                    FunctionCode = "HR_CONF_BANK",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "Bank",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 153,
                    FunctionCode = "HR_CONF_BANK",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Bank",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        #endregion

        #region " [ Leave Management ] "

        #endregion

        private static void CreateDefaultCommandEmployee(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 84,
                    FunctionCode = "HR_EMPLOYEE",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "Employee",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 85,
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
                    Id = 86,
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
                    Id = 87,
                    FunctionCode = "HR_EMPLOYEE",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "Employee",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 96,
                    FunctionCode = "HR_EMPLOYEE_PERSONAL_INFO",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "EmployeeInfo",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 97,
                    FunctionCode = "HR_EMPLOYEE_PERSONAL_INFO",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeInfo",
                    ActionName = "Update",
                    Precedence = 4,
                    IsView = false,
                }
            );
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 98,
                    FunctionCode = "HR_EMPLOYEE_CONTACT",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "EmployeeContact",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 99,
                    FunctionCode = "HR_EMPLOYEE_CONTACT",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "EmployeeContact",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 100,
                    FunctionCode = "HR_EMPLOYEE_CONTACT",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeContact",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 101,
                    FunctionCode = "HR_EMPLOYEE_CONTACT",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeContact",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 102,
                    FunctionCode = "HR_EMPLOYEE_EDUCATION",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "EmployeeEducation",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 103,
                    FunctionCode = "HR_EMPLOYEE_EDUCATION",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "EmployeeEducation",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 104,
                    FunctionCode = "HR_EMPLOYEE_EDUCATION",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeEducation",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 105,
                    FunctionCode = "HR_EMPLOYEE_EDUCATION",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeEducation",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 106,
                    FunctionCode = "HR_EMPLOYEE_CERTIFICATE",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "EmployeeCertificate",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 107,
                    FunctionCode = "HR_EMPLOYEE_CERTIFICATE",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "EmployeeCertificate",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 108,
                    FunctionCode = "HR_EMPLOYEE_CERTIFICATE",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeCertificate",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 109,
                    FunctionCode = "HR_EMPLOYEE_CERTIFICATE",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeCertificate",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 110,
                    FunctionCode = "HR_EMPLOYEE_IDENTIFICATION",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "EmployeeIdentification",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 111,
                    FunctionCode = "HR_EMPLOYEE_IDENTIFICATION",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "EmployeeIdentification",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 112,
                    FunctionCode = "HR_EMPLOYEE_IDENTIFICATION",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeIdentification",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 113,
                    FunctionCode = "HR_EMPLOYEE_IDENTIFICATION",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeIdentification",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 114,
                    FunctionCode = "HR_EMPLOYEE_BANK",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "EmployeeBank",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 115,
                    FunctionCode = "HR_EMPLOYEE_BANK",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "EmployeeBank",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 116,
                    FunctionCode = "HR_EMPLOYEE_BANK",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeBank",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 117,
                    FunctionCode = "HR_EMPLOYEE_BANK",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeBank",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 118,
                    FunctionCode = "HR_EMPLOYEE_RELATIONSHIP",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "EmployeeRelationship",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 119,
                    FunctionCode = "HR_EMPLOYEE_RELATIONSHIP",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "EmployeeRelationship",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 120,
                    FunctionCode = "HR_EMPLOYEE_RELATIONSHIP",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeRelationship",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 121,
                    FunctionCode = "HR_EMPLOYEE_RELATIONSHIP",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeRelationship",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 122,
                    FunctionCode = "HR_EMPLOYEE_CONTRACT",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "EmployeeContract",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 123,
                    FunctionCode = "HR_EMPLOYEE_CONTRACT",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "EmployeeContract",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 124,
                    FunctionCode = "HR_EMPLOYEE_CONTRACT",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeContract",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 125,
                    FunctionCode = "HR_EMPLOYEE_CONTRACT",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeContract",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 126,
                    FunctionCode = "HR_EMPLOYEE_COMMENDATION",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "EmployeeCommendation",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 127,
                    FunctionCode = "HR_EMPLOYEE_COMMENDATION",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "EmployeeCommendation",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 128,
                    FunctionCode = "HR_EMPLOYEE_COMMENDATION",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeCommendation",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 129,
                    FunctionCode = "HR_EMPLOYEE_COMMENDATION",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeCommendation",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 130,
                    FunctionCode = "HR_EMPLOYEE_DISCIPLINE",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "EmployeeDiscipline",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 131,
                    FunctionCode = "HR_EMPLOYEE_DISCIPLINE",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "EmployeeDiscipline",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 132,
                    FunctionCode = "HR_EMPLOYEE_DISCIPLINE",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeDiscipline",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 133,
                    FunctionCode = "HR_EMPLOYEE_DISCIPLINE",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeDiscipline",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 154,
                    FunctionCode = "HR_EMPLOYEE_DEPENDENCY",
                    Name = "VIEW",
                    ModuleName = "HR",
                    ControllerName = "EmployeeDependency",
                    ActionName = "List",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 155,
                    FunctionCode = "HR_EMPLOYEE_DEPENDENCY",
                    Name = "INSERT",
                    ModuleName = "HR",
                    ControllerName = "EmployeeDependency",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 156,
                    FunctionCode = "HR_EMPLOYEE_DEPENDENCY",
                    Name = "UPDATE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeDependency",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 157,
                    FunctionCode = "HR_EMPLOYEE_DEPENDENCY",
                    Name = "DELETE",
                    ModuleName = "HR",
                    ControllerName = "EmployeeDependency",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        #endregion


        #region "[ Default module ]"

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
                    Code = "HR_CONF_BANK",
                    Name = "BANK",
                    Url = "/configuration/bank",
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
                    Code = "HR_CONF_MARITAL",
                    Name = "MARITAL",
                    Url = "/configuration/marital-status",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 4,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_RELIGION",
                    Name = "RELIGION",
                    Url = "/configuration/religion",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 5,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_ETHNICITY",
                    Name = "ETHNICITY",
                    Url = "/configuration/ethnicity",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 6,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_NATIONALITY",
                    Name = "NATIONALITY",
                    Url = "/configuration/nationality",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 7,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_IDENTIFICATION",
                    Name = "IDENTIFICATION",
                    Url = "/configuration/identification",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 8,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_EDUCATION",
                    Name = "EDUCATION",
                    Url = "/configuration/education",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 9,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_QUALIFICATION",
                    Name = "QUALIFICATION",
                    Url = "/configuration/qualification",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 10,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_CERTIFICATED",
                    Name = "CERTIFICATED",
                    Url = "/configuration/certificated",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 11,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_SCHOOL",
                    Name = "SCHOOL",
                    Url = "/configuration/school",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 12,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_MAJOR",
                    Name = "MAJOR",
                    Url = "/configuration/major",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 13,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_MODEL_OF_STUDY",
                    Name = "MODEL_OF_STUDY",
                    Url = "/configuration/model-of-study",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 14,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_RANKING",
                    Name = "RANKING",
                    Url = "/configuration/ranking",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 15,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_RELATIONSHIP",
                    Name = "RELATIONSHIP_TYPE",
                    Url = "/configuration/relationship-type",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 16,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_CONTRACT",
                    Name = "CONTRACT_TYPE",
                    Url = "/configuration/contract-type",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 17,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_WORKING",
                    Name = "WORKING_STATUS",
                    Url = "/configuration/employee-status",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 18,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_JOB",
                    Name = "JOB_TITLE",
                    Url = "/configuration/job-title",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 19,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_CONF_APPROVE_ST",
                    Name = "APPROVE_STATUS",
                    Url = "/configuration/approve-status",
                    Icon = string.Empty,
                    ParentCode = "HR_CONFIGURATION",
                    Precedence = 20,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_EMPLOYEE_PERSONAL_INFO",
                    Name = "PERSONAL_INFO",
                    Url = "#personalInfo",
                    Icon = string.Empty,
                    ParentCode = "HR_EMPLOYEE",
                    Precedence = 1,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_EMPLOYEE_CONTACT",
                    Name = "CONTACT",
                    Url = "#contact",
                    Icon = string.Empty,
                    ParentCode = "HR_EMPLOYEE",
                    Precedence = 2,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_EMPLOYEE_EDUCATION",
                    Name = "EDUCATION",
                    Url = "#education",
                    Icon = string.Empty,
                    ParentCode = "HR_EMPLOYEE",
                    Precedence = 3,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_EMPLOYEE_CERTIFICATE",
                    Name = "CERTIFICATION",
                    Url = "#certification",
                    Icon = string.Empty,
                    ParentCode = "HR_EMPLOYEE",
                    Precedence = 4,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_EMPLOYEE_IDENTIFICATION",
                    Name = "IDENTIFICATION",
                    Url = "#identification",
                    Icon = string.Empty,
                    ParentCode = "HR_EMPLOYEE",
                    Precedence = 5,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_EMPLOYEE_BANK",
                    Name = "BANK",
                    Url = "#bank",
                    Icon = string.Empty,
                    ParentCode = "HR_EMPLOYEE",
                    Precedence = 6,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_EMPLOYEE_RELATIONSHIP",
                    Name = "RELATIONSHIP",
                    Url = "#relationship",
                    Icon = string.Empty,
                    ParentCode = "HR_EMPLOYEE",
                    Precedence = 7,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_EMPLOYEE_DEPENDENCY",
                    Name = "DEPENDENCY",
                    Url = "#dependency",
                    Icon = string.Empty,
                    ParentCode = "HR_EMPLOYEE",
                    Precedence = 8,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_EMPLOYEE_CONTRACT",
                    Name = "CONTRACT",
                    Url = "#contract",
                    Icon = string.Empty,
                    ParentCode = "HR_EMPLOYEE",
                    Precedence = 9,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_EMPLOYEE_COMMENDATION",
                    Name = "COMMENDATION",
                    Url = "#commendation",
                    Icon = string.Empty,
                    ParentCode = "HR_EMPLOYEE",
                    Precedence = 10,
                    ModuleCode = "HR"
                },
                new Function()
                {
                    Code = "HR_EMPLOYEE_DISCIPLINE",
                    Name = "DISCIPLINE",
                    Url = "#discipline",
                    Icon = string.Empty,
                    ParentCode = "HR_EMPLOYEE",
                    Precedence = 11,
                    ModuleCode = "HR"
                }
            );

        }

        #endregion
    }
}
