using Hashing;
using System;

public class HashSetChaining : HashSet
{
    private Node[] buckets;
    private int currentSize;

    private class Node
    {
        public Node(Object data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public Object Data { get; set; }
        public Node Next { get; set; }
    }

    public HashSetChaining(int size)
    {
        buckets = new Node[size];
        currentSize = 0;
    }

    public bool Contains(Object x)
    {
        int h = HashValue(x);
        Node bucket = buckets[h];
        bool found = false;
        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x))
            {
                found = true;
            }
            else
            {
                bucket = bucket.Next;
            }
        }
        return found;
    }

    public bool Add(Object x)
    {

        if (buckets.Length > 0)
        {
            if ((double)currentSize / buckets.Length >= 0.75) //loadfactor
            {
                ReHash();
            }
        }

        int h = HashValue(x);

        Node bucket = buckets[h];
        bool found = false;
        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x))
            {
                found = true;
            }
            else
            {
                bucket = bucket.Next;
            }
        }

        if (!found)
        {
            // Addfirst på index
            Node newNode = new Node(x, buckets[h]);
            buckets[h] = newNode;
            currentSize++;
        }

        return !found;
    }

    private void ReHash()
    {

        Node[] oldbuckets = buckets;
        currentSize = 0;
        buckets = new Node[2 * buckets.Length];

        for (int i = 0; i < oldbuckets.Length; i++)
        {
            Node temp = oldbuckets[i];
            while (temp != null)
            {
                Add(temp.Data);
                temp = temp.Next;
            }
        }
    }

    public bool Remove(Object x)
    {
        if (!Contains(x))
        {
            return false;
        }

        int h = HashValue(x);
        Boolean found = false;
        Node before = null!;

        Node bucket = buckets[h];

        if (bucket == null)
        {
            return false;
        }

        if (bucket.Data.Equals(x))
        {
            found = true;
            buckets[h] = bucket.Next;
            currentSize--;
            return found;
        } // else {
          // before = bucket;
          // } ikke nødvendig, se nedenfor

        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x))
            {
                found = true;
                before.Next = bucket.Next;
                currentSize--;
            }
            else
            {
                // Vil altid køre først grundet if ovenover
                before = bucket;
                bucket = bucket.Next;
            }
        }
        return found;
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

    public int Size()
    {
        return currentSize;
    }

    public override String ToString()
    {
        String result = "";
        for (int i = 0; i < buckets.Length; i++)
        {
            Node temp = buckets[i];
            if (temp != null)
            {
                result += i + "\t";
                while (temp != null)
                {
                    result += temp.Data + " (h:" + HashValue(temp.Data) + ")\t";
                    temp = temp.Next;
                }
                result += "\n";
            }
        }
        return result;
    }
}
