using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drogaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_TipoFalta_Tabela_Falta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Falta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Falta");
        }
    }
}
