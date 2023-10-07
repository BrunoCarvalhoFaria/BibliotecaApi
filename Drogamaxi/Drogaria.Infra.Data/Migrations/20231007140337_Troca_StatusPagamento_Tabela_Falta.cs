using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drogaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Troca_StatusPagamento_Tabela_Falta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Pago",
                table: "Falta",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Pago",
                table: "Falta",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
