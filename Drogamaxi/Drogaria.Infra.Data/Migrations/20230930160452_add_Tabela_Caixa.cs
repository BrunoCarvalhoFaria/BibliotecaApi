using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Drogaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_Tabela_Caixa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caixa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DataAbertura = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    DataFechamento = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UsuarioId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ValorAbertura = table.Column<float>(type: "float", nullable: false),
                    ValorFechamento = table.Column<float>(type: "float", nullable: false),
                    Sangria = table.Column<float>(type: "float", nullable: false),
                    EntradaValor = table.Column<float>(type: "float", nullable: false),
                    VendaCartao = table.Column<float>(type: "float", nullable: false),
                    CascadeMode = table.Column<int>(type: "int", nullable: false),
                    Excluido = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caixa_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Caixa_UsuarioId",
                table: "Caixa",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caixa");
        }
    }
}
