var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Testdata for Mail
var mailListJens = new List<Mail>
{
    new Mail(1, "Velkomstmail", "jens@example.com", "afsender@example.com"),
    new Mail(2, "Opdatering", "jens@example.com", "afsender@example.com"),
    new Mail(3, "Påmindelse", "jens@example.com", "afsender@example.com")
};

var mailListPeter = new List<Mail>
{
    new Mail(4, "Kvittering", "peter@example.com", "afsender@example.com"),
    new Mail(5, "Velkomstmail", "peter@example.com", "afsender@example.com"),
    new Mail(6, "Opdatering", "peter@example.com", "afsender@example.com")
};

// Testdata for User
var userList = new List<User>
{
    new User(1, "Jens", mailListJens),
    new User(2, "Peter", mailListPeter)
};


app.MapGet("/", () => "Hello World!");

// Endpoint som henter alle users
app.MapGet("/api/user", () => userList);

// Endpoint som henter alle emails for en user.
app.MapGet("/api/mails/{username}", (string username) => 
{
    var user = userList.FirstOrDefault(user => user.Navn == username);

    if (user != null && user.Mails != null)
    {
        return Results.Ok(user.Mails);
    }
    return Results.NotFound();
});

// Post Api/Mails, men modtageren (User) får mailen
app.MapPost("/api/mails", (MailInput mailInput) => 
{
    var user = userList.FirstOrDefault(user => user.Navn == mailInput.Modtager);

    if (user != null)
    {
        int highestId = user.Mails.Max(mail => mail.Id);
        int newId = highestId + 1;

        user.Mails.Add(new Mail(newId, mailInput.Beskrivelse, mailInput.Modtager, mailInput.Afsender));
        return Results.Created($"/api/mails/{newId}", mailInput);
    }
    return Results.NotFound();
});

// Slet en mail, men kun udfra mailId
app.MapDelete("/api/mails/{id}", (int id) => 
{
    foreach (var user in userList)
    {
        var mail = user.Mails.FirstOrDefault(mail => mail.Id == id);

        if (mail != null)
        {
            user.Mails.Remove(mail);
            return Results.Ok("Mail slettet");
        }
    }
    return Results.NotFound("Mail ikke fundet");
});


// Endpoint som henter en specifik email for en user.
app.MapGet("/api/mails/{username}/{mailId}", (string username, int mailId) => 
{
    var user = userList.FirstOrDefault(user => user.Navn == username);

    if (user != null && user.Mails != null)
    {
        var mail = user.Mails.FirstOrDefault(mail => mail.Id == mailId);

        if (mail != null)
        {
            return Results.Ok(mail);
        }
    }
    return Results.NotFound();
});


app.Run();
public record MailInput (int Id , string Beskrivelse, string Modtager, string Afsender);

public class User
{
    public int Id { get; set; }
    public string Navn { get; set; }
    public List<Mail> Mails { get; set; }

    public User(int id, string navn, List<Mail> mails)
    {
        Id = id;
        Navn = navn;
        Mails = mails;
    }
}

public class Mail 
{
    public int Id { get; set; }
    public string Beskrivelse { get; set; }
    public string Modtager { get; set; }
    public string Afsender { get; set; }

    public Mail(int id, string beskrivelse, string modtager, string afsender)
    {
        Id = id;
        Beskrivelse = beskrivelse;
        Modtager = modtager;
        Afsender = afsender;
    }
}