using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ModifyClassSchedule2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "0aca6cae-01ee-4b23-aace-1f31dca8f13c");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "ClassSchedules");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "597acc30-8964-465e-968c-931eb1d5d973", new DateTime(2025, 5, 8, 13, 3, 26, 492, DateTimeKind.Local).AddTicks(214), "superadmin@studify.com", false, "Super Admin", "$2a$11$haNH4Au0PnKefNplZ7c4xOFdGcXIDVtqxfZVZkmeIslK36zeVvsfe", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "597acc30-8964-465e-968c-931eb1d5d973");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "ClassSchedules",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "0aca6cae-01ee-4b23-aace-1f31dca8f13c", new DateTime(2025, 5, 6, 13, 45, 8, 646, DateTimeKind.Local).AddTicks(67), "superadmin@studify.com", false, "Super Admin", "$2a$11$qgEe0UhHbAYQmQhNkiVBCeR8cDveMGS4pzElHJiHJK.biJuYCzGkq", null, "SuperAdmin", null });
        }
    }
}
