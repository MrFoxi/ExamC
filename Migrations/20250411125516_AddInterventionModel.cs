using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceApi.Migrations
{
    /// <inheritdoc />
    public partial class AddInterventionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Technicians",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Technicians");
        }
    }
}
