using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drogaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_ValorPago_Tabela_Falta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorPago",
                table: "Falta",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorPago",
                table: "Falta");
        }
    }
}
