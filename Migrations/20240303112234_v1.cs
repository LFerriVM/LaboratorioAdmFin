using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace admfin.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balancos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataCriacao = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Valor = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balancos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensBalancos",
                columns: table => new
                {
                    IdItem = table.Column<int>(type: "INTEGER", nullable: false),
                    IdBalanco = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorItem = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensBalancos", x => new { x.IdItem, x.IdBalanco });
                    table.ForeignKey(
                        name: "FK_ItensBalancos_Balancos_IdBalanco",
                        column: x => x.IdBalanco,
                        principalTable: "Balancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensBalancos_Itens_IdItem",
                        column: x => x.IdItem,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensBalancos_IdBalanco",
                table: "ItensBalancos",
                column: "IdBalanco");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensBalancos");

            migrationBuilder.DropTable(
                name: "Balancos");

            migrationBuilder.DropTable(
                name: "Itens");
        }
    }
}
