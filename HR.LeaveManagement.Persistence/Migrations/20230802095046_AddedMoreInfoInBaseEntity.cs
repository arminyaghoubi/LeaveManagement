using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreInfoInBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "LeaveTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifierId",
                table: "LeaveTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifierId",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "LeaveAllocations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifierId",
                table: "LeaveAllocations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "CreatorId", "LastModifiedDate", "ModifierId" },
                values: new object[] { new DateTime(2023, 8, 2, 13, 20, 46, 30, DateTimeKind.Local).AddTicks(1096), null, new DateTime(2023, 8, 2, 13, 20, 46, 30, DateTimeKind.Local).AddTicks(1110), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "LeaveTypes");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "LeaveTypes");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "LeaveAllocations");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "LeaveAllocations");

            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 21, 10, 7, 58, 33, DateTimeKind.Local).AddTicks(9050), new DateTime(2023, 7, 21, 10, 7, 58, 33, DateTimeKind.Local).AddTicks(9071) });
        }
    }
}
