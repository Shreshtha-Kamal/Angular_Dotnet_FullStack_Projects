﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayerMovieBookingAppDAL.DB;

#nullable disable

namespace NLayerMovieBookingAppDAL.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240304055019_Added Cardinality, seeded users and movies")]
    partial class AddedCardinalityseededusersandmovies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "809b85d0-f43d-445f-9a1f-9bf1f48366e3",
                            ConcurrencyStamp = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "3483e31b-9ef1-42fa-a91f-c0bbda860d60",
                            ConcurrencyStamp = "2",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "691322b5-6fac-4af2-8b40-5ab42cd25937",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bf339c90-ae31-42ee-b6ab-0e749da59b1a",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN_USER",
                            PasswordHash = "AQAAAAEAACcQAAAAEB193FamwzpJ7l+dCgj03TekojnpIK8Ce5a9rAQcfw4yv4yNUW/hvbzce7H6DPMsWw==",
                            PhoneNumber = "9876543210",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "ab453c39-0538-47db-8697-e11a2c0487e0",
                            TwoFactorEnabled = false,
                            UserName = "Admin_User"
                        },
                        new
                        {
                            Id = "835b08ac-f700-40b5-b9f0-cd900964ecdb",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "38b032e3-142c-4a24-937f-4113985e3809",
                            Email = "shreshtha@abc.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "SHRESHTHA@ABC.COM",
                            NormalizedUserName = "SHRESHTHA_KAMAL",
                            PasswordHash = "AQAAAAEAACcQAAAAELjYXUl7RGjNkzd0OxjjVkOaSISMJvz1yJvRqV7yVCwOPyyBMLBfuCUwOflm6cyS6g==",
                            PhoneNumber = "9987654321",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "e0f84c68-8a96-4957-8644-7348e485918c",
                            TwoFactorEnabled = false,
                            UserName = "Shreshtha_Kamal"
                        },
                        new
                        {
                            Id = "462e7c8f-c658-4b30-8223-996f8a15ee7f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "743771aa-5f40-4479-b25c-5d9dcc80bbf7",
                            Email = "rahul@abc.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "RAHUL@ABC.COM",
                            NormalizedUserName = "RAHUL_DEY",
                            PasswordHash = "AQAAAAEAACcQAAAAEAOYMFiIUrAYEL/vm8zyF4VtmYaKDHhTCxWXlg3l2ZK+wqhXE+bIilG2TF9b+fm6aA==",
                            PhoneNumber = "8887654321",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "21ee6f16-1869-4e6a-a3e2-47724c497f7d",
                            TwoFactorEnabled = false,
                            UserName = "Rahul_Dey"
                        },
                        new
                        {
                            Id = "a26ad3a0-0432-4189-933e-5b4a4e6d09e6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2ae0d2d8-e113-43d9-afdd-3089a0ef8f54",
                            Email = "aseem@abc.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ASEEM@ABC.COM",
                            NormalizedUserName = "ASEEM_SHARMA",
                            PasswordHash = "AQAAAAEAACcQAAAAEGRNw9yuqg4aCbxCrCLMhbX2HUXh/csL4nbZ1FXy8hKvKcalHDZY7Yiy33lAUWw4Tg==",
                            PhoneNumber = "9988654321",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "d3e0fcfb-7cf4-4c07-87e0-290bba7fa75b",
                            TwoFactorEnabled = false,
                            UserName = "Aseem_Sharma"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "691322b5-6fac-4af2-8b40-5ab42cd25937",
                            RoleId = "809b85d0-f43d-445f-9a1f-9bf1f48366e3"
                        },
                        new
                        {
                            UserId = "835b08ac-f700-40b5-b9f0-cd900964ecdb",
                            RoleId = "3483e31b-9ef1-42fa-a91f-c0bbda860d60"
                        },
                        new
                        {
                            UserId = "462e7c8f-c658-4b30-8223-996f8a15ee7f",
                            RoleId = "3483e31b-9ef1-42fa-a91f-c0bbda860d60"
                        },
                        new
                        {
                            UserId = "a26ad3a0-0432-4189-933e-5b4a4e6d09e6",
                            RoleId = "3483e31b-9ef1-42fa-a91f-c0bbda860d60"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("NLayerMovieBookingAppDomain.Entities.Movie", b =>
                {
                    b.Property<Guid>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BannerImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsShowAdded")
                        .HasColumnType("bit");

                    b.Property<int>("MovieLengthInMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = new Guid("51f3932f-d12e-48ea-b23b-cdb88011d649"),
                            BannerImageUrl = "https://th.bing.com/th/id/OIP.iUa8j-Q-4JqiqYk4Uq1MawHaEK?rs=1&pid=ImgDetMain",
                            Description = "Story of 4 Friends in College",
                            DirectorName = "Rajkumar Hirani",
                            Genre = "Comedy",
                            IsShowAdded = true,
                            MovieLengthInMinutes = 153,
                            Name = "Fukrey Returns"
                        });
                });

            modelBuilder.Entity("NLayerMovieBookingAppDomain.Entities.MovieShow", b =>
                {
                    b.Property<Guid>("ShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ScreenId")
                        .HasColumnType("int");

                    b.Property<int>("SeatsRemaining")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("ShowId");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.ToTable("Shows");

                    b.HasData(
                        new
                        {
                            ShowId = new Guid("c83c0ddc-20bc-434e-b1dd-3e21dedf40ca"),
                            EndDate = new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 15, 0, 0, 0),
                            MovieId = new Guid("51f3932f-d12e-48ea-b23b-cdb88011d649"),
                            Price = 200,
                            ScreenId = 1,
                            SeatsRemaining = 150,
                            StartDate = new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new TimeSpan(0, 12, 0, 0, 0),
                            TotalSeats = 150
                        });
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

            modelBuilder.Entity("NLayerMovieBookingAppDomain.Entities.MovieShow", b =>
                {
                    b.HasOne("NLayerMovieBookingAppDomain.Entities.Movie", "MovieData")
                        .WithOne("MovieShow")
                        .HasForeignKey("NLayerMovieBookingAppDomain.Entities.MovieShow", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovieData");
                });

            modelBuilder.Entity("NLayerMovieBookingAppDomain.Entities.Movie", b =>
                {
                    b.Navigation("MovieShow");
                });
#pragma warning restore 612, 618
        }
    }
}
