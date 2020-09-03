using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version1_0_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Common_CodeType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TypeCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModuleCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    ModuleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_CodeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Common_District",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_District", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Common_File",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Size = table.Column<decimal>(type: "decimal(12, 0)", nullable: false),
                    MineType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Extension = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    SystemFileName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FilePath = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    FilePath32 = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    FilePath64 = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    FilePath128 = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    WaitForDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_File", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Common_ProfessionalQualification",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_ProfessionalQualification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Common_Province",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Common_Ward",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_Ward", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCommendation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Money = table.Column<decimal>(type: "money", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CommendationId = table.Column<int>(type: "int", nullable: false),
                    ProposerId = table.Column<int>(type: "int", nullable: false),
                    ProposeDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ApprovedStatus = table.Column<int>(type: "int", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCommendation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContract",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeProcessId = table.Column<int>(type: "int", nullable: false),
                    ContractTypeId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SignOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comment = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    GrossSalary = table.Column<decimal>(type: "money", nullable: false),
                    NetSalary = table.Column<decimal>(type: "money", nullable: false),
                    ContractStatusId = table.Column<int>(type: "int", nullable: true),
                    ContractStatusSignId = table.Column<int>(type: "int", nullable: true),
                    ContractStatusReason = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    ContractStatusDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContractStatusHistory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    SignId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    GrossSalary = table.Column<decimal>(type: "money", nullable: false),
                    NetSalary = table.Column<decimal>(type: "money", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContractStatusHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDiscipline",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Money = table.Column<decimal>(type: "money", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comment = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CommendationId = table.Column<int>(type: "int", nullable: false),
                    ProposerId = table.Column<int>(type: "int", nullable: false),
                    ProposeDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ApprovedStatusId = table.Column<int>(type: "int", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDiscipline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEducation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    SpecializedTrainingId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    TrainingTypeId = table.Column<int>(type: "int", nullable: false),
                    RankingId = table.Column<int>(type: "int", nullable: false),
                    ModelOfStudyId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEducation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeIdentification",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeIdentification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRelationship",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RelationshipTypeId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Mobile = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRelationship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_ApproveStatus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_ApproveStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_Commendation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Money = table.Column<decimal>(type: "money", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Commendation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_ContractType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 250, nullable: true),
                    AllowInsurance = table.Column<bool>(type: "bit", nullable: false),
                    AllowLeaveDate = table.Column<bool>(type: "bit", nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_ContractType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_Discipline",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Money = table.Column<decimal>(type: "money", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Discipline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_Education",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Education", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_Employee",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvatarFileId = table.Column<int>(type: "int", nullable: true),
                    EmployeeCode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    ProbationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StartWorkingDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    BadgeCardNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DateApplyBadge = table.Column<DateTime>(type: "datetime", nullable: true),
                    FingerSignNumber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    DateApplyFingerSign = table.Column<DateTime>(type: "datetime", nullable: true),
                    WorkingEmail = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    WorkingPhone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    EmployeeWorkingStatusId = table.Column<int>(type: "int", nullable: false),
                    BasicSalary = table.Column<decimal>(type: "money", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_EmployeeContact",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Mobile = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Skyper = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    TemporaryAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TemporaryWardId = table.Column<int>(type: "int", nullable: true),
                    TemporaryDistrictId = table.Column<int>(type: "int", nullable: false),
                    TemporaryCityId = table.Column<int>(type: "int", nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PermanentWardId = table.Column<int>(type: "int", nullable: false),
                    PermanentDistrictId = table.Column<int>(type: "int", nullable: true),
                    PermanentCityId = table.Column<int>(type: "int", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_EmployeeContact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_EmployeeInfo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    MaterialStatusId = table.Column<int>(type: "int", nullable: true),
                    ReligionId = table.Column<int>(type: "int", nullable: true),
                    EthnicityId = table.Column<int>(type: "int", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    AcademicLevelId = table.Column<int>(type: "int", nullable: true),
                    ProfessionalQualificationId = table.Column<int>(type: "int", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_EmployeeInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_EmployeeWorkingStatus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_EmployeeWorkingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_Ethnicity",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Ethnicity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_IdentificationType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_IdentificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_ModelOfStudy",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_ModelOfStudy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_Nationality",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Nationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_Position",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_Ranking",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Ranking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_RelationshipType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_RelationshipType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_Religion",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Religion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Security_Module",
                schema: "dbo",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Icon = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    ParentCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_Module", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Security_Role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Security_SessionLog",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "varchar(500)", nullable: false),
                    RefreshToken = table.Column<string>(type: "varchar(500)", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    LogoutTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ExpirationTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IPAddress = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Platform = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Browser = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    OSName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_SessionLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Security_User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 40, nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Secutiry_SystemLog",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    MessageTemplate = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secutiry_SystemLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training_Appraise",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training_Appraise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training_AppraiseAnswer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppraiseQuestionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Point = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training_AppraiseAnswer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training_AppraiseQuestion",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppraiseSectionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsInputAnswer = table.Column<bool>(type: "bit", nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training_AppraiseQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training_AppraiseSection",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppraiseId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training_AppraiseSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training_Lecturer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Mobile = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Fax = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    IsWorkInCenter = table.Column<bool>(type: "bit", nullable: false),
                    TrainingCenterId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training_Lecturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training_SpecializedTraining",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training_SpecializedTraining", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training_TrainingCenter",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TaxCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training_TrainingCenter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training_TrainingCenterContact",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Fax = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    TrainingCenterId = table.Column<int>(type: "int", nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training_TrainingCenterContact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training_TrainingCourse",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CompleteDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training_TrainingCourse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training_TrainingCourseDocument",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    TrainingCourseId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training_TrainingCourseDocument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training_TrainingType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training_TrainingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Security_Function",
                schema: "dbo",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Icon = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    ParentCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ModuleCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_Function", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Security_Function_Security_Module_ModuleCode",
                        column: x => x.ModuleCode,
                        principalSchema: "dbo",
                        principalTable: "Security_Module",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Security_UserRole",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Security_UserRole_Security_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Security_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Security_UserRole_Security_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Security_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Security_FunctionCommand",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FunctionCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsView = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ModuleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ControllerName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ActionName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_FunctionCommand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Security_FunctionCommand_Security_Function_FunctionCode",
                        column: x => x.FunctionCode,
                        principalSchema: "dbo",
                        principalTable: "Security_Function",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Security_RoleDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CommandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security_RoleDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Security_RoleDetail_Security_FunctionCommand_CommandId",
                        column: x => x.CommandId,
                        principalSchema: "dbo",
                        principalTable: "Security_FunctionCommand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Security_RoleDetail_Security_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Security_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "HR_Employee",
                columns: new[] { "Id", "AvatarFileId", "BadgeCardNumber", "BasicSalary", "CreateBy", "DateApplyBadge", "DateApplyFingerSign", "EmployeeCode", "EmployeeWorkingStatusId", "FingerSignNumber", "ProbationDate", "StartWorkingDate", "UpdateBy", "UpdateDate", "WorkingEmail", "WorkingPhone" },
                values: new object[] { 1, null, null, 0m, 0, null, null, "SYSTEM", 1, null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "HR_EmployeeInfo",
                columns: new[] { "Id", "AcademicLevelId", "CreateBy", "DateOfBirth", "EmployeeId", "EthnicityId", "ExpirationDate", "FirstName", "Gender", "LastName", "MaterialStatusId", "NationalityId", "ProfessionalQualificationId", "ReligionId", "UpdateBy", "UpdateDate" },
                values: new object[] { 1, null, 0, null, 1, null, null, "Sys", null, "Admin", null, null, null, null, null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "HR_EmployeeWorkingStatus",
                columns: new[] { "Id", "Code", "CreateBy", "Description", "Name", "UpdateBy", "UpdateDate" },
                values: new object[] { 1, "Sys", 0, null, "System", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_Module",
                columns: new[] { "Code", "Icon", "Name", "ParentCode", "Precedence", "Url" },
                values: new object[,]
                {
                    { "DASHBOARD", "", "DASHBOARD", "", 1, "/dashboard" },
                    { "HR", "", "HR", "", 2, "/hr" },
                    { "SYSTEM", "", "SYSTEM", "", 5, "/system" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_User",
                columns: new[] { "Id", "CreateBy", "EmployeeId", "LastLogin", "Password", "UpdateBy", "UpdateDate", "UserName" },
                values: new object[] { 1, 0, 1, null, "NTZFMjNDNTNCNjVFMjdGMjM3NDIyOTkwRTI5MjJFNzA0RkE2MTJBQzQ3OEE3NjA4NUI5QkQxMTU1OTBDNTgyMw==", null, null, "sysadmin" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_Function",
                columns: new[] { "Code", "Icon", "ModuleCode", "Name", "ParentCode", "Precedence", "Url" },
                values: new object[,]
                {
                    { "HR_DASHBOARD", "", "HR", "DASHBOARD", "", 1, "/dashboard" },
                    { "SYS_ACCOUNT", "", "SYSTEM", "ACCOUNT", "", 1, "/account" },
                    { "HR_CONF_JOB", "", "HR", "JOB_TITLE", "HR_CONFIGURATION", 14, "/configuration/job-title" },
                    { "HR_CONF_WORKING", "", "HR", "WORKING_STATUS", "HR_CONFIGURATION", 13, "/configuration/working-status" },
                    { "HR_CONF_CONTRACT", "", "HR", "CONTRACT_TYPE", "HR_CONFIGURATION", 12, "/configuration/contract-type" },
                    { "HR_CONF_RELATIONSHIP", "", "HR", "RELATIONSHIP_TYPE", "HR_CONFIGURATION", 11, "/configuration/relationship-type" },
                    { "HR_CONF_RANKING", "", "HR", "RANKING", "HR_CONFIGURATION", 10, "/configuration/ranking" },
                    { "HR_CONF_MODEL_OF_STUDY", "", "HR", "MODEL_OF_STUDY", "HR_CONFIGURATION", 9, "/configuration/model-of-study" },
                    { "HR_CONF_QUALIFICATION", "", "HR", "QUALIFICATION", "HR_CONFIGURATION", 8, "/configuration/qualification" },
                    { "HR_CONF_EDUCATION", "", "HR", "EDUCATION", "HR_CONFIGURATION", 7, "/configuration/education" },
                    { "HR_CONF_NATIONALITY", "", "HR", "NATIONALITY", "HR_CONFIGURATION", 6, "/configuration/nationality" },
                    { "HR_CONF_ETHNICITY", "", "HR", "ETHNICITY", "HR_CONFIGURATION", 5, "/configuration/ethnicity" },
                    { "HR_CONF_RELIGION", "", "HR", "RELIGION", "HR_CONFIGURATION", 4, "/configuration/religion" },
                    { "HR_CONF_WARD", "", "HR", "WARD", "HR_CONFIGURATION", 3, "/configuration/ward" },
                    { "SYS_ROLE", "", "SYSTEM", "ROLE", "", 2, "/role" },
                    { "HR_CONF_DISTRICT", "", "HR", "DISTRICT", "HR_CONFIGURATION", 2, "/configuration/district" },
                    { "HR_CONFIGURATION", "", "HR", "CONFIGURATION", "", 9, "/configuration" },
                    { "HR_HOLIDAY", "", "HR", "HOLIDAY", "", 8, "/holiday" },
                    { "HR_LEAVE_APPROVE_ST", "", "HR", "APPROVE_STATUS", "HR_LEAVE_MNT", 4, "/leave-management/approve-status" },
                    { "HR_LEAVE_NEW", "", "HR", "NEW", "HR_LEAVE_MNT", 3, "/leave-management/new" },
                    { "HR_LEAVE_SUMMARY", "", "HR", "SUMMARY", "HR_LEAVE_MNT", 2, "/leave-management/summary" },
                    { "HR_LEAVE_CALENDAR", "", "HR", "CALENDAR", "HR_LEAVE_MNT", 1, "/leave-management/calendar" },
                    { "HR_LEAVE_MNT", "", "HR", "LEAVE_MANAGEMENT", "", 7, "/leave-management" },
                    { "HR_EMPLOYEE", "", "HR", "EMPLOYEE", "", 6, "/employee" },
                    { "HR_DISCIPLINE", "", "HR", "DISCIPLINE", "", 6, "/discipline" },
                    { "HR_COMMENDATION", "", "HR", "COMMENDATION", "", 5, "/commendation" },
                    { "HR_POSITION", "", "HR", "POSITION", "", 4, "/position" },
                    { "HR_TEAM", "", "HR", "TEAM", "", 3, "/team" },
                    { "HR_DEPARTMENT", "", "HR", "DASHBOARD", "", 2, "/department" },
                    { "HR_CONF_PROVINCE", "", "HR", "PROVINCE", "HR_CONFIGURATION", 1, "/configuration/province" },
                    { "SYS_SYSTEM_ERROR", "", "SYSTEM", "SYSTEM_ERROR", "", 2, "/system-error" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_ApproveStatus_Code",
                schema: "dbo",
                table: "HR_ApproveStatus",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_ContractType_Code",
                schema: "dbo",
                table: "HR_ContractType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HR_EmployeeWorkingStatus_Code",
                schema: "dbo",
                table: "HR_EmployeeWorkingStatus",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Security_Function_ModuleCode",
                schema: "dbo",
                table: "Security_Function",
                column: "ModuleCode");

            migrationBuilder.CreateIndex(
                name: "IX_Security_FunctionCommand_FunctionCode",
                schema: "dbo",
                table: "Security_FunctionCommand",
                column: "FunctionCode");

            migrationBuilder.CreateIndex(
                name: "IX_Security_RoleDetail_CommandId",
                schema: "dbo",
                table: "Security_RoleDetail",
                column: "CommandId");

            migrationBuilder.CreateIndex(
                name: "IX_Security_RoleDetail_RoleId",
                schema: "dbo",
                table: "Security_RoleDetail",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Security_UserRole_RoleId",
                schema: "dbo",
                table: "Security_UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Security_UserRole_UserId",
                schema: "dbo",
                table: "Security_UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Common_CodeType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Common_District",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Common_File",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Common_ProfessionalQualification",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Common_Province",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Common_Ward",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeCommendation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeContract",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeContractStatusHistory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeDiscipline",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeEducation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeIdentification",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeRelationship",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_ApproveStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_Commendation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_ContractType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_Discipline",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_Education",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_Employee",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_EmployeeContact",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_EmployeeInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_EmployeeWorkingStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_Ethnicity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_IdentificationType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_ModelOfStudy",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_Nationality",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_Position",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_Ranking",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_RelationshipType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_Religion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Security_RoleDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Security_SessionLog",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Security_UserRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Secutiry_SystemLog",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Training_Appraise",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Training_AppraiseAnswer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Training_AppraiseQuestion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Training_AppraiseSection",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Training_Lecturer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Training_SpecializedTraining",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Training_TrainingCenter",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Training_TrainingCenterContact",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Training_TrainingCourse",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Training_TrainingCourseDocument",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Training_TrainingType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Security_FunctionCommand",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Security_Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Security_User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Security_Function",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Security_Module",
                schema: "dbo");
        }
    }
}
