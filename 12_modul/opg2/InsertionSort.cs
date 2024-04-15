namespace Sortering;

public class InsertionSort
{

    public static void Sort(int[] array)
    {

        // Loop through all elements in the array
        for (int i = 1; i < array.Length; i++)
        {
            // Store the current element in a variable
            int current = array[i];
            int j = i - 1;

            // Loop through all elements in the array from the current element to the first element
            while (j >= 0 && array[j] > current)
            {
                // Move the current element to the right
                array[j + 1] = array[j];
                j--;
            }

            // Insert the current element in the correct position
            array[j + 1] = current;
        }
        return;
    }
}

/*
 * Insertion sort er en simpel sorteringsalgoritme, der fungerer ved at tage et element ad gangen og 
 indsætte det på den rigtige plads i en sorteret del af arrayet. 
 Algoritmen starter med at antage; 
 1: at det første element i arrayet er sorteret.
    2: Derefter tager den det næste element og indsætter det på den rigtige plads i den sorteret del af arrayet.
       3: Dette gentages, indtil hele arrayet er sorteret.
    */ 

    // Tidskompleksitet: O(n^2)