using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version1_0_10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Major",
                schema: "dbo");

            migrationBuilder.AddColumn<int>(
                name: "CurrentDepartmentId",
                schema: "dbo",
                table: "HR_Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentPositionId",
                schema: "dbo",
                table: "HR_Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Common_Certificated",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_Common_Certificated", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Common_Major",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
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
                    table.PrimaryKey("PK_Common_Major", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Common_School",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_Common_School", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_COMMENDATION",
                column: "Precedence",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_APPROVE_ST",
                column: "Precedence",
                value: 17);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_CONTRACT",
                column: "Precedence",
                value: 14);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_DISTRICT",
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_EDUCATION",
                column: "Precedence",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_ETHNICITY",
                column: "Precedence",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_IDENTIFICATION",
                column: "Precedence",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_JOB",
                column: "Precedence",
                value: 16);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_MODEL_OF_STUDY",
                column: "Precedence",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_NATIONALITY",
                column: "Precedence",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_PROVINCE",
                column: "Precedence",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_QUALIFICATION",
                column: "Precedence",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_RANKING",
                column: "Precedence",
                value: 12);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_RELATIONSHIP",
                column: "Precedence",
                value: 13);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_RELIGION",
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_WARD",
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_WORKING",
                column: "Precedence",
                value: 15);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONFIGURATION",
                column: "Precedence",
                value: 9);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_DASHBOARD",
                column: "Precedence",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_DEPARTMENT",
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_DISCIPLINE",
                column: "Precedence",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE",
                column: "Precedence",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_BANK",
                column: "Precedence",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_CERTIFICATION",
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_COMMENDATION",
                column: "Precedence",
                value: 9);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_CONTACT",
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_CONTRACT",
                column: "Precedence",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_DISCIPLINE",
                column: "Precedence",
                value: 10);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_EDUCATION",
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_IDENTIFICATION",
                column: "Precedence",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_PERSONAL_INFO",
                column: "Precedence",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_RELATIONSHIP",
                column: "Precedence",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_HOLIDAY",
                column: "Precedence",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_APPROVE_ST",
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_CALENDAR",
                column: "Precedence",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_MNT",
                column: "Precedence",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_NEW",
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_SUMMARY",
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_POSITION",
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_TEAM",
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "SYS_ACCOUNT",
                column: "Precedence",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "SYS_ROLE",
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "SYS_SYSTEM_ERROR",
                column: "Precedence",
                value: 2);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_Function",
                columns: new[] { "Code", "Icon", "ModuleCode", "Name", "ParentCode", "Precedence", "Url" },
                values: new object[,]
                {
                    { "HR_CONF_CERTIFICATED", "", "HR", "EDUCATION", "HR_CONFIGURATION", 8, "/configuration/certificated" },
                    { "HR_CONF_MAJOR", "", "HR", "MAJOR", "HR_CONFIGURATION", 10, "/configuration/major" },
                    { "HR_CONF_SCHOOL", "", "HR", "SCHOOL", "HR_CONFIGURATION", 9, "/configuration/school" }
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 2,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 3,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 4,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 5,
                column: "Precedence",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 6,
                column: "Precedence",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 7,
                column: "Precedence",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 9,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 10,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 11,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 13,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 14,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 15,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 17,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 18,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 19,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 21,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 22,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 23,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 25,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 26,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 27,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 29,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 30,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 31,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 33,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 34,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 35,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 37,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 38,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 39,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 41,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 42,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 43,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 45,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 46,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 47,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 49,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 50,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 51,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 53,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 54,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 55,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 57,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 58,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 59,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 61,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 62,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 63,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 65,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 66,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 67,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 69,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 70,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 71,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 73,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 74,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 75,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 77,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 78,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 79,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 81,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 82,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 83,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 85,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 86,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 87,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 89,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 90,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 91,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 93,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 94,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 95,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 97,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 99,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 100,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 101,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 103,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 104,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 105,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 107,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 108,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 109,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 111,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 112,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 113,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 115,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 116,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 117,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 119,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 120,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 121,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 123,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 124,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 125,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 127,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 128,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 129,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 131,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 132,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 133,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Module",
                keyColumn: "Code",
                keyValue: "DASHBOARD",
                column: "Precedence",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Module",
                keyColumn: "Code",
                keyValue: "HR",
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Module",
                keyColumn: "Code",
                keyValue: "SYSTEM",
                column: "Precedence",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "IsActive" },
                values: new object[] { new DateTime(2020, 11, 5, 6, 26, 42, 915, DateTimeKind.Local).AddTicks(1052), true });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "IsView", "ModuleName", "Name", "Precedence" },
                values: new object[] { 142, "GetList", "Certificated", "HR_CONF_CERTIFICATED", true, "HR", "VIEW", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "ModuleName", "Name", "Precedence" },
                values: new object[,]
                {
                    { 143, "Insert", "Certificated", "HR_CONF_CERTIFICATED", "HR", "INSERT", 2 },
                    { 144, "Update", "Certificated", "HR_CONF_CERTIFICATED", "HR", "UPDATE", 3 },
                    { 145, "Delete", "Certificated", "HR_CONF_CERTIFICATED", "HR", "DELETE", 4 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "IsView", "ModuleName", "Name", "Precedence" },
                values: new object[] { 138, "GetList", "School", "HR_CONF_SCHOOL", true, "HR", "VIEW", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "ModuleName", "Name", "Precedence" },
                values: new object[,]
                {
                    { 139, "Insert", "School", "HR_CONF_SCHOOL", "HR", "INSERT", 2 },
                    { 140, "Update", "School", "HR_CONF_SCHOOL", "HR", "UPDATE", 3 },
                    { 141, "Delete", "School", "HR_CONF_SCHOOL", "HR", "DELETE", 4 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "IsView", "ModuleName", "Name", "Precedence" },
                values: new object[] { 134, "GetList", "Major", "HR_CONF_MAJOR", true, "HR", "VIEW", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "ModuleName", "Name", "Precedence" },
                values: new object[,]
                {
                    { 135, "Insert", "Major", "HR_CONF_MAJOR", "HR", "INSERT", 2 },
                    { 136, "Update", "Major", "HR_CONF_MAJOR", "HR", "UPDATE", 3 },
                    { 137, "Delete", "Major", "HR_CONF_MAJOR", "HR", "DELETE", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Common_Certificated",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Common_Major",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Common_School",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_CERTIFICATED");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_MAJOR");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_SCHOOL");

            migrationBuilder.DropColumn(
                name: "CurrentDepartmentId",
                schema: "dbo",
                table: "HR_Employee");

            migrationBuilder.DropColumn(
                name: "CurrentPositionId",
                schema: "dbo",
                table: "HR_Employee");

            migrationBuilder.CreateTable(
                name: "HR_Major",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    RowVersion = table.Column<byte[]>(type: "timestamp", rowVersion: true, nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Major", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_COMMENDATION",
                column: "Precedence",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_APPROVE_ST",
                column: "Precedence",
                value: 14);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_CONTRACT",
                column: "Precedence",
                value: 12);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_DISTRICT",
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_EDUCATION",
                column: "Precedence",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_ETHNICITY",
                column: "Precedence",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_IDENTIFICATION",
                column: "Precedence",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_JOB",
                column: "Precedence",
                value: 14);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_MODEL_OF_STUDY",
                column: "Precedence",
                value: 9);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_NATIONALITY",
                column: "Precedence",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_PROVINCE",
                column: "Precedence",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_QUALIFICATION",
                column: "Precedence",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_RANKING",
                column: "Precedence",
                value: 10);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_RELATIONSHIP",
                column: "Precedence",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_RELIGION",
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_WARD",
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_WORKING",
                column: "Precedence",
                value: 13);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONFIGURATION",
                column: "Precedence",
                value: 9);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_DASHBOARD",
                column: "Precedence",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_DEPARTMENT",
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_DISCIPLINE",
                column: "Precedence",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE",
                column: "Precedence",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_BANK",
                column: "Precedence",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_CERTIFICATION",
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_COMMENDATION",
                column: "Precedence",
                value: 9);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_CONTACT",
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_CONTRACT",
                column: "Precedence",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_DISCIPLINE",
                column: "Precedence",
                value: 10);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_EDUCATION",
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_IDENTIFICATION",
                column: "Precedence",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_PERSONAL_INFO",
                column: "Precedence",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_RELATIONSHIP",
                column: "Precedence",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_HOLIDAY",
                column: "Precedence",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_APPROVE_ST",
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_CALENDAR",
                column: "Precedence",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_MNT",
                column: "Precedence",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_NEW",
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_SUMMARY",
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_POSITION",
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_TEAM",
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "SYS_ACCOUNT",
                column: "Precedence",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "SYS_ROLE",
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "SYS_SYSTEM_ERROR",
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 2,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 3,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 4,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 5,
                column: "Precedence",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 6,
                column: "Precedence",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 7,
                column: "Precedence",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 9,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 10,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 11,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 13,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 14,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 15,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 17,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 18,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 19,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 21,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 22,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 23,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 25,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 26,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 27,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 29,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 30,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 31,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 33,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 34,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 35,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 37,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 38,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 39,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 41,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 42,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 43,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 45,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 46,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 47,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 49,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 50,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 51,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 53,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 54,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 55,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 57,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 58,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 59,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 61,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 62,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 63,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 65,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 66,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 67,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 69,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 70,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 71,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 73,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 74,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 75,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 77,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 78,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 79,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 81,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 82,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 83,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 85,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 86,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 87,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 89,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 90,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 91,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 93,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 94,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 95,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 97,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 99,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 100,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 101,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 103,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 104,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 105,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 107,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 108,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 109,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 111,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 112,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 113,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 115,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 116,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 117,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 119,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 120,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 121,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 122,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 123,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 124,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 125,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 126,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 127,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 128,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 129,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 130,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 131,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 132,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 133,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Module",
                keyColumn: "Code",
                keyValue: "DASHBOARD",
                column: "Precedence",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Module",
                keyColumn: "Code",
                keyValue: "HR",
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Module",
                keyColumn: "Code",
                keyValue: "SYSTEM",
                column: "Precedence",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "IsActive" },
                values: new object[] { new DateTime(2020, 11, 3, 6, 29, 11, 92, DateTimeKind.Local).AddTicks(7277), true });
        }
    }
}
