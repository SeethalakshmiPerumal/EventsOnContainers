using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "catalog_event_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_location_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "CatalogLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    Zipcode = table.Column<int>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(fixedLength: true, nullable: false),
                    Time = table.Column<DateTime>(fixedLength: true, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(maxLength: 50, nullable: false),
                    PictureUrl = table.Column<string>(maxLength: 100, nullable: false),
                    ContactName = table.Column<string>(maxLength: 100, nullable: false),
                    ContactNum = table.Column<long>(fixedLength: true, nullable: false),
                    CatalogLocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogEvents_CatalogLocations_CatalogLocationId",
                        column: x => x.CatalogLocationId,
                        principalTable: "CatalogLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogEvents_CatalogLocationId",
                table: "CatalogEvents",
                column: "CatalogLocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogEvents");

            migrationBuilder.DropTable(
                name: "CatalogLocations");

            migrationBuilder.DropSequence(
                name: "catalog_event_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_location_hilo");
        }
    }
}
