namespace Sortering
{
    public static class MergeSort
    {
        public static void Sort(int[] array)
        {
            MergeSortRecursive(array, 0, array.Length - 1);
        }

        private static void MergeSortRecursive(int[] array, int left, int right)
        {
            if (left < right)
            {
                // Find midten af arrayet
                int middle = left + (right - left) / 2;

                // Sortér den første og anden halvdel
                MergeSortRecursive(array, left, middle);
                MergeSortRecursive(array, middle + 1, right);

                // Flet de sorterede halvdele
                Merge(array, left, middle, right);
            }
        }

        private static void Merge(int[] array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            // Opret midlertidige arrays
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            // Kopier data til midlertidige arrays
            Array.Copy(array, left, leftArray, 0, n1);
            Array.Copy(array, middle + 1, rightArray, 0, n2);

            int i = 0, j = 0;
            int k = left;

            // Flet de midlertidige arrays tilbage i arrayet
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

            // Kopier resterende elementer af leftArray, hvis nogen
            while (i < n1)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }

            // Kopier resterende elementer af rightArray, hvis nogen
            while (j < n2)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
        }
    }
}
