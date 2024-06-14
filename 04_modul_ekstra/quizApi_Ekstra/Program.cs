var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Testdata
Quiz[] quizzer = new Quiz[]
{
    new Quiz
    {
        Id = 1,
        Spørgsmål = "Hvad er hovedstaden i Danmark?",
        Svarmuligheder = new Svar[]
        {
            new Svar { SvarTekst = "København", ErRigtigt = true },
            new Svar { SvarTekst = "Århus", ErRigtigt = false },
            new Svar { SvarTekst = "Odense", ErRigtigt = false },
            new Svar { SvarTekst = "Aalborg", ErRigtigt = false }
        }
    },
    new Quiz
    {
        Id = 2,
        Spørgsmål = "Hvad er hovedstaden i Sverige?",
        Svarmuligheder = new Svar[]
        {
            new Svar { SvarTekst = "København", ErRigtigt = false },
            new Svar { SvarTekst = "Stockholm", ErRigtigt = true },
            new Svar { SvarTekst = "Oslo", ErRigtigt = false },
            new Svar { SvarTekst = "Helsinki", ErRigtigt = false }
        }
    }
};

// GET /api/questions: Henter alle spørgsmål og deres svarmuligheder, men ikke hvilke svar der er de rigtige
app.MapGet("/api/questions", () => Results.Ok(
    quizzer.Select(q => new {
        q.Id,
        q.Spørgsmål,
        Svarmuligheder = q.Svarmuligheder.Select(s => new { s.SvarTekst }).ToArray()
    })
));

// GET /api/questions/{id}: Henter et bestemt spørgsmål og dets svarmuligheder
app.MapGet("/api/questions/{id}", (int id) =>
{
    var quiz = quizzer.FirstOrDefault(q => q.Id == id);
    if (quiz is null)
    {
        return Results.NotFound("Ingen quiz med dette Id");
    }

    var result = new
    {
        quiz.Id,
        quiz.Spørgsmål,
        Svarmuligheder = quiz.Svarmuligheder.Select(s => new { s.SvarTekst }).ToArray()
    };
    
    return Results.Ok(result);
});

// POST /api/questions/{id}/validate: Her kan postes et spørgsmåls-id og en svar 
app.MapPost("/api/questions/{id}/validate", (int id, Svar svar) =>
{
    var quiz = quizzer.FirstOrDefault(q => q.Id == id);
    if (quiz is null)
    {
        return Results.NotFound("Ingen quiz med dette Id");
    }

    var rigtigtSvar = quiz.Svarmuligheder.FirstOrDefault(s => s.ErRigtigt);
    if (rigtigtSvar is null)
    {
        return Results.NotFound("Ingen rigtige svarmuligheder fundet");
    }

    return svar.SvarTekst == rigtigtSvar.SvarTekst ? Results.Ok("Rigtigt svar") : Results.Ok("Forkert svar");
});

app.Run();

// Record-klasse: En quiz indeholder en spørgsmålstekst, samt mindst fire svarmuligheder (i et array). En af svarmulighederne er angivet som den rigtige.
public record Quiz
{
    public int Id { get; set; }
    public string Spørgsmål { get; set; }
    public Svar[] Svarmuligheder { get; set; }
}

public record Svar
{
    public string SvarTekst { get; set; }
    public bool ErRigtigt { get; set; }
}



/*
Ekstra Opgaver:
Opgave 3 - Mini-projekt: Byg en Quiz API
En quiz indeholder en spørgsmålstekst, samt mindst fire svarmuligheder (i et array). En af svarmulighederne er angivet som den rigtige.

Du skal som minimum implementere følgende endpoints:

GET /api/questions: Henter alle spørgsmål og deres svarmuligheder, men ikke hvilke svar der er de rigtige
GET /api/questions/{id}: Henter et bestemt spørgsmål og dets svarmuligheder, men ikke hvilket svar der er det rigtige
POST /api/questions/{id}/validate: Her kan postes et spørgsmåls-id og en svarmulighed, og så får man at vide, om svaret er rigtigt eller forkert
Sørg for der er noget testdata i programmet når det starter op. Det er ikke nødvendigt at gemme data i en rigtig database (bare brug et array eller en list).

Test API’en med Postman eller curl.
*/