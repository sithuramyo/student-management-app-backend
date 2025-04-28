using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ModifyClassSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "7a8204bf-3400-4670-ac9d-4194383477bf");

            migrationBuilder.AddColumn<string>(
                name: "CourseTitle",
                table: "ClassSchedules",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacultyName",
                table: "ClassSchedules",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "2d126407-22b0-4eac-9e89-a6f810f73184", new DateTime(2025, 4, 27, 19, 45, 32, 989, DateTimeKind.Local).AddTicks(6798), "superadmin@studify.com", false, "Super Admin", "$2a$11$piE4.rsXolCEdlxRaisTC.ddtPFQe89h04hqjesJvyUgij57tJUtq", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "2d126407-22b0-4eac-9e89-a6f810f73184");

            migrationBuilder.DropColumn(
                name: "CourseTitle",
                table: "ClassSchedules");

            migrationBuilder.DropColumn(
                name: "FacultyName",
                table: "ClassSchedules");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "7a8204bf-3400-4670-ac9d-4194383477bf", new DateTime(2025, 4, 27, 19, 19, 32, 610, DateTimeKind.Local).AddTicks(1896), "superadmin@studify.com", false, "Super Admin", "$2a$11$ZF1DfMO9EnWT7k1/ccic4.PASLUdNUS.APqXP8DgpqtyNnGP7rKhy", null, "SuperAdmin", null });
        }
    }
}
