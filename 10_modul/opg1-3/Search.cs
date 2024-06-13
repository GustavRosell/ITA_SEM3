using System.Security.Cryptography.X509Certificates;

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
        public static int FindNumberLinear(int[] array, int tal) {
            // TODO: Implement!
            for (int i = 0; i < array.Length; i++) {
                if(array[i] == tal) 
                {
                    return i;
                }
            }

            return -1;
        }
        /// <summary>
        /// Finder tallet i arrayet med en binær søgning.
        /// </summary>
        /// <param name="array">Det array der søges i.</param>
        /// <param name="tal">Det tal der skal findes.</param>
        /// <returns></returns>
        public static int FindNumberBinary(int[] array, int tal) {
            // TODO: Implement!
            int min = 0; 
            int max = array.Length - 1; 

            while (min <= max) { // while loopet kører så længe min er mindre end eller lig med max
                int mid = (min + max) / 2; // midten af arrayet
                if (tal == array[mid]) { 
                    return mid;
                }
                else if (tal < array[mid]){ 
                    max = mid - 1;
                }
                else { 
                    min = mid + 1;
                }
            }
            return -1;
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
        public static int[] InsertSorted(int tal) {
            // TODO: Implement!

            if(next == sortedArray.Length) // 
            {
                return sortedArray;
            }

            int i;
            for (i = sortedArray.Length - 2; (i >= 0 && (sortedArray[i] > tal || sortedArray[i] == -1)); i--)
            {
                Console.WriteLine(i);
                sortedArray[i+1] = sortedArray[i];
            }

            sortedArray[i+1] = tal;

            next ++;
            
            return sortedArray;
        }
    }
}