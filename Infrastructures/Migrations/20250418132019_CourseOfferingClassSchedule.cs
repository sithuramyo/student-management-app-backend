using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class CourseOfferingClassSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "7e364aea-4d3c-4808-bf5b-cb95047b2a4b");

            migrationBuilder.DropColumn(
                name: "AcademicTermId",
                table: "ClassSchedules");

            migrationBuilder.CreateTable(
                name: "CourseOfferingClassSchedules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CourseOfferingId = table.Column<string>(type: "text", nullable: false),
                    ClassScheduleId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOfferingClassSchedules", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "ae805925-8816-4df6-8ac6-061f363a57e7", new DateTime(2025, 4, 18, 19, 50, 18, 900, DateTimeKind.Local).AddTicks(9293), "superadmin@studify.com", false, "Super Admin", "$2a$11$2sNErrhAZ0Eweg6JY8i9iO6pr9PyYGdQ8of/m2Mujnvh29mJNcJDe", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseOfferingClassSchedules");

            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "ae805925-8816-4df6-8ac6-061f363a57e7");

            migrationBuilder.AddColumn<string>(
                name: "AcademicTermId",
                table: "ClassSchedules",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "7e364aea-4d3c-4808-bf5b-cb95047b2a4b", new DateTime(2025, 4, 18, 19, 41, 50, 872, DateTimeKind.Local).AddTicks(5129), "superadmin@studify.com", false, "Super Admin", "$2a$11$2a8y4WhcETCB8JWDHNeIi.lzxR3P.ih7h1jsamX8gMZ87Dagw2hvy", null, "SuperAdmin", null });
        }
    }
}
