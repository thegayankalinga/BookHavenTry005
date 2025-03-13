using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookHavenClassLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastLoginAt", "LastName", "PasswordHash", "Role", "Salt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), "admin@bookhaven.com", "Admin", new DateTime(2024, 3, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), "User", "QpLkF1G7uy0L1+VyiQKduG0qK6JZbbTtFqeRzGcy3Vs=", 0, "1oX2+HLYhpIImDRzMYlu+g==" },
                    { 2, new DateTime(2024, 3, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), "sales001@bookhaven.com", "John", new DateTime(2024, 3, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), "Sales001", "rCPxaz0+DAoNSKkvruJH3PxjfDMeIyTYlMFrYl1BmPU=", 1, "cQQxDnVvUg6iSC3qcaVj4Q==" },
                    { 3, new DateTime(2024, 3, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), "clerk001@bookhaven.com", "John", new DateTime(2024, 3, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), "Clerk001", "Qo2lVpmulOfrFvTYWCP0XlgFQ0q2q+KjQGhhGgNGvd8=", 1, "qf0effYCz9WKVKXCc2A7Zw==" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
