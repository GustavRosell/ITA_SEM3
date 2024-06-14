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

        // Opgave 1.4
        Opg_04 opgave4 = new Opg_04();
        opgave4.Opgave4(people);

        // Opgave 1.5
        Opg_05 opgave5 = new Opg_05();
        opgave5.Opgave5(people);

         // Opgave 1.6
        Opg_06 opgave6 = new Opg_06();
        opgave6.Opgave6(people);
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


// ---------------------------------------- Ekstra opgaver fra chatten ----------------------------------------

class Opg_04
{
    //1.1 Beregn det gennemsnitlige alder for alle personer.
    public void Opgave4(Person[] people)
    {
        Console.WriteLine("Opgave 4: ");
        Console.WriteLine("-----------");

        double aldersGennemsnit = people.Average(p => p.Age);


        Console.WriteLine(aldersGennemsnit);
        Console.WriteLine("-----------\n");
    }
}

class Opg_05
{
    //1.2 Tæl hvor mange personer der har et navn, der starter med "J".
    public void Opgave5(Person[] people)
    {
        Console.WriteLine("Opgave 5: ");
        Console.WriteLine("-----------");

        int startsWithJ = people.Count(p => p.Name.StartsWith("J"));

        Console.WriteLine(startsWithJ);
        Console.WriteLine("-----------\n");
    }
}

class Opg_06
{
    //1.3 Find den yngste person.

    public void Opgave6(Person[] people)
    {
        Console.WriteLine("Opgave 5: ");
        Console.WriteLine("-----------");
        
        int youngestAge = people.Min(p => p.Age); // Finder den højeste alder
        var youngestPeople = people.Where(p => p.Age == youngestAge); // Finder alle personer med denne alder

        foreach (var person in youngestPeople)
        {
            Console.WriteLine($"Den yngste person er {person.Name} med en alder af: {person.Age}");
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