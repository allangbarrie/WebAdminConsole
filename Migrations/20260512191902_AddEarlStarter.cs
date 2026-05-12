using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAdminConsole.Migrations
{
    /// <inheritdoc />
    public partial class AddEarlStarter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Saturday",
                table: "Runner",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sunday",
                table: "Runner",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saturday",
                table: "Runner");

            migrationBuilder.DropColumn(
                name: "Sunday",
                table: "Runner");
        }
    }
}
