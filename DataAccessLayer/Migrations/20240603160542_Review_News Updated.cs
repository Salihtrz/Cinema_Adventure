using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Review_NewsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Reviews_ReviewId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Reviews_News",
                newName: "Review_NewsId");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "News",
                newName: "Review_NewsId");

            migrationBuilder.RenameIndex(
                name: "IX_News_ReviewId",
                table: "News",
                newName: "IX_News_Review_NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Reviews_News_Review_NewsId",
                table: "News",
                column: "Review_NewsId",
                principalTable: "Reviews_News",
                principalColumn: "Review_NewsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Reviews_News_Review_NewsId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "Review_NewsId",
                table: "Reviews_News",
                newName: "ReviewId");

            migrationBuilder.RenameColumn(
                name: "Review_NewsId",
                table: "News",
                newName: "ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_News_Review_NewsId",
                table: "News",
                newName: "IX_News_ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Reviews_ReviewId",
                table: "News",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "ReviewId");
        }
    }
}
