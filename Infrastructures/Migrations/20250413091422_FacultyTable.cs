using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FacultyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "799cd6f1-7ad7-4035-a7b6-e382b70941b9");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "Faculties",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Faculties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "276239ef-682f-48e7-9ddb-240f9d3b38e0", new DateTime(2025, 4, 13, 15, 44, 21, 247, DateTimeKind.Local).AddTicks(8181), "superadmin@studify.com", false, "Super Admin", "$2a$11$d9hOY8mbD5yqGdN41VCyAuciiTt8kS43K0Vc0aY69hKVA0Zm.NqRO", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "276239ef-682f-48e7-9ddb-240f9d3b38e0");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Faculties");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "799cd6f1-7ad7-4035-a7b6-e382b70941b9", new DateTime(2025, 3, 27, 22, 11, 39, 959, DateTimeKind.Local).AddTicks(4883), "superadmin@studify.com", false, "Super Admin", "$2a$11$DcAQjac.ikxUWxgTO.Edde4izoLBorbld.1jRSFUTdiR6tVmm6QTK", null, "SuperAdmin", null });
        }
    }
}
