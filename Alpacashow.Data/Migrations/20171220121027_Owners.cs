using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Alpacashow.Data.Migrations
{
    public partial class Owners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowEventAnimals",
                table: "ShowEventAnimals");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "ShowEventAnimals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowEventAnimals",
                table: "ShowEventAnimals",
                columns: new[] { "AnimalId", "ShowEventId", "OwnerId" });

            migrationBuilder.CreateTable(
                name: "AnimalOwners",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalOwners", x => new { x.AnimalId, x.OwnerId });
                    table.ForeignKey(
                        name: "FK_AnimalOwners_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalOwners_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShowEventAnimals_OwnerId",
                table: "ShowEventAnimals",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalOwners_OwnerId",
                table: "AnimalOwners",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowEventAnimals_Owners_OwnerId",
                table: "ShowEventAnimals",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowEventAnimals_Owners_OwnerId",
                table: "ShowEventAnimals");

            migrationBuilder.DropTable(
                name: "AnimalOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowEventAnimals",
                table: "ShowEventAnimals");

            migrationBuilder.DropIndex(
                name: "IX_ShowEventAnimals_OwnerId",
                table: "ShowEventAnimals");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ShowEventAnimals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowEventAnimals",
                table: "ShowEventAnimals",
                columns: new[] { "AnimalId", "ShowEventId" });
        }
    }
}
