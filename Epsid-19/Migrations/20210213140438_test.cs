using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Epsid_19.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Prenom = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Sexe = table.Column<string>(type: "TEXT", maxLength: 2, nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TypePersonne = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Injections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marque = table.Column<string>(type: "TEXT", nullable: true),
                    NumLotVaccin = table.Column<int>(type: "INTEGER", nullable: false),
                    DateInjection = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateRappel = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdTypeVaccin = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonneId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Injections_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Injections_PersonneId",
                table: "Injections",
                column: "PersonneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Injections");

            migrationBuilder.DropTable(
                name: "Personnes");
        }
    }
}
