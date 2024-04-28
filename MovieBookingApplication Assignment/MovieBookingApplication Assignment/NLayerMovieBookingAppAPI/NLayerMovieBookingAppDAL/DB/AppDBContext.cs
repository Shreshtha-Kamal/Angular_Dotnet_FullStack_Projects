using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NLayerMovieBookingAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerMovieBookingAppDAL.DB
{
    public class AppDBContext: IdentityDbContext<IdentityUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieShow> Shows { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var adminRoleId = Guid.NewGuid().ToString();
            var userRoleId = Guid.NewGuid().ToString();
            var adminUserId = Guid.NewGuid().ToString();
            var movieId1 = Guid.NewGuid();
            SeedRoles(builder, adminRoleId, userRoleId);
            SeedUserData(builder, adminUserId, adminRoleId, userRoleId);
            SeedMovieData(builder, movieId1);
            SeedShowData(builder, movieId1);
            builder.Entity<Movie>()
                .HasOne(e => e.MovieShow)
                .WithOne(e=>e.MovieData)
                .HasForeignKey<MovieShow>(m => m.MovieId)
                .IsRequired();
            builder.Entity<MovieShow>()
                .HasMany(e=>e.Tickets)
                .WithOne(e=>e.ShowData)
                .HasForeignKey(e=>e.ShowId)
                .IsRequired();
        }

        private static void SeedRoles(ModelBuilder builder, string adminRoleId, string userRoleId)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = adminRoleId, Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = userRoleId, Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" }
                );
        }

        private static void SeedUserData(ModelBuilder builder, string adminUserId, string adminRoleId, string userRoleId)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            //creating user ID for users so that I Can seed them to userRole table also
            var normalUserId1 = Guid.NewGuid().ToString();
            var normalUserId2 = Guid.NewGuid().ToString();
            var normalUserId3 = Guid.NewGuid().ToString();
            //creating Admin and normal users
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser()
                {
                    Id = adminUserId,
                    UserName = "Admin_User",
                    NormalizedUserName = "ADMIN_USER",
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "9876543210",
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "Admin@1234")
                },
                new IdentityUser()
                {
                    Id = normalUserId1,
                    UserName = "Shreshtha_Kamal",
                    NormalizedUserName = "SHRESHTHA_KAMAL",
                    Email = "shreshtha@abc.com",
                    NormalizedEmail = "SHRESHTHA@ABC.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "9987654321",
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "Shreshtha@1234")
                },
                new IdentityUser()
                {
                    Id = normalUserId2,
                    UserName = "Rahul_Dey",
                    NormalizedUserName = "RAHUL_DEY",
                    Email = "rahul@abc.com",
                    NormalizedEmail = "RAHUL@ABC.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "8887654321",
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "Rahul@1234")
                },
                new IdentityUser()
                {
                    Id = normalUserId3,
                    UserName = "Aseem_Sharma",
                    NormalizedUserName = "ASEEM_SHARMA",
                    Email = "aseem@abc.com",
                    NormalizedEmail = "ASEEM@ABC.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "9988654321",
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null!, "Aseem@1234")
                }
                );
            //mapping users and respective roles
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId,
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = normalUserId1
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = normalUserId2
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = normalUserId3
                }
                );
        }
        private static void SeedMovieData(ModelBuilder builder, Guid movieId1)
        {   
            builder.Entity<Movie>().HasData(
            new Movie()
            {
                MovieId= movieId1,
                Name= "Fukrey Returns",
                Genre= "Comedy",
                DirectorName= "Rajkumar Hirani",
                Description= "Story of 4 Friends in College",
                BannerImageUrl= "https://th.bing.com/th/id/OIP.iUa8j-Q-4JqiqYk4Uq1MawHaEK?rs=1&pid=ImgDetMain",
                MovieLengthInMinutes= 153,
                IsShowAdded= true,
            });
        }

        private static void SeedShowData(ModelBuilder builder, Guid movieId1)
        {
            var showId1= Guid.NewGuid();
            builder.Entity<MovieShow>().HasData(
                new MovieShow()
                {
                    ShowId = showId1,
                    StartDate = new DateTime(2024, 2, 23),
                    EndDate = new DateTime(2024, 3, 5),
                    StartTime = new TimeSpan(12, 0, 0),
                    EndTime= new TimeSpan(15, 0, 0),
                    TotalSeats= 150,
                    Price= 200,
                    ScreenId= 1,
                    MovieId= movieId1,
                    SeatsRemaining= 150
                });
        }
    }
}
