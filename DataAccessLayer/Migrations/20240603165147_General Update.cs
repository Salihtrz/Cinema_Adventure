using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class GeneralUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Reviews_News_Review_NewsId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_Review_NewsId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Review_NewsId",
                table: "News");

            migrationBuilder.AddColumn<int>(
                name: "NewsId",
                table: "Reviews_News",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_News_NewsId",
                table: "Reviews_News",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_News_News_NewsId",
                table: "Reviews_News",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "NewsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_News_News_NewsId",
                table: "Reviews_News");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_News_NewsId",
                table: "Reviews_News");

            migrationBuilder.DropColumn(
                name: "NewsId",
                table: "Reviews_News");

            migrationBuilder.AddColumn<int>(
                name: "Review_NewsId",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_Review_NewsId",
                table: "News",
                column: "Review_NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Reviews_News_Review_NewsId",
                table: "News",
                column: "Review_NewsId",
                principalTable: "Reviews_News",
                principalColumn: "Review_NewsId");
        }
    }
}
