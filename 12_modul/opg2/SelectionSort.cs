namespace Sortering;

public class SelectionSort
{
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    public static void Sort(int[] array)
    {
        // Loop through all elements in the array
        for (int i = 0; i < array.Length; i++)
        {
            // Find the index of the smallest element in the array
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            // Swap the smallest element with the current element
            Swap(array, i, minIndex);
        }
        return;
    }
}

/*
 * Selection sort er en simpel sorteringsalgoritme, 
 der fungerer ved at finde det mindste element i arrayet og bytte det med det første element. 
 Derefter finder den det næstmindste element og bytter det med det andet element, og så videre. 
 Denne proces fortsætter, indtil hele arrayet er sorteret.
  
 Algoritmen har en tidskompleksitet på O(n^2), hvilket betyder, at den er langsommere end mere avancerede 
 sorteringsalgoritmer som f.eks. quicksort og mergesort. 
 Derfor er selection sort ikke en god løsning til store mængder data
 */

// Tidskompleksitet: O(n^2)