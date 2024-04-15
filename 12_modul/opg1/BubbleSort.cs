namespace Sortering;

public class BubbleSort
{
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    public static void Sort(int[] array)
    {
        int n = array.Length;
        bool swapped;

        while (true)
        {
            swapped = false;
            for (int i = 0; i < n - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    Swap(array, i, i + 1);
                    swapped = true;
                }
            }
            n--;  // Reducerer antallet af elementer at tjekke
            if (!swapped)
            {
                break;  // Stopper løkken, hvis der ikke blev foretaget nogen bytninger
            }
        }
    }
}
