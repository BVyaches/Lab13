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
            Challenge item = new("Математика", 25, "Ирина");
            bool eventRaised = false;
            hashTable.CollectionCountChanged += (sender, args) =>
            {
                if (args.ChangeType == "Добавление" && args.Source == item)
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
            Challenge item = new("Математика", 25, "Павел");
            Challenge changedItem = new();
            hashTable.Add(item);
            bool eventRaised = false;
            hashTable.CollectionReferenceChanged += (sender, args) =>
            {
                if (args.ChangeType == "Изменение" && args.Source == changedItem)
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
            Challenge item = new("Математика", 25, "Ирина");
            hashTable.Add(item);
            bool eventRaised = false;
            hashTable.CollectionCountChanged += (sender, args) =>
            {
                if (args.ChangeType == "Удаление" && args.Source == item)
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