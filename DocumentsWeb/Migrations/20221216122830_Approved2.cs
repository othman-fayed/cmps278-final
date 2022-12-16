using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentsWeb.Migrations
{
    /// <inheritdoc />
    public partial class Approved2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Approved",
                table: "Documents",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Documents",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Documents",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Documents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c0bf5ee-6d7d-4798-abcb-0f9aae7caba6", "AQAAAAIAAYagAAAAEHCeSQwiVTemtBKY2co2Xzv5uIqJNzZo1tMjb9HKy7gAqCDaxelUHPLO1LnNbtO7PA==", "77b346a5-2c19-4c09-be24-907eaf75aeaf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Documents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17e4d5fd-da6e-406e-a1b4-6a6f4db76720", "AQAAAAIAAYagAAAAEGlo6LYg+wU4KLFmwqpXrYVh9iMvblWtZCOJRnXd2Ur9XqjdeCYpawfY1mBZu3vMqA==", "c22dd4eb-7e85-4d06-8889-2641bd307adc" });
        }
    }
}
