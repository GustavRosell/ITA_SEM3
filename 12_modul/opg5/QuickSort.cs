namespace Sortering;

public static class QuickSort
{
    // Hjælpemetode; bytter to elementer i arrayet
    private static void Swap(int[] array, int k, int j)
    {
        int tmp = array[k];
        array[k] = array[j];
        array[j] = tmp;
    }

    // Hjælpemetode; rekursivt sorterer arrayet
    private static void _quickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivot = Partition(array, low, high);
            _quickSort(array, low, pivot - 1);
            _quickSort(array, pivot + 1, high);
        }
    }

    // Hjælpemetode; partitionerer arrayet og returnerer partitioneringsindexen
    private static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];  // Bruger det sidste element som pivot // OVERVEJ OG LAV NY MED PIVOT PÅ FØRSTE ELEMENT
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

/*
    * Quicksort er en effektiv sorteringsalgoritme, der fungerer ved at vælge et pivot element og placere det på den rigtige plads i arrayet. 
    * Derefter sorterer den de elementer, der er mindre end pivoten, til venstre og de elementer, der er større end pivoten, til højre. 
    * Algoritmen fortsætter med at vælge pivot elementer og sortere elementerne, indtil hele arrayet er sorteret.
    * 
    * Quicksort har en gennemsnitlig tidskompleksitet på O(n log n), hvilket gør den hurtigere end sorteringsalgoritmer som f.eks. 
    * bubblesort og selectionsort. 
    * Derfor er quicksort en god løsning til store mængder data.
    */

    // Tidskompleksitet: O(n log n)
    // i værste tilfælde: O(n^2) hvis det første element er det største eller mindste element i arrayet, 
    // da det vil tage O(n) tid at finde det korrekte pivot element