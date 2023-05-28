using NewHashTable;
using ChallengeLibrary;
using System.Diagnostics.CodeAnalysis;

namespace TestCollections
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class NewHashTableTests
    {
        [TestMethod]
        public void NewHashTableAddNewItemAddedCountChangedEventRaisedTest()
        {
            NewHashTable<Challenge> hashTable = new("TestHashTable");
            Challenge item = new("Математика", 25, "Ирина");
            bool eventRaised = false;
            hashTable.CollectionCountChanged += (sender, args) =>
            {
                if (args.ChangeType == "Добавление" && args.Item == item)
                {
                    eventRaised = true;
                }
            };

            hashTable.Add(item);

            Assert.IsTrue(eventRaised);
        }

        [TestMethod]
        public void NewHashTableAddExistingItemAddedReferenceChangedEventRaisedTest()
        {
            NewHashTable<Challenge> hashTable = new("TestHashTable");
            Challenge item = new("Математика", 25, "Павел");
            Challenge changedItem = new();
            hashTable.Add(item);
            bool eventRaised = false;
            hashTable.CollectionReferenceChanged += (sender, args) =>
            {
                if (args.ChangeType == "Изменение" && args.Item == changedItem)
                {
                    eventRaised = true;
                }
            };

            hashTable[item] = changedItem;

            Assert.IsTrue(eventRaised);
        }

        [TestMethod]
        public void NewHashTableRemoveItemRemovedCountChangedEventRaisedTest()
        {
            NewHashTable<Challenge> hashTable = new("TestHashTable");
            Challenge item = new("Математика", 25, "Ирина");
            hashTable.Add(item);
            bool eventRaised = false;
            hashTable.CollectionCountChanged += (sender, args) =>
            {
                if (args.ChangeType == "Удаление" && args.Item == item)
                {
                    eventRaised = true;
                }
            };

            hashTable.Remove(item);

            Assert.IsTrue(eventRaised);
        }
    }
}