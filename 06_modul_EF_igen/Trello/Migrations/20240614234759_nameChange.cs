using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trello.Migrations
{
    /// <inheritdoc />
    public partial class nameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Todos",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Todos",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Todos",
                type: "TEXT",
                nullable: true);
        }
    }
}
