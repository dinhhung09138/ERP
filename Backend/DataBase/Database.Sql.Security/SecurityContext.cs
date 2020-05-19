using Database.Sql.Security.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Database.Sql.Security
{
    public class SecurityContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<SessionLog> SessionLog { get; set; }

        public SecurityContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Model creating.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity<User>();
            modelBuilder.Entity<SessionLog>();
        }

    }
}
