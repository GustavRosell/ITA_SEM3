// Todo.cs

namespace Model
{
    public class Todo
    {

        public Todo(string Title, User user)
        {
            this.Title = Title;
            this.User = user;
        }

        public Todo(string Title)
        {
            this.Title = Title;
        }

        public long TodoId { get; set; }
        public string? Title { get; set; }
        public User? User { get; set; }
        public Board? Board { get; set; }
    }
}

/* ting til at lave en migration i opgave 2:

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Todos",
                nullable: true);
                
            migrationBuilder.Sql(
                @"UPDATE Todos
                    SET Title = Category || ':' || Name;
                    ");

            // TODO: Drop de to gamle kolonner
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Todos");

            migrationBuilder.DropColumn(
            name: "Category",
            table: "Todos");
*/