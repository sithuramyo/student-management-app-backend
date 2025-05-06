using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ModifyClassSchedule1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "c3de684f-ee43-4f8d-a8f8-d96b888ea162");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ScheduleDate",
                table: "ClassSchedules",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "0aca6cae-01ee-4b23-aace-1f31dca8f13c", new DateTime(2025, 5, 6, 13, 45, 8, 646, DateTimeKind.Local).AddTicks(67), "superadmin@studify.com", false, "Super Admin", "$2a$11$qgEe0UhHbAYQmQhNkiVBCeR8cDveMGS4pzElHJiHJK.biJuYCzGkq", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "0aca6cae-01ee-4b23-aace-1f31dca8f13c");

            migrationBuilder.DropColumn(
                name: "ScheduleDate",
                table: "ClassSchedules");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "c3de684f-ee43-4f8d-a8f8-d96b888ea162", new DateTime(2025, 4, 29, 21, 30, 5, 892, DateTimeKind.Local).AddTicks(9960), "superadmin@studify.com", false, "Super Admin", "$2a$11$bNAKWY1c.PnjgX2W6Rb5luYiK9X/xJee.7vL6wdwt/37M5nzSfogO", null, "SuperAdmin", null });
        }
    }
}
