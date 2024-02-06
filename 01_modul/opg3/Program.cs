// Modul 01; Opgave 3
using System;

class opg_3
{
    public static void Main()
    {
        Console.WriteLine(opg_3.Faculty(5)); // Output skal være '120'.
    }

    public static int Faculty(int n)
    {
        // Termineringsregel
        if (n == 0)
        {
            return 1;
        }

        // Rekurrensregel
        else
        {
            Console.WriteLine(n);
            return n * Faculty(n - 1);
        }
    }
}
