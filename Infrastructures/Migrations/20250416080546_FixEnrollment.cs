using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixEnrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "d3b9fe14-49f4-43d3-aa3a-b0b03524f580");

            migrationBuilder.DropColumn(
                name: "AcademicTermId",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Enrollments",
                newName: "CourseOfferingId");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "e88c4056-c0eb-458c-b6f9-e504c1102aba", new DateTime(2025, 4, 16, 14, 35, 46, 136, DateTimeKind.Local).AddTicks(4533), "superadmin@studify.com", false, "Super Admin", "$2a$11$silp.qowdsceTzh54PJZb.2GHXyT7yladR2sYQ.IfBMgeiIZxsB12", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "e88c4056-c0eb-458c-b6f9-e504c1102aba");

            migrationBuilder.RenameColumn(
                name: "CourseOfferingId",
                table: "Enrollments",
                newName: "CourseId");

            migrationBuilder.AddColumn<string>(
                name: "AcademicTermId",
                table: "Enrollments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "d3b9fe14-49f4-43d3-aa3a-b0b03524f580", new DateTime(2025, 4, 16, 14, 31, 53, 557, DateTimeKind.Local).AddTicks(4904), "superadmin@studify.com", false, "Super Admin", "$2a$11$Z6qSrN3M4rFomhHlTb2r/OGed616K/o5nVFhzyjDxC6dI3a3hq.Tq", null, "SuperAdmin", null });
        }
    }
}
