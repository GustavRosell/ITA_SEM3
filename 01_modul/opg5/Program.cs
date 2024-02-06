using System;
using System.IO;

// Modul 1; Opgave 5 - (Ekstra opgave)

class opg_5
   
{

    public static void Main()
    {   
        // Opgave 5.1 - Tæller antallet af mapper
        Console.WriteLine("--------------------\nOpgave 5.1:\n-------------------- ");
        string path = "/Users/rosell/IT-A/3. Sem";
        Console.WriteLine($"Antal mapper: {ScanDirCount(path)}");
        Console.WriteLine("-------------------- ");

        // Opgave 5.2 - Udskriver mappestrukturen med indrykning
        Console.WriteLine("Opgave 5.2:\n-------------------- ");
        Console.WriteLine("\nMappe struktur:");
        ScanDirIndented(path);
        Console.WriteLine("-------------------- ");
    }

    // Opgave 5.1: Tæller antallet af mapper rekursivt
    public static int ScanDirCount(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        int folderCount = 1; // Tæller den nuværende mappe

        DirectoryInfo[] dirs = dir.GetDirectories();
        foreach (DirectoryInfo subdir in dirs)
        {
            folderCount += ScanDirCount(subdir.FullName); // Rekursivt kald til undermapper
        }

        return folderCount;
    }

    // Opgave 5.2: Udskriver mappestrukturen med indrykning
    public static void ScanDirIndented(string path, int level = 0)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        string indentation = new string(' ', level * 2); // 2 mellemrum pr. niveau

        Console.WriteLine($"{indentation}{new DirectoryInfo(path).Name}");
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            Console.WriteLine($"{indentation}  {file.Name}"); // Filnavne indrykket med 2 ekstra mellemrum
        }

        DirectoryInfo[] dirs = dir.GetDirectories();
        foreach (DirectoryInfo subdir in dirs)
        {
            ScanDirIndented(subdir.FullName, level + 1); // Rekursivt kald med øget niveau
        }
    }
}
