var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapdGet("/", () => "Hello World!");

app.Run();
