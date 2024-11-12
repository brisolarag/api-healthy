using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.healthy.Migrations
{
    /// <inheritdoc />
    public partial class addedHeigth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_BodyInformation_BodyInformationId",
                table: "Diets");

            migrationBuilder.DropTable(
                name: "BodyInformation");

            migrationBuilder.DropIndex(
                name: "IX_Diets_BodyInformationId",
                table: "Diets");

            migrationBuilder.DropColumn(
                name: "BodyInformationId",
                table: "Diets");

            migrationBuilder.AddColumn<int>(
                name: "Heigth",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Weigth",
                table: "Diets",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Heigth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Weigth",
                table: "Diets");

            migrationBuilder.AddColumn<Guid>(
                name: "BodyInformationId",
                table: "Diets",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BodyInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Heigth = table.Column<double>(type: "REAL", nullable: false),
                    Weigth = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyInformation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diets_BodyInformationId",
                table: "Diets",
                column: "BodyInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_BodyInformation_BodyInformationId",
                table: "Diets",
                column: "BodyInformationId",
                principalTable: "BodyInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
