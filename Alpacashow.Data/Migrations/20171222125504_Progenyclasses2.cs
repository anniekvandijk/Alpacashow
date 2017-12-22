using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Alpacashow.Data.Migrations
{
    public partial class Progenyclasses2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FemaleProgeny",
                columns: table => new
                {
                    FemaleProgenyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Animal1AnimalId = table.Column<int>(nullable: true),
                    Animal2AnimalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FemaleProgeny", x => x.FemaleProgenyId);
                    table.ForeignKey(
                        name: "FK_FemaleProgeny_Animals_Animal1AnimalId",
                        column: x => x.Animal1AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FemaleProgeny_Animals_Animal2AnimalId",
                        column: x => x.Animal2AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaleProgeny",
                columns: table => new
                {
                    MaleProgenyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Animal1AnimalId = table.Column<int>(nullable: true),
                    Animal2AnimalId = table.Column<int>(nullable: true),
                    Animal3AnimalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaleProgeny", x => x.MaleProgenyId);
                    table.ForeignKey(
                        name: "FK_MaleProgeny_Animals_Animal1AnimalId",
                        column: x => x.Animal1AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaleProgeny_Animals_Animal2AnimalId",
                        column: x => x.Animal2AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaleProgeny_Animals_Animal3AnimalId",
                        column: x => x.Animal3AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FemaleProgeny_Animal1AnimalId",
                table: "FemaleProgeny",
                column: "Animal1AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_FemaleProgeny_Animal2AnimalId",
                table: "FemaleProgeny",
                column: "Animal2AnimalId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FemaleProgeny");

            migrationBuilder.DropTable(
                name: "MaleProgeny");
        }
    }
}
