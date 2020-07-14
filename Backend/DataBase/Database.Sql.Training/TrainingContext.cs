using System;
using Database.Sql.Training.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Sql.Training
{
    public class TrainingContext : DbContext
    {
        public virtual DbSet<TrainingCenter> TrainingCenter { get; set; }
        public virtual DbSet<TrainingType> TrainingType { get; set; }
        public virtual DbSet<SpecializedTraining> SpecializedTraining { get; set; }

        public TrainingContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity<TrainingCenter>();
            modelBuilder.Entity<TrainingType>();
            modelBuilder.Entity<SpecializedTraining>();
        }
    }
}
