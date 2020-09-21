using Database.Sql.ERP.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Sql.ERP.Creation
{
    public static class SystemModule
    {
        #region " [ Model Creating ] "

        public static void SecutiryModelCreating(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Function>(entity =>
            {
                entity.Property(m => m.Precedence).HasDefaultValue(1);
            });

            modelBuilder.Entity<Function>()
                        .HasOne(p => p.Module)
                        .WithMany(b => b.Functions)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FunctionCommand>(entity =>
            {
                entity.Property(m => m.IsView).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
            });

            modelBuilder.Entity<FunctionCommand>()
                        .HasOne(p => p.Function)
                        .WithMany(b => b.Commands)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Module>(entity =>
            {
                entity.Property(m => m.Precedence).HasDefaultValue(1);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<RoleDetail>();

            modelBuilder.Entity<RoleDetail>()
                        .HasOne(p => p.FunctionCommand)
                        .WithMany(b => b.RoleDetails)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RoleDetail>()
                        .HasOne(p => p.Role)
                        .WithMany(b => b.Details)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SessionLog>(entity =>
            {
                entity.Property(m => m.LoginTime).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsOnline).HasDefaultValue(true);
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<SystemLog>();

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<UserRole>();
            modelBuilder.Entity<UserRole>()
                        .HasOne(p => p.User)
                        .WithMany(b => b.UserRoles)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserRole>()
                        .HasOne(p => p.Role)
                        .WithMany(b => b.UserRoles)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserModule>();
            modelBuilder.Entity<UserModule>()
                        .HasOne(p => p.User)
                        .WithMany(b => b.UserModules)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserModule>()
                        .HasOne(p => p.Module)
                        .WithMany(b => b.UserModules)
                        .OnDelete(DeleteBehavior.Cascade);
        }
        #endregion

        public static void CreateSystemDefaultCommand(this ModelBuilder modelBuilder)
        {
            modelBuilder.CreateDefaultCommandRole();
        }

        #region " [ Default Command ] "

        private static void CreateDefaultCommandRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionCommand>().HasData(
                new FunctionCommand()
                {
                    Id = 8,
                    FunctionCode = "SYS_ROLE",
                    Name = "VIEW",
                    ModuleName = "System",
                    ControllerName = "Role",
                    ActionName = "GetList",
                    Precedence = 1,
                    IsView = true,
                },
                new FunctionCommand()
                {
                    Id = 9,
                    FunctionCode = "SYS_ROLE",
                    Name = "INSERT",
                    ModuleName = "System",
                    ControllerName = "Role",
                    ActionName = "Insert",
                    Precedence = 2,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 10,
                    FunctionCode = "SYS_ROLE",
                    Name = "UPDATE",
                    ModuleName = "System",
                    ControllerName = "Role",
                    ActionName = "Update",
                    Precedence = 3,
                    IsView = false,
                },
                new FunctionCommand()
                {
                    Id = 11,
                    FunctionCode = "SYS_ROLE",
                    Name = "DELETE",
                    ModuleName = "System",
                    ControllerName = "Role",
                    ActionName = "Delete",
                    Precedence = 4,
                    IsView = false,
                }
            );
        }

        #endregion

        public static void CreateDefaultFunctionModuleSystem(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Function>().HasData(
               new Function()
               {
                   Code = "SYS_ACCOUNT",
                   Name = "ACCOUNT",
                   Url = "/account",
                   Icon = string.Empty,
                   ParentCode = string.Empty,
                   Precedence = 1,
                   ModuleCode = "SYSTEM"
               },
               new Function()
               {
                   Code = "SYS_ROLE",
                   Name = "ROLE",
                   Url = "/role",
                   Icon = string.Empty,
                   ParentCode = string.Empty,
                   Precedence = 2,
                   ModuleCode = "SYSTEM"
               },
               new Function()
               {
                   Code = "SYS_SYSTEM_ERROR",
                   Name = "SYSTEM_ERROR",
                   Url = "/system-error",
                   Icon = string.Empty,
                   ParentCode = string.Empty,
                   Precedence = 2,
                   ModuleCode = "SYSTEM"
               }
           );
        }

    }
}
