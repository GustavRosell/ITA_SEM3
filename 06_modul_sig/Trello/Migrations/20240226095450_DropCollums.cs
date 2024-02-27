using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trello.Migrations
{
    /// <inheritdoc />
    public partial class DropCollums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "Done",
                table: "Todo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "User",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Todo",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "Todo",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
