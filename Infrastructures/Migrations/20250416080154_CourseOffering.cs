using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class CourseOffering : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseFaculties");

            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "c6da9bb3-1fad-42e3-97cb-9759a36b4ccc");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "ClassSchedules");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "ClassSchedules",
                newName: "CourseOfferingId");

            migrationBuilder.CreateTable(
                name: "CourseOfferings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AcademicTermId = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<string>(type: "text", nullable: false),
                    FacultyId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOfferings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "d3b9fe14-49f4-43d3-aa3a-b0b03524f580", new DateTime(2025, 4, 16, 14, 31, 53, 557, DateTimeKind.Local).AddTicks(4904), "superadmin@studify.com", false, "Super Admin", "$2a$11$Z6qSrN3M4rFomhHlTb2r/OGed616K/o5nVFhzyjDxC6dI3a3hq.Tq", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseOfferings");

            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "d3b9fe14-49f4-43d3-aa3a-b0b03524f580");

            migrationBuilder.RenameColumn(
                name: "CourseOfferingId",
                table: "ClassSchedules",
                newName: "FacultyId");

            migrationBuilder.AddColumn<string>(
                name: "CourseId",
                table: "ClassSchedules",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CourseFaculties",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FacultyCode = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFaculties", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "c6da9bb3-1fad-42e3-97cb-9759a36b4ccc", new DateTime(2025, 4, 13, 16, 26, 49, 726, DateTimeKind.Local).AddTicks(3941), "superadmin@studify.com", false, "Super Admin", "$2a$11$HDRfRe9pvzy7dIvF61P4k.kAAjugsOgrcQ9lLZV6cjA67foHb6pEi", null, "SuperAdmin", null });
        }
    }
}
