using System;
using Microsoft.VisualBasic;

class Program
{
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

        // Opgave 4.2: Sammenligner to personer efter alder
        Func<Person, Person, int> compareAges = (person1, person2) =>
        {
            if (person1.Age < person2.Age)
            {
                return -1;
            }
            else if (person1.Age == person2.Age)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        };

        // Sorterer personer efter alder
        BubbleSort.Sort(people, compareAges);

        // Opgave 4.2: Udskriver personer sorteret efter alder
        Console.WriteLine("Opgave 4.2:");
        foreach (var person in people)
        {
            Console.WriteLine($"{person.Name}, {person.Age}, {person.Phone}");
        }

        // ----------------------------------------------------------------------------------------------------------------------------------------

        // Opgave 4.3: Sorterer personer efter navn
        Func<Person, Person, int> compareNames = (person1, person2) =>
        {
            return person1.Name.CompareTo(person2.Name);
        };
        // Sorterer personer efter navn
        BubbleSort.Sort(people, compareNames);

        // Opgave 4.3: Udskriver personer sorteret efter navn
        Console.WriteLine("\nOpgave 4.3:");
        foreach (var person in people)
        {
            Console.WriteLine($"{person.Name}, {person.Age}, {person.Phone}");
        }

        // ----------------------------------------------------------------------------------------------------------------------------------------

        // Opgave 4.4: Sorterer personer efter telefonnummer
        Func<Person, Person, int> comparePhones = (person1, person2) =>
        {
            return person1.Phone.CompareTo(person2.Phone);
        };
        // Sorterer personer efter telefonnummer
        BubbleSort.Sort(people, comparePhones);

        // Opgave 4.4: Udskriver personer sorteret efter telefonnummer
        Console.WriteLine("\nOpgave 4.4:");
        foreach (var person in people)
        {
            Console.WriteLine($"{person.Name}, {person.Age}, {person.Phone}");
        }

        // ----------------------------------------------------------------------------------------------------------------------------------------

        // Opgave 5.1: Højere Ordens Funktion
        // Der laves en ny sorterings-funktion hvor der sammenlignes på alder
        var PeopleSortAge = BubbleSort.CreateSorter((person1, person2) => person1.Age - person2.Age);
        // Den nye funktion bruges til at sortere et array
        var sortedPeople = PeopleSortAge(people);
        // Det sorterede array udskrives med LINQ så vi kan se at det virker
        Console.WriteLine("\nOpgave 5.1:");
        sortedPeople.ToList().ForEach(p => Console.WriteLine(p.Age + " " + p.Name));

    }
}

public class BubbleSort
{
    // Bytter om på to elementer i et array
    private static void Swap(Person[] array, int i, int j)
    {
        Person temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    // Laver sortering på array med Bubble Sort. 
    // compareFn bruges til at sammeligne to personer med.
    public static void Sort(Person[] array, Func<Person, Person, int> compareFn)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j <= i - 1; j++)
            {
                // Laver en ombytning, hvis to personer står forkert sorteret
                if (compareFn(array[j], array[j + 1]) > 0)
                {
                    Swap(array, j, j + 1);
                }
            }
        }
    }

    // ----------------------------------------------------------------------------------------------------------------------------------------

    /*
// Opgave 5.1: Højere Ordens Funktion

I dagens præsentation er der et eksempel på at bruge en højere ordens funktion (“createGreeterFn”) til at genererer en ny funktion (“greetStudent”).

I denne opgave skal du lave en højere ordens funktion, som kan lave en ny udgave af BubbleSort, hvor input-parameteren compareFn er givet på forhånd. Eller sagt på en anden måde, compareFn skal være indbygget i return-funktionen, ligesom navnet på “studerende” var indbygget i “greetStudent” fra dagens slide.

Den nye version af BubbleSort skal kunne bruges på denne måde:
// Din opgave er, med andre ord, at implementere CreateSorter i ovenstående eksempel. Den skal baserer sig på koden fra sidste opgave.
// Den nye version af BubbleSort skal kunne bruges på følgende måde:
// Der laves en ny sorterings-funktion hvor der sammenlignes på alder
var PeopleSortAge = CreateSorter((person1, person2) => person1.Age - person2.Age);
// Den nye funktion bruges til at sortere et array
var sortedPeople = PeopleSort(people);
// Det sorterede array udskrives med LINQ så vi kan se at det virker
sortedPeople.ToList().ForEach(p => Console.WriteLine(p.Age + " " + p.Name));
*/

    // Opgave 5.1: Højere Ordens Funktion
    public static Func<Person[], Person[]> CreateSorter(Func<Person, Person, int> compareFn)
    {
        return (array) =>
        {
            Person[] newArray = (Person[])array.Clone();
            BubbleSort.Sort(newArray, compareFn);
            return newArray;
        };
    }
    // ----------------------------------------------------------------------------------------------------------------------------------------
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
}

