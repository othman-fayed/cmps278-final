using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentsWeb.Migrations
{
    /// <inheritdoc />
    public partial class ApprovedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "approved", null, "Approved", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab45391f-f8bc-4215-ac01-6fde6fdb1dc6", "AQAAAAIAAYagAAAAENoMmYKNQ3m7GzmGv1DUVFOWRJTW40kxWGrpEpfveCR4Dl+yfJKNv/nSsMwUXndhlQ==", "fe805091-6d5b-4544-84d3-26dccaed77d9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "approved");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2c91df8-c2b6-44d7-b746-fcdfbea69cf7", "AQAAAAIAAYagAAAAEFdc/61aO7sbQ7Oa1k6wcttumBGKNfDBrOsK/J+6T0dmAVj7vk2dAqmo29mr/xMZOg==", "a6ba7039-a5c7-4b92-8c6b-99a7b63610d3" });
        }
    }
}
