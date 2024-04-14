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
        // Loop through all elements in the array
        for (int i = 0; i < array.Length; i++)
        {
            // Loop through all elements in the array except the last i elements
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                // If the current element is greater than the next element, swap them
                if (array[j] > array[j + 1])
                {
                    Swap(array, j, j + 1);
                }
            }
        }

        return;
    }
}