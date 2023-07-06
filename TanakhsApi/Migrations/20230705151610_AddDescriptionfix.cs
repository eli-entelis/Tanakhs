using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TanakhsApi.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripiton",
                table: "BlogPosts",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "BlogPosts",
                newName: "Descripiton");
        }
    }
}
