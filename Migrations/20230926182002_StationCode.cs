using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COeX_India.Migrations
{
    /// <inheritdoc />
    public partial class StationCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StationNo",
                table: "RailwayStations",
                newName: "StationCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StationCode",
                table: "RailwayStations",
                newName: "StationNo");
        }
    }
}
