namespace SearchMethods
{
    public class Search
    {
        /// <summary>
        /// Finder tallet i arrayet med en lineær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns></returns>
        public static int FindNumberLinear(int[] array, int tal)
        {
            // TODO: Implement!
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == tal)
                {
                    return i; // Returner indekset hvor tallet er fundet
                }
            }
            return -1; // Returner -1 hvis tallet ikke er fundet
        }

        /// <summary>
        /// Finder tallet i arrayet med en binær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns></returns>

        public static int FindNumberBinary(int[] array, int tal)
        {
            // TODO: Implement!
            int min = 0;
            int max = array.Length - 1;

            while (min <= max)
            { // Så længe min er mindre end eller lig med max
                int mid = (min + max) / 2; // Find midten af arrayet
                if (tal == array[mid])
                { // Hvis tallet er midt i arrayet
                    return mid; // Returner indekset
                }
                else if (tal < array[mid])
                { // Hvis tallet er mindre end midten
                    max = mid - 1; // Sæt max til midten - 1
                }
                else
                { // Hvis tallet er større end midten
                    min = mid + 1; // Sæt min til midten + 1
                }
            }

            return -1; // Returner -1 hvis tallet ikke er fundet
        }

        private static int[] sortedArray { get; set; } =
            new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        private static int next = 0;

        /// <summary>
        /// Indsætter et helt array. Arrayet skal være sorteret på forhånd.
        /// </summary>
        /// <param name="sortedArray">Array der skal indsættes.</param>
        /// <param name="next">Den næste ledige plads i arrayet.</param>
        public static void InitSortedArray(int[] sortedArray, int next)
        {
            Search.sortedArray = sortedArray;
            Search.next = next;
        }

        /// <summary>
        /// Indsætter et tal i et sorteret array. En kopi af arrayet returneres.
        /// Array er fortsat sorteret efter det nye tal er indsat.
        /// </summary>
        /// <param name="tal">Tallet der skal indsættes</param>
        /// <returns>En kopi af det sorterede array med det nye tal i.</returns>
        public static int[] InsertSorted(int tal)
        {
            // TODO: Implement!

            // Hvis arrayet er fuldt, returner en kopi af arrayet uden ændringer.
            if (next >= sortedArray.Length)
            {
                int[] fullArray = new int[sortedArray.Length];
                Array.Copy(sortedArray, fullArray, sortedArray.Length);
                return fullArray;
            }

            // Find den korrekte position at indsætte tallet.
            int i;
            for (i = next - 1; i >= 0 && sortedArray[i] > tal; i--)
            {
                sortedArray[i + 1] = sortedArray[i]; // Flyt elementet en plads til højre
            }

            // Indsæt tallet på den korrekte plads
            sortedArray[i + 1] = tal;
            next++; // Opdater næste ledige plads

            // Lav en kopi af arrayet med de aktuelle elementer og udfyld resten med -1
            int[] resultArray = new int[sortedArray.Length];
            for (int j = 0; j < resultArray.Length; j++)
            {
                resultArray[j] = j < next ? sortedArray[j] : -1;
            }
            return resultArray;

        }
    }
}