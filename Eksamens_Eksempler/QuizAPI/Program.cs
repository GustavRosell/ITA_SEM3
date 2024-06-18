var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

var quizzes = new List<Quiz>
{
    new Quiz
    {
        Id = 1,
        Titel = "General Knowledge",
        Beskrivelse = "A quiz about general knowledge.",
        Questions = new List<Question>
        {
            new Question
            {
                Text = "What is the capital of France?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Paris", IsCorrect = true },
                    new Answer { Text = "Berlin", IsCorrect = false },
                    new Answer { Text = "Rome", IsCorrect = false }
                }
            },
            new Question
            {
                Text = "Who wrote 'To Kill a Mockingbird'?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Harper Lee", IsCorrect = true },
                    new Answer { Text = "Mark Twain", IsCorrect = false },
                    new Answer { Text = "Ernest Hemingway", IsCorrect = false }
                }
            }
        }
    },
    new Quiz
    {
        Id = 2,
        Titel = "Science",
        Beskrivelse = "A quiz about science.",
        Questions = new List<Question>
        {
            new Question
            {
                Text = "What is H2O?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Water", IsCorrect = true },
                    new Answer { Text = "Oxygen", IsCorrect = false },
                    new Answer { Text = "Hydrogen", IsCorrect = false }
                }
            },
            new Question
            {
                Text = "What planet is known as the Red Planet?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Mars", IsCorrect = true },
                    new Answer { Text = "Jupiter", IsCorrect = false },
                    new Answer { Text = "Saturn", IsCorrect = false }
                }
            }
        }
    },
    new Quiz
    {
        Id = 3,
        Titel = "History",
        Beskrivelse = "A quiz about historical events.",
        Questions = new List<Question>
        {
            new Question
            {
                Text = "Who was the first President of the United States?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "George Washington", IsCorrect = true },
                    new Answer { Text = "Thomas Jefferson", IsCorrect = false },
                    new Answer { Text = "Abraham Lincoln", IsCorrect = false }
                }
            },
            new Question
            {
                Text = "In which year did the Titanic sink?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "1912", IsCorrect = true },
                    new Answer { Text = "1905", IsCorrect = false },
                    new Answer { Text = "1920", IsCorrect = false }
                }
            }
        }
    }
};

// GET /api/quizzer: Henter alle quizzer.
app.MapGet("/api/quizzer", () => quizzes);


// GET /api/quizzer/{id}: Henter en bestemt quiz ud fra ID.
app.MapGet("/api/quizzer/{id}", (int id) =>
{
    var quiz = quizzes.FirstOrDefault(q => q.Id == id);

    if (quiz != null)
    {
        return Results.Ok(quiz);
    }

    return Results.NotFound("No quiz with this ID");
});

// GET /api/quizzer/{id}/spørgsmål: Henter alle spørgsmål for en bestemt quiz.
app.MapGet("/api/quizzer/{id}/spørgsmål", (int id) =>
{
    var quiz = quizzes.FirstOrDefault(q => q.Id == id);

    if (quiz != null)
    {
        return Results.Ok(quiz.Questions);
    }

    return Results.NotFound("No quiz with this ID");
});

// GET /api/quizzer/{id}/spørgsmål/{spørgsmålId}/svarmuligheder: Henter alle svarmuligheder for et bestemt spørgsmål.
app.MapGet("/api/quizzer/{id}/spørgsmål/{spørgsmålId}/svarmuligheder", (int id, int spørgsmålId) =>
{
    var quiz = quizzes.FirstOrDefault(q => q.Id == id);

    if (quiz == null)
    {
        return Results.NotFound("No quiz with this ID");
    }

    var question = quiz.Questions.FirstOrDefault(q => q.Id == spørgsmålId);

    if (question == null)
    {
        return Results.NotFound("No question with this ID");
    }

    return Results.Ok(question.Answers);
});

// POST /api/quizzer: Tager imod en ny quiz, der skal oprettes.
app.MapPost("/api/quizzer", (NewQuiz newQuiz) =>
{
    var quiz = new Quiz
    {
        Id = quizzes.Max(q => q.Id) + 1,
        Titel = newQuiz.Titel,
        Beskrivelse = newQuiz.Beskrivelse
    };

    quizzes.Add(quiz);

    return Results.Created($"/api/quizzer/{quiz.Id}", quiz);
});

