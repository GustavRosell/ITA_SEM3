using Model;

using (var db = new TaskContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");

    // Create User
    Console.WriteLine("Indsæt en ny bruger");
    var newUser = new User("John Doe");
    db.Add(newUser);
    db.SaveChanges();
    Console.WriteLine("Ny bruger indsat.");

    // Create TodoTask
    Console.WriteLine("Indsæt et nyt task");
    var newTask = new TodoTask("En opgave der skal løses", false, "Pis-test", newUser);
    db.Add(newTask);
    db.SaveChanges();
    Console.WriteLine("Ny opgave indsat.");

    // Read
    Console.WriteLine("Find det sidste task");
    var lastTask = db.Tasks
        .OrderByDescending(b => b.TodoTaskId)
        .FirstOrDefault();
    if (lastTask != null)
    {
        Console.WriteLine($"Text: {lastTask.Text}, User: {lastTask.User.Name}");
    }

    // Update
    Console.WriteLine("Opdater task");
    var taskToUpdate = db.Tasks.OrderByDescending(b => b.TodoTaskId).FirstOrDefault();
    if (taskToUpdate != null)
    {
        taskToUpdate.Text = "En opgave der er løst";
        db.SaveChanges();
        Console.WriteLine("Opgave opdateret.");
    }

   /* // Delete
    Console.WriteLine("Slet task baseret på tekst");
    var textToDelete = "En opgave der er løst";
    var taskToDelete = db.Tasks.FirstOrDefault(t => t.Text == textToDelete);
    if (taskToDelete != null)
    {
        db.Remove(taskToDelete);
        db.SaveChanges();
        Console.WriteLine("Opgave slettet.");
    }
    else
    {
        Console.WriteLine("Ingen opgave fundet med den givne tekst.");
    }
    */
}

/*
Opgave 5 - Kan du svare på følgende? Test dig selv.
1. Hvordan ved Entity Framework hvilke migrations der mangler at blive kørt på? Hvor gemmes denne information?
- Entity Framework gemmer informationen om hvilke migrations der er blevet kørt i databasen. Dette gøres i tabellen __EFMigrationsHistory.

2. Hvad er formålet med filerne i folderen Migrations i dit projekt? Hvad indeholder de?
- Migrations indeholder filer, der beskriver de ændringer, der skal foretages i databasen for at opdatere den til den nyeste version.

3. Hvad styrer hvad tabellerne i databasen kommer til at hedde? Kan det ændres?
- Navnene på tabellerne i databasen styres af navnet på DbSet'et i DbContext-klassen. 
- Navnet kan ændres ved at bruge ToTable-metoden i OnModelCreating-metoden i DbContext-klassen.

4. Hvad styrer hvor databasefilen bliver oprettet? Kan det ændres? (gælder kun sqlite)
- Databasefilen bliver oprettet i den mappe, der er angivet i DbPath-property'en i DbContext-klassen.

5. Hvad sker der hvis du sletter database-filen? Hvordan får du en ny?
- Hvis du sletter databasefilen, vil en ny databasefil blive oprettet, næste gang du kører programmet.
- Dvs; en ny databasefil vil blive oprettet, hvis du i terminalen skriver dotnet run.
*/