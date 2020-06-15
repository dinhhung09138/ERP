using DataBase.Sql.HR.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataBase.Sql.HR
{
    public class HRContext : DbContext
    {
        public virtual DbSet<Education> AcademicLevel { get; set; }

        public virtual DbSet<ApproveStatus> ApproveStatus { get; set; }

        public virtual DbSet<CodeType> CodeType { get; set; }

        public virtual DbSet<Commendation> Commendation { get; set; }

        public virtual DbSet<ContractType> ContractType { get; set; }

        public virtual DbSet<ContractType> Discipline { get; set; }

        public virtual DbSet<District> District { get; set; }

        public virtual DbSet<Employee> Employee { get; set; }

        public virtual DbSet<EmployeeCommendation> EmployeeCommendation { get; set; }

        public virtual DbSet<EmployeeContact> EmployeeContact { get; set; }

        public virtual DbSet<EmployeeContract> EmployeeContract { get; set; }

        public virtual DbSet<EmployeeContractStatusHistory> EmployeeContractStatusHistory { get; set; }

        public virtual DbSet<EmployeeDiscipline> EmployeeDiscipline { get; set; }

        public virtual DbSet<EmployeeEducation> EmployeeEducation { get; set; }

        public virtual DbSet<EmployeeIdentification> EmployeeIdentification { get; set; }

        public virtual DbSet<EmployeeInfo> EmployeeInfo { get; set; }

        public virtual DbSet<EmployeeRelationship> EmployeeRelationship { get; set; }

        public virtual DbSet<EmployeeWorkingStatus> EmployeeWorkingStatus { get; set; }

        public virtual DbSet<IdentificationType> IdentificationType { get; set; }

        public virtual DbSet<ModelOfStudy> ModelOfStudy { get; set; }

        public virtual DbSet<ProfessionalQualification> ProfessionalQualification { get; set; }

        public virtual DbSet<Province> Province { get; set; }

        public virtual DbSet<Ranking> Ranking { get; set; }

        public virtual DbSet<RelationshipType> RelationshipType { get; set; }

        public virtual DbSet<SpecializedTraining> SpecializedTraining { get; set; }

        public virtual DbSet<TrainingCenter> TrainingCenter { get; set; }

        public virtual DbSet<TrainingType> TrainingType { get; set; }

        public virtual DbSet<Ward> Ward { get; set; }

        public HRContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity<Education>();
            modelBuilder.Entity<ApproveStatus>();
            modelBuilder.Entity<CodeType>();
            modelBuilder.Entity<Commendation>();
            modelBuilder.Entity<ContractType>();
            modelBuilder.Entity<Discipline>();
            modelBuilder.Entity<District>();
            modelBuilder.Entity<Employee>();
            modelBuilder.Entity<EmployeeCommendation>();
            modelBuilder.Entity<EmployeeContact>();
            modelBuilder.Entity<EmployeeContract>();
            modelBuilder.Entity<EmployeeContractStatusHistory>();
            modelBuilder.Entity<EmployeeDiscipline>();
            modelBuilder.Entity<EmployeeEducation>();
            modelBuilder.Entity<EmployeeIdentification>();
            modelBuilder.Entity<EmployeeInfo>();
            modelBuilder.Entity<EmployeeRelationship>();
            modelBuilder.Entity<EmployeeWorkingStatus>();
            modelBuilder.Entity<IdentificationType>();
            modelBuilder.Entity<ModelOfStudy>();
            modelBuilder.Entity<ProfessionalQualification>();
            modelBuilder.Entity<Province>();
            modelBuilder.Entity<Ranking>();
            modelBuilder.Entity<RelationshipType>();
            modelBuilder.Entity<SpecializedTraining>();
            modelBuilder.Entity<TrainingCenter>();
            modelBuilder.Entity<TrainingType>();
            modelBuilder.Entity<Ward>();

        }
    }
   
}
    
