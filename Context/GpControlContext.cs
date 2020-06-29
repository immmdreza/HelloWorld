using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HelloWorld.Models;

namespace HelloWorld.Context
{
    public partial class GpControlContext : DbContext
    {
        public GpControlContext()
        {
        }

        public GpControlContext(DbContextOptions<GpControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<MediaOptions> MediaOptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("connectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Groups>(entity =>
            {
                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<MediaOptions>(entity =>
            {
                entity.HasIndex(e => e.GroupId)
                    .HasName("NonClusteredIndex-20200614-151307")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Links).HasColumnName("LInks");

                entity.Property(e => e.Ltr).HasColumnName("LTR");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
