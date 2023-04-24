using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eMedPlus.Data.Models
{
    public partial class RatingContext : DbContext
    {
        public RatingContext()
        {
        }

        public RatingContext(DbContextOptions<RatingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RatingInfo> RatingInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=Rating; user id=SA;password=Welcome@1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RatingInfo>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("pk_Rating_RatingId");

                entity.Property(e => e.Comment).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
