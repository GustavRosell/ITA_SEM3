using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedList.Tests
{
    [TestClass]
    public class LinkedList_Tests
    {
        [TestMethod]
        public void TestAddSorted()
        {
            // Opretter brugere
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            // Opretter en ny SortedUserLinkedList
            SortedUserLinkedList list = new SortedUserLinkedList();

            // Tilføjer brugere i ikke-sorteret rækkefølge
            list.Add(mads); // Mads (2)
            list.Add(torill); // Torill (3), bør være sidst
            list.Add(kristian); // Kristian (1), bør være først

            // Kontrollerer, at den første bruger i listen er Kristian
            Assert.AreEqual(kristian, list.GetFirst());

            // Kontrollerer, at den sidste bruger i listen er Torill
            Assert.AreEqual(torill, list.GetLast());

            // Kontrollerer, at antallet af brugere i listen er 3
            Assert.AreEqual(3, list.CountUsers());
        }


        [TestMethod]
        public void TestRemoveFirst()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            SortedUserLinkedList list = new SortedUserLinkedList();
            list.Add(kristian);
            list.Add(mads);
            list.Add(torill);
            Assert.AreEqual(kristian, list.RemoveFirst());
        }

        [TestMethod]
        public void TestCountUsers()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);

            SortedUserLinkedList list = new SortedUserLinkedList();
            list.Add(kristian);
            list.Add(mads);
            list.Add(torill);
            Assert.AreEqual(3, list.CountUsers());
        }

        [TestMethod]
        public void TestRemoveUser()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);
            User henrik = new User("Henrik", 5);
            User klaus = new User("Klaus", 6);

            SortedUserLinkedList list = new SortedUserLinkedList();

            list.Add(kristian);
            list.Add(mads);
            list.Add(torill);
            list.Add(henrik);
            list.Add(klaus);

            list.RemoveUser(mads);
            Assert.AreEqual(4, list.CountUsers());
            list.RemoveUser(kristian);
            Assert.AreEqual(3, list.CountUsers());
        }

        [TestMethod]
        public void TestGetLast()
        {
            User kristian = new User("Kristian", 1);
            User mads = new User("Mads", 2);
            User torill = new User("Torill", 3);
            User henrik = new User("Henrik", 5);
            User klaus = new User("Klaus", 6);

            SortedUserLinkedList list = new SortedUserLinkedList();

            list.Add(kristian);
            list.Add(mads);
            list.Add(torill);
            list.Add(henrik);
            list.Add(klaus);

            Assert.AreEqual(klaus.Name, list.GetLast().Name);
        }

    }
}