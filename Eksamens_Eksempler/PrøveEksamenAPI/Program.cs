using Microsoft.VisualBasic;
using System.Linq; // Gør at du kan bruge LINQ, fx FirstOrDefault

// Brugen af responstypen Results.OK, Results.NotFound som er HTTP-statuskoder (200, 404) er i overensstemmelse med HTTP-protokollens standarder. 
// Giver klarhed og konsistens for blandt andet andre udviklere.

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


// Tom liste og tilføjelse til liste
// List<Kunde> tomListe = new List<Kunde>();

// kundeListe.Add(new Kunde { Id = nextId++, Navn = "Jens", Email = "Jens@gmail.com", Type = "Erhverv" });
// kundeListe.Add(new Kunde { Id = nextId++, Navn = "Hans", Email = "Hans@gmail.com", Type = "Privat" });

// Tomt array
// Kunde[] tomtArray = new Kunde[0];

int nextId = 0;

// lav et arary som indeholder Kunder indeholder som minimum navn, id, email-adresse og type (“erhverv” eller “privat”).
Kunde[] kunder = new Kunde[]
{
    new Kunde {Id = nextId++, Navn = "Jens", Email = "Jens@gmail.com", Type = "Erhverv"},
    new Kunde {Id = nextId++, Navn = "Hans", Email = "Hans@gmail.com", Type = "Privat"},
    new Kunde {Id = nextId++, Navn = "Peter", Email = "Peter@hotmail.com", Type = "Erhverv"},
};

// Endpoint som retunere alle kunder i arrayet
app.MapGet("api/kunder", () => Results.Ok(kunder));

// Endpoint som retunere en bestemt kunde udfra Id
app.MapGet("api/kunder/{id}", (int id) =>
{
    // Lambda-funktionen her iterer igennem vores array af kunder, inputparameteren(kunde) og vores betingelse (k.Id == id)
    var kunde = kunder.FirstOrDefault(kunde => kunde.Id == id);

    
    if (kunde != null)
    {
        return Results.Ok(kunde);
    }
    return Results.NotFound("Ingen kunde med dette Id");
    // Kan også skrives som
    // return kunde is not null ? return Results.OK(kunde) : Results.NotFound("Ingen kunde med dette Id")
});

app.MapPost("api/kunder", (Kunde KundeInput) =>
{
    // Find det højeste Id i arrayet og tilføj 1 til det
    int newId;
    // .Count hvis det var en liste
    if (kunder.Length > 0)
    {
        newId = kunder.Max(k => k.Id) + 1;
    }
    else
    {
        newId = 1;
    }

    var kundeToAdd = new Kunde
    {
        Id = newId,
        Navn = KundeInput.Navn,
        Email = KundeInput.Email,
        Type = KundeInput.Type
    };

    // Array er en fast størrelse, så vi laver en liste, tilføjer kunden og konverterer tilbage til array
    var kunderList = kunder.ToList();
    kunderList.Add(kundeToAdd);
    kunder = kunderList.ToArray();

    // ALTERNATIVE NOTER

        // Kan også bruge Resize, brug ref for at ændre på det oprindelige array, ellers vil det nye array kun eksistere i metoden
        // Array.Resize(ref kunder, kunder.Length + 1);
        // kunder[kunder.Length - 1] = kundeToAdd;

        // Hvis kunder var en liste bruges blot Add-metoden
        // kunder.Add(kundeToAdd);

    // HTTP-statuskode 201 Created, url er nyttig for at kunne finde den nye ressource, og objektet for at se id'et
    return Results.Created($"/api/kunder/{kundeToAdd.Id}", kundeToAdd);
});

// Endpoint som indsætter en ny kunde et bestemt sted i arrayet
app.MapPost("api/kunder/index/{index}", (Kunde KundeInput, int index) =>
{
    // Find det højeste Id i arrayet og tilføj 1 til det
    int newId;
    if (kunder.Length > 0)
    {
        newId = kunder.Max(k => k.Id) + 1;
    }
    else
    {
        newId = 1;
    }

    var kundeToAdd = new Kunde
    {
        Id = newId,
        Navn = KundeInput.Navn,
        Email = KundeInput.Email,
        Type = KundeInput.Type
    };

    // Opretter et nyt array, der er en størrelse større end det oprindelige array
    var newArray = new Kunde[kunder.Length + 1];

    // Kopierer elementerne fra det oprindelige array til det nye array
    // Array.Copy(SourceArray, SourceIndex, DestinationArray, DestinationIndex, Length); 
    // SourceIndex er startpositonen i kilden, Length er antal elementer der skal kopieres
    Array.Copy(kunder, 0, newArray, 0, index);

    // Indsætter det nye element på den ønskede position
    newArray[index] = kundeToAdd;

    // Kopierer resten af elementerne
    Array.Copy(kunder, index, newArray, index + 1, kunder.Length - index);

    // Tildeler det nye array til kunder
    kunder = newArray;

    // ALTERNATIVE NOTER

        // Hvis kunder var en liste bruges blot Insert-metoden
        // kunder.Insert(index, kundeToAdd);

    // HTTP-statuskode 201 Created, url er nyttig for at kunne finde den nye ressource, og objektet for at se id'et
    return Results.Created($"/api/kunder/{kundeToAdd.Id}", kundeToAdd);
});

// Endpoint som opdaterer en kunde
app.MapPut("api/kunder/{id}", (Kunde KundeInput, int id) =>
{
    // Find kunden i arrayet
    var kunde = kunder.FirstOrDefault(k => k.Id == id);

    if (kunde != null)
    {
        kunde.Navn = KundeInput.Navn;
        kunde.Email = KundeInput.Email;
        kunde.Type = KundeInput.Type;

        return Results.Ok(kunde);
    }
    return Results.NotFound("Ingen kunde med dette Id");
});

// Endpoint som sletter en kunde
app.MapDelete("api/kunder/{id}", (int id) =>
{
    // Find kunden i arrayet
    var kunde = kunder.FirstOrDefault(k => k.Id == id);

    if (kunde != null)
    {
        // Opretter et nyt array, der er en størrelse mindre end det oprindelige array
        var newArray = new Kunde[kunder.Length - 1];

        // Kopierer elementerne fra det oprindelige array til det nye array, undtagen den kunde der skal slettes
        Array.Copy(kunder, 0, newArray, 0, kunder.ToList().IndexOf(kunde));
        Array.Copy(kunder, kunder.ToList().IndexOf(kunde) + 1, newArray, kunder.ToList().IndexOf(kunde), kunder.Length - kunder.ToList().IndexOf(kunde) - 1);

        // Tildeler det nye array til kunder
        kunder = newArray;

        // ALTERNATIVE NOTER

            // Hvis kunder var en liste bruges blot Remove-metoden
            // kunder.Remove(kunde);

        return Results.Ok(kunde);
    }
    return Results.NotFound("Ingen kunde med dette Id");
});

// Endpoint som retunere alle emails af en bestemt type
app.MapGet("api/emails/{type}", (string type) =>
{
    // Lambda-funktionen her iterer igennem vores array af kunder, inputparameteren(kunde) og vores betingelse (k.Type == type)
    var emails = kunder.Where(k => k.Type == type).Select(k => k.Email).ToList();

    if (emails.Count > 0)
    {
        return Results.Ok(emails);
    }
    return Results.NotFound("Ingen kunder af denne type");
});

app.Run();

public record KundeInput(string Navn, string Email, string Type);
public class Kunde
{
    public int Id { get; set; }
    public string Navn { get; set; }
    public string Email { get; set; }
    public string Type { get; set; }
}
