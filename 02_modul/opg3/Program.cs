using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Opgave 3.1
        // Eksempel på brug af CreateWordFilterFn
        var filterWords = new string[] { "shit", "fucking", "fuck" };
        var FilterWords = CreateWordFilterFn(filterWords);

        Console.WriteLine("-----------");
        Console.WriteLine("Opgave 3.1: ");
        Console.WriteLine("-----------");
        Console.WriteLine(FilterWords("fuck noget fucking shit makker."));
        Console.WriteLine("-----------\n");


        // Opgave 3.2
        // Eksempel på brug af CreateWordReplacerFn
        var badWords = new string[] { "shit", "fuck", "idiot" };
        var ReplaceBadWords = CreateWordReplacerFn(badWords, "kage");
        Console.WriteLine("Opgave 3.2: ");
        Console.WriteLine("-----------");
        Console.WriteLine(ReplaceBadWords("Sikke en gang shit, fuck det, sikke en idiot."));
        Console.WriteLine("-----------\n");
    }

    // Opgave 3.1: Fjerner 'Bad Words'
    static Func<string, string> CreateWordFilterFn(string[] words)
    {
        return (text) =>
        {
            var wordsList = text.Split(' ').ToList();
            var filteredWords = wordsList.Where(word => !words.Contains(word)).ToList();
            return String.Join(" ", filteredWords);
        };
    }

    // Opgave 3.2: Erstatter 'Bad Words' med 'Kage'
    static Func<string, string> CreateWordReplacerFn(string[] words, string replacementWord)
    {
        return (text) =>
        {
            var wordsList = text.Split(' ').ToList();
            var replacedWords = wordsList.Select(word => words.Contains(word) ? replacementWord : word).ToList();
            return String.Join(" ", replacedWords);
        };
    }
}
