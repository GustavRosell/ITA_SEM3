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

    class SortedUserLinkedList
    {
        private Node first = null!;

        public void Add(User newUser)
        {
            Node newNode = new Node(newUser, null); // Opretter en ny node med det nye User-objekt.

            // Hvis listen er tom, eller det nye elements id er mindre end det første elements id. 
            if (first == null || first.Data.Id > newUser.Id)
            {
                newNode.Next = first; // Det nye elements 'Next' bliver det tidligere første element. (null! hvis ingen elemter)
                first = newNode; // Det nye element bliver nu det første element i listen.
            }
            else
            {
                // Sætter current til første node
                Node current = first;

                // Kører indtil slutningen af listen, eller indtil at vores input (newUser.Id) er mindre end 
                // referancepunktet for current.Next (current.Next.Data.Id) 
                while (current.Next != null && current.Next.Data.Id < newUser.Id)
                {
                    current = current.Next;
                }

                // Indsætter det nye element i listen.
                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }


        public User RemoveFirst()
        {
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
            // Kan også bruge Node CurrentNode = first;
            // while(currentNode.Next != null) {current = current.Next}
            // return current.Data
            {
                if (node.Next == null)
                {
                    return node.Data;
                }
            }

            return null!;
        }

        public int CountUsers()
        {
            int count = 0; // Variabel til at holde antal

            for (Node node = first; node != null; node = node.Next)
            {
                count += 1;
            }

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
                // Console.WriteLine(node.Data.Name); // --logger "console;verbosity=detailed" 
                if (node.Data.Name == user.Name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}