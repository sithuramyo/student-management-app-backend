using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixClassSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "b2a0d6f3-bbf7-47d8-9f22-792b7538e09e");

            migrationBuilder.RenameColumn(
                name: "CourseOfferingId",
                table: "ClassSchedules",
                newName: "AcademicTermId");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "7e364aea-4d3c-4808-bf5b-cb95047b2a4b", new DateTime(2025, 4, 18, 19, 41, 50, 872, DateTimeKind.Local).AddTicks(5129), "superadmin@studify.com", false, "Super Admin", "$2a$11$2a8y4WhcETCB8JWDHNeIi.lzxR3P.ih7h1jsamX8gMZ87Dagw2hvy", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "7e364aea-4d3c-4808-bf5b-cb95047b2a4b");

            migrationBuilder.RenameColumn(
                name: "AcademicTermId",
                table: "ClassSchedules",
                newName: "CourseOfferingId");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "b2a0d6f3-bbf7-47d8-9f22-792b7538e09e", new DateTime(2025, 4, 17, 17, 37, 10, 653, DateTimeKind.Local).AddTicks(5092), "superadmin@studify.com", false, "Super Admin", "$2a$11$dkos/gGJIybVgwM05ZfoIe0gBx0nz4YNZTIm8TbattjVWug3ne7fS", null, "SuperAdmin", null });
        }
    }
}
