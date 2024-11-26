using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingMania.Data.Migrations
{
    /// <inheritdoc />
    public partial class car : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rezervation",
                table: "Cars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Rezervation",
                table: "Cars",
                type: "datetime2",
                nullable: true);
        }
    }
}
