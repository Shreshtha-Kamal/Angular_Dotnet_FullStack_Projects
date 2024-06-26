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
    [Migration("20240304132157_Added Cardinality for ticket")]
    partial class AddedCardinalityforticket
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
                            Id = "b1f2d4f0-f481-4835-a449-cb407de91e96",
                            ConcurrencyStamp = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "96cfe238-60ac-437d-a22e-cd8dd6376a6a",
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
                            Id = "f7d76828-4209-4f86-86de-34a87ad69682",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e3c2aaa3-5e73-465f-a754-5463978c692d",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN_USER",
                            PasswordHash = "AQAAAAEAACcQAAAAEDqJedUJNKg4sgh37fyzxWzZx9S/MpV7q9QzcDzC93vNyO8ImRzLVdMEtLMK9Nhsgw==",
                            PhoneNumber = "9876543210",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "aedfebe1-d7ca-4215-8c04-c7833b70125f",
                            TwoFactorEnabled = false,
                            UserName = "Admin_User"
                        },
                        new
                        {
                            Id = "2768db5d-4744-4de1-ab07-3cbaded6944a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e748f251-9ce0-499a-aa11-f4a323b9f249",
                            Email = "shreshtha@abc.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "SHRESHTHA@ABC.COM",
                            NormalizedUserName = "SHRESHTHA_KAMAL",
                            PasswordHash = "AQAAAAEAACcQAAAAEAAF9F5vhTCQxd9+fyYSV7jbzrvM9PYxhbBodeZo/MXmTVtCr4n+lDOP8/CO5gonJg==",
                            PhoneNumber = "9987654321",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "4361b1b3-fbe6-44c0-af9e-6f2d07ea6aa1",
                            TwoFactorEnabled = false,
                            UserName = "Shreshtha_Kamal"
                        },
                        new
                        {
                            Id = "09a58e9e-43c2-4dd9-9e37-dd3bbbecd26b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "724b7059-c71c-433f-9648-6bd6c4b9a77d",
                            Email = "rahul@abc.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "RAHUL@ABC.COM",
                            NormalizedUserName = "RAHUL_DEY",
                            PasswordHash = "AQAAAAEAACcQAAAAEGRyktCbP/SBOhpsf/8WGYPFEiBjEhLx0BsGgUdzGW1qli9WyLh7/xRyM78DLtKu6A==",
                            PhoneNumber = "8887654321",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "c6aa62d3-a824-4c51-b28f-7f0fcafd257c",
                            TwoFactorEnabled = false,
                            UserName = "Rahul_Dey"
                        },
                        new
                        {
                            Id = "3499b310-0945-467a-a067-50b553365978",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b5cd27e8-159f-478c-8ff0-956e0ff72cbc",
                            Email = "aseem@abc.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ASEEM@ABC.COM",
                            NormalizedUserName = "ASEEM_SHARMA",
                            PasswordHash = "AQAAAAEAACcQAAAAEH0DlB+PhJ3RDABWekXFxQ3dh3yJriM9egoC9XO8s+IWXBr33EB9NaMcPW03E1e9rw==",
                            PhoneNumber = "9988654321",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "e26306ba-c262-4537-8d8a-82a674b7a7dc",
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
                            UserId = "f7d76828-4209-4f86-86de-34a87ad69682",
                            RoleId = "b1f2d4f0-f481-4835-a449-cb407de91e96"
                        },
                        new
                        {
                            UserId = "2768db5d-4744-4de1-ab07-3cbaded6944a",
                            RoleId = "96cfe238-60ac-437d-a22e-cd8dd6376a6a"
                        },
                        new
                        {
                            UserId = "09a58e9e-43c2-4dd9-9e37-dd3bbbecd26b",
                            RoleId = "96cfe238-60ac-437d-a22e-cd8dd6376a6a"
                        },
                        new
                        {
                            UserId = "3499b310-0945-467a-a067-50b553365978",
                            RoleId = "96cfe238-60ac-437d-a22e-cd8dd6376a6a"
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
                            MovieId = new Guid("a033dae0-c69e-49e4-97af-a83d6963f6a5"),
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
                            ShowId = new Guid("555fa1ec-5182-49fd-8e5b-e45ae25f3814"),
                            EndDate = new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndTime = new TimeSpan(0, 15, 0, 0, 0),
                            MovieId = new Guid("a033dae0-c69e-49e4-97af-a83d6963f6a5"),
                            Price = 200,
                            ScreenId = 1,
                            SeatsRemaining = 150,
                            StartDate = new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new TimeSpan(0, 12, 0, 0, 0),
                            TotalSeats = 150
                        });
                });

            modelBuilder.Entity("NLayerMovieBookingAppDomain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PricePerSeat")
                        .HasColumnType("int");

                    b.Property<int>("SeatCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShowDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ShowId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TicketId");

                    b.HasIndex("ShowId");

                    b.ToTable("Tickets");
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

            modelBuilder.Entity("NLayerMovieBookingAppDomain.Entities.Ticket", b =>
                {
                    b.HasOne("NLayerMovieBookingAppDomain.Entities.MovieShow", "ShowData")
                        .WithMany("Tickets")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShowData");
                });

            modelBuilder.Entity("NLayerMovieBookingAppDomain.Entities.Movie", b =>
                {
                    b.Navigation("MovieShow");
                });

            modelBuilder.Entity("NLayerMovieBookingAppDomain.Entities.MovieShow", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
