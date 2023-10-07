using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Drogaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Tabela_Fornecedor_Tabela_Falta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    CascadeMode = table.Column<int>(type: "int", nullable: false),
                    Excluido = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Falta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    UsuarioCriacaoId = table.Column<string>(type: "varchar(255)", nullable: false),
                    CodigoDeBarras = table.Column<string>(type: "longtext", nullable: false),
                    NomeProduto = table.Column<string>(type: "longtext", nullable: false),
                    Laboratorio = table.Column<string>(type: "longtext", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    NomeCliente = table.Column<string>(type: "longtext", nullable: false),
                    TelefoneCliente = table.Column<string>(type: "longtext", nullable: false),
                    Pago = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    VendedorId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FornecedorId = table.Column<long>(type: "bigint", nullable: false),
                    ObservacaoComprador = table.Column<string>(type: "longtext", nullable: true),
                    CascadeMode = table.Column<int>(type: "int", nullable: false),
                    Excluido = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Falta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Falta_AspNetUsers_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Falta_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Falta_Vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Falta_FornecedorId",
                table: "Falta",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Falta_UsuarioCriacaoId",
                table: "Falta",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Falta_VendedorId",
                table: "Falta",
                column: "VendedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Falta");

            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
