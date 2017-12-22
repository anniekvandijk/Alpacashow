using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Alpacashow.Data.Migrations
{
    public partial class SplitHalsterAndFleeceshow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Breeds_BreedId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Colors_ColorId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Sexes_SexId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_ShowEvents_ShowEventId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Colors_ShowEvents_ShowEventId",
                table: "Colors");

            migrationBuilder.DropForeignKey(
                name: "FK_FemaleProgeny_Animals_Animal1AnimalId",
                table: "FemaleProgeny");

            migrationBuilder.DropForeignKey(
                name: "FK_FemaleProgeny_Animals_Animal2AnimalId",
                table: "FemaleProgeny");

            migrationBuilder.DropForeignKey(
                name: "FK_MaleProgeny_Animals_Animal1AnimalId",
                table: "MaleProgeny");

            migrationBuilder.DropForeignKey(
                name: "FK_MaleProgeny_Animals_Animal2AnimalId",
                table: "MaleProgeny");

            migrationBuilder.DropForeignKey(
                name: "FK_MaleProgeny_Animals_Animal3AnimalId",
                table: "MaleProgeny");

            migrationBuilder.DropTable(
                name: "ShowEvents");

            migrationBuilder.DropTable(
                name: "ShowTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animals",
                table: "Animals");

            migrationBuilder.RenameTable(
                name: "Animals",
                newName: "Animal");

            migrationBuilder.RenameColumn(
                name: "ShowEventId",
                table: "Colors",
                newName: "HaltershowEventShowEventId");

            migrationBuilder.RenameIndex(
                name: "IX_Colors_ShowEventId",
                table: "Colors",
                newName: "IX_Colors_HaltershowEventShowEventId");

            migrationBuilder.RenameColumn(
                name: "ShowEventId",
                table: "Animal",
                newName: "HaltershowEventShowEventId");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_ShowEventId",
                table: "Animal",
                newName: "IX_Animal_HaltershowEventShowEventId");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_SexId",
                table: "Animal",
                newName: "IX_Animal_SexId");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_ColorId",
                table: "Animal",
                newName: "IX_Animal_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_BreedId",
                table: "Animal",
                newName: "IX_Animal_BreedId");

            migrationBuilder.AddColumn<int>(
                name: "HaltershowEventShowEventId",
                table: "MaleProgeny",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HaltershowEventShowEventId",
                table: "FemaleProgeny",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FleeceshowEventShowEventId",
                table: "Colors",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BeforeSheerDate",
                table: "Animal",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Animal",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FleeceshowEventShowEventId",
                table: "Animal",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animal",
                table: "Animal",
                column: "AnimalId");

            migrationBuilder.CreateTable(
                name: "FleeceshowOrder",
                columns: table => new
                {
                    FleeceshowOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HaltershowOrder", x => x.HaltershowOrderId);
                });

            migrationBuilder.CreateTable(
                name: "FleeceshowEvents",
                columns: table => new
                {
                    ShowEventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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

            migrationBuilder.CreateIndex(
                name: "IX_MaleProgeny_HaltershowEventShowEventId",
                table: "MaleProgeny",
                column: "HaltershowEventShowEventId");

            migrationBuilder.CreateIndex(
                name: "IX_FemaleProgeny_HaltershowEventShowEventId",
                table: "FemaleProgeny",
                column: "HaltershowEventShowEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_FleeceshowEventShowEventId",
                table: "Colors",
                column: "FleeceshowEventShowEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_FleeceshowEventShowEventId",
                table: "Animal",
                column: "FleeceshowEventShowEventId");

            migrationBuilder.CreateIndex(
                name: "IX_FleeceshowEvents_FleeceshowOrderId",
                table: "FleeceshowEvents",
                column: "FleeceshowOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_HaltershowEvents_HaltershowOrderId",
                table: "HaltershowEvents",
                column: "HaltershowOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Breeds_BreedId",
                table: "Animal",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "BreedId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Colors_ColorId",
                table: "Animal",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Sexes_SexId",
                table: "Animal",
                column: "SexId",
                principalTable: "Sexes",
                principalColumn: "SexId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_FleeceshowEvents_FleeceshowEventShowEventId",
                table: "Animal",
                column: "FleeceshowEventShowEventId",
                principalTable: "FleeceshowEvents",
                principalColumn: "ShowEventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_HaltershowEvents_HaltershowEventShowEventId",
                table: "Animal",
                column: "HaltershowEventShowEventId",
                principalTable: "HaltershowEvents",
                principalColumn: "ShowEventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_FleeceshowEvents_FleeceshowEventShowEventId",
                table: "Colors",
                column: "FleeceshowEventShowEventId",
                principalTable: "FleeceshowEvents",
                principalColumn: "ShowEventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_HaltershowEvents_HaltershowEventShowEventId",
                table: "Colors",
                column: "HaltershowEventShowEventId",
                principalTable: "HaltershowEvents",
                principalColumn: "ShowEventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FemaleProgeny_Animal_Animal1AnimalId",
                table: "FemaleProgeny",
                column: "Animal1AnimalId",
                principalTable: "Animal",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FemaleProgeny_Animal_Animal2AnimalId",
                table: "FemaleProgeny",
                column: "Animal2AnimalId",
                principalTable: "Animal",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FemaleProgeny_HaltershowEvents_HaltershowEventShowEventId",
                table: "FemaleProgeny",
                column: "HaltershowEventShowEventId",
                principalTable: "HaltershowEvents",
                principalColumn: "ShowEventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaleProgeny_Animal_Animal1AnimalId",
                table: "MaleProgeny",
                column: "Animal1AnimalId",
                principalTable: "Animal",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaleProgeny_Animal_Animal2AnimalId",
                table: "MaleProgeny",
                column: "Animal2AnimalId",
                principalTable: "Animal",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaleProgeny_Animal_Animal3AnimalId",
                table: "MaleProgeny",
                column: "Animal3AnimalId",
                principalTable: "Animal",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaleProgeny_HaltershowEvents_HaltershowEventShowEventId",
                table: "MaleProgeny",
                column: "HaltershowEventShowEventId",
                principalTable: "HaltershowEvents",
                principalColumn: "ShowEventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Breeds_BreedId",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Colors_ColorId",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Sexes_SexId",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_FleeceshowEvents_FleeceshowEventShowEventId",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_HaltershowEvents_HaltershowEventShowEventId",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Colors_FleeceshowEvents_FleeceshowEventShowEventId",
                table: "Colors");

            migrationBuilder.DropForeignKey(
                name: "FK_Colors_HaltershowEvents_HaltershowEventShowEventId",
                table: "Colors");

            migrationBuilder.DropForeignKey(
                name: "FK_FemaleProgeny_Animal_Animal1AnimalId",
                table: "FemaleProgeny");

            migrationBuilder.DropForeignKey(
                name: "FK_FemaleProgeny_Animal_Animal2AnimalId",
                table: "FemaleProgeny");

            migrationBuilder.DropForeignKey(
                name: "FK_FemaleProgeny_HaltershowEvents_HaltershowEventShowEventId",
                table: "FemaleProgeny");

            migrationBuilder.DropForeignKey(
                name: "FK_MaleProgeny_Animal_Animal1AnimalId",
                table: "MaleProgeny");

            migrationBuilder.DropForeignKey(
                name: "FK_MaleProgeny_Animal_Animal2AnimalId",
                table: "MaleProgeny");

            migrationBuilder.DropForeignKey(
                name: "FK_MaleProgeny_Animal_Animal3AnimalId",
                table: "MaleProgeny");

            migrationBuilder.DropForeignKey(
                name: "FK_MaleProgeny_HaltershowEvents_HaltershowEventShowEventId",
                table: "MaleProgeny");

            migrationBuilder.DropTable(
                name: "FleeceshowEvents");

            migrationBuilder.DropTable(
                name: "HaltershowEvents");

            migrationBuilder.DropTable(
                name: "FleeceshowOrder");

            migrationBuilder.DropTable(
                name: "HaltershowOrder");

            migrationBuilder.DropIndex(
                name: "IX_MaleProgeny_HaltershowEventShowEventId",
                table: "MaleProgeny");

            migrationBuilder.DropIndex(
                name: "IX_FemaleProgeny_HaltershowEventShowEventId",
                table: "FemaleProgeny");

            migrationBuilder.DropIndex(
                name: "IX_Colors_FleeceshowEventShowEventId",
                table: "Colors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animal",
                table: "Animal");

            migrationBuilder.DropIndex(
                name: "IX_Animal_FleeceshowEventShowEventId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "HaltershowEventShowEventId",
                table: "MaleProgeny");

            migrationBuilder.DropColumn(
                name: "HaltershowEventShowEventId",
                table: "FemaleProgeny");

            migrationBuilder.DropColumn(
                name: "FleeceshowEventShowEventId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "FleeceshowEventShowEventId",
                table: "Animal");

            migrationBuilder.RenameTable(
                name: "Animal",
                newName: "Animals");

            migrationBuilder.RenameColumn(
                name: "HaltershowEventShowEventId",
                table: "Colors",
                newName: "ShowEventId");

            migrationBuilder.RenameIndex(
                name: "IX_Colors_HaltershowEventShowEventId",
                table: "Colors",
                newName: "IX_Colors_ShowEventId");

            migrationBuilder.RenameColumn(
                name: "HaltershowEventShowEventId",
                table: "Animals",
                newName: "ShowEventId");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_HaltershowEventShowEventId",
                table: "Animals",
                newName: "IX_Animals_ShowEventId");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_SexId",
                table: "Animals",
                newName: "IX_Animals_SexId");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_ColorId",
                table: "Animals",
                newName: "IX_Animals_ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_BreedId",
                table: "Animals",
                newName: "IX_Animals_BreedId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BeforeSheerDate",
                table: "Animals",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animals",
                table: "Animals",
                column: "AnimalId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ShowEvents_ShowTypeId",
                table: "ShowEvents",
                column: "ShowTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Breeds_BreedId",
                table: "Animals",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "BreedId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Colors_ColorId",
                table: "Animals",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Sexes_SexId",
                table: "Animals",
                column: "SexId",
                principalTable: "Sexes",
                principalColumn: "SexId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_ShowEvents_ShowEventId",
                table: "Animals",
                column: "ShowEventId",
                principalTable: "ShowEvents",
                principalColumn: "ShowEventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_ShowEvents_ShowEventId",
                table: "Colors",
                column: "ShowEventId",
                principalTable: "ShowEvents",
                principalColumn: "ShowEventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FemaleProgeny_Animals_Animal1AnimalId",
                table: "FemaleProgeny",
                column: "Animal1AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FemaleProgeny_Animals_Animal2AnimalId",
                table: "FemaleProgeny",
                column: "Animal2AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaleProgeny_Animals_Animal1AnimalId",
                table: "MaleProgeny",
                column: "Animal1AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaleProgeny_Animals_Animal2AnimalId",
                table: "MaleProgeny",
                column: "Animal2AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaleProgeny_Animals_Animal3AnimalId",
                table: "MaleProgeny",
                column: "Animal3AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
