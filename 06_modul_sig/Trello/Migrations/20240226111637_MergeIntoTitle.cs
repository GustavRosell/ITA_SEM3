using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trello.Migrations
{
    /// <inheritdoc />
    public partial class MergeIntoTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Todo",
                type: "TEXT",
                nullable: true);

            migrationBuilder.Sql(
                @"UPDATE todo
                SET Title = Text || ';' || Category;
             ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Todo");
        }
    }
}
