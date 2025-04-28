using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ModifyAttendance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "7784cbf4-55ae-445c-b7d1-bf441158c8ed");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Attendances",
                newName: "ClassScheduleId");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "7a8204bf-3400-4670-ac9d-4194383477bf", new DateTime(2025, 4, 27, 19, 19, 32, 610, DateTimeKind.Local).AddTicks(1896), "superadmin@studify.com", false, "Super Admin", "$2a$11$ZF1DfMO9EnWT7k1/ccic4.PASLUdNUS.APqXP8DgpqtyNnGP7rKhy", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "7a8204bf-3400-4670-ac9d-4194383477bf");

            migrationBuilder.RenameColumn(
                name: "ClassScheduleId",
                table: "Attendances",
                newName: "CourseId");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "7784cbf4-55ae-445c-b7d1-bf441158c8ed", new DateTime(2025, 4, 22, 11, 46, 31, 496, DateTimeKind.Local).AddTicks(9099), "superadmin@studify.com", false, "Super Admin", "$2a$11$0tvGtsbYAklYjMpxCFNkyuZgDbW/H80Y/eLQPoKHfv/eyErvsszOS", null, "SuperAdmin", null });
        }
    }
}
