using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixEnrollmentTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "0591540b-9201-45b1-aeea-64c07e5c5d02");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "b2a0d6f3-bbf7-47d8-9f22-792b7538e09e", new DateTime(2025, 4, 17, 17, 37, 10, 653, DateTimeKind.Local).AddTicks(5092), "superadmin@studify.com", false, "Super Admin", "$2a$11$dkos/gGJIybVgwM05ZfoIe0gBx0nz4YNZTIm8TbattjVWug3ne7fS", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "b2a0d6f3-bbf7-47d8-9f22-792b7538e09e");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "0591540b-9201-45b1-aeea-64c07e5c5d02", new DateTime(2025, 4, 17, 17, 29, 12, 951, DateTimeKind.Local).AddTicks(8156), "superadmin@studify.com", false, "Super Admin", "$2a$11$iPGReha4Nfxsgxa0qlBXvuiJFvWjiVUn6OlK/RX/OvSl/U9cX4cFa", null, "SuperAdmin", null });
        }
    }
}
