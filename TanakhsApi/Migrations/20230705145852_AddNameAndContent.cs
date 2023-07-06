using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TanakhsApi.Migrations
{
    /// <inheritdoc />
    public partial class AddNameAndContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_ChapterRating_ChapterRatingId",
                table: "BlogPosts");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "BlogPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BlogPosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_ChapterRating_ChapterRatingId",
                table: "BlogPosts",
                column: "ChapterRatingId",
                principalTable: "ChapterRating",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_ChapterRating_ChapterRatingId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BlogPosts");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_ChapterRating_ChapterRatingId",
                table: "BlogPosts",
                column: "ChapterRatingId",
                principalTable: "ChapterRating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
