using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "a5582b96-5bfa-4bcd-b4ae-6feed195c3e5");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ChatRooms",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "4a9fd70a-a3ce-4f4f-859a-81c93b060cba", new DateTime(2025, 3, 22, 12, 14, 18, 914, DateTimeKind.Local).AddTicks(3474), "superadmin@studify.com", false, "Super Admin", "$2a$11$I/9OeMmlnfrfruXuK7tGKeBGs34lehyLAPvGmDbeXYoWLxP6.Ephi", null, "SUPERADMIN", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "4a9fd70a-a3ce-4f4f-859a-81c93b060cba");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ChatRooms",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "a5582b96-5bfa-4bcd-b4ae-6feed195c3e5", new DateTime(2025, 3, 22, 10, 52, 33, 17, DateTimeKind.Local).AddTicks(8124), "superadmin@studify.com", false, "Super Admin", "$2a$11$Mmb3gWai6LPQ6DtjHLyJL.vstCkCrhPu4ZlnVK1AquLkQo9pJ6nuG", null, "SUPERADMIN", null });
        }
    }
}
