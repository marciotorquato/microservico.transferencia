using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservico.Transferencia.Repository.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContaCorrentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Saldo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    DataLancamento = table.Column<DateTime>(nullable: false),
                    ContaOrigemId = table.Column<int>(nullable: true),
                    ContaDestinoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamentos_ContaCorrentes_ContaDestinoId",
                        column: x => x.ContaDestinoId,
                        principalTable: "ContaCorrentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lancamentos_ContaCorrentes_ContaOrigemId",
                        column: x => x.ContaOrigemId,
                        principalTable: "ContaCorrentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ContaDestinoId",
                table: "Lancamentos",
                column: "ContaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ContaOrigemId",
                table: "Lancamentos",
                column: "ContaOrigemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "ContaCorrentes");
        }
    }
}
