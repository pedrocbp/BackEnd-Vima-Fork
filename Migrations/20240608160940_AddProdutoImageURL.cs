using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VimaV2.Migrations
{
    /// <inheritdoc />
    public partial class AddProdutoImageURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagemUrl",
                table: "Produtos",
                newName: "Tamanhos");

            migrationBuilder.AddColumn<int>(
                name: "Estoque",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Produtos",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Imagens",
                table: "Produtos",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estoque",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Imagens",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "Tamanhos",
                table: "Produtos",
                newName: "ImagemUrl");
        }
    }
}
