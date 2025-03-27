using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ModifyPrerequisite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "882018f7-4e2b-4d95-bbdb-f72b19829197");

            migrationBuilder.DropColumn(
                name: "Prerequisite",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "MinimumGradeRequired",
                table: "Prerequisites",
                newName: "RequiredMinimumGrade");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "59066d63-3849-4219-8d9a-fb6eafe20c97", new DateTime(2025, 3, 27, 13, 8, 5, 260, DateTimeKind.Local).AddTicks(4300), "superadmin@studify.com", false, "Super Admin", "$2a$11$R68loZBa6vOt.BiWMUQH8..1jCEVHjqe5AMVeSH52ThvcPIaITA4a", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "59066d63-3849-4219-8d9a-fb6eafe20c97");

            migrationBuilder.RenameColumn(
                name: "RequiredMinimumGrade",
                table: "Prerequisites",
                newName: "MinimumGradeRequired");

            migrationBuilder.AddColumn<string>(
                name: "Prerequisite",
                table: "Courses",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "882018f7-4e2b-4d95-bbdb-f72b19829197", new DateTime(2025, 3, 22, 20, 37, 22, 104, DateTimeKind.Local).AddTicks(5662), "superadmin@studify.com", false, "Super Admin", "$2a$11$Hyaf7TQnPpGLyNQNzSJrs.EdIPNIMKmv3m/Zj9AKUlPgKEAQxVboG", null, "SuperAdmin", null });
        }
    }
}
