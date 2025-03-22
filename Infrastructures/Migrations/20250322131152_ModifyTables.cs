using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ModifyTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "4a9fd70a-a3ce-4f4f-859a-81c93b060cba");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "Profile",
                table: "Faculties");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Students",
                newName: "SystemUserId");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Faculties",
                newName: "SystemUserId");

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
                values: new object[] { "cce21ba4-9929-491b-a05a-460d85af3b0e", new DateTime(2025, 3, 22, 19, 41, 52, 356, DateTimeKind.Local).AddTicks(5567), "superadmin@studify.com", false, "Super Admin", "$2a$11$8GtDNZh9RZuJeughedRE9OX7rQzAGMFP5SMc9QqfKNP3ElqJ.RgUm", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "cce21ba4-9929-491b-a05a-460d85af3b0e");

            migrationBuilder.RenameColumn(
                name: "SystemUserId",
                table: "Students",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "SystemUserId",
                table: "Faculties",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Faculties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Faculties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Profile",
                table: "Faculties",
                type: "text",
                nullable: true);

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
    }
}
