﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab.Data;

#nullable disable

namespace lab.Migrations
{
    [DbContext(typeof(RestaurantsContext))]
    [Migration("20230422135707_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("lab.Data.DovidnykClientiv", b =>
                {
                    b.Property<int>("Kodkl")
                        .HasColumnType("int(11)")
                        .HasColumnName("KODKL");

                    b.Property<string>("Namekl")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("NAMEKL");

                    b.HasKey("Kodkl")
                        .HasName("PRIMARY");

                    b.ToTable("dovidnyk_clientiv", (string)null);
                });

            modelBuilder.Entity("lab.Data.DovidnykDostavki", b =>
                {
                    b.Property<int>("Koddos")
                        .HasColumnType("int(11)")
                        .HasColumnName("KODDOS");

                    b.Property<string>("Tupdos")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("TUPDOS");

                    b.HasKey("Koddos")
                        .HasName("PRIMARY");

                    b.ToTable("dovidnyk_dostavki", (string)null);
                });

            modelBuilder.Entity("lab.Data.DovidnykProdukcii", b =>
                {
                    b.Property<int>("Kodpr")
                        .HasColumnType("int(11)")
                        .HasColumnName("KODPR");

                    b.Property<decimal>("Cina")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)")
                        .HasColumnName("CINA");

                    b.Property<string>("Namepr")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("NAMEPR")
                        .UseCollation("utf8mb4_0900_ai_ci");

                    b.HasKey("Kodpr")
                        .HasName("PRIMARY");

                    b.ToTable("dovidnyk_produkcii", (string)null);
                });

            modelBuilder.Entity("lab.Data.VmistZamovleny", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("Kil")
                        .HasColumnType("int(11)")
                        .HasColumnName("KIL");

                    b.Property<int>("Kodpr")
                        .HasColumnType("int(11)")
                        .HasColumnName("KODPR");

                    b.Property<int>("Nz")
                        .HasColumnType("int(11)")
                        .HasColumnName("NZ");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Kodpr" }, "vmist_zam_dov_prod_idx");

                    b.HasIndex(new[] { "Nz" }, "vmist_zam_zam_prod_idx");

                    b.ToTable("vmist_zamovleny", (string)null);

                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("lab.Data.ZamovlenyaProductcii", b =>
                {
                    b.Property<int>("Nz")
                        .HasColumnType("int(11)")
                        .HasColumnName("NZ");

                    b.Property<DateOnly?>("Datesp")
                        .HasColumnType("date")
                        .HasColumnName("DATESP");

                    b.Property<DateOnly>("Datez")
                        .HasColumnType("date")
                        .HasColumnName("DATEZ");

                    b.Property<int>("Koddos")
                        .HasColumnType("int(11)")
                        .HasColumnName("KODDOS");

                    b.Property<int>("Kodkl")
                        .HasColumnType("int(11)")
                        .HasColumnName("KODKL");

                    b.HasKey("Nz")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Kodkl" }, "zam_prod_dov_cientiv_idx");

                    b.HasIndex(new[] { "Koddos" }, "zam_prod_dov_dost_idx");

                    b.ToTable("zamovlenya_productcii", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "eaf84d89-3e71-47a1-8b57-ba1955f1365d",
                            ConcurrencyStamp = "802e3e6d-4659-49cd-b8c1-dcf77773b01e",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "6c179007-348b-4741-b0a0-d62837e8b4d6",
                            ConcurrencyStamp = "cce7c9c4-9a27-410b-a83b-068ef0ab35f3",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("lab.Data.VmistZamovleny", b =>
                {
                    b.HasOne("lab.Data.DovidnykProdukcii", "KodprNavigation")
                        .WithMany("VmistZamovlenies")
                        .HasForeignKey("Kodpr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("vmist_zam_dov_prod");

                    b.HasOne("lab.Data.ZamovlenyaProductcii", "NzNavigation")
                        .WithMany("VmistZamovlenies")
                        .HasForeignKey("Nz")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("vmist_zam_zam_prod");

                    b.Navigation("KodprNavigation");

                    b.Navigation("NzNavigation");
                });

            modelBuilder.Entity("lab.Data.ZamovlenyaProductcii", b =>
                {
                    b.HasOne("lab.Data.DovidnykDostavki", "KoddosNavigation")
                        .WithMany("ZamovlenyaProductciis")
                        .HasForeignKey("Koddos")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("zam_prod_dov_dost");

                    b.HasOne("lab.Data.DovidnykClientiv", "KodklNavigation")
                        .WithMany("ZamovlenyaProductciis")
                        .HasForeignKey("Kodkl")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("zam_prod_dov_cientiv");

                    b.Navigation("KoddosNavigation");

                    b.Navigation("KodklNavigation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("lab.Data.DovidnykClientiv", b =>
                {
                    b.Navigation("ZamovlenyaProductciis");
                });

            modelBuilder.Entity("lab.Data.DovidnykDostavki", b =>
                {
                    b.Navigation("ZamovlenyaProductciis");
                });

            modelBuilder.Entity("lab.Data.DovidnykProdukcii", b =>
                {
                    b.Navigation("VmistZamovlenies");
                });

            modelBuilder.Entity("lab.Data.ZamovlenyaProductcii", b =>
                {
                    b.Navigation("VmistZamovlenies");
                });
#pragma warning restore 612, 618
        }
    }
}
