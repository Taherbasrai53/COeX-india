using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COeX_India.Migrations
{
    /// <inheritdoc />
    public partial class Commonfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertedAt",
                table: "Requests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsertedById",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Requests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertedAt",
                table: "RailwayStations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsertedById",
                table: "RailwayStations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "RailwayStations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "RailwayStations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertedAt",
                table: "Mines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsertedById",
                table: "Mines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Mines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Mines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertedAt",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "InsertedById",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "InsertedAt",
                table: "RailwayStations");

            migrationBuilder.DropColumn(
                name: "InsertedById",
                table: "RailwayStations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "RailwayStations");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "RailwayStations");

            migrationBuilder.DropColumn(
                name: "InsertedAt",
                table: "Mines");

            migrationBuilder.DropColumn(
                name: "InsertedById",
                table: "Mines");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Mines");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Mines");
        }
    }
}
