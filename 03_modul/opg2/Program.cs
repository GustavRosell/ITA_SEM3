// Modul 3; Opgave 2 + Opgave 3 + Opgave 4

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// -------------------------------------------------------------------------------------------------------------------------

// Lav ændringer til “MapGet” så du i stedet for at returnerer "Hello World!" returnerer new { Message = "Hello world!" }

// Opgave 2.1: En hello-funktion der hilser verden
app.MapGet("/api/hello", () => new { Message = "Hello World!"});
// Test ved at skrive: http://localhost:5195/api/hello

// Opgave 3.1: En hello-funktion der hilser dig
app.MapGet("/api/hello/{name}", (string name) => new { Message = $"Hello {name}!"});
// Test ved at skrive: http://localhost:5195/api/hello/makker 

// Opgave 3.2: En hello-funktion der hilser dig og fortæller din alder
app.MapGet("/api/hello/{name}/{age}", (string name, int age) => new { Message = $"Hello {name}, you are {age} years old!"});
// Test ved at skrive: http://localhost:5195/api/hello/makker/24

// -------------------------------------------------------------------------------------------------------------------------

// Opgave 4 - Lav en ny API som indeholder et array af frugtnavne
String[] frugter = new String[]
{
    "æble", "banan", "pære", "ananas"
};

// Tilføjer endpoints:

// Returnerer alle frugter
app.MapGet("/api/fruit", () => frugter);

// Returnerer en specifik frugt
app.MapGet("/api/fruit/{id}", (int id) => frugter[id]);

// Returnerer en random frugt
app.MapGet("/api/fruit/random", () => frugter[new Random().Next(frugter.Length)]);

// -------------------------------------------------------------------------------------------------------------------------

// Opgave 5 - Mere frugt API

/*
Du skal nu tilføje en POST som kan sende nye frugter til frugt-API’en.

POST /api/fruit: Tilføjer en ny frugt til arrayet.
Nye frugter sendes til POST-endpointet som JSON. JSON skal have følgende format (eksempel):

{
    "name": "citron"
}
Når du koder POST-routen, er du nødt til at lave en type, der svarer til inputtet i routen. Typen kunne være følgende record, som placeres i bunden af Program.cs:

record Fruit(string name);
Din route kan herefter kodes således:
*/

app.MapPost("/api/fruit", (Fruit fruit) =>
{
    // TODO: Tilføj den nye frugt til dit array!
    

    Console.WriteLine($"Tilføjet frugt: {fruit.name}");

    // TODO: Returnér herefter arrayet med alle frugter
});

app.Run();
