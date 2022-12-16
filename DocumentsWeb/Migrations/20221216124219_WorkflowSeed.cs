using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentsWeb.Migrations
{
    /// <inheritdoc />
    public partial class WorkflowSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowStep_Workflows_WorkflowId",
                table: "WorkflowStep");

            migrationBuilder.AlterColumn<int>(
                name: "WorkflowId",
                table: "WorkflowStep",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b47cb79a-2e5a-4027-9763-5c80ab612179", "AQAAAAIAAYagAAAAEPXSJxStB1Q1BumQ9PFQxEQ8S+lEkqdAzZujQe1nYbEeB8RqkEp3w/s4veb9ib0edg==", "2a92e231-ccf4-4ecf-a4b4-da0ad97f4561" });

            migrationBuilder.InsertData(
                table: "Workflows",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Default" });

            migrationBuilder.InsertData(
                table: "WorkflowStep",
                columns: new[] { "Id", "Action", "Order", "Value", "WorkflowId" },
                values: new object[] { 1, 1, 1, "*", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowStep_Workflows_WorkflowId",
                table: "WorkflowStep",
                column: "WorkflowId",
                principalTable: "Workflows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowStep_Workflows_WorkflowId",
                table: "WorkflowStep");

            migrationBuilder.DeleteData(
                table: "WorkflowStep",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workflows",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "WorkflowId",
                table: "WorkflowStep",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c0bf5ee-6d7d-4798-abcb-0f9aae7caba6", "AQAAAAIAAYagAAAAEHCeSQwiVTemtBKY2co2Xzv5uIqJNzZo1tMjb9HKy7gAqCDaxelUHPLO1LnNbtO7PA==", "77b346a5-2c19-4c09-be24-907eaf75aeaf" });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowStep_Workflows_WorkflowId",
                table: "WorkflowStep",
                column: "WorkflowId",
                principalTable: "Workflows",
                principalColumn: "Id");
        }
    }
}
