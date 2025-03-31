using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ModifyStudentNFaculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "d115bd7f-6845-4a0d-b66a-38280dff2a5b");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Guardians",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Faculties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Profile",
                table: "Faculties",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "a58408fa-50a5-4f04-b13d-bbbbd660f66d", new DateTime(2025, 3, 27, 21, 20, 51, 951, DateTimeKind.Local).AddTicks(5272), "superadmin@studify.com", false, "Super Admin", "$2a$11$Pe.Wu.3MDuFXadYMNBe0YOKu31mAa8Cy1OLQUKzbYpsZ81BNlkxD.", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "a58408fa-50a5-4f04-b13d-bbbbd660f66d");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "Profile",
                table: "Faculties");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Guardians",
                newName: "FullName");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "d115bd7f-6845-4a0d-b66a-38280dff2a5b", new DateTime(2025, 3, 27, 14, 4, 25, 290, DateTimeKind.Local).AddTicks(7968), "superadmin@studify.com", false, "Super Admin", "$2a$11$hev3.7AGdOTVFJKZrkKCEONteHQPO7EZCjvqR9Xr1UGPWsIGNZMMy", null, "SuperAdmin", null });
        }
    }
}
