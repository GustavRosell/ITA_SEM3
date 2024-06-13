using System.Data;
using Model;

using (var db = new TaskContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");

    // Read User
    Console.WriteLine("Find den sidste user");
    var lastUser = db.Users
        .OrderBy(b => b.UserId)
        .Last();
    Console.WriteLine($"Id for user: {lastUser.UserId}");

    
    // // Create task
    Console.WriteLine("Indsæt et nyt task");
    db.Add(new TodoTask("En opgave der skal løses", "Personlig", false, lastUser));
    db.SaveChanges();


    // Create User
    Console.WriteLine("Opretter ny bruger");
    db.Add(new User("Søren", 43));
    db.SaveChanges();


    // Update Task (Bind user til en task/ændre UserId for en task)
    Console.WriteLine("Ændre UserId for en task");
    
    var taskToUpdate = db.Tasks.Where(Task => Task.TodoTaskId == 2).FirstOrDefault();
    Console.WriteLine($"UserId bundet til tasken før update {taskToUpdate.UserId}");
    var userToConnectToTask = db.Users.Where(User => User.UserId == 1).FirstOrDefault();
    taskToUpdate.UserId = userToConnectToTask.UserId;
    db.SaveChanges();
    Console.WriteLine($"UserId bundet til tasken efter update {taskToUpdate.UserId}");


    // Read Task
    Console.WriteLine("Find det sidste task");
    var lastTask = db.Tasks
        .OrderBy(b => b.TodoTaskId)
        .Last();
    Console.WriteLine($"Text: {lastTask.Text}");


    //Update Task
    // Console.WriteLine("Opdater en task");

    // var taskToUpdate = db.Tasks.Where(task => task.TodoTaskId == 5).FirstOrDefault();
    // Console.WriteLine($"Task.Text før opdatering {taskToUpdate.Text}");
    // taskToUpdate.Text = "Opdateret task";
    // db.SaveChanges();
    // Console.WriteLine($"{taskToUpdate}");
    // Console.WriteLine($"Task.Text Efter opdatering {taskToUpdate.Text}");


    // Delete Task
    // Console.WriteLine("Delete en task");

    // var taskToDelete = db.Tasks.Where(task => task.TodoTaskId == 5).FirstOrDefault();
    // Console.WriteLine($"Task.TodoTaskId som slettes er: {taskToDelete.TodoTaskId}");
    // db.Tasks.Remove(taskToDelete);
    // db.SaveChanges();

}