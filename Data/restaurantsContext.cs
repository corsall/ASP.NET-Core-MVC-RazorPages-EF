using lab.Data.configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace lab.Data
{
    public partial class RestaurantsContext : IdentityDbContext<IdentityUser>
    {
        public RestaurantsContext(DbContextOptions<RestaurantsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DovidnykClientiv> DovidnykClientivs { get; set; } = null!;
        public virtual DbSet<DovidnykDostavki> DovidnykDostavkis { get; set; } = null!;
        public virtual DbSet<DovidnykProdukcii> DovidnykProdukciis { get; set; } = null!;
        public virtual DbSet<VmistZamovleny> VmistZamovlenies { get; set; } = null!;
        public virtual DbSet<ZamovlenyaProductcii> ZamovlenyaProductciis { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<DovidnykClientiv>(entity =>
            {
                entity.HasKey(e => e.Kodkl)
                    .HasName("PRIMARY");

                entity.ToTable("dovidnyk_clientiv");

                entity.Property(e => e.Kodkl)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("KODKL");

                entity.Property(e => e.Namekl)
                    .HasMaxLength(45)
                    .HasColumnName("NAMEKL");
            });

            modelBuilder.Entity<DovidnykDostavki>(entity =>
            {
                entity.HasKey(e => e.Koddos)
                    .HasName("PRIMARY");

                entity.ToTable("dovidnyk_dostavki");

                entity.Property(e => e.Koddos)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("KODDOS");

                entity.Property(e => e.Tupdos)
                    .HasMaxLength(45)
                    .HasColumnName("TUPDOS");
            });

            modelBuilder.Entity<DovidnykProdukcii>(entity =>
            {
                entity.HasKey(e => e.Kodpr)
                    .HasName("PRIMARY");

                entity.ToTable("dovidnyk_produkcii");

                entity.Property(e => e.Kodpr)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("KODPR");

                entity.Property(e => e.Cina)
                    .HasPrecision(4, 2)
                    .HasColumnName("CINA");

                entity.Property(e => e.Namepr)
                    .HasMaxLength(45)
                    .HasColumnName("NAMEPR")
                    .UseCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<VmistZamovleny>(entity =>
            {
                entity.ToTable("vmist_zamovleny");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Kodpr, "vmist_zam_dov_prod_idx");

                entity.HasIndex(e => e.Nz, "vmist_zam_zam_prod_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Kil)
                    .HasColumnType("int(11)")
                    .HasColumnName("KIL");

                entity.Property(e => e.Kodpr)
                    .HasColumnType("int(11)")
                    .HasColumnName("KODPR");

                entity.Property(e => e.Nz)
                    .HasColumnType("int(11)")
                    .HasColumnName("NZ");

                entity.HasOne(d => d.KodprNavigation)
                    .WithMany(p => p.VmistZamovlenies)
                    .HasForeignKey(d => d.Kodpr)
                    .HasConstraintName("vmist_zam_dov_prod");

                entity.HasOne(d => d.NzNavigation)
                    .WithMany(p => p.VmistZamovlenies)
                    .HasForeignKey(d => d.Nz)
                    .HasConstraintName("vmist_zam_zam_prod");
            });

            modelBuilder.Entity<ZamovlenyaProductcii>(entity =>
            {
                entity.HasKey(e => e.Nz)
                    .HasName("PRIMARY");

                entity.ToTable("zamovlenya_productcii");

                entity.HasIndex(e => e.Kodkl, "zam_prod_dov_cientiv_idx");

                entity.HasIndex(e => e.Koddos, "zam_prod_dov_dost_idx");

                entity.Property(e => e.Nz)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("NZ");

                entity.Property(e => e.Datesp).HasColumnName("DATESP");

                entity.Property(e => e.Datez).HasColumnName("DATEZ");

                entity.Property(e => e.Koddos)
                    .HasColumnType("int(11)")
                    .HasColumnName("KODDOS");

                entity.Property(e => e.Kodkl)
                    .HasColumnType("int(11)")
                    .HasColumnName("KODKL");

                entity.HasOne(d => d.KoddosNavigation)
                    .WithMany(p => p.ZamovlenyaProductciis)
                    .HasForeignKey(d => d.Koddos)
                    .HasConstraintName("zam_prod_dov_dost");

                entity.HasOne(d => d.KodklNavigation)
                    .WithMany(p => p.ZamovlenyaProductciis)
                    .HasForeignKey(d => d.Kodkl)
                    .HasConstraintName("zam_prod_dov_cientiv");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
