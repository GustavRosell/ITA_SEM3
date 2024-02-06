// Modul 01; Opgave 4
using System;

class opg_4
{
    static void Main()
    {
        // Opgave 4.1
        int a = 30;
        int b = 12;
        Console.WriteLine("\nOpgave 4.1: ");
        Console.WriteLine("-----------");
        Console.WriteLine($"Den største fælles divisor af {a} og {b} er: {Sfd(a, b)}");
        Console.WriteLine($"Den største fælles divisor af {a} og {b} er: {Sfd2(a, b)}");
        Console.WriteLine("-----------\n");

        // Opgave 4.2
        int grundtal = 5;
        int eksponent = 4;
        Console.WriteLine("Opgave 4.2: ");
        Console.WriteLine("-----------");
        Console.WriteLine($"{grundtal} opløftet til {eksponent}'te potens er: {OpløftTilPotens(grundtal, eksponent)}");
        Console.WriteLine("-----------\n");

        // Opgave 4.3
        int a1 = 4;
        int b1 = 2;
        Console.WriteLine("Opgave 4.3: ");
        Console.WriteLine("-----------");
        Console.WriteLine($"{a1} * {b1} er = {GangeUdenAtGangeLol(a1, b1)}");
        Console.WriteLine("-----------\n");

        // Opgave 4.4
        string tekst = "EGAKNANAB";
        Console.WriteLine("Opgave 4.4: ");
        Console.WriteLine("-----------");
        Console.WriteLine($"Teksten: {tekst}, er = {Reverse(tekst)} baglæns");
        Console.WriteLine("-----------\n");

    }

    // Opgave 4.1
    public static int Sfd(int a, int b)
    {
        // Termineringsregel

        if (b == 0)
            return a;

        // Rekurrensregel
        return Sfd(b, a % b);
    }

    // Opgave 4.1 (På en anden måde)
    public static int Sfd2(int a, int b)
    {
        // Termineringsregel: Returner b, hvis b går op i a
        if (a % b == 0)
            return b;

        // Rekurrensregel
        if (a < b)
            return Sfd2(b, a);
        else
            return Sfd2(b, a % b);
    }

    // Opgave 4.2
    public static int OpløftTilPotens(int grundtal, int eksponent)
    {
        // Termineringsregel
        if (eksponent == 0)
            return 1;

        // Rekurrensregel
        return grundtal * OpløftTilPotens(grundtal, eksponent - 1);
    }

    // Opgave 4.3
    public static int GangeUdenAtGangeLol(int a1, int b1)
    {
        // Termineringsregel
        if (a1 == 0)
            return 0;

        if (a1 == 1)
            return b1;

        // Rekurrensregel
        return GangeUdenAtGangeLol(a1 - 1, b1) + b1;
    }

    // Opgave 4.4
    public static string Reverse(string tekst)
    {
        // Termineringsregel: Hvis strengen er tom eller har én karakter
        if (string.IsNullOrEmpty(tekst) || tekst.Length == 1)
        {
            return tekst;
        }

        // Rekursions tilfælde: Vend resten af strengen og tilføj den første karakter på enden
        return Reverse(tekst.Substring(1)) + tekst[0];
    }
}
