using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Review_Newsaddedstateandvisibility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Reviews_News",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Visibility",
                table: "Reviews_News",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Reviews_News");

            migrationBuilder.DropColumn(
                name: "Visibility",
                table: "Reviews_News");
        }
    }
}
