using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cv10_databaze.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Predmety",
                columns: table => new
                {
                    Zkratka = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nazev = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmety", x => x.Zkratka);
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    ID_Studenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jmeno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prijmeni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum_Narozeni = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.ID_Studenta);
                });

            migrationBuilder.CreateTable(
                name: "Hodnoceni",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Studenta = table.Column<int>(type: "int", nullable: false),
                    StudentID_Studenta = table.Column<int>(type: "int", nullable: false),
                    Zkratka_Predmetu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PredmetZkratka = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Datum_Hodnoceni = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Známka = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hodnoceni", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hodnoceni_Predmety_PredmetZkratka",
                        column: x => x.PredmetZkratka,
                        principalTable: "Predmety",
                        principalColumn: "Zkratka",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hodnoceni_Studenti_StudentID_Studenta",
                        column: x => x.StudentID_Studenta,
                        principalTable: "Studenti",
                        principalColumn: "ID_Studenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zapsani",
                columns: table => new
                {
                    ID_Studenta = table.Column<int>(type: "int", nullable: false),
                    Zkratka_Predmetu = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zapsani", x => new { x.ID_Studenta, x.Zkratka_Predmetu });
                    table.ForeignKey(
                        name: "FK_Zapsani_Predmety_Zkratka_Predmetu",
                        column: x => x.Zkratka_Predmetu,
                        principalTable: "Predmety",
                        principalColumn: "Zkratka",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zapsani_Studenti_ID_Studenta",
                        column: x => x.ID_Studenta,
                        principalTable: "Studenti",
                        principalColumn: "ID_Studenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hodnoceni_PredmetZkratka",
                table: "Hodnoceni",
                column: "PredmetZkratka");

            migrationBuilder.CreateIndex(
                name: "IX_Hodnoceni_StudentID_Studenta",
                table: "Hodnoceni",
                column: "StudentID_Studenta");

            migrationBuilder.CreateIndex(
                name: "IX_Zapsani_Zkratka_Predmetu",
                table: "Zapsani",
                column: "Zkratka_Predmetu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hodnoceni");

            migrationBuilder.DropTable(
                name: "Zapsani");

            migrationBuilder.DropTable(
                name: "Predmety");

            migrationBuilder.DropTable(
                name: "Studenti");
        }
    }
}
