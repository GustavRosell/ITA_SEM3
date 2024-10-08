using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// TAGS: web-api, get, post, record, array

// Opgave 2.1: En hello-funktion der hilser verden
app.MapGet("/api/hello", () => new { Message = "Hello World!" });
// Test ved at skrive: http://localhost:5195/api/hello

// Opgave 3.1: En hello-funktion der hilser dig
app.MapGet("/api/hello/{name}", (string name) => new { Message = $"Hello {name}!" });
// Test ved at skrive: http://localhost:5195/api/hello/makker 

// Opgave 3.2: En hello-funktion der hilser dig og fortæller din alder
app.MapGet("/api/hello/{name}/{age}", (string name, int age) => new { Message = $"Hello {name}, you are {age} years old!" });
// Test ved at skrive: http://localhost:5195/api/hello/makker/24

// Opgave 4 - Lav en ny API som indeholder et array af frugtnavne
string[] frugter = new string[]
{
    "æble", "banan", "pære", "ananas"
};

// Tilføjer endpoints:

// Returnerer alle frugter
app.MapGet("/api/fruit", () => frugter);

// Returnerer en specifik frugt
app.MapGet("/api/fruit/{id}", (int id) => 
{
    if (id < 0 || id >= frugter.Length)
    {
        return Results.NotFound("Frugten blev ikke fundet");
    }
    return Results.Ok(frugter[id]);
});

// Returnerer en random frugt
app.MapGet("/api/fruit/random", () => frugter[new Random().Next(frugter.Length)]);

// Opgave 5 - Mere frugt API

app.MapPost("/api/fruit", (Fruit fruit) =>
{
    if (string.IsNullOrEmpty(fruit.name))
    {
        return Results.BadRequest("Frugt navn må ikke være tomt");
    }

    // Tilføjer frugt til array
    frugter = frugter.Append(fruit.name).ToArray();
    Console.WriteLine($"Tilføjet frugt: {fruit.name}");

    // Returnerer arrayet med alle frugter
    return Results.Ok(frugter);
});

// Definition af Fruit record
app.Run();

public record Fruit(string name);