using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version1_0_21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_APPROVE_ST");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_SUMMARY");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "Common_CodeType");

            migrationBuilder.DropColumn(
                name: "ModuleCode",
                schema: "dbo",
                table: "Common_CodeType");

            migrationBuilder.DropColumn(
                name: "Precedence",
                schema: "dbo",
                table: "Common_CodeType");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "dbo",
                table: "Common_CodeType");

            migrationBuilder.DropColumn(
                name: "TypeCode",
                schema: "dbo",
                table: "Common_CodeType");

            migrationBuilder.DropColumn(
                name: "TypeName",
                schema: "dbo",
                table: "Common_CodeType");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Common_CodeType",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Common_Code",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_Code", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_EmployeeLeave",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    LeaveStatusId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    LineManagerId = table.Column<int>(type: "int", nullable: false),
                    CCMember = table.Column<string>(type: "varchar(250)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
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
                    table.PrimaryKey("PK_HR_EmployeeLeave", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_EmployeeLeaveConfiguration",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    NumOfDay = table.Column<int>(type: "int", nullable: false),
                    DayUsed = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
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
                    table.PrimaryKey("PK_HR_EmployeeLeaveConfiguration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_EmployeeLeaveStatus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproveBy = table.Column<int>(type: "int", nullable: false),
                    ApproveDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ApproveComment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_EmployeeLeaveStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_LeaveStatus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_HR_LeaveStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HR_LeaveType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumOfDay = table.Column<int>(type: "int", nullable: false),
                    IsDeductible = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Precedence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_HR_LeaveType", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_Function",
                columns: new[] { "Code", "Icon", "ModuleCode", "Name", "ParentCode", "Precedence", "Url" },
                values: new object[,]
                {
                    { "HR_LEAVE_STATUS", "", "HR", "LEAVE_STATUS", "HR_LEAVE_MNT", 4, "/leave-management/leave-status" },
                    { "HR_LEAVE_TYPE", "", "HR", "LEAVE_TYPE", "HR_LEAVE_MNT", 5, "/leave-management/leave-type" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "IsView", "ModuleName", "Name", "Precedence" },
                values: new object[] { 167, "List", "Leave", "HR_LEAVE_NEW", true, "HR", "VIEW", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "ModuleName", "Name", "Precedence" },
                values: new object[,]
                {
                    { 168, "Insert", "Leave", "HR_LEAVE_NEW", "HR", "INSERT", 2 },
                    { 169, "Update", "Leave", "HR_LEAVE_NEW", "HR", "UPDATE", 3 },
                    { 170, "Delete", "Leave", "HR_LEAVE_NEW", "HR", "DELETE", 4 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "IsView", "ModuleName", "Name", "Precedence" },
                values: new object[] { 171, "Summary", "Leave", "HR_LEAVE_CALENDAR", true, "HR", "VIEW", 1 });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 12, 22, 6, 40, 8, 277, DateTimeKind.Local).AddTicks(9580));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "IsView", "ModuleName", "Name", "Precedence" },
                values: new object[] { 159, "List", "LeaveStatus", "HR_LEAVE_STATUS", true, "HR", "VIEW", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "ModuleName", "Name", "Precedence" },
                values: new object[,]
                {
                    { 160, "Insert", "LeaveStatus", "HR_LEAVE_STATUS", "HR", "INSERT", 2 },
                    { 161, "Update", "LeaveStatus", "HR_LEAVE_STATUS", "HR", "UPDATE", 3 },
                    { 162, "Delete", "LeaveStatus", "HR_LEAVE_STATUS", "HR", "DELETE", 4 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "IsView", "ModuleName", "Name", "Precedence" },
                values: new object[] { 163, "List", "LeaveType", "HR_LEAVE_TYPE", true, "HR", "VIEW", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                columns: new[] { "Id", "ActionName", "ControllerName", "FunctionCode", "ModuleName", "Name", "Precedence" },
                values: new object[,]
                {
                    { 164, "Insert", "LeaveType", "HR_LEAVE_TYPE", "HR", "INSERT", 2 },
                    { 165, "Update", "LeaveType", "HR_LEAVE_TYPE", "HR", "UPDATE", 3 },
                    { 166, "Delete", "LeaveType", "HR_LEAVE_TYPE", "HR", "DELETE", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Common_Code",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_EmployeeLeave",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_EmployeeLeaveConfiguration",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_EmployeeLeaveStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_LeaveStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HR_LeaveType",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_FunctionCommand",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_STATUS");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Security_Function",
                keyColumn: "Code",
                keyValue: "HR_LEAVE_TYPE");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "Common_CodeType");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Common_CodeType",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModuleCode",
                schema: "dbo",
                table: "Common_CodeType",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Precedence",
                schema: "dbo",
                table: "Common_CodeType",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "dbo",
                table: "Common_CodeType",
                type: "timestamp",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "TypeCode",
                schema: "dbo",
                table: "Common_CodeType",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                schema: "dbo",
                table: "Common_CodeType",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_Function",
                columns: new[] { "Code", "Icon", "ModuleCode", "Name", "ParentCode", "Precedence", "Url" },
                values: new object[] { "HR_LEAVE_SUMMARY", "", "HR", "SUMMARY", "HR_LEAVE_MNT", 2, "/leave-management/summary" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Security_Function",
                columns: new[] { "Code", "Icon", "ModuleCode", "Name", "ParentCode", "Precedence", "Url" },
                values: new object[] { "HR_LEAVE_APPROVE_ST", "", "HR", "APPROVE_STATUS", "HR_LEAVE_MNT", 4, "/leave-management/approve-status" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Security_Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 12, 15, 6, 59, 40, 141, DateTimeKind.Local).AddTicks(2405));
        }
    }
}
