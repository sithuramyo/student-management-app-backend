using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeLeave : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "597acc30-8964-465e-968c-931eb1d5d973");

            migrationBuilder.CreateTable(
                name: "EmployeeLeaveInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    LeaveName = table.Column<string>(type: "text", nullable: false),
                    LeaveType = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TypicalDays = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLeaveInfos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmployeeLeaveInfos",
                columns: new[] { "Id", "Description", "LeaveName", "LeaveType", "TypicalDays" },
                values: new object[,]
                {
                    { "1bb6282b-c72c-419c-9c5a-d16b5b72b402", "In lieu of working extra hours/weekends", "Compensatory Leave", 7, "Depends on overtime" },
                    { "382bb94d-f742-406b-8562-8413d18096b9", "When all other paid leave is exhausted", "Unpaid Leave", 6, "Unlimited (as approved)" },
                    { "4cc57b0b-bc7f-45ba-a5dc-f922000ffea6", "For male employees after child birth", "Paternity Leave", 5, "5–15 days" },
                    { "66bde8d8-da28-4d9b-860d-c95b909b5de8", "For death of immediate family", "Bereavement Leave", 8, "3–7 days" },
                    { "6e602c9e-0216-46c4-aa0d-df20282d27f9", "Short-term urgent needs (e.g., family matters, errands)", "Casual Leave", 3, "3–7 days" },
                    { "87c9f36e-2cbc-4803-a313-dff6f2c4d47d", "Paid vacation leave for rest or travel", "Annual Leave", 1, "10–20 days" },
                    { "9adfc0b5-03b7-4843-8b36-f25de6bd5599", "For personal illness or medical reasons", "Sick Leave", 2, "5–15 days" },
                    { "b1fa7f0e-df6d-40b4-95fd-18b997ce3507", "For exam/study purposes", "Study Leave", 10, "Varies (optional)" },
                    { "b6443c24-1185-4470-b632-997180483c55", "For childbirth and recovery (only for female employees)", "Maternity Leave", 4, "60–90 days" },
                    { "fc3ffdc8-3d63-4e47-9c02-1f2faf09b8dd", "For employee's own wedding", "Marriage Leave", 9, "3–5 days" }
                });

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "680ecd77-8a05-43c6-9035-0dd69c7b389e", new DateTime(2025, 5, 9, 15, 24, 59, 629, DateTimeKind.Local).AddTicks(2702), "superadmin@studify.com", false, "Super Admin", "$2a$11$RQnHtNvdCEftkgg.5s5yPe4eHsIIFrGBVzCYBQoMAl/C9cHaOXP6K", null, "SuperAdmin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLeaveInfos");

            migrationBuilder.DeleteData(
                table: "SystemUsers",
                keyColumn: "Id",
                keyValue: "680ecd77-8a05-43c6-9035-0dd69c7b389e");

            migrationBuilder.InsertData(
                table: "SystemUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Profile", "Role", "UpdatedAt" },
                values: new object[] { "597acc30-8964-465e-968c-931eb1d5d973", new DateTime(2025, 5, 8, 13, 3, 26, 492, DateTimeKind.Local).AddTicks(214), "superadmin@studify.com", false, "Super Admin", "$2a$11$haNH4Au0PnKefNplZ7c4xOFdGcXIDVtqxfZVZkmeIslK36zeVvsfe", null, "SuperAdmin", null });
        }
    }
}
