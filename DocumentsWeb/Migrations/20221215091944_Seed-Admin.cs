using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentsWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00ec1ab1-7cff-4eba-a109-1f176bd0216a", true, "AQAAAAIAAYagAAAAEAfjvnVZ6E4/O+vACFX1Yc24uucG17sjDQiIJtZjeUYvcdeVymgMIoS0VpUtznyNdQ==", "e58f55e0-91c5-4e2a-a7e5-3350309a170a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df037e00-9b5b-483d-b95e-4eda9eb068e2", false, null, "f51aaed3-5fa8-4dc6-b9c8-d8dbe0297bf6" });
        }
    }
}
