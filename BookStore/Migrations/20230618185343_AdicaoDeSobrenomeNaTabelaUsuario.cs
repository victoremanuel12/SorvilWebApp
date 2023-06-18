using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoDeSobrenomeNaTabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Sobrenome");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "Senha");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Users",
                newName: "Name");
        }
    }
}
