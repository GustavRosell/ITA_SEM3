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

        // Opgave 1.1
        Opg_01 opgave1 = new Opg_01();
        opgave1.Opgave1(people);

        // Opgave 1.2
        Opg_02 opgave2 = new Opg_02();
        opgave2.Opgave2(people);

        // Opgave 1.3
        Opg_03 opgave3 = new Opg_03();
        opgave3.Opgave3(people);
    }
}

class Opg_01
{
    public void Opgave1(Person[] people)
    {
        Console.WriteLine("Opgave 1: ");
        Console.WriteLine("-----------");
        int totalAge = people.Sum(p => p.Age);
        Console.WriteLine("Den samlede alder for alle personer er: " + totalAge);
        Console.WriteLine("-----------\n");
    }
}

class Opg_02
{
    public void Opgave2(Person[] people)
    {
        Console.WriteLine("Opgave 2: ");
        Console.WriteLine("-----------");
        int countNielsen = people.Count(p => p.Name.Contains("Nielsen"));
        Console.WriteLine("Antallet af personer, der hedder 'Nielsen': " + countNielsen);
        Console.WriteLine("-----------\n");
    }
}

class Opg_03
{
    public void Opgave3(Person[] people)
    {
        Console.WriteLine("Opgave 3: ");
        Console.WriteLine("-----------");
        int oldestAge = people.Max(p => p.Age); // Finder den højeste alder
        var oldestPeople = people.Where(p => p.Age == oldestAge); // Finder alle personer med denne alder

        foreach (var person in oldestPeople)
        {
            // For hver person, udskriv navn og alder
            Console.WriteLine($"Den ældste person er {person.Name} med en alder af: {person.Age}");
        }

        Console.WriteLine("-----------\n");
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
}