using Hashing;

public class HashSetLinearProbing : HashSet
{
    private Object[] buckets;
    private int currentSize;
    private enum State { DELETED }

    public HashSetLinearProbing(int bucketsLength)
    {
        buckets = new Object[bucketsLength];
        currentSize = 0;
    }

    public bool Contains(Object x)
    {
        // TODO: Implement!
        int hashValue = HashValue(x);

        // Hvis bucket er tom; return false
        if (buckets[hashValue] == null)
        {
            return false;
        }

        // Hvis bucket indeholder x; return true
        if (buckets[hashValue].Equals(x))
        {
            return true;
        }

        // Hvis bucket ikke indeholder x; find næste bucket
        int probe;   // Laver en probe til at finde næste bucket
        if (hashValue == (buckets.Length - 1))
        {
            probe = 0;
        }
        else
        {
            probe = hashValue + 1;
        }

        // Så længe vi ikke er tilbage ved starten
        while (probe != hashValue)
        {
            // hvis bucket er tom; return false
            if (buckets[probe] == null)
            {
                return false;
            }

            // hvis bucket indeholder x; return true
            if (buckets[probe].Equals(x))
            {
                return true;
            }

            // Hvis bucket ikke indeholder x; find næste bucket
            if (probe == (buckets.Length - 1 ))
            {
                probe = 0;
            }
            else{
                probe++;
            }
        }
        return false;
    }

    public bool Add(Object x)
    {
        // TODO: Implement!

        int hashValue = HashValue(x);

        // Hvis x allerede findes; return false
        if (Contains (x)){
            return false;
        }

        // Hvis bucket er tom; tilføj x til bucket
        if (buckets[hashValue] == null)
        {
            buckets[hashValue] = x;
            currentSize++;
            return true;
        }

        // Hvis bucket ikke er tom; find næste bucket
        int probe; // Laver en probe til at finde næste bucket
        if (hashValue == (buckets.Length - 1))
        {
            probe = 0;
        }
        else {
            probe = hashValue + 1;
        }

        // Så længe vi ikke er tilbage ved starten
        while (probe != hashValue)
        {
            // Hvis bucket er tom; tilføj x til bucket
            if (buckets[probe] == null)
            {
                buckets[probe] = x;
                currentSize++;
                return true;
            }

            // Hvis bucket ikke er tom; find næste bucket
            if (probe == (buckets.Length - 1))
            {
                probe = 0;
            }
            else
            {
                probe++;
            }
        }

        // Hvis vi er tilbage ved starten; return false
        return false;
    }

    public bool Remove(Object x)
    {
        // TODO: Implement!

        // Hvis x ikke findes; return false
        if (!Contains(x))
        {
            return false;
        }

        int hashValue = HashValue(x);

        // Hvis x er i første bucket; slet x fra bucket
        if (buckets[hashValue].Equals(x))
        {
            buckets[hashValue] = State.DELETED;
            currentSize--;
            return true;
        }

        // Hvis x ikke er i første bucket; find næste bucket
        int probe; // Laver en probe til at finde næste bucket
        if (hashValue == (buckets.Length - 1))
        {
            probe = 0;
        }
        else
        {
            probe = hashValue + 1;
        }

        // Så længe vi ikke er tilbage ved starten
        while (probe != hashValue)
        {
            // Hvis x er i bucket; slet x fra bucket
            if (buckets[probe].Equals(x))
            {
                buckets[probe] = State.DELETED;
                currentSize--;
                return true;
            }

            // Hvis x ikke er i bucket; find næste bucket
            if (probe == (buckets.Length - 1))
            {
                probe = 0;
            }
            else
            {
                probe++;
            }
        }

        // Hvis vi er tilbage ved starten; return false
        return false;
    }

    public int Size()
    {
        return currentSize;
    }

    private int HashValue(Object x)
    {
        int h = x.GetHashCode();
        if (h < 0)
        {
            h = -h;
        }
        h = h % buckets.Length;
        return h;
    }

    public override String ToString()
    {
        String result = "";
        for (int i = 0; i < buckets.Length; i++)
        {
            int value = buckets[i] != null && !buckets[i].Equals(State.DELETED) ?
                    HashValue(buckets[i]) : -1;
            result += i + "\t" + buckets[i] + "(h:" + value + ")\n";
        }
        return result;
    }

}
