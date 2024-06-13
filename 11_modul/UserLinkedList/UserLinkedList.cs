namespace LinkedList
{
    class Node
    {
    
        public Node(User data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public User Data;
        public Node Next;
    }

    class UserLinkedList
    {
        private Node first = null!;

        public void AddFirst(User user)
        {
            Node node = new Node(user, first);
            first = node;
        }

        public User RemoveFirst()
        {
            // TODO: Implement!
            if (first == null) // Hvis listen er tom
            {
                return null;
            }

            else
            {
                Node node = first;  // Gemmer første node i en variabel
                first = first.Next; // Første node bliver nu den næste node i listen
                return node.Data;   // Returnere data fra den første node (Den slettede node) 
            }
            return null;
        }

        public void RemoveUser(User user)
        {
            Node node = first;
            Node previous = null!;
            bool found = false;

            while (!found && node != null)
            {
                if (node.Data.Name == user.Name)
                {
                    found = true;
                    if (node == first)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = node.Next;
                    }
                }
                else
                {
                    previous = node;
                    node = node.Next;
                }
            }
        }

        public User GetFirst()
        {
            return first.Data;
        }

        public User GetLast()
        {
            for (Node node = first; node != null; node = node.Next)
            // Startværdi: node = first;
            // Betingelse: node != null;
            // Iteration: node = node.Next
            {
                if (node.Next == null)
                {
                    return node.Data;
                }
            }
            // TODO: Implement
            return null!;
        }

        public int CountUsers()
        {
            int count = 0; // Variabel til at holde antal

            for (Node node = first; node != null; node = node.Next)
            {
                count += 1;
            }

            // TODO: Implement
            return count;
        }

        public override String ToString()
        {
            Node node = first;
            String result = "";
            while (node != null)
            {
                result += node.Data.Name + ", ";
                node = node.Next;
            }
            return result.Trim();
        }

        public bool Contains(User user)
        { 
            for (Node node = first; node != null; node = node.Next) 
            {
                Console.WriteLine(node.Data.Name); // --logger "console;verbosity=detailed" 
                if (node.Data.Name == user.Name) 
                {
                    return true;
                }
            }

            return false;
        }
    }
}