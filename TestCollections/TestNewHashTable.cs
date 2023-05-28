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
            Challenge item = new("����������", 25, "�����");
            bool eventRaised = false;
            hashTable.CollectionCountChanged += (sender, args) =>
            {
                if (args.ChangeType == "����������" && args.Item == item)
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
            Challenge item = new("����������", 25, "�����");
            Challenge changedItem = new();
            hashTable.Add(item);
            bool eventRaised = false;
            hashTable.CollectionReferenceChanged += (sender, args) =>
            {
                if (args.ChangeType == "���������" && args.Item == changedItem)
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
            Challenge item = new("����������", 25, "�����");
            hashTable.Add(item);
            bool eventRaised = false;
            hashTable.CollectionCountChanged += (sender, args) =>
            {
                if (args.ChangeType == "��������" && args.Item == item)
                {
                    eventRaised = true;
                }
            };

            hashTable.Remove(item);

            Assert.IsTrue(eventRaised);
        }
    }
}