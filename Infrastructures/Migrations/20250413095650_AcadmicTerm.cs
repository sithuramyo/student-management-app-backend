using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AcadmicTerm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "276239ef-682f-48e7-9ddb-240f9d3b38e0");

            migrationBuilder.DropColumn(
                name: "IsCurrentTerm",
                table: "AcademicTerms");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "c6da9bb3-1fad-42e3-97cb-9759a36b4ccc", new DateTime(2025, 4, 13, 16, 26, 49, 726, DateTimeKind.Local).AddTicks(3941), "superadmin@studify.com", false, "Super Admin", "$2a$11$HDRfRe9pvzy7dIvF61P4k.kAAjugsOgrcQ9lLZV6cjA67foHb6pEi", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "c6da9bb3-1fad-42e3-97cb-9759a36b4ccc");

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentTerm",
                table: "AcademicTerms",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "276239ef-682f-48e7-9ddb-240f9d3b38e0", new DateTime(2025, 4, 13, 15, 44, 21, 247, DateTimeKind.Local).AddTicks(8181), "superadmin@studify.com", false, "Super Admin", "$2a$11$d9hOY8mbD5yqGdN41VCyAuciiTt8kS43K0Vc0aY69hKVA0Zm.NqRO", null, "SuperAdmin", null });
        }
    }
}
