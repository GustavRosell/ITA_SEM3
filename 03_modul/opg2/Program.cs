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



app.Run();
