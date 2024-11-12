using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.healthy.Migrations
{
    /// <inheritdoc />
    public partial class addddddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Weigth = table.Column<double>(type: "REAL", nullable: false),
                    Heigth = table.Column<double>(type: "REAL", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Macros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Calories = table.Column<double>(type: "REAL", nullable: false),
                    Protein = table.Column<double>(type: "REAL", nullable: false),
                    Fat = table.Column<double>(type: "REAL", nullable: false),
                    Carbs = table.Column<double>(type: "REAL", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Macros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExerciseLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    BodyInformationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BMR = table.Column<double>(type: "REAL", nullable: false),
                    MedianKcalLose = table.Column<double>(type: "REAL", nullable: false),
                    RecomendedKcalToEat = table.Column<double>(type: "REAL", nullable: false),
                    MacrosId = table.Column<Guid>(type: "TEXT", nullable: true),
                    UserCpf = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diets_BodyInformation_BodyInformationId",
                        column: x => x.BodyInformationId,
                        principalTable: "BodyInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diets_Macros_MacrosId",
                        column: x => x.MacrosId,
                        principalTable: "Macros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Diets_Users_UserCpf",
                        column: x => x.UserCpf,
                        principalTable: "Users",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diets_BodyInformationId",
                table: "Diets",
                column: "BodyInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_MacrosId",
                table: "Diets",
                column: "MacrosId");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_UserCpf",
                table: "Diets",
                column: "UserCpf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "BodyInformation");

            migrationBuilder.DropTable(
                name: "Macros");
        }
    }
}
