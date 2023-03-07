using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DictionaryFabricApplication
{
    public partial class FabricDbContext : DbContext
    {
        public FabricDbContext()
        {
        }

        public FabricDbContext(DbContextOptions<FabricDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DictionaryFabric> DictionaryFabrics { get; set; } = null!;
        public virtual DbSet<KnittedWeave> KnittedWeaves { get; set; } = null!;
        public virtual DbSet<Pattern> Patterns { get; set; } = null!;
        public virtual DbSet<Thread> Threads { get; set; } = null!;
        public virtual DbSet<TypeKnitted> TypeKnitteds { get; set; } = null!;
        public virtual DbSet<TypeStitch> TypeStitches { get; set; } = null!;
        public virtual DbSet<TypesFabric> TypesFabrics { get; set; } = null!;
        public virtual DbSet<TypesWovenPattern> TypesWovenPatterns { get; set; } = null!;
        public virtual DbSet<WevingWeave> WevingWeaves { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Filename=FabricDb.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DictionaryFabric>(entity =>
            {
                entity.ToTable("DictionaryFabric");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<KnittedWeave>(entity =>
            {
                entity.ToTable("KnittedWeave");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Pattern>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Thread>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Composition).HasColumnName("composition");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<TypeKnitted>(entity =>
            {
                entity.ToTable("TypeKnitted");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Composition).HasColumnName("composition");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.WeaveId).HasColumnName("weave_id");

                entity.HasOne(d => d.Weave)
                    .WithMany(p => p.TypeKnitteds)
                    .HasForeignKey(d => d.WeaveId);
            });

            modelBuilder.Entity<TypeStitch>(entity =>
            {
                entity.ToTable("TypeStitch");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<TypesFabric>(entity =>
            {
                entity.ToTable("TypesFabric");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Composition).HasColumnName("composition");

                entity.Property(e => e.Density).HasColumnName("density");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.WeaveId).HasColumnName("weave_id");

                entity.HasOne(d => d.Weave)
                    .WithMany(p => p.TypesFabrics)
                    .HasForeignKey(d => d.WeaveId);
            });

            modelBuilder.Entity<TypesWovenPattern>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color).HasColumnName("color");

                entity.Property(e => e.Composition).HasColumnName("composition");

                entity.Property(e => e.IdPattern).HasColumnName("idPattern");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.NumberDesign).HasColumnName("numberDesign");

                entity.Property(e => e.Rapport).HasColumnName("rapport");

                entity.HasOne(d => d.IdPatternNavigation)
                    .WithMany(p => p.TypesWovenPatterns)
                    .HasForeignKey(d => d.IdPattern);
            });

            modelBuilder.Entity<WevingWeave>(entity =>
            {
                entity.ToTable("WevingWeave");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
