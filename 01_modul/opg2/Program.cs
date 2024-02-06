// Modul 1; Opgave 2
using System;

class Program
{
    static void Main()
    {
        int bredde = 5; // Du kan ændre denne værdi for at teste med forskellige bredde værdier
        int resultat = areal(bredde);
        Console.WriteLine($"Arealet af figuren med bredde {bredde} er: {resultat}");
    }

    public static int areal(int bredde)
    {
        int resultat;
        if (bredde == 1)
        {
            resultat = 1;
        }
        else
        {
            resultat = bredde + areal(bredde - 1);
        }
        return resultat;
    }
}
