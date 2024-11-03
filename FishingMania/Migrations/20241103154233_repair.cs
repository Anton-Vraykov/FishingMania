using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FishingMania.Migrations
{
    /// <inheritdoc />
    public partial class repair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FishingPlaces_Hotel_HotelId",
                table: "FishingPlaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel");

            migrationBuilder.RenameTable(
                name: "Hotel",
                newName: "Hotels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels",
                column: "Id");

            migrationBuilder.InsertData(
                table: "TypesFishings",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("12c8dd8d-346b-426e-b06c-75bba97dcd63"), "RiverFishing" },
                    { new Guid("bc64e8ef-5f7c-4edc-83d5-a43c9973eefc"), "LakeFishing" },
                    { new Guid("bd719745-fa48-4adc-bac1-0898a04e5822"), "SeaFishing" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FishingPlaces_Hotels_HotelId",
                table: "FishingPlaces",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FishingPlaces_Hotels_HotelId",
                table: "FishingPlaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels");

            migrationBuilder.DeleteData(
                table: "TypesFishings",
                keyColumn: "Id",
                keyValue: new Guid("12c8dd8d-346b-426e-b06c-75bba97dcd63"));

            migrationBuilder.DeleteData(
                table: "TypesFishings",
                keyColumn: "Id",
                keyValue: new Guid("bc64e8ef-5f7c-4edc-83d5-a43c9973eefc"));

            migrationBuilder.DeleteData(
                table: "TypesFishings",
                keyColumn: "Id",
                keyValue: new Guid("bd719745-fa48-4adc-bac1-0898a04e5822"));

            migrationBuilder.RenameTable(
                name: "Hotels",
                newName: "Hotel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotel",
                table: "Hotel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FishingPlaces_Hotel_HotelId",
                table: "FishingPlaces",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
