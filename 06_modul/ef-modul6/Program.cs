using System.Data;
using Model;

using (var db = new BoardContext())
{
    // Create User
    var user = new User { Name = "Søren" };
    db.Users.Add(user);
    db.SaveChanges();

    // Create Board
    var board = new Board();
    db.Boards.Add(board);
    db.SaveChanges();

    // Create Todo
    var todo = new Todo { Name = "En opgave der skal løses", Category = "Personlig", User = user, Board = board };
    db.Todos.Add(todo);
    db.SaveChanges();

    // Read User, Board and Todo
    var lastUser = db.Users.OrderBy(b => b.UserId).Last();
    var lastBoard = db.Boards.OrderBy(b => b.BoardId).Last();
    var lastTodo = db.Todos.OrderBy(b => b.TodoId).Last();

    Console.WriteLine($"Last User: {lastUser.Name}");
    Console.WriteLine($"Last Board: {lastBoard.BoardId}");
    Console.WriteLine($"Last Todo: {lastTodo.Name}, Category: {lastTodo.Category}, User: {lastTodo.User.Name}");
}