using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASDLL.ASDLL.ValueObjects
{
    public partial class AstroEntities : DbContext
    {
        public AstroEntities()
        {
        }

        public AstroEntities(DbContextOptions<AstroEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<ACountryMaster> ACountryMasters { get; set; } = null!;
        public virtual DbSet<APlaceMaster> APlaceMasters { get; set; } = null!;
        public virtual DbSet<AStateMaster> AStateMasters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ApplicationConfiguration.DbConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AI");

            modelBuilder.Entity<ACountryMaster>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_a_country_master")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<APlaceMaster>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_a_place_master")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AStateMaster>(entity =>
            {
                entity.HasIndex(e => e.Sno, "IX_a_state_master")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
