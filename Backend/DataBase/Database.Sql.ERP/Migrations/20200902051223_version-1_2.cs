using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version1_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FunctionCode",
                schema: "dbo",
                table: "Security_RoleDetail");

            migrationBuilder.DropColumn(
                name: "ModuleCode",
                schema: "dbo",
                table: "Security_RoleDetail");

            migrationBuilder.AlterColumn<string>(
                name: "FunctionCode",
                schema: "dbo",
                table: "Security_FunctionCommand",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "dbo",
                table: "Security_Function",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_Function",
                columns: new[] { "Code", "Icon", "ModuleCode", "Name", "ParentCode", "Precedence", "Url" },
                values: new object[,]
                {
                    { "HR_DASHBOARD", "", "HR", "DASHBOARD", "", 1, "/dashboard" },
                    { "SYS_SYSTEM_ERROR", "", "SYSTEM", "SYSTEM_ERROR", "", 2, "/system-error" },
                    { "SYS_ROLE", "", "SYSTEM", "ROLE", "", 2, "/role" },
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
                    { "HR_LEAVE_MNT", "", "HR", "LEAVE_MANAGEMENT", "", 7, "/leave-management" },
                    { "HR_CONF_PROVINCE", "", "HR", "PROVINCE", "HR_CONFIGURATION", 1, "/configuration/province" },
                    { "HR_CONFIGURATION", "", "HR", "CONFIGURATION", "", 9, "/configuration" },
                    { "HR_HOLIDAY", "", "HR", "HOLIDAY", "", 8, "/holiday" },
                    { "HR_LEAVE_APPROVE_ST", "", "HR", "APPROVE_STATUS", "HR_LEAVE_MNT", 4, "/leave-management/approve-status" },
                    { "HR_LEAVE_NEW", "", "HR", "NEW", "HR_LEAVE_MNT", 3, "/leave-management/new" },
                    { "HR_LEAVE_SUMMARY", "", "HR", "SUMMARY", "HR_LEAVE_MNT", 2, "/leave-management/summary" },
                    { "HR_LEAVE_CALENDAR", "", "HR", "CALENDAR", "HR_LEAVE_MNT", 1, "/leave-management/calendar" },
                    { "HR_CONF_DISTRICT", "", "HR", "DISTRICT", "HR_CONFIGURATION", 2, "/configuration/district" },
                    { "HR_EMPLOYEE", "", "HR", "EMPLOYEE", "", 6, "/employee" },
                    { "HR_DISCIPLINE", "", "HR", "DISCIPLINE", "", 6, "/discipline" },
                    { "HR_COMMENDATION", "", "HR", "COMMENDATION", "", 5, "/commendation" },
                    { "HR_POSITION", "", "HR", "POSITION", "", 4, "/position" },
                    { "HR_TEAM", "", "HR", "TEAM", "", 3, "/team" },
                    { "HR_DEPARTMENT", "", "HR", "DASHBOARD", "", 2, "/department" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_Module",
                columns: new[] { "Code", "Icon", "Name", "ParentCode", "Precedence", "Url" },
                values: new object[,]
                {
                    { "HR", "", "HR", "", 2, "/hr" },
                    { "DASHBOARD", "", "DASHBOARD", "", 1, "/dashboard" },
                    { "SYSTEM", "", "SYSTEM", "", 5, "/system" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_COMMENDATION");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_CONTRACT");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_DISTRICT");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_EDUCATION");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_ETHNICITY");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_JOB");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_MODEL_OF_STUDY");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_NATIONALITY");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_PROVINCE");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_QUALIFICATION");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_RANKING");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_RELATIONSHIP");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_RELIGION");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_WARD");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONF_WORKING");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_CONFIGURATION");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_DASHBOARD");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_DEPARTMENT");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_DISCIPLINE");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_HOLIDAY");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_APPROVE_ST");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_CALENDAR");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_MNT");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_NEW");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_SUMMARY");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_POSITION");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_TEAM");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "SYS_ACCOUNT");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "SYS_ROLE");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "SYS_SYSTEM_ERROR");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Module",
                keyColumn: "Code",
                keyValue: "DASHBOARD");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Module",
                keyColumn: "Code",
                keyValue: "HR");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Module",
                keyColumn: "Code",
                keyValue: "SYSTEM");

            migrationBuilder.AddColumn<string>(
                name: "FunctionCode",
                schema: "dbo",
                table: "Security_RoleDetail",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModuleCode",
                schema: "dbo",
                table: "Security_RoleDetail",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FunctionCode",
                schema: "dbo",
                table: "Security_FunctionCommand",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "dbo",
                table: "Security_Function",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);
        }
    }
}
