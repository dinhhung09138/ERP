using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Sql.ERP.Migrations
{
    public partial class version1_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Training_TrainingType",
                newName: "Training_TrainingType",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Training_TrainingCourseDocument",
                newName: "Training_TrainingCourseDocument",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Training_TrainingCourse",
                newName: "Training_TrainingCourse",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Training_TrainingCenterContact",
                newName: "Training_TrainingCenterContact",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Training_TrainingCenter",
                newName: "Training_TrainingCenter",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Training_SpecializedTraining",
                newName: "Training_SpecializedTraining",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Training_Lecturer",
                newName: "Training_Lecturer",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Training_AppraiseSection",
                newName: "Training_AppraiseSection",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Training_AppraiseQuestion",
                newName: "Training_AppraiseQuestion",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Training_AppraiseAnswer",
                newName: "Training_AppraiseAnswer",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Training_Appraise",
                newName: "Training_Appraise",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Secutiry_SystemLog",
                newName: "Secutiry_SystemLog",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Security_UserRole",
                newName: "Security_UserRole",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Security_User",
                newName: "Security_User",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Security_SessionLog",
                newName: "Security_SessionLog",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Security_Role",
                newName: "Security_Role",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Security_Module",
                newName: "Security_Module",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Security_FunctionCommand",
                newName: "Security_FunctionCommand",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Security_Function",
                newName: "Security_Function",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_Religion",
                newName: "HR_Religion",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_RelationshipType",
                newName: "HR_RelationshipType",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_Ranking",
                newName: "HR_Ranking",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_Position",
                newName: "HR_Position",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_Nationality",
                newName: "HR_Nationality",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_ModelOfStudy",
                newName: "HR_ModelOfStudy",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_IdentificationType",
                newName: "HR_IdentificationType",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_Ethnicity",
                newName: "HR_Ethnicity",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_EmployeeWorkingStatus",
                newName: "HR_EmployeeWorkingStatus",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_EmployeeInfo",
                newName: "HR_EmployeeInfo",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_Employee",
                newName: "HR_Employee",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_Education",
                newName: "HR_Education",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_Discipline",
                newName: "HR_Discipline",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_ContractType",
                newName: "HR_ContractType",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_Commendation",
                newName: "HR_Commendation",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "HR_ApproveStatus",
                newName: "HR_ApproveStatus",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EmployeeRelationship",
                newName: "EmployeeRelationship",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EmployeeIdentification",
                newName: "EmployeeIdentification",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EmployeeEducation",
                newName: "EmployeeEducation",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EmployeeDiscipline",
                newName: "EmployeeDiscipline",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EmployeeContractStatusHistory",
                newName: "EmployeeContractStatusHistory",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EmployeeContract",
                newName: "EmployeeContract",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EmployeeContact",
                newName: "EmployeeContact",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EmployeeCommendation",
                newName: "EmployeeCommendation",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Common_Ward",
                newName: "Common_Ward",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Common_Province",
                newName: "Common_Province",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Common_ProfessionalQualification",
                newName: "Common_ProfessionalQualification",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Common_File",
                newName: "Common_File",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Common_District",
                newName: "Common_District",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CodeType",
                newName: "CodeType",
                newSchema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Training_TrainingType",
                schema: "dbo",
                newName: "Training_TrainingType");

            migrationBuilder.RenameTable(
                name: "Training_TrainingCourseDocument",
                schema: "dbo",
                newName: "Training_TrainingCourseDocument");

            migrationBuilder.RenameTable(
                name: "Training_TrainingCourse",
                schema: "dbo",
                newName: "Training_TrainingCourse");

            migrationBuilder.RenameTable(
                name: "Training_TrainingCenterContact",
                schema: "dbo",
                newName: "Training_TrainingCenterContact");

            migrationBuilder.RenameTable(
                name: "Training_TrainingCenter",
                schema: "dbo",
                newName: "Training_TrainingCenter");

            migrationBuilder.RenameTable(
                name: "Training_SpecializedTraining",
                schema: "dbo",
                newName: "Training_SpecializedTraining");

            migrationBuilder.RenameTable(
                name: "Training_Lecturer",
                schema: "dbo",
                newName: "Training_Lecturer");

            migrationBuilder.RenameTable(
                name: "Training_AppraiseSection",
                schema: "dbo",
                newName: "Training_AppraiseSection");

            migrationBuilder.RenameTable(
                name: "Training_AppraiseQuestion",
                schema: "dbo",
                newName: "Training_AppraiseQuestion");

            migrationBuilder.RenameTable(
                name: "Training_AppraiseAnswer",
                schema: "dbo",
                newName: "Training_AppraiseAnswer");

            migrationBuilder.RenameTable(
                name: "Training_Appraise",
                schema: "dbo",
                newName: "Training_Appraise");

            migrationBuilder.RenameTable(
                name: "Secutiry_SystemLog",
                schema: "dbo",
                newName: "Secutiry_SystemLog");

            migrationBuilder.RenameTable(
                name: "Security_UserRole",
                schema: "dbo",
                newName: "Security_UserRole");

            migrationBuilder.RenameTable(
                name: "Security_User",
                schema: "dbo",
                newName: "Security_User");

            migrationBuilder.RenameTable(
                name: "Security_SessionLog",
                schema: "dbo",
                newName: "Security_SessionLog");

            migrationBuilder.RenameTable(
                name: "Security_Role",
                schema: "dbo",
                newName: "Security_Role");

            migrationBuilder.RenameTable(
                name: "Security_Module",
                schema: "dbo",
                newName: "Security_Module");

            migrationBuilder.RenameTable(
                name: "Security_FunctionCommand",
                schema: "dbo",
                newName: "Security_FunctionCommand");

            migrationBuilder.RenameTable(
                name: "Security_Function",
                schema: "dbo",
                newName: "Security_Function");

            migrationBuilder.RenameTable(
                name: "HR_Religion",
                schema: "dbo",
                newName: "HR_Religion");

            migrationBuilder.RenameTable(
                name: "HR_RelationshipType",
                schema: "dbo",
                newName: "HR_RelationshipType");

            migrationBuilder.RenameTable(
                name: "HR_Ranking",
                schema: "dbo",
                newName: "HR_Ranking");

            migrationBuilder.RenameTable(
                name: "HR_Position",
                schema: "dbo",
                newName: "HR_Position");

            migrationBuilder.RenameTable(
                name: "HR_Nationality",
                schema: "dbo",
                newName: "HR_Nationality");

            migrationBuilder.RenameTable(
                name: "HR_ModelOfStudy",
                schema: "dbo",
                newName: "HR_ModelOfStudy");

            migrationBuilder.RenameTable(
                name: "HR_IdentificationType",
                schema: "dbo",
                newName: "HR_IdentificationType");

            migrationBuilder.RenameTable(
                name: "HR_Ethnicity",
                schema: "dbo",
                newName: "HR_Ethnicity");

            migrationBuilder.RenameTable(
                name: "HR_EmployeeWorkingStatus",
                schema: "dbo",
                newName: "HR_EmployeeWorkingStatus");

            migrationBuilder.RenameTable(
                name: "HR_EmployeeInfo",
                schema: "dbo",
                newName: "HR_EmployeeInfo");

            migrationBuilder.RenameTable(
                name: "HR_Employee",
                schema: "dbo",
                newName: "HR_Employee");

            migrationBuilder.RenameTable(
                name: "HR_Education",
                schema: "dbo",
                newName: "HR_Education");

            migrationBuilder.RenameTable(
                name: "HR_Discipline",
                schema: "dbo",
                newName: "HR_Discipline");

            migrationBuilder.RenameTable(
                name: "HR_ContractType",
                schema: "dbo",
                newName: "HR_ContractType");

            migrationBuilder.RenameTable(
                name: "HR_Commendation",
                schema: "dbo",
                newName: "HR_Commendation");

            migrationBuilder.RenameTable(
                name: "HR_ApproveStatus",
                schema: "dbo",
                newName: "HR_ApproveStatus");

            migrationBuilder.RenameTable(
                name: "EmployeeRelationship",
                schema: "dbo",
                newName: "EmployeeRelationship");

            migrationBuilder.RenameTable(
                name: "EmployeeIdentification",
                schema: "dbo",
                newName: "EmployeeIdentification");

            migrationBuilder.RenameTable(
                name: "EmployeeEducation",
                schema: "dbo",
                newName: "EmployeeEducation");

            migrationBuilder.RenameTable(
                name: "EmployeeDiscipline",
                schema: "dbo",
                newName: "EmployeeDiscipline");

            migrationBuilder.RenameTable(
                name: "EmployeeContractStatusHistory",
                schema: "dbo",
                newName: "EmployeeContractStatusHistory");

            migrationBuilder.RenameTable(
                name: "EmployeeContract",
                schema: "dbo",
                newName: "EmployeeContract");

            migrationBuilder.RenameTable(
                name: "EmployeeContact",
                schema: "dbo",
                newName: "EmployeeContact");

            migrationBuilder.RenameTable(
                name: "EmployeeCommendation",
                schema: "dbo",
                newName: "EmployeeCommendation");

            migrationBuilder.RenameTable(
                name: "Common_Ward",
                schema: "dbo",
                newName: "Common_Ward");

            migrationBuilder.RenameTable(
                name: "Common_Province",
                schema: "dbo",
                newName: "Common_Province");

            migrationBuilder.RenameTable(
                name: "Common_ProfessionalQualification",
                schema: "dbo",
                newName: "Common_ProfessionalQualification");

            migrationBuilder.RenameTable(
                name: "Common_File",
                schema: "dbo",
                newName: "Common_File");

            migrationBuilder.RenameTable(
                name: "Common_District",
                schema: "dbo",
                newName: "Common_District");

            migrationBuilder.RenameTable(
                name: "CodeType",
                schema: "dbo",
                newName: "CodeType");
        }
    }
}
