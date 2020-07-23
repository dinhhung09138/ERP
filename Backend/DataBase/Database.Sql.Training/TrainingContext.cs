using System;
using Database.Sql.Training.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Sql.Training
{
    public class TrainingContext : DbContext
    {
        public virtual DbSet<Appraise> Appraise { get; set; }
        public virtual DbSet<AppraiseAnswer> AppraiseAnswer { get; set; }
        public virtual DbSet<AppraiseQuestion> AppraiseQuestion { get; set; }
        public virtual DbSet<AppraiseSection> AppraiseSection { get; set; }
        public virtual DbSet<Lecturer> Lecturer { get; set; }
        public virtual DbSet<SpecializedTraining> SpecializedTraining { get; set; }
        public virtual DbSet<TrainingCenter> TrainingCenter { get; set; }
        public virtual DbSet<TrainingCenterContact> TrainingCenterContact { get; set; }
        public virtual DbSet<TrainingCourse> TrainingCourse { get; set; }
        public virtual DbSet<TrainingCourseDocument> TrainingCourseDocument { get; set; }
        public virtual DbSet<TrainingType> TrainingType { get; set; }

        public TrainingContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity<Appraise>();
            modelBuilder.Entity<AppraiseAnswer>();
            modelBuilder.Entity<AppraiseQuestion>();
            modelBuilder.Entity<AppraiseSection>();
            modelBuilder.Entity<Lecturer>();
            modelBuilder.Entity<SpecializedTraining>();
            modelBuilder.Entity<TrainingCenter>();
            modelBuilder.Entity<TrainingCenterContact>();
            modelBuilder.Entity<TrainingCourse>();
            modelBuilder.Entity<TrainingCourseDocument>();
            modelBuilder.Entity<TrainingType>();
        }
    }
}
