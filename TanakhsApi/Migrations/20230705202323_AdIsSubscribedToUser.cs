﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TanakhsApi.Migrations
{
    /// <inheritdoc />
    public partial class AdIsSubscribedToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSubscribed",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubscribed",
                table: "Users");
        }
    }
}
