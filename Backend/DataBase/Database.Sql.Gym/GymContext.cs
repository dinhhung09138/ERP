using Database.Sql.Gym.Enitties;
using Microsoft.EntityFrameworkCore;
using System;

namespace Database.Sql.Gym
{
    public class GymContext : DbContext
    {
        public virtual DbSet<Muscle> Muscle { get; set; }
        public virtual DbSet<Exercise> Exercise { get; set; }
        public virtual DbSet<ExerciseLevel> ExerciseLevel { get; set; }
        public virtual DbSet<ExerciseResource> ExerciseResource { get; set; }

        public GymContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Model creating.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity<Muscle>();
            modelBuilder.Entity<Exercise>();
            modelBuilder.Entity<ExerciseLevel>();
            modelBuilder.Entity<ExerciseResource>();
        }

    }
}
