using System.Xml.Linq;
using System;

namespace LinkedList
{
    class Node
    {
        public Node(User data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public Node(User user)
        {
            Data = user;
            Next = null;
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

        public void AddSorted(User user)
        {
            Node newNode = new Node(user, first);
            // first see if the list is empty
            if (first == null)
            {

                first = newNode;
                return;
            }
            // there is something in the list
            // now check to see if it belongs in front
            else if (string.Compare(user.Name,first.Data.Name) < 0)
            {
                newNode.Next = first;
                first = newNode;
                return;
            }
            // otherwise, step down the list. After will stop 
            // at the node after the new node, and before will
            // stop at the node before the new node
            else
            {
                Node after = first.Next;
                Node before = first;
                Boolean found = false;
               
                while (after != null && found == false)
                {
                    //if (string.Compare(user.Name, after.Data.Name) < 0)
                    //break;
                    //before = after;
                    //after = after.Next;
                    
                    if (string.Compare(user.Name, after.Data.Name) > 0)
                    {
                        before = after;
                        after = after.Next;
                    }
                    else
                    {
                        found = true;
                    }
                }

                // insert between before & after
                // after may be null here - no problem, not used
                newNode.Next = before.Next;
                before.Next = newNode;
                return;
            }
        }

        public void InsertSorted(User user)
        {
            Node newNode = new Node(user);

            // If the list is empty or the new node is smaller than the first, insert at the beginning
            if (first == null || String.Compare(user.Name, first.Data.Name) < 0)
            {
                newNode.Next = first;
                first = newNode;
                return;
            }

            // Traverse the list to find the correct position for the new node
            Node current = first;
            while (current.Next != null && String.Compare(current.Next.Data.Name, user.Name) < 0)
            {
                current = current.Next;
            }

            // Insert the new node in the sorted position
            newNode.Next = current.Next;
            current.Next = newNode;
        }


        public User RemoveFirst()
        {
            if(first == null)
            {
                return null!;
            }
            
            User res = first.Data;
            first = first.Next;
            
            return res;
        }

        public bool RemoveUser(User user)
        {
            Node node = first;
            Node previous = null!;

            while (node != null)
            {
                if (node.Data.Name == user.Name)
                {
                    if (node == first)
                    {
                        RemoveFirst();
                        return true;       
                    }
                    else
                    {
                        previous.Next = node.Next;
                        return true;
                    }
                }
                else
                {
                    previous = node;
                    node = node.Next;
                }
            }
            return false;
        }

        public User GetFirst()
        {
            if(first == null)
            {
                return null!;
            }

            return first.Data;
        }
        public User GetLast()
        {

            if(first == null)
            {
                return null!;
            }

            Node currentNode = first;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Data;

            }

        public int CountUsers()
        {
            Node currentNode = first;
            int counter = 0;

            while (currentNode != null)
            {
                currentNode = currentNode.Next;
                counter++;
            };
            return counter;
        }

        public bool Contains(User user)
        {
            Node nextNode = first;

            if(first == null)
            {
                return false;
            }

            while (nextNode != null)
            {
                if (nextNode.Data.Name == user.Name)
                {
                    return true;
                }
                nextNode = nextNode.Next;
            }
            return false;
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
    }
}