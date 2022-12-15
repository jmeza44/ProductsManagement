using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsManagement.Migrations
{
    /// <inheritdoc />
    public partial class ProductsCodeRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
