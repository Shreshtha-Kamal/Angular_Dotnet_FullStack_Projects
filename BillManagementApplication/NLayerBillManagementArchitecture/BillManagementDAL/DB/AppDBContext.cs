using BillManagementDomain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillManagementDAL.DB
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<AllowedLoad> AllowedLoads { get; set; }
        public DbSet<Bill> Bills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var adminRoleId = Guid.NewGuid().ToString();
            var userRoleId = Guid.NewGuid().ToString();
            var adminUserId = Guid.NewGuid().ToString();
            SeedRoles(builder, adminRoleId, userRoleId);
            SeedUserData(builder, adminUserId, adminRoleId, userRoleId);
            SeedAllowedLoadsData(builder);
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
            var normalUserId= Guid.NewGuid().ToString();
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser()
                {
                    Id= adminUserId,
                    UserName = "AdminUser",
                    NormalizedUserName = "ADMIN",
                    Name = "Admin User",
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "9999999999",
                    PhoneNumberConfirmed = true,
                    AlternatePhoneNumber= "9999988888",
                    Address= "Bankura West Bengal",
                    PinCode= "400030",
                    CreatedAt= new DateTime(2024,2,15),
                    PasswordHash= hasher.HashPassword(null!, "Admin@1234")
                },
                new ApplicationUser()
                {
                    Id= normalUserId,
                    UserName= "ShreshthaKamal",
                    NormalizedUserName= "SHRESHTHAKAMAL",
                    Name= "Shreshtha Kamal",
                    Email= "shreshtha@abc.com",
                    NormalizedEmail= "SHRESHTHA@ABC.COM",
                    EmailConfirmed= true,
                    PhoneNumber= "8888888888",
                    PhoneNumberConfirmed= true,
                    AlternatePhoneNumber= "8888877777",
                    Address= "Mughalsarai Chandauli UP",
                    PinCode= "400040",
                    LoadAllowed= 2,
                    CreatedAt= new DateTime(2024,2,15),
                    PasswordHash= hasher.HashPassword(null!,"Shreshtha@1234")
                }
                );
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId,
                },
                new IdentityUserRole<string>
                {
                    RoleId= userRoleId,
                    UserId= normalUserId,
                }
                );
        }

        private static void SeedAllowedLoadsData(ModelBuilder builder)
        {
            builder.Entity<AllowedLoad>().HasData(
                new AllowedLoad()
                {
                    LoadCategoryInKW = 2,
                    BasePrice = 299
                },
                new AllowedLoad()
                {
                    LoadCategoryInKW= 4,
                    BasePrice= 499
                },
                new AllowedLoad()
                {
                    LoadCategoryInKW = 6,
                    BasePrice = 699
                },
                new AllowedLoad()
                {
                    LoadCategoryInKW = 8,
                    BasePrice = 1099
                }
                );
        }
    }
}
