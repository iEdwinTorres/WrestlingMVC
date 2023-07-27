using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WrestlingMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToUseStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Retired",
                table: "Wrestlers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Defunct",
                table: "Promotions",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Defunct",
                table: "Championships",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Wrestlers",
                newName: "Retired");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Promotions",
                newName: "Defunct");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Championships",
                newName: "Defunct");
        }
    }
}
