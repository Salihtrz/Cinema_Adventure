using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ForeignKey kısıtlamasını kaldırın
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categorys_CategoryId",
                table: "Movies");

            // CategoryId sütununu silin
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Movies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // CategoryId sütununu yeniden ekleyin
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Movies",
                type: "int",
                nullable: true);

            // ForeignKey kısıtlamasını yeniden oluşturun
            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categorys_CategoryId",
                table: "Movies",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}