using System.Data;
using Microsoft.EntityFrameworkCore;
using Model;

using (var db = new AppDbContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");

    // Create User
    Console.WriteLine("Inserting a new user");
    var newUser = new User { Name = "John Doe" };
    db.Users.Add(newUser);
    db.SaveChanges();
    Console.WriteLine("New user inserted.");

    // Create Board
    Console.WriteLine("Inserting a new board");
    var newBoard = new Board { Name = "Project Board" };
    db.Boards.Add(newBoard);
    db.SaveChanges();
    Console.WriteLine("New board inserted.");

    // Create Todo
    Console.WriteLine("Inserting a new todo");
    var newTodo = new Todo { Title = "New Title", User = newUser, Board = newBoard };
    db.Todos.Add(newTodo);
    db.SaveChanges();
    Console.WriteLine("New todo inserted.");

    // Read
    Console.WriteLine("Finding the last todo");
    var lastTodo = db.Todos
        .Include(t => t.User)
        .OrderByDescending(t => t.TodoId)
        .FirstOrDefault();
    if (lastTodo != null)
    {
        Console.WriteLine($"Todo: {lastTodo.Title}, User: {lastTodo.User.Name}");
    }

    // Update
    Console.WriteLine("Updating the last todo");
    var todoToUpdate = db.Todos.OrderByDescending(t => t.TodoId).FirstOrDefault();
    if (todoToUpdate != null)
    {
        todoToUpdate.Title = "Updated Task";
        db.SaveChanges();
        Console.WriteLine("Todo updated.");
    }
/*
    // Delete
    Console.WriteLine("Deleting the last todo");
    var todoToDelete = db.Todos.OrderByDescending(t => t.TodoId).FirstOrDefault();
    if (todoToDelete != null)
    {
        db.Todos.Remove(todoToDelete);
        db.SaveChanges();
        Console.WriteLine("Todo deleted.");
    }
    */
}