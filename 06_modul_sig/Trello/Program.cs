using System.Data;
using Model;

// TAGS: ef, entity-framework, database, sqlite, user, board, todo

using (var db = new BoardContext())
{
    // // Opretter en ny bruger
    // var user = new User("Rasmus"); 

    // // Opretter en ny opgave og tilknytter brugeren
    // var todo = new Todo("Spis Burger", "Mad", user); 

    // // Opretter et nyt board og tilføjer opgaven til dette
    // var board = new Board();
    // board.Todos.Add(todo); 

    // // Tilføjer boardet og gemmer ændringerne
    // db.Boards.Add(board);
    // db.SaveChanges();
}
