using Database.Sql.ERP.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Database.Sql.ERP.Creation
{
    public static class CommonModule
    {
        public static void CommonModelCreating(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<ProfessionalQualification>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.Property(m => m.CreateDate).HasDefaultValueSql("getdate()");
                entity.Property(m => m.IsActive).HasDefaultValue(true);
                entity.Property(m => m.Deleted).HasDefaultValue(false);
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(m => m.RowVersion).IsRowVersion();
            });

            modelBuilder.Entity<CodeType>(entity =>
            {
                entity.Property(m => m.Precedence).HasDefaultValue(1);
                entity.Property(m => m.RowVersion).IsRowVersion();
            });
        }
    }
}
