using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayerMovieBookingAppDAL.Migrations
{
    public partial class AddedCardinalityforticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3483e31b-9ef1-42fa-a91f-c0bbda860d60", "462e7c8f-c658-4b30-8223-996f8a15ee7f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "809b85d0-f43d-445f-9a1f-9bf1f48366e3", "691322b5-6fac-4af2-8b40-5ab42cd25937" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3483e31b-9ef1-42fa-a91f-c0bbda860d60", "835b08ac-f700-40b5-b9f0-cd900964ecdb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3483e31b-9ef1-42fa-a91f-c0bbda860d60", "a26ad3a0-0432-4189-933e-5b4a4e6d09e6" });

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: new Guid("c83c0ddc-20bc-434e-b1dd-3e21dedf40ca"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3483e31b-9ef1-42fa-a91f-c0bbda860d60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "809b85d0-f43d-445f-9a1f-9bf1f48366e3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "462e7c8f-c658-4b30-8223-996f8a15ee7f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "691322b5-6fac-4af2-8b40-5ab42cd25937");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "835b08ac-f700-40b5-b9f0-cd900964ecdb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a26ad3a0-0432-4189-933e-5b4a4e6d09e6");

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: new Guid("51f3932f-d12e-48ea-b23b-cdb88011d649"));

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatCount = table.Column<int>(type: "int", nullable: false),
                    ShowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricePerSeat = table.Column<int>(type: "int", nullable: false),
                    ShowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "ShowId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShowId",
                table: "Tickets",
                column: "ShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3483e31b-9ef1-42fa-a91f-c0bbda860d60", "2", "User", "USER" },
                    { "809b85d0-f43d-445f-9a1f-9bf1f48366e3", "1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "462e7c8f-c658-4b30-8223-996f8a15ee7f", 0, "743771aa-5f40-4479-b25c-5d9dcc80bbf7", "rahul@abc.com", true, false, null, "RAHUL@ABC.COM", "RAHUL_DEY", "AQAAAAEAACcQAAAAEAOYMFiIUrAYEL/vm8zyF4VtmYaKDHhTCxWXlg3l2ZK+wqhXE+bIilG2TF9b+fm6aA==", "8887654321", true, "21ee6f16-1869-4e6a-a3e2-47724c497f7d", false, "Rahul_Dey" },
                    { "691322b5-6fac-4af2-8b40-5ab42cd25937", 0, "bf339c90-ae31-42ee-b6ab-0e749da59b1a", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN_USER", "AQAAAAEAACcQAAAAEB193FamwzpJ7l+dCgj03TekojnpIK8Ce5a9rAQcfw4yv4yNUW/hvbzce7H6DPMsWw==", "9876543210", true, "ab453c39-0538-47db-8697-e11a2c0487e0", false, "Admin_User" },
                    { "835b08ac-f700-40b5-b9f0-cd900964ecdb", 0, "38b032e3-142c-4a24-937f-4113985e3809", "shreshtha@abc.com", true, false, null, "SHRESHTHA@ABC.COM", "SHRESHTHA_KAMAL", "AQAAAAEAACcQAAAAELjYXUl7RGjNkzd0OxjjVkOaSISMJvz1yJvRqV7yVCwOPyyBMLBfuCUwOflm6cyS6g==", "9987654321", true, "e0f84c68-8a96-4957-8644-7348e485918c", false, "Shreshtha_Kamal" },
                    { "a26ad3a0-0432-4189-933e-5b4a4e6d09e6", 0, "2ae0d2d8-e113-43d9-afdd-3089a0ef8f54", "aseem@abc.com", true, false, null, "ASEEM@ABC.COM", "ASEEM_SHARMA", "AQAAAAEAACcQAAAAEGRNw9yuqg4aCbxCrCLMhbX2HUXh/csL4nbZ1FXy8hKvKcalHDZY7Yiy33lAUWw4Tg==", "9988654321", true, "d3e0fcfb-7cf4-4c07-87e0-290bba7fa75b", false, "Aseem_Sharma" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "BannerImageUrl", "Description", "DirectorName", "Genre", "IsShowAdded", "MovieLengthInMinutes", "Name" },
                values: new object[] { new Guid("51f3932f-d12e-48ea-b23b-cdb88011d649"), "https://th.bing.com/th/id/OIP.iUa8j-Q-4JqiqYk4Uq1MawHaEK?rs=1&pid=ImgDetMain", "Story of 4 Friends in College", "Rajkumar Hirani", "Comedy", true, 153, "Fukrey Returns" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3483e31b-9ef1-42fa-a91f-c0bbda860d60", "462e7c8f-c658-4b30-8223-996f8a15ee7f" },
                    { "809b85d0-f43d-445f-9a1f-9bf1f48366e3", "691322b5-6fac-4af2-8b40-5ab42cd25937" },
                    { "3483e31b-9ef1-42fa-a91f-c0bbda860d60", "835b08ac-f700-40b5-b9f0-cd900964ecdb" },
                    { "3483e31b-9ef1-42fa-a91f-c0bbda860d60", "a26ad3a0-0432-4189-933e-5b4a4e6d09e6" }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowId", "EndDate", "EndTime", "MovieId", "Price", "ScreenId", "SeatsRemaining", "StartDate", "StartTime", "TotalSeats" },
                values: new object[] { new Guid("c83c0ddc-20bc-434e-b1dd-3e21dedf40ca"), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 15, 0, 0, 0), new Guid("51f3932f-d12e-48ea-b23b-cdb88011d649"), 200, 1, 150, new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), 150 });
        }
    }
}
