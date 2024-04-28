using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayerMovieBookingAppDAL.Migrations
{
    public partial class AddeduserIdinTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "96cfe238-60ac-437d-a22e-cd8dd6376a6a", "09a58e9e-43c2-4dd9-9e37-dd3bbbecd26b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "96cfe238-60ac-437d-a22e-cd8dd6376a6a", "2768db5d-4744-4de1-ab07-3cbaded6944a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "96cfe238-60ac-437d-a22e-cd8dd6376a6a", "3499b310-0945-467a-a067-50b553365978" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b1f2d4f0-f481-4835-a449-cb407de91e96", "f7d76828-4209-4f86-86de-34a87ad69682" });

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: new Guid("555fa1ec-5182-49fd-8e5b-e45ae25f3814"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96cfe238-60ac-437d-a22e-cd8dd6376a6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1f2d4f0-f481-4835-a449-cb407de91e96");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09a58e9e-43c2-4dd9-9e37-dd3bbbecd26b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2768db5d-4744-4de1-ab07-3cbaded6944a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3499b310-0945-467a-a067-50b553365978");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f7d76828-4209-4f86-86de-34a87ad69682");

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: new Guid("a033dae0-c69e-49e4-97af-a83d6963f6a5"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d6e7972-22df-4ec3-a90c-e269e1e16e02", "2", "User", "USER" },
                    { "e298f69a-7736-4ef1-976c-e098f3f52092", "1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1572716a-b14b-4e2c-800d-80439e72bccc", 0, "75affe4a-cfa0-4a68-84e8-0b4473fea8ef", "rahul@abc.com", true, false, null, "RAHUL@ABC.COM", "RAHUL_DEY", "AQAAAAEAACcQAAAAEN2U/sMQHHVHg5xllb4brnGJZZzVk22zlV/En9nEntIL9YvCdOsjiZ1AlWgCK9AQlA==", "8887654321", true, "ed34f6cd-4b4a-44bd-949b-7c146dc005a7", false, "Rahul_Dey" },
                    { "5d10a95b-b14d-41ef-9294-d5c45a87432f", 0, "5024a161-e42d-438c-b6c0-6d3f3ef5dd63", "aseem@abc.com", true, false, null, "ASEEM@ABC.COM", "ASEEM_SHARMA", "AQAAAAEAACcQAAAAEM/zd8M3/VRSf9+e23V0nQMnm9xmnOZzK6hNWJGUvm0AjV2SBnV92nNLsIR6y6IK2w==", "9988654321", true, "4f925360-f69b-48e0-9d6e-61bbf8a8f9a8", false, "Aseem_Sharma" },
                    { "6b53cfaf-4b94-496c-96fc-9700dfb9d077", 0, "a7a95c60-ec6e-48ac-ad29-c544ede8c0ba", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN_USER", "AQAAAAEAACcQAAAAEC3UtTeF3qEK3Yw2cTNqm4zMbPE2OWwO/+OmX/z8SfBZI6LWZbfWYvaPclkMSNIDXA==", "9876543210", true, "8f02719d-357f-4ccf-b7b6-9a03b20a82af", false, "Admin_User" },
                    { "86609c4c-30ff-4e22-8d6e-c92c1035fedb", 0, "8f3b619f-093e-4af9-8a01-dc8a561ff9dc", "shreshtha@abc.com", true, false, null, "SHRESHTHA@ABC.COM", "SHRESHTHA_KAMAL", "AQAAAAEAACcQAAAAENFNibl3/14OFJP2e6kWrgb+kEGFe8P5dcK8od48Cm1DN1G0HRk929RyxXtAmFd1XA==", "9987654321", true, "32d44edd-482a-40bc-a551-2a750b5734d0", false, "Shreshtha_Kamal" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "BannerImageUrl", "Description", "DirectorName", "Genre", "IsShowAdded", "MovieLengthInMinutes", "Name" },
                values: new object[] { new Guid("10af67fc-722f-45d5-aa7c-71d6f4727c8b"), "https://th.bing.com/th/id/OIP.iUa8j-Q-4JqiqYk4Uq1MawHaEK?rs=1&pid=ImgDetMain", "Story of 4 Friends in College", "Rajkumar Hirani", "Comedy", true, 153, "Fukrey Returns" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2d6e7972-22df-4ec3-a90c-e269e1e16e02", "1572716a-b14b-4e2c-800d-80439e72bccc" },
                    { "2d6e7972-22df-4ec3-a90c-e269e1e16e02", "5d10a95b-b14d-41ef-9294-d5c45a87432f" },
                    { "e298f69a-7736-4ef1-976c-e098f3f52092", "6b53cfaf-4b94-496c-96fc-9700dfb9d077" },
                    { "2d6e7972-22df-4ec3-a90c-e269e1e16e02", "86609c4c-30ff-4e22-8d6e-c92c1035fedb" }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowId", "EndDate", "EndTime", "MovieId", "Price", "ScreenId", "SeatsRemaining", "StartDate", "StartTime", "TotalSeats" },
                values: new object[] { new Guid("35e1dfce-9ccc-4044-9e9a-7d3ab7b2a069"), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 15, 0, 0, 0), new Guid("10af67fc-722f-45d5-aa7c-71d6f4727c8b"), 200, 1, 150, new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), 150 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d6e7972-22df-4ec3-a90c-e269e1e16e02", "1572716a-b14b-4e2c-800d-80439e72bccc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d6e7972-22df-4ec3-a90c-e269e1e16e02", "5d10a95b-b14d-41ef-9294-d5c45a87432f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e298f69a-7736-4ef1-976c-e098f3f52092", "6b53cfaf-4b94-496c-96fc-9700dfb9d077" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d6e7972-22df-4ec3-a90c-e269e1e16e02", "86609c4c-30ff-4e22-8d6e-c92c1035fedb" });

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: new Guid("35e1dfce-9ccc-4044-9e9a-7d3ab7b2a069"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d6e7972-22df-4ec3-a90c-e269e1e16e02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e298f69a-7736-4ef1-976c-e098f3f52092");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1572716a-b14b-4e2c-800d-80439e72bccc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d10a95b-b14d-41ef-9294-d5c45a87432f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b53cfaf-4b94-496c-96fc-9700dfb9d077");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86609c4c-30ff-4e22-8d6e-c92c1035fedb");

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: new Guid("10af67fc-722f-45d5-aa7c-71d6f4727c8b"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tickets");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "96cfe238-60ac-437d-a22e-cd8dd6376a6a", "2", "User", "USER" },
                    { "b1f2d4f0-f481-4835-a449-cb407de91e96", "1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "09a58e9e-43c2-4dd9-9e37-dd3bbbecd26b", 0, "724b7059-c71c-433f-9648-6bd6c4b9a77d", "rahul@abc.com", true, false, null, "RAHUL@ABC.COM", "RAHUL_DEY", "AQAAAAEAACcQAAAAEGRyktCbP/SBOhpsf/8WGYPFEiBjEhLx0BsGgUdzGW1qli9WyLh7/xRyM78DLtKu6A==", "8887654321", true, "c6aa62d3-a824-4c51-b28f-7f0fcafd257c", false, "Rahul_Dey" },
                    { "2768db5d-4744-4de1-ab07-3cbaded6944a", 0, "e748f251-9ce0-499a-aa11-f4a323b9f249", "shreshtha@abc.com", true, false, null, "SHRESHTHA@ABC.COM", "SHRESHTHA_KAMAL", "AQAAAAEAACcQAAAAEAAF9F5vhTCQxd9+fyYSV7jbzrvM9PYxhbBodeZo/MXmTVtCr4n+lDOP8/CO5gonJg==", "9987654321", true, "4361b1b3-fbe6-44c0-af9e-6f2d07ea6aa1", false, "Shreshtha_Kamal" },
                    { "3499b310-0945-467a-a067-50b553365978", 0, "b5cd27e8-159f-478c-8ff0-956e0ff72cbc", "aseem@abc.com", true, false, null, "ASEEM@ABC.COM", "ASEEM_SHARMA", "AQAAAAEAACcQAAAAEH0DlB+PhJ3RDABWekXFxQ3dh3yJriM9egoC9XO8s+IWXBr33EB9NaMcPW03E1e9rw==", "9988654321", true, "e26306ba-c262-4537-8d8a-82a674b7a7dc", false, "Aseem_Sharma" },
                    { "f7d76828-4209-4f86-86de-34a87ad69682", 0, "e3c2aaa3-5e73-465f-a754-5463978c692d", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN_USER", "AQAAAAEAACcQAAAAEDqJedUJNKg4sgh37fyzxWzZx9S/MpV7q9QzcDzC93vNyO8ImRzLVdMEtLMK9Nhsgw==", "9876543210", true, "aedfebe1-d7ca-4215-8c04-c7833b70125f", false, "Admin_User" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "BannerImageUrl", "Description", "DirectorName", "Genre", "IsShowAdded", "MovieLengthInMinutes", "Name" },
                values: new object[] { new Guid("a033dae0-c69e-49e4-97af-a83d6963f6a5"), "https://th.bing.com/th/id/OIP.iUa8j-Q-4JqiqYk4Uq1MawHaEK?rs=1&pid=ImgDetMain", "Story of 4 Friends in College", "Rajkumar Hirani", "Comedy", true, 153, "Fukrey Returns" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "96cfe238-60ac-437d-a22e-cd8dd6376a6a", "09a58e9e-43c2-4dd9-9e37-dd3bbbecd26b" },
                    { "96cfe238-60ac-437d-a22e-cd8dd6376a6a", "2768db5d-4744-4de1-ab07-3cbaded6944a" },
                    { "96cfe238-60ac-437d-a22e-cd8dd6376a6a", "3499b310-0945-467a-a067-50b553365978" },
                    { "b1f2d4f0-f481-4835-a449-cb407de91e96", "f7d76828-4209-4f86-86de-34a87ad69682" }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowId", "EndDate", "EndTime", "MovieId", "Price", "ScreenId", "SeatsRemaining", "StartDate", "StartTime", "TotalSeats" },
                values: new object[] { new Guid("555fa1ec-5182-49fd-8e5b-e45ae25f3814"), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 15, 0, 0, 0), new Guid("a033dae0-c69e-49e4-97af-a83d6963f6a5"), 200, 1, 150, new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), 150 });
        }
    }
}
