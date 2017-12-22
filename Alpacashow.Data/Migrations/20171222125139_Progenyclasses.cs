using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Alpacashow.Data.Migrations
{
    public partial class Progenyclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowEventId",
                table: "Colors",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BeforeSheerDate",
                table: "Animals",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SheerDate",
                table: "Animals",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ShowEventId",
                table: "Colors",
                column: "ShowEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_ShowEvents_ShowEventId",
                table: "Colors",
                column: "ShowEventId",
                principalTable: "ShowEvents",
                principalColumn: "ShowEventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_ShowEvents_ShowEventId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Colors_ShowEventId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "ShowEventId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "BeforeSheerDate",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "SheerDate",
                table: "Animals");
        }
    }
}
