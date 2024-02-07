// Modul 3; Opgave 2 + Opgave 3

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// Lav ændringer til “MapGet” så du i stedet for at returnerer "Hello World!" returnerer new { Message = "Hello world!" }

// Opgave 2.1
app.MapGet("/api/hello", () => new { Message = "Hello World!"});
// Test ved at skrive: http://localhost:5195/api/hello

// Opgave 3.1
app.MapGet("/api/hello/{name}", (string name) => new { Message = $"Hello {name}!"});
// Test ved at skrive: http://localhost:5195/api/hello/makker 

// Opgave 3.2
app.MapGet("/api/hello/{name}/{age}", (string name, int age) => new { Message = $"Hello {name}, you are {age} years old!"});
// Test ved at skrive: http://localhost:5195/api/hello/makker/24

app.Run();
