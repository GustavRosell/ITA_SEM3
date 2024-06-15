using LinkedList;

User kristian = new User("Kristian", 1);
User mads = new User("Mads", 2);
User torill = new User("Torill", 3);
User kell = new User("Kell", 63);
User henrik = new User("Henrik", 52);
User klaus = new User("Klaus", 60);

UserLinkedList list = new UserLinkedList();
list.AddFirst(kristian);
list.AddFirst(mads);
list.AddFirst(torill);
list.AddFirst(henrik);
list.AddFirst(klaus);

Console.WriteLine(list.CountUsers());
Console.WriteLine(list);

list.RemoveUser(mads);
list.RemoveFirst();

Console.WriteLine(list.CountUsers());
Console.WriteLine(list);

Console.WriteLine("\nDoublelinkedlist test:\n");

DoublyLinkedList<User> myList = new DoublyLinkedList<User>();

myList.AddFirst(kristian);
myList.AddFirst(kell);
myList.AddFirst(klaus);

myList.AddLast(torill);
myList.AddLast(henrik);

myList.PrintList(); 

myList.RemoveFirst();
myList.PrintList(); 

myList.RemoveLast();
myList.PrintList(); 