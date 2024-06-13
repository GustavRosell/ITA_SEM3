namespace Sortering
{
    public static class MergeSort
    {
        public static void Sort(int[] array)
        {
            MergeSortRecursive(array, 0, array.Length - 1);
        }

        // Hjælpemetode; rekursivt opdeler arrayet i mindre dele og fletter dem sammen.
        private static void MergeSortRecursive(int[] array, int left, int right)
        {
            // Hvis der er mere end et element i det aktuelle subarray, fortsætter sorteringen.
            if (left < right)
            {
                // Find midten af arrayet.
                int middle = left + (right - left) / 2;

                // Sortér den første og anden halvdel af arrayet.
                MergeSortRecursive(array, left, middle);
                MergeSortRecursive(array, middle + 1, right);

                // Flet de to sorterede halvdele sammen.
                Merge(array, left, middle, right);
            }
        }

        // Hjælpemetode; fletter to sorterede subarrays sammen.
        private static void Merge(int[] array, int left, int middle, int right)
        {
            // Beregn størrelserne af de to subarrays.
            int n1 = middle - left + 1;
            int n2 = right - middle;

            // Opret midlertidige arrays for de to subarrays.
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            // Kopier data til de midlertidige arrays.
            Array.Copy(array, left, leftArray, 0, n1);
            Array.Copy(array, middle + 1, rightArray, 0, n2);

            // Initialiser indekser til de to subarrays og det samlede array.
            int i = 0, j = 0;
            int k = left;

            // Flet de to subarrays sammen, indtil en af dem er tom.
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            // Kopier resterende elementer fra venstre subarray, hvis der er nogen
            while (i < n1)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }

            // Kopier resterende elementer fra højre subarray, hvis der er nogen
            while (j < n2)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
        }
    }
}

/*
    * Mergesort er en effektiv sorteringsalgoritme, der fungerer ved at opdele arrayet i mindre dele, 
    * sortere de mindre dele og derefter flette dem sammen for at opnå det endelige sorteret array. 
    * Algoritmen starter med at opdele arrayet i to halvdele, sortere de to halvdele og derefter flette dem sammen. 
    * Dette gentages, indtil hele arrayet er sorteret.
    * 
    * Mergesort har en tidskompleksitet på O(n log n), hvilket betyder, at den er hurtigere end sorteringsalgoritmer som f.eks. 
    * bubblesort, selectionsort og insertionsort. 
    * Derfor er mergesort en god løsning til store mængder data.
    */

    // Tidskompleksitet: O(n log n)