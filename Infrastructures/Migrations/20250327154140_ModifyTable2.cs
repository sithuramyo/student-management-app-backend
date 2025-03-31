using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ModifyTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "a58408fa-50a5-4f04-b13d-bbbbd660f66d");

            migrationBuilder.RenameColumn(
                name: "FacultyCode",
                table: "ClassSchedules",
                newName: "FacultyId");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "799cd6f1-7ad7-4035-a7b6-e382b70941b9", new DateTime(2025, 3, 27, 22, 11, 39, 959, DateTimeKind.Local).AddTicks(4883), "superadmin@studify.com", false, "Super Admin", "$2a$11$DcAQjac.ikxUWxgTO.Edde4izoLBorbld.1jRSFUTdiR6tVmm6QTK", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "799cd6f1-7ad7-4035-a7b6-e382b70941b9");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "ClassSchedules",
                newName: "FacultyCode");

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Level = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Profile = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "a58408fa-50a5-4f04-b13d-bbbbd660f66d", new DateTime(2025, 3, 27, 21, 20, 51, 951, DateTimeKind.Local).AddTicks(5272), "superadmin@studify.com", false, "Super Admin", "$2a$11$Pe.Wu.3MDuFXadYMNBe0YOKu31mAa8Cy1OLQUKzbYpsZ81BNlkxD.", null, "SuperAdmin", null });
        }
    }
}
