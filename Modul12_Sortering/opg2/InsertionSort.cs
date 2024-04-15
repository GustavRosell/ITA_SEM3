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
