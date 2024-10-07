using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class rolesadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCastReadAccess",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCastWriteAccess",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNewsReadAccess",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNewsWriteAccess",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReview_NewsReadAccess",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReview_NewsWriteAccess",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReviewsReadAccess",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReviewsWriteAccess",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCastReadAccess",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsCastWriteAccess",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsNewsReadAccess",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsNewsWriteAccess",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsReview_NewsReadAccess",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsReview_NewsWriteAccess",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsReviewsReadAccess",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsReviewsWriteAccess",
                table: "Roles");
        }
    }
}
