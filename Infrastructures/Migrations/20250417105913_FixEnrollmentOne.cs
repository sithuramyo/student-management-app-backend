using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixEnrollmentOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "e88c4056-c0eb-458c-b6f9-e504c1102aba");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Enrollments");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "0591540b-9201-45b1-aeea-64c07e5c5d02", new DateTime(2025, 4, 17, 17, 29, 12, 951, DateTimeKind.Local).AddTicks(8156), "superadmin@studify.com", false, "Super Admin", "$2a$11$iPGReha4Nfxsgxa0qlBXvuiJFvWjiVUn6OlK/RX/OvSl/U9cX4cFa", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "0591540b-9201-45b1-aeea-64c07e5c5d02");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Enrollments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "e88c4056-c0eb-458c-b6f9-e504c1102aba", new DateTime(2025, 4, 16, 14, 35, 46, 136, DateTimeKind.Local).AddTicks(4533), "superadmin@studify.com", false, "Super Admin", "$2a$11$silp.qowdsceTzh54PJZb.2GHXyT7yladR2sYQ.IfBMgeiIZxsB12", null, "SuperAdmin", null });
        }
    }
}
