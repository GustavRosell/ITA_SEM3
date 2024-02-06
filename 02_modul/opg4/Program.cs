using System;

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

        BubbleSort.Sort(people, compareAges);

        // Print sorted people
        foreach (var person in people)
        {
            Console.WriteLine($"{person.Name}, {person.Age}, {person.Phone}");
        }
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
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
}