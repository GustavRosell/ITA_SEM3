using Hashing;
using System;

public interface Map<K, V>
{
    public V Get(K key);
    public V Put(K key, V value);
    public V Remove(K key);
    public bool IsEmpty();
    public int Size();
}

// Bemærk simpel LinkedList implementation - O(n)!
public class HashMap<K, V> : Map<K, V>
{
    private Node start;
    private int size;

    private class Node
    {
        public Node()
        {
        }

        public Node next { get; set; }
        public K key { get; set; }
        public V value { get; set; }
      
    }

    public HashMap()
    {
        // Sentinel (tomt listehoved, der ikke indeholder data)
        start = new Node();
        size = 0;
    }

    public V Get(K key)
    {
        // Console.WriteLine("Getting " + key);
        Node node = start.next;
        V? result = default(V);

        while (node != null)
        {
            if (node.key != null && node.key.Equals(key))
            {
                result = node.value;
                return result;
            }
            else
            {
                node = node.next;
            }
        }
        return result!;
    }

    public Boolean IsEmpty()
    {
        return size == 0;
    }

    public V Put(K key, V value)
    {
        // Console.WriteLine("Putting (" + key + ", " + value + ")");
        Node current = start;
        Node previous = null!;
        while (current != null)
        {
            if (current.key != null && current.key.Equals(key))
            {
                V old = current.value;
                current.value = value;
                return old;
            }
            else
            {
                previous = current;
                current = current.next;
            }
        }

        Node node = new Node();
        node.value = value;
        node.key = key;
        node.next = current!;
        previous.next = node;
        size++;
        return default(V)!;
    }

    public V Remove(K key)
    {
        Node current = start;
        Node previous = null!;
        Boolean found = false;
        while (current.next != null && !found)
        {
            if (key!.Equals(current.key))
            {
                found = true;
            }
            else
            {
                previous = current;
                current = current.next;
            }
        }

        if (found)
        {
            if (previous == null)
            {
                start = current.next!;
            }
            else
            {
                previous.next = current.next!;
            }
        }
        size--;
        return current.value;
    }


    public override String ToString()
    {
        //Console.WriteLine("Calling toString");
        String s = "Dictionary:\n";
        Node n = start.next;

        // for each node in the linked list
        while (n != null)
        {
            s = s + "k: " + n.key + " ";
            s = s + "v: " + n.value + "\n";
            //Console.WriteLine("Appending " + n.key + " " + n.value);
            n = n.next;
        }

        // return s
        // System.out.println("Now s: " + s.toString());
        return s;
    }

    public int Size()
    {
        return size;
    }

}

