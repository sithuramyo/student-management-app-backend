using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ModifySuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "cce21ba4-9929-491b-a05a-460d85af3b0e");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentId",
                table: "Courses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "882018f7-4e2b-4d95-bbdb-f72b19829197", new DateTime(2025, 3, 22, 20, 37, 22, 104, DateTimeKind.Local).AddTicks(5662), "superadmin@studify.com", false, "Super Admin", "$2a$11$Hyaf7TQnPpGLyNQNzSJrs.EdIPNIMKmv3m/Zj9AKUlPgKEAQxVboG", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "882018f7-4e2b-4d95-bbdb-f72b19829197");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentId",
                table: "Courses",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "cce21ba4-9929-491b-a05a-460d85af3b0e", new DateTime(2025, 3, 22, 19, 41, 52, 356, DateTimeKind.Local).AddTicks(5567), "superadmin@studify.com", false, "Super Admin", "$2a$11$8GtDNZh9RZuJeughedRE9OX7rQzAGMFP5SMc9QqfKNP3ElqJ.RgUm", null, "SuperAdmin", null });
        }
    }
}
