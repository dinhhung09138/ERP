using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version1_5 : Migration
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
                name: "IX_Security_FunctionCommand_FunctionCode",
                schema: "dbo",
                table: "Security_FunctionCommand",
                column: "FunctionCode");

            migrationBuilder.CreateIndex(
                name: "IX_Security_Function_ModuleCode",
                schema: "dbo",
                table: "Security_Function",
                column: "ModuleCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Security_Function_Security_Module_ModuleCode",
                schema: "dbo",
                table: "Security_Function",
                column: "ModuleCode",
                principalSchema: "dbo",
                principalTable: "Security_Module",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Security_FunctionCommand_Security_Function_FunctionCode",
                schema: "dbo",
                table: "Security_FunctionCommand",
                column: "FunctionCode",
                principalSchema: "dbo",
                principalTable: "Security_Function",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Security_RoleDetail_Security_FunctionCommand_CommandId",
                schema: "dbo",
                table: "Security_RoleDetail",
                column: "CommandId",
                principalSchema: "dbo",
                principalTable: "Security_FunctionCommand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Security_RoleDetail_Security_Role_RoleId",
                schema: "dbo",
                table: "Security_RoleDetail",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "Security_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Security_Function_Security_Module_ModuleCode",
                schema: "dbo",
                table: "Security_Function");

            migrationBuilder.DropForeignKey(
                name: "FK_Security_FunctionCommand_Security_Function_FunctionCode",
                schema: "dbo",
                table: "Security_FunctionCommand");

            migrationBuilder.DropForeignKey(
                name: "FK_Security_RoleDetail_Security_FunctionCommand_CommandId",
                schema: "dbo",
                table: "Security_RoleDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Security_RoleDetail_Security_Role_RoleId",
                schema: "dbo",
                table: "Security_RoleDetail");

            migrationBuilder.DropIndex(
                name: "IX_Security_RoleDetail_CommandId",
                schema: "dbo",
                table: "Security_RoleDetail");

            migrationBuilder.DropIndex(
                name: "IX_Security_RoleDetail_RoleId",
                schema: "dbo",
                table: "Security_RoleDetail");

            migrationBuilder.DropIndex(
                name: "IX_Security_FunctionCommand_FunctionCode",
                schema: "dbo",
                table: "Security_FunctionCommand");

            migrationBuilder.DropIndex(
                name: "IX_Security_Function_ModuleCode",
                schema: "dbo",
                table: "Security_Function");

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
