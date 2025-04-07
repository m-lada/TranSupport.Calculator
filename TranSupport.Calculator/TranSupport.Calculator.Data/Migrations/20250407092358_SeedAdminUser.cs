using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranSupport.Calculator.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "PasswordHash", "UserRole" },
                values: new object[] { new Guid("ab87b1cd-8b67-44f8-bca0-4511da8d9c9c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@ts.pl", "$2a$11$DNEo7Gt7Asse1B0szA4Ls.SX2dR9YjKjpf/EnRQZyXg7S3ImMEZWy", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ab87b1cd-8b67-44f8-bca0-4511da8d9c9c"));
        }
    }
}
