using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version1_0_20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_EmployeeDependency",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RelationshipTypeId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
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
                    table.PrimaryKey("PK_HR_EmployeeDependency", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_COMMENDATION",
                column: "Precedence",
                value: 10);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_CONTRACT",
                column: "Precedence",
                value: 9);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_DISCIPLINE",
                column: "Precedence",
                value: 11);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_Function",
                columns: new[] { "Code", "Icon", "ModuleCode", "Name", "ParentCode", "Precedence", "Url" },
                values: new object[] { "HR_EMPLOYEE_DEPENDENCY", "", "HR", "DEPENDENCY", "HR_EMPLOYEE", 8, "#dependency" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 12, 15, 6, 59, 40, 141, DateTimeKind.Local).AddTicks(2405));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "IsView", "ModuleName", "Name", "Precedence" },
                values: new object[] { 154, "List", "EmployeeDependency", "HR_EMPLOYEE_DEPENDENCY", true, "HR", "VIEW", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "ModuleName", "Name", "Precedence" },
                values: new object[,]
                {
                    { 155, "Insert", "EmployeeDependency", "HR_EMPLOYEE_DEPENDENCY", "HR", "INSERT", 2 },
                    { 156, "Update", "EmployeeDependency", "HR_EMPLOYEE_DEPENDENCY", "HR", "UPDATE", 3 },
                    { 157, "Delete", "EmployeeDependency", "HR_EMPLOYEE_DEPENDENCY", "HR", "DELETE", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_EmployeeDependency",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_EMPLOYEE_DEPENDENCY");

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
                table: "Security_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 11, 30, 6, 25, 14, 222, DateTimeKind.Local).AddTicks(9436));
        }
    }
}
