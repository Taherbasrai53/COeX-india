using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COeX_India.Migrations
{
    /// <inheritdoc />
    public partial class RailwayLoginCredentials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassKey",
                table: "RailwayStations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StationAdminId",
                table: "RailwayStations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StationNo",
                table: "RailwayStations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassKey",
                table: "RailwayStations");

            migrationBuilder.DropColumn(
                name: "StationAdminId",
                table: "RailwayStations");

            migrationBuilder.DropColumn(
                name: "StationNo",
                table: "RailwayStations");
        }
    }
}
