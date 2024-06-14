using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*
Sørg for der er noget testdata i programmet når det starter op. 
Det er ikke nødvendigt at gemme data i en rigtig database (bare brug et array eller en list). 
*/

int nextId = 0;

List<Kunde> kunder = new List<Kunde>
{
    new Kunde { Id = nextId++, Navn = "Jens", Email = "Jens@gmail.com", Type = "Erhverv" },
    new Kunde { Id = nextId++, Navn = "Hans", Email = "Hans@gmail.com", Type = "Privat" },
    new Kunde { Id = nextId++, Navn = "Peter", Email = "Peter@hotmail.com", Type = "Erhverv" }
};

// -----------------------------------------------------------------------------------------------------------------------------------------------------------


app.MapGet("/", () => "Hello World!");

// GET /api/kunder: Henter alle kunder
app.MapGet("/api/kunder", () => Results.Ok(kunder));

// GET /api/kunder/{id}: Henter en bestemt kunde ud fra ID
app.MapGet("/api/kunder/{id}", (int id) =>
{
    var kunde = kunder.FirstOrDefault(k => k.Id == id);
    return kunde is not null ? Results.Ok(kunde) : Results.NotFound("Ingen kunde med dette Id");
});

// POST /api/kunder: Tager imod en ny kunde der skal oprettes
app.MapPost("/api/kunder", (Kunde kundeInput) =>
{
    var newKunde = kundeInput with { Id = nextId++ };
    kunder.Add(newKunde);
    return Results.Created($"/api/kunder/{newKunde.Id}", newKunde);
});

// DELETE /api/kunder/{id}: Sletter en bestemt kunde
app.MapDelete("/api/kunder/{id}", (int id) =>
{
    var kunde = kunder.FirstOrDefault(k => k.Id == id);
    if (kunde is null)
    {
        return Results.NotFound("Ingen kunde med dette Id");
    }
    
    kunder.Remove(kunde);
    return Results.Ok(kunde);
});

// GET /api/emails/{type}: Henter en liste over alle kunders email-adresser. Typen afgør om det er for privat-kunder eller erhvervskunder.
app.MapGet("/api/emails/{type}", (string type) =>
{
    var emails = kunder.Where(k => k.Type == type).Select(k => k.Email).ToList();
    return emails.Any() ? Results.Ok(emails) : Results.NotFound("Ingen kunder af denne type");
});

// -----------------------------------------------------------------------------------------------------------------------------------------------------------


app.Run();
public record Kunde
{
    public int Id { get; init; }
    public string Navn { get; init; }
    public string Email { get; init; }
    public string Type { get; init; }
}

/*

// Teorispørgsmål

I semestret har der været diskuteret foreskellige kriterier der kan måles på, når der skal designes en god Web API. 
Hvilke kriterier er der tale om og hvad dækker de over? Hvornår er en API “god”?

- Brugervenlighed
    - Selvforklarende endpoints
    - Konsistent design
    - God dokumentation

- Ydeevne
    - Hurtig responstid
    - Effektiv ressourceforvaltning

- Sikkerhed 
    - Autentificering og autorisation

- Skalerbarhed
    - Horisontal skalering
    - Load balancing

- Pålidelighed
    - Høj tilgængelighed
    - Fejlhåndtering

Hvornår er en API “god”?
En API er "god", når den opfylder ovenstående kriterier og giver en positiv oplevelse for udviklere, der bruger den. 
En god API er let at bruge, hurtigt at lære, pålidelig, sikker og effektiv. 
Den skal også være fleksibel nok til at kunne tilpasses fremtidige behov og teknologiske ændringer.

Ved at fokusere på disse kriterier kan du sikre, at din API ikke kun fungerer godt teknisk set, 
men også opfylder brugernes og udviklernes behov på en effektiv og tilfredsstillende måde.

*/