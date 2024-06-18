using System.Data;
using Model;

using (var db = new StudioContext())
{

    // Opretter actors
    var actor1 = new Actor("Rasmus", "Mand");
    var actor2 = new Actor("Laila", "Kvinde");
    var actor3 = new Actor("Søren", "Mand");

    // Opretter film
    var film1 = new Film("Titanic");
    var film2 = new Film("BadBoys in the trailerpark");

    // Tilføjer actors til film
    film1.Actors.Add(actor1);
    film1.Actors.Add(actor2);
    film2.Actors.Add(actor3);

    // Opretter studier
    var studio1 = new Studio("Studio 1");

    // Tilføjer film til studier
    studio1.Films.Add(film1);
    studio1.Films.Add(film2);

    // Tilføjer studier og gemmer ændringerne
    db.Studios.Add(studio1);
    db.SaveChanges();

    // ------------------------------//

    // Hent en bestemt actor, men igennem studio og film
    var actorFromStudio = db.Studios
        .Where(s => s.StudioId == 1)
        .SelectMany(s => s.Films)
        .SelectMany(f => f.Actors)
        .Where(a => a.ActorId == 1)
        .FirstOrDefault();
    // Udskriv actor
    Console.WriteLine(actorFromStudio.Name);


    // Hent alle actors fra film 1
    var actorsFromFilm1 = db.Studios
        .Where(s => s.StudioId == 1)
        .SelectMany(s => s.Films)
        .Where(f => f.FilmId == 1)
        .SelectMany(f => f.Actors)
        .ToList();
    // Udskriv actors fra film 1
    foreach (var actor in actorsFromFilm1)
    {
        Console.WriteLine(actor.Name);
    }


    // --------------Alle Disse Kræver DBSET for Actor og Film----------------//

    // //Slet actor 1, men igennem studio og film
    // var actorToDelete = db.Studios
    //     .Where(s => s.StudioId == 1)
    //     .SelectMany(s => s.Films)
    //     .SelectMany(f => f.Actors)
    //     .Where(a => a.ActorId == 1)
    //     .FirstOrDefault();
    // db.Actors.Remove(actorToDelete);
    // db.SaveChanges();



    // // Hent actor 1
    // var actor = db.Actors
    //     .Where(a => a.ActorId == 1)
    //     .FirstOrDefault();
    // // Udskriv actor
    // Console.WriteLine(actor.Name);

    // // Hent actors fra film 1
    // var actorsFromFilm1 = db.Films
    //     .Where(f => f.FilmId == 1)
    //     .SelectMany(f => f.Actors)
    //     .ToList();
    // // Udskriv actors fra film 1
    // foreach (var actor in actorsFromFilm1)
    // {
    //     Console.WriteLine(actor.Name);
    // }

}