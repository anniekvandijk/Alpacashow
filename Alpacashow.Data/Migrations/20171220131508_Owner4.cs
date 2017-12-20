using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Alpacashow.Data.Migrations
{
    public partial class Owner4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimalOwners",
                table: "AnimalOwners");

            migrationBuilder.AddColumn<int>(
                name: "AnimalOwnerId",
                table: "AnimalOwners",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimalOwners",
                table: "AnimalOwners",
                column: "AnimalOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalOwners_AnimalId",
                table: "AnimalOwners",
                column: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimalOwners",
                table: "AnimalOwners");

            migrationBuilder.DropIndex(
                name: "IX_AnimalOwners_AnimalId",
                table: "AnimalOwners");

            migrationBuilder.DropColumn(
                name: "AnimalOwnerId",
                table: "AnimalOwners");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimalOwners",
                table: "AnimalOwners",
                columns: new[] { "AnimalId", "OwnerId" });
        }
    }
}
