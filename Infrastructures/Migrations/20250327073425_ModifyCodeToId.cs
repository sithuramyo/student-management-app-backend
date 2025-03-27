using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCodeToId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "59066d63-3849-4219-8d9a-fb6eafe20c97");

            migrationBuilder.RenameColumn(
                name: "CourseCode",
                table: "Subjects",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "StudentCode",
                table: "Guardians",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "StudentCode",
                table: "GradeReports",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "StudentCode",
                table: "Enrollments",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "CourseCode",
                table: "Enrollments",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "CourseCode",
                table: "CoursePrerequisites",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "CourseCode",
                table: "CourseFaculties",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "CourseCode",
                table: "ClassSchedules",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "StudentCode",
                table: "Attendances",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "CourseCode",
                table: "Attendances",
                newName: "CourseId");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "d115bd7f-6845-4a0d-b66a-38280dff2a5b", new DateTime(2025, 3, 27, 14, 4, 25, 290, DateTimeKind.Local).AddTicks(7968), "superadmin@studify.com", false, "Super Admin", "$2a$11$hev3.7AGdOTVFJKZrkKCEONteHQPO7EZCjvqR9Xr1UGPWsIGNZMMy", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "d115bd7f-6845-4a0d-b66a-38280dff2a5b");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Subjects",
                newName: "CourseCode");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Guardians",
                newName: "StudentCode");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "GradeReports",
                newName: "StudentCode");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Enrollments",
                newName: "StudentCode");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Enrollments",
                newName: "CourseCode");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CoursePrerequisites",
                newName: "CourseCode");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseFaculties",
                newName: "CourseCode");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "ClassSchedules",
                newName: "CourseCode");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Attendances",
                newName: "StudentCode");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Attendances",
                newName: "CourseCode");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "59066d63-3849-4219-8d9a-fb6eafe20c97", new DateTime(2025, 3, 27, 13, 8, 5, 260, DateTimeKind.Local).AddTicks(4300), "superadmin@studify.com", false, "Super Admin", "$2a$11$R68loZBa6vOt.BiWMUQH8..1jCEVHjqe5AMVeSH52ThvcPIaITA4a", null, "SuperAdmin", null });
        }
    }
}
