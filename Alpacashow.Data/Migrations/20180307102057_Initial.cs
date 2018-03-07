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
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.BreedId);
                });

            migrationBuilder.CreateTable(
                name: "FleeceshowOrder",
                columns: table => new
                {
                    FleeceshowOrderId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FleeceshowOrder", x => x.FleeceshowOrderId);
                });

            migrationBuilder.CreateTable(
                name: "HaltershowOrder",
                columns: table => new
                {
                    HaltershowOrderId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HaltershowOrder", x => x.HaltershowOrderId);
                });

            migrationBuilder.CreateTable(
                name: "Sexes",
                columns: table => new
                {
                    SexId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexes", x => x.SexId);
                });

            migrationBuilder.CreateTable(
                name: "FleeceshowEvents",
                columns: table => new
                {
                    ShowEventId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Archived = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FleeceshowOrderId = table.Column<int>(nullable: true),
                    Judge = table.Column<string>(maxLength: 100, nullable: false),
                    Location = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FleeceshowEvents", x => x.ShowEventId);
                    table.ForeignKey(
                        name: "FK_FleeceshowEvents_FleeceshowOrder_FleeceshowOrderId",
                        column: x => x.FleeceshowOrderId,
                        principalTable: "FleeceshowOrder",
                        principalColumn: "FleeceshowOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HaltershowEvents",
                columns: table => new
                {
                    ShowEventId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Archived = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    HaltershowOrderId = table.Column<int>(nullable: true),
                    Judge = table.Column<string>(maxLength: 100, nullable: false),
                    Location = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HaltershowEvents", x => x.ShowEventId);
                    table.ForeignKey(
                        name: "FK_HaltershowEvents_HaltershowOrder_HaltershowOrderId",
                        column: x => x.HaltershowOrderId,
                        principalTable: "HaltershowOrder",
                        principalColumn: "HaltershowOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FleeceshowEventShowEventId = table.Column<int>(nullable: true),
                    HaltershowEventShowEventId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorId);
                    table.ForeignKey(
                        name: "FK_Colors_FleeceshowEvents_FleeceshowEventShowEventId",
                        column: x => x.FleeceshowEventShowEventId,
                        principalTable: "FleeceshowEvents",
                        principalColumn: "ShowEventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colors_HaltershowEvents_HaltershowEventShowEventId",
                        column: x => x.HaltershowEventShowEventId,
                        principalTable: "HaltershowEvents",
                        principalColumn: "ShowEventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BreedId = table.Column<int>(nullable: false),
                    Chip = table.Column<string>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    Dam = table.Column<string>(maxLength: 100, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    FarmName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    SexId = table.Column<int>(nullable: false),
                    SheerDate = table.Column<DateTime>(nullable: false),
                    Sire = table.Column<string>(maxLength: 100, nullable: false),
                    BeforeSheerDate = table.Column<DateTime>(nullable: true),
                    FleeceshowEventShowEventId = table.Column<int>(nullable: true),
                    HaltershowEventShowEventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animal_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "BreedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_Sexes_SexId",
                        column: x => x.SexId,
                        principalTable: "Sexes",
                        principalColumn: "SexId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animal_FleeceshowEvents_FleeceshowEventShowEventId",
                        column: x => x.FleeceshowEventShowEventId,
                        principalTable: "FleeceshowEvents",
                        principalColumn: "ShowEventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_HaltershowEvents_HaltershowEventShowEventId",
                        column: x => x.HaltershowEventShowEventId,
                        principalTable: "HaltershowEvents",
                        principalColumn: "ShowEventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FemaleProgeny",
                columns: table => new
                {
                    FemaleProgenyId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Animal1AnimalId = table.Column<int>(nullable: true),
                    Animal2AnimalId = table.Column<int>(nullable: true),
                    HaltershowEventShowEventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FemaleProgeny", x => x.FemaleProgenyId);
                    table.ForeignKey(
                        name: "FK_FemaleProgeny_Animal_Animal1AnimalId",
                        column: x => x.Animal1AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FemaleProgeny_Animal_Animal2AnimalId",
                        column: x => x.Animal2AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FemaleProgeny_HaltershowEvents_HaltershowEventShowEventId",
                        column: x => x.HaltershowEventShowEventId,
                        principalTable: "HaltershowEvents",
                        principalColumn: "ShowEventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaleProgeny",
                columns: table => new
                {
                    MaleProgenyId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Animal1AnimalId = table.Column<int>(nullable: true),
                    Animal2AnimalId = table.Column<int>(nullable: true),
                    Animal3AnimalId = table.Column<int>(nullable: true),
                    HaltershowEventShowEventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaleProgeny", x => x.MaleProgenyId);
                    table.ForeignKey(
                        name: "FK_MaleProgeny_Animal_Animal1AnimalId",
                        column: x => x.Animal1AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaleProgeny_Animal_Animal2AnimalId",
                        column: x => x.Animal2AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaleProgeny_Animal_Animal3AnimalId",
                        column: x => x.Animal3AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaleProgeny_HaltershowEvents_HaltershowEventShowEventId",
                        column: x => x.HaltershowEventShowEventId,
                        principalTable: "HaltershowEvents",
                        principalColumn: "ShowEventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_BreedId",
                table: "Animal",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ColorId",
                table: "Animal",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_SexId",
                table: "Animal",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_FleeceshowEventShowEventId",
                table: "Animal",
                column: "FleeceshowEventShowEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_HaltershowEventShowEventId",
                table: "Animal",
                column: "HaltershowEventShowEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_FleeceshowEventShowEventId",
                table: "Colors",
                column: "FleeceshowEventShowEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_HaltershowEventShowEventId",
                table: "Colors",
                column: "HaltershowEventShowEventId");

            migrationBuilder.CreateIndex(
                name: "IX_FemaleProgeny_Animal1AnimalId",
                table: "FemaleProgeny",
                column: "Animal1AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_FemaleProgeny_Animal2AnimalId",
                table: "FemaleProgeny",
                column: "Animal2AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_FemaleProgeny_HaltershowEventShowEventId",
                table: "FemaleProgeny",
                column: "HaltershowEventShowEventId");

            migrationBuilder.CreateIndex(
                name: "IX_FleeceshowEvents_FleeceshowOrderId",
                table: "FleeceshowEvents",
                column: "FleeceshowOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_HaltershowEvents_HaltershowOrderId",
                table: "HaltershowEvents",
                column: "HaltershowOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MaleProgeny_Animal1AnimalId",
                table: "MaleProgeny",
                column: "Animal1AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_MaleProgeny_Animal2AnimalId",
                table: "MaleProgeny",
                column: "Animal2AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_MaleProgeny_Animal3AnimalId",
                table: "MaleProgeny",
                column: "Animal3AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_MaleProgeny_HaltershowEventShowEventId",
                table: "MaleProgeny",
                column: "HaltershowEventShowEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgeClasses");

            migrationBuilder.DropTable(
                name: "FemaleProgeny");

            migrationBuilder.DropTable(
                name: "MaleProgeny");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sexes");

            migrationBuilder.DropTable(
                name: "FleeceshowEvents");

            migrationBuilder.DropTable(
                name: "HaltershowEvents");

            migrationBuilder.DropTable(
                name: "FleeceshowOrder");

            migrationBuilder.DropTable(
                name: "HaltershowOrder");
        }
    }
}
