using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Epsid19.Migrations
{
    public partial class CreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Injections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marque = table.Column<string>(type: "TEXT", nullable: true),
                    NumLot = table.Column<string>(type: "TEXT", nullable: true),
                    DateInjection = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateRappel = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TypeVaccin = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    Sexe = table.Column<string>(type: "TEXT", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TypePersonne = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InjectionsPersonnes",
                columns: table => new
                {
                    InjectionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonnesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InjectionsPersonnes", x => new { x.InjectionsId, x.PersonnesId });
                    table.ForeignKey(
                        name: "FK_InjectionsPersonnes_Injections_InjectionsId",
                        column: x => x.InjectionsId,
                        principalTable: "Injections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InjectionsPersonnes_Personnes_PersonnesId",
                        column: x => x.PersonnesId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InjectionsPersonnes_PersonnesId",
                table: "InjectionsPersonnes",
                column: "PersonnesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InjectionsPersonnes");

            migrationBuilder.DropTable(
                name: "Injections");

            migrationBuilder.DropTable(
                name: "Personnes");
        }
    }
}
