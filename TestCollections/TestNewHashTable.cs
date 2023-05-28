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
        public void Add_WhenNewItemAdded_CountChangedEventRaised()
        {
            // Arrange
            NewHashTable<Challenge> hashTable = new("TestHashTable");
            Challenge item = new("����������", 25, "�����");
            bool eventRaised = false;
            hashTable.CollectionCountChanged += (sender, args) =>
            {
                if (args.ChangeType == "����������" && args.Source == item)
                {
                    eventRaised = true;
                }
            };

            // Act
            hashTable.Add(item);

            // Assert
            Assert.IsTrue(eventRaised);
        }

        [TestMethod]
        public void Add_WhenExistingItemAdded_ReferenceChangedEventRaised()
        {
            // Arrange
            NewHashTable<Challenge> hashTable = new("TestHashTable");
            Challenge item = new("����������", 25, "�����");
            Challenge changedItem = new();
            hashTable.Add(item);
            bool eventRaised = false;
            hashTable.CollectionReferenceChanged += (sender, args) =>
            {
                if (args.ChangeType == "���������" && args.Source == changedItem)
                {
                    eventRaised = true;
                }
            };

            // Act
            hashTable[item] = changedItem;

            // Assert
            Assert.IsTrue(eventRaised);
        }

        [TestMethod]
        public void Remove_WhenItemRemoved_CountChangedEventRaised()
        {
            // Arrange
            NewHashTable<Challenge> hashTable = new("TestHashTable");
            Challenge item = new("����������", 25, "�����");
            hashTable.Add(item);
            bool eventRaised = false;
            hashTable.CollectionCountChanged += (sender, args) =>
            {
                if (args.ChangeType == "��������" && args.Source == item)
                {
                    eventRaised = true;
                }
            };

            // Act
            hashTable.Remove(item);

            // Assert
            Assert.IsTrue(eventRaised);
        }
    }
}