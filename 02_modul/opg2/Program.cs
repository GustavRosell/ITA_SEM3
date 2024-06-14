using System;
using System.Linq;

class Program
{
    // TAGS: higher-order-functions, word-filter, word-replacer
    static void Main()
    {
        Person[] people = new Person[]
        {
            new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
            new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
            new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
            new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
            new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
            new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
        };

        // Opgave 2.1
        Opg_02 opgave1 = new Opg_02();
        opgave1.Opgave1(people);

        // Opgave 2.2
        Opg_02 opgave2 = new Opg_02();
        opgave2.Opgave2(people);

        // Opgave 2.3
        Opg_02 opgave3 = new Opg_02();
        opgave3.Opgave3(people);

        // Opgave 2.3: MEGET nemmere måde, at fjerne '+45'
        Opg_02 opgave3_2 = new Opg_02();
        opgave3.Opgave3_2(people);

        // Opgave 2.4
        Opg_02 opgave4 = new Opg_02();
        opgave4.Opgave4(people);

        // Opgave 2.5 - Ekstra
        Opg_05 opgave5 = new Opg_05();
        opgave5.Opgave5(people);

        // Opgave 2.6 - Ekstra
        Opg_06 opgave6 = new Opg_06();
        opgave6.Opgave6(people);
    }
}

class Opg_02
{
    // Opgave 2.1
    // Find og udskriv personen med mobilnummer “+4543215687”.
    public void Opgave1(Person[] people)
    {
        Console.WriteLine("Opgave 2.1: ");
        Console.WriteLine("-----------");
        var findNr = people.Where(p => p.Phone == "+4543215687");

        foreach (var person in findNr)
        {
            Console.WriteLine($"Personen med tlfnr'et: {person.Phone}, er: {person.Name}");
        }
        Console.WriteLine("-----------\n");
    }

    // Opgave 2.2
    // Vælg alle som er over 30 og udskriv dem.
    public void Opgave2(Person[] people)
    {
        Console.WriteLine("Opgave 2.2: ");
        Console.WriteLine("-----------");

        var oldafPeople = people.Where(p => p.Age > 30);

        foreach (var person in oldafPeople)
        {
            Console.WriteLine($"{person.Name} er {person.Age} år gammel");
        }
        Console.WriteLine("-----------\n");
    }

    // Opgave 2.3
    // Lav et nyt array med de samme personer, men hvor “+45” er fjernet fra alle telefonnumre.
    public void Opgave3(Person[] people)
    {
        Console.WriteLine("Opgave 2.3: ");
        Console.WriteLine("-----------");

        // Opretter et nyt array med personer, hvor "+45" er fjernet fra telefonnumre
        var updatedPeople = people.Select(p => new Person
        {
            Name = p.Name,
            Age = p.Age,

            // Fjerner "+45" fra starten af telefonnummeret, hvis det er til stede
            Phone = p.Phone.StartsWith("+45") ? p.Phone.Substring(3) : p.Phone
        }).ToArray();

        // Udskriver det opdaterede array for at bekræfte ændringerne
        foreach (var person in updatedPeople)
        {
            Console.WriteLine($"{person.Name}, {person.Age} år, Tlf: {person.Phone}");
        }

        Console.WriteLine("-----------\n");
    }

    // Opgave 2.3
    // Lav et nyt array med de samme personer, men hvor “+45” er fjernet fra alle telefonnumre.
    public void Opgave3_2(Person[] people)
    {
        Console.WriteLine("Opgave 2.3 (på en sejere måde): ");
        Console.WriteLine("-----------");

        // Opretter et nyt array med personer, hvor "+45" er fjernet fra telefonnumre
        var updatedPeople = people.Select(p => new Person
        {
            Name = p.Name,
            Age = p.Age,

            // Fjerner "+45" fra starten af telefonnummeret, hvis det er til stede
            Phone = p.Phone.Replace("+45", " ")
        });

        // Udskriver det opdaterede array for at bekræfte ændringerne
        foreach (var person in updatedPeople)
        {
            Console.WriteLine($"{person.Name}, {person.Age} år, Tlf: {person.Phone}");
        }

        Console.WriteLine("-----------\n");
    }

    // Opgave 2.4
    // Generér en string med navn og telefonnummer på de personer,
    // der er yngre end 30, adskilt med komma


    public void Opgave4(Person[] people)
    {
        Console.WriteLine("Opgave 2.4: ");
        Console.WriteLine("-----------");

        // Filtrer personer yngre end 30, projektér til en ny formatstreng og saml dem med komma
        var youngPeopleInfo = people
            .Where(person => person.Age < 30)
            .Select(person => $"{person.Name} ({person.Phone})")
            .Aggregate((current, next) => current + ", " + next);

        Console.WriteLine("Personer under 30 (i én streng): \n" + youngPeopleInfo);
        Console.WriteLine("-----------\n");
    }
}

// ---------------------------------------- Ekstra opgaver fra chatten ----------------------------------------

//2.5 - ekstra  Find og udskriv alle personer, hvis navn indeholder "sen".
class Opg_05
{
    public void Opgave5(Person[] people)
    {
        Console.WriteLine("Opgave 2.5 - Ekstra: ");
        Console.WriteLine("-----------");

        var containsSen = people.Where(p => p.Name.Contains("sen"));

        foreach (var person in containsSen)
        {
            Console.WriteLine(person.Name);
        }

        Console.WriteLine("-----------\n");
    }
}

class Opg_06
{
    public void Opgave6(Person[] people)
    {
        Console.WriteLine("Opgave 2.6 - Ekstra: ");
        Console.WriteLine("-----------");
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
}