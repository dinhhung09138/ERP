using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version1_0_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                value: 20);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_CERTIFICATED",
                column: "Precedence",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_CONTRACT",
                column: "Precedence",
                value: 17);

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
                value: 9);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_ETHNICITY",
                column: "Precedence",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_IDENTIFICATION",
                column: "Precedence",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_JOB",
                column: "Precedence",
                value: 19);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_MAJOR",
                column: "Precedence",
                value: 13);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_MARITAL",
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_MODEL_OF_STUDY",
                column: "Precedence",
                value: 14);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_NATIONALITY",
                column: "Precedence",
                value: 7);

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
                value: 10);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_RANKING",
                column: "Precedence",
                value: 15);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_RELATIONSHIP",
                column: "Precedence",
                value: 16);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_RELIGION",
                column: "Precedence",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_SCHOOL",
                column: "Precedence",
                value: 12);

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
                value: 18);

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
                keyValue: "HR_EMPLOYEE_CERTIFICATE",
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
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 135,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 136,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 137,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 139,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 140,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 141,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 143,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 144,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 145,
                column: "Precedence",
                value: 4);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "ModuleName", "Name", "Precedence" },
                values: new object[,]
                {
                    { 149, "Delete", "MaritalStatus", "HR_CONF_MARITAL", "Common", "DELETE", 4 },
                    { 148, "Update", "MaritalStatus", "HR_CONF_MARITAL", "Common", "UPDATE", 3 },
                    { 147, "Insert", "MaritalStatus", "HR_CONF_MARITAL", "Common", "INSERT", 2 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "IsView", "ModuleName", "Name", "Precedence" },
                values: new object[] { 146, "GetList", "MaritalStatus", "HR_CONF_MARITAL", true, "Common", "VIEW", 1 });

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
                values: new object[] { new DateTime(2020, 11, 11, 7, 18, 22, 892, DateTimeKind.Local).AddTicks(8842), true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 149);

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
                value: 20);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_CERTIFICATED",
                column: "Precedence",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_CONTRACT",
                column: "Precedence",
                value: 17);

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
                value: 9);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_ETHNICITY",
                column: "Precedence",
                value: 6);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_IDENTIFICATION",
                column: "Precedence",
                value: 8);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_JOB",
                column: "Precedence",
                value: 19);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_MAJOR",
                column: "Precedence",
                value: 13);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_MARITAL",
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_MODEL_OF_STUDY",
                column: "Precedence",
                value: 14);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_NATIONALITY",
                column: "Precedence",
                value: 7);

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
                value: 10);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_RANKING",
                column: "Precedence",
                value: 15);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_RELATIONSHIP",
                column: "Precedence",
                value: 16);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_RELIGION",
                column: "Precedence",
                value: 5);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_SCHOOL",
                column: "Precedence",
                value: 12);

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
                value: 18);

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
                keyValue: "HR_EMPLOYEE_CERTIFICATE",
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
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 134,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 135,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 136,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 137,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 138,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 139,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 140,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 141,
                column: "Precedence",
                value: 4);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 142,
                columns: new[] { "IsView", "Precedence" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 143,
                column: "Precedence",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 144,
                column: "Precedence",
                value: 3);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 145,
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
                values: new object[] { new DateTime(2020, 11, 11, 7, 11, 38, 531, DateTimeKind.Local).AddTicks(4550), true });
        }
    }
}
