using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingMania.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "FishingPlaces");

            migrationBuilder.DropColumn(
                name: "Reservation",
                table: "FishingPlaces");

            migrationBuilder.AddColumn<Guid>(
                name: "HotelId",
                table: "FishingPlaces",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    FreePlace = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FishingPlaces_HotelId",
                table: "FishingPlaces",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_FishingPlaces_Hotel_HotelId",
                table: "FishingPlaces",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FishingPlaces_Hotel_HotelId",
                table: "FishingPlaces");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropIndex(
                name: "IX_FishingPlaces_HotelId",
                table: "FishingPlaces");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "FishingPlaces");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Events");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "FishingPlaces",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Reservation",
                table: "FishingPlaces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
