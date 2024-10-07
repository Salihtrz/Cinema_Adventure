using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class MovieUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categorys_CategoryId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Movies",
                newName: "categorysCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                newName: "IX_Movies_categorysCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categorys_categorysCategoryId",
                table: "Movies",
                column: "categorysCategoryId",
                principalTable: "Categorys",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categorys_categorysCategoryId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "categorysCategoryId",
                table: "Movies",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_categorysCategoryId",
                table: "Movies",
                newName: "IX_Movies_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categorys_CategoryId",
                table: "Movies",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "CategoryId");
        }
    }
}
