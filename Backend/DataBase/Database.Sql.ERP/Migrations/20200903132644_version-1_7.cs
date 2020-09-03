using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version1_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                schema: "dbo",
                table: "Security_User",
                type: "datetime",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLogin",
                schema: "dbo",
                table: "Security_User");

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
        }
    }
}
