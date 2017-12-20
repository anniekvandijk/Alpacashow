using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Alpacashow.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeClasses",
                columns: table => new
                {
                    AgeClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeClasses", x => x.AgeClassId);
                });

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    BreedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.BreedId);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FarmName = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Sexes",
                columns: table => new
                {
                    SexId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexes", x => x.SexId);
                });

            migrationBuilder.CreateTable(
                name: "ShowTypes",
                columns: table => new
                {
                    ShowTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowTypes", x => x.ShowTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BreedId = table.Column<int>(nullable: false),
                    Chip = table.Column<string>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    Dam = table.Column<string>(maxLength: 100, nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    SexId = table.Column<int>(nullable: false),
                    Sire = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "BreedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Sexes_SexId",
                        column: x => x.SexId,
                        principalTable: "Sexes",
                        principalColumn: "SexId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowEvents",
                columns: table => new
                {
                    ShowEventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Archived = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Judge = table.Column<string>(maxLength: 100, nullable: false),
                    Location = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ShowTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowEvents", x => x.ShowEventId);
                    table.ForeignKey(
                        name: "FK_ShowEvents_ShowTypes_ShowTypeId",
                        column: x => x.ShowTypeId,
                        principalTable: "ShowTypes",
                        principalColumn: "ShowTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowEventAnimals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false),
                    ShowEventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowEventAnimals", x => new { x.AnimalId, x.ShowEventId });
                    table.ForeignKey(
                        name: "FK_ShowEventAnimals_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowEventAnimals_ShowEvents_ShowEventId",
                        column: x => x.ShowEventId,
                        principalTable: "ShowEvents",
                        principalColumn: "ShowEventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_BreedId",
                table: "Animals",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ColorId",
                table: "Animals",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_OwnerId",
                table: "Animals",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SexId",
                table: "Animals",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowEventAnimals_ShowEventId",
                table: "ShowEventAnimals",
                column: "ShowEventId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowEvents_ShowTypeId",
                table: "ShowEvents",
                column: "ShowTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgeClasses");

            migrationBuilder.DropTable(
                name: "ShowEventAnimals");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "ShowEvents");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Sexes");

            migrationBuilder.DropTable(
                name: "ShowTypes");
        }
    }
}
