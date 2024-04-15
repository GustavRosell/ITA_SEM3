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