namespace Sortering;

public static class QuickSort
{
    private static void Swap(int[] array, int k, int j)
    {
        int tmp = array[k];
        array[k] = array[j];
        array[j] = tmp;
    }

    private static void _quickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivot = Partition(array, low, high);
            _quickSort(array, low, pivot - 1);
            _quickSort(array, pivot + 1, high);
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];  // Bruger det sidste element som pivot
        int i = (low - 1);  // Placering af mindre element

        for (int j = low; j < high; j++)
        {
            // Hvis det aktuelle element er mindre end eller lig med pivot
            if (array[j] <= pivot)
            {
                i++;  // Inkrementér index for mindre element
                Swap(array, i, j);  // Byt elementer
            }
        }
        Swap(array, i + 1, high);  // Byt pivot elementet til sin korrekte placering
        return i + 1;  // Returner partitioneringsindexen
    }

    public static void Sort(int[] array)
    {
        _quickSort(array, 0, array.Length - 1);  // Sikrer, at hele arrayet sorteres
    }
}