// Post - tilføj spørgsmål til quiz
app.MapPost("/api/quizzer/{id}/spørgsmål", (int id, NewQuestion newQuestion) =>
{
    var quiz = quizzes.FirstOrDefault(q => q.Id == id);

    if (quiz == null)
    {
        return Results.NotFound("No quiz with this ID");
    }

    var question = new Question
    {
        Id = quiz.Questions.Max(q => q.Id) + 1,
        Text = newQuestion.Text,
        Answers = new List<Answer>()
    };

    quiz.Questions.Add(question);

    return Results.Created($"/api/quizzer/{id}/spørgsmål", question);
});

// Post- tilføj svarmuligheder til spørgsmål
app.MapPost("/api/quizzer/{id}/spørgsmål/{spørgsmålId}/svarmuligheder", (int id, int spørgsmålId, NewAnswer newAnswer) =>
{
    var quiz = quizzes.FirstOrDefault(q => q.Id == id);

    if (quiz == null)
    {
        return Results.NotFound("No quiz with this ID");
    }

    var question = quiz.Questions.FirstOrDefault(q => q.Id == spørgsmålId);

    if (question == null)
    {
        return Results.NotFound("No question with this ID");
    }

    var answer = new Answer
    {
        Text = newAnswer.Text,
        IsCorrect = newAnswer.IsCorrect
    };

    question.Answers.Add(answer);

    return Results.Created($"/api/quizzer/{id}/spørgsmål/{spørgsmålId}/svarmuligheder", answer);
});

// PUT /api/quizzer/{id}: Opdaterer en eksisterende quiz.
app.MapPut("/api/quizzer/{id}", (int id, Quiz quiz) =>
{
    var existingQuiz = quizzes.FirstOrDefault(q => q.Id == id);

    if (existingQuiz == null)
    {
        return Results.NotFound("No quiz with this ID");
    }

    existingQuiz.Titel = quiz.Titel;
    existingQuiz.Beskrivelse = quiz.Beskrivelse;

    return Results.Ok(existingQuiz);
});

// DELETE /api/quizzer/{id}: Sletter en bestemt quiz.
app.MapDelete("/api/quizzer/{id}", (int id) =>
{
    var quiz = quizzes.FirstOrDefault(q => q.Id == id);

    if (quiz == null)
    {
        return Results.NotFound("No quiz with this ID");
    }

    quizzes.Remove(quiz);

    return Results.NoContent();
});

app.Run();

// Record som skal bruges til at oprette ny quiz
public record NewQuiz(string Titel, string Beskrivelse, List<NewQuestion> Questions);

public record NewQuestion(string Text, List<NewAnswer> Answers);

public record NewAnswer(string Text, bool IsCorrect);

public class Quiz
{
    public int Id { get; set; }
    public string Titel { get; set; }
    public string Beskrivelse { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();

}

public class Question
{
    public int Id { get; set;}
    public string Text { get; set; }
    public List<Answer> Answers { get; set; } = new List<Answer>();
}

public class Answer
{
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}

/* 
Quizzerne skal som minimum indeholde følgende felter: id, titel, beskrivelse og en liste over spørgsmål. 
Hvert spørgsmål skal have en tekst og en liste over svarmuligheder med en markering af, hvilket svar der er korrekt.


GET /api/quizzer: Henter alle quizzer.
GET /api/quizzer/{id}: Henter en bestemt quiz ud fra ID.
POST /api/quizzer: Tager imod en ny quiz, der skal oprettes.
PUT /api/quizzer/{id}: Opdaterer en eksisterende quiz.
DELETE /api/quizzer/{id}: Sletter en bestemt quiz.
GET /api/quizzer/{id}/spørgsmål: Henter alle spørgsmål for en bestemt quiz.
 */




 /* Hvis man skal have answers og questions med i POST
app.MapPost("/api/quizzer", (NewQuiz newQuiz) =>
{
    var quiz = new Quiz
    {
        Titel = newQuiz.Titel,
        Beskrivelse = newQuiz.Beskrivelse,
        Questions = newQuiz.Questions.Select(q => new Question
        {
            Text = q.Text,
            Answers = q.Answers.Select(a => new Answer
            {
                Text = a.Text,
                IsCorrect = a.IsCorrect
            }).ToList()
        }).ToList()
    };

    if (quizzes.Count > 0)
    {
        quiz.Id = quizzes.Max(q => q.Id) + 1;
    }
    else
    {
        quiz.Id = 1;
    }

    quizzes.Add(quiz);

    return Results.Created($"/api/quizzer/{quiz.Id}", quiz);
});
*/