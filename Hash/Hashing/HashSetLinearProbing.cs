using Hashing;

public class HashSetLinearProbing : HashSet {
    private Object[] buckets;
    private int currentSize;
    private enum State { DELETED }

    public HashSetLinearProbing(int bucketsLength) {
        buckets = new Object[bucketsLength];
        currentSize = 0;
    }

    public bool Contains(Object x) {
        int probe;

        int code = HashValue(x);

        if (buckets[code] == null)
        {
            // fordi vi bruger State.deleted
            return false;
        }

        else if (buckets[code].Equals(x))
        {
            return true;
        }

        else
        {
            if (code == (buckets.Length - 1))
            {
                probe = 0;
            }
            else
            {
                probe = code + 1;
            }
        }

        while (probe != code)
        {

            if (buckets[probe] == null)
            {
                // fordi vi bruger State.deleted
                return false;
            }
            else if (buckets[probe].Equals(x))
            {
                return true;
            }

            else
            {
                if (probe == (buckets.Length - 1))
                {
                    probe = 0;
                }
                else
                {
                    probe++;
                }
            }
        }

        return false;
    }

    public bool Add(Object x) {
       
        if (Contains(x))
        {
            return false;
        }

        int probe;

        int code = HashValue(x);

        if ((buckets[code] == null) || buckets[code].Equals(State.DELETED))
        {
            buckets[code] = x;
            currentSize++;
            return true;
        }

        else
        {
            if (code == (buckets.Length - 1))
            {
                probe = 0;
            }
            else
            {
                probe = code + 1;
            }
        }

        while (probe != code)
        {

            if ((buckets[probe] == null) || buckets[probe].Equals(State.DELETED))
            {
                buckets[probe] = x;
                currentSize++;

                return true;

            }
            // burde ikke kunne ske hvis tjek med Contains
            else if (buckets[probe].Equals(x))
            {
                // pga. Set
                return false;
            }

            else
            {
                if (probe == (buckets.Length - 1))
                {
                    probe = 0;
                }
                else
                {
                    probe++;
                }
            }
        }

        return false;
    }

    public bool Remove(Object x) {
        
        int probe;

        int code = HashValue(x);

        // Tjek med Contains?

        if (buckets[code] == null)
        {
            return false;
        }

        else if (buckets[code].Equals(x))
        {
            buckets[code] = State.DELETED;
            currentSize--;
            return true;
        }

        else
        {
            if (code == (buckets.Length - 1))
            {
                probe = 0;
            }
            else
            {
                probe = code + 1;
            }
        }

        while (probe != code)
        {

            if (buckets[probe] == null)
            {
                return false;
            }
            else if (buckets[probe].Equals(x))
            {
                buckets[probe] = State.DELETED;
                currentSize--;
                return true;
            }

            else
            {
                if (probe == (buckets.Length - 1))
                {
                    probe = 0;
                }
                else
                {
                    probe++;
                }
            }
        }

        return false;
    }

    public int Size() {
        return currentSize;
    }

    private int HashValue(Object x) {
        int h = x.GetHashCode();
        if (h < 0) {
            h = -h;
        }
        h = h % buckets.Length;
        return h;
    }

    public override String ToString() {
        String result = "";
        for (int i = 0; i < buckets.Length; i++) {
            int value = buckets[i] != null && !buckets[i].Equals(State.DELETED) ? 
                    HashValue(buckets[i]) : -1;
            result += i + "\t" + buckets[i] + "(h:" + value + ")\n";
        }
        return result;
    }

}
