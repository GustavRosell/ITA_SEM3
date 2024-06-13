using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new BoardContext())
        {
            // Create a new User, Board and Todo
            var user = new User { Name = "GMoney" };
            var board = new Board { Todos = new List<Todo>() };
            // var todo = new Todo { Name = "Test2", Category = "RocketLeague", User = user, Board = board };

            // Add the Todo to the Board
            // board.Todos.Add(todo);

            // Save the User, Board and Todo to the database
            db.Users.Add(user);
            db.Boards.Add(board);
            // db.Todos.Add(todo);
            db.SaveChanges();
        }

        using (var db = new BoardContext())
        {
            // Read the last User, Board and Todo
            var lastUser = db.Users.OrderBy(u => u.UserId).Last();
            var lastBoard = db.Boards.Include(b => b.Todos).OrderBy(b => b.BoardId).Last();
            var lastTodo = db.Todos.Include(t => t.User).Include(t => t.Board).OrderBy(t => t.TodoId).Last();

            Console.WriteLine($"Last User: {lastUser.Name}");
            Console.WriteLine($"Last Board: {lastBoard.BoardId}, Todos: {lastBoard.Todos.Count}");
            // Console.WriteLine($"Last Todo: {lastTodo.Name}, Category: {lastTodo.Category}, User: {lastTodo.User.Name}, Board: {lastTodo.Board.BoardId}");
        }
    }
}