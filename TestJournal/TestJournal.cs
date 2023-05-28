using NewHashTable;
using System.Diagnostics.CodeAnalysis;

namespace TestJournal
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class JournalTests
    {
        [TestMethod]
        public void JournalCollectionCountChangedAddsJournalEntryToListTest()
        {
            Journal journal = new Journal();
            CollectionHandlerEventArgs eventArgs = new CollectionHandlerEventArgs("CollectionName", "ChangeType", "SourceString");

            journal.CollectionCountChanged(null, eventArgs);

            Assert.AreEqual(1, journal.JournalData.Count);
            Assert.AreEqual("ChangeType в коллекции CollectionName: SourceString\n", journal.JournalData[0].ToString());
        }

        [TestMethod]
        public void JournalCollectionReferenceChangedAddsJournalEntryToListTest()
        {
            Journal journal = new Journal();
            CollectionHandlerEventArgs eventArgs = new CollectionHandlerEventArgs("CollectionName", "ChangeType", "SourceString");

            journal.CollectionReferenceChanged(null, eventArgs);

            Assert.AreEqual(1, journal.JournalData.Count);
            Assert.AreEqual("ChangeType в коллекции CollectionName: SourceString\n", journal.JournalData[0].ToString());
        }

        [TestMethod]
        public void JournalToStringReturnsFormattedStringTest()
        {
            Journal journal = new Journal();
            CollectionHandlerEventArgs eventArgs1 = new CollectionHandlerEventArgs("CollectionName1", "ChangeType1", "SourceString1");
            CollectionHandlerEventArgs eventArgs2 = new CollectionHandlerEventArgs("CollectionName2", "ChangeType2", "SourceString2");

            journal.CollectionCountChanged(null, eventArgs1);
            journal.CollectionReferenceChanged(null, eventArgs2);

            string expected = "ChangeType1 в коллекции CollectionName1: SourceString1\n" +
                              "ChangeType2 в коллекции CollectionName2: SourceString2\n";
            Assert.AreEqual(expected, journal.ToString());
        }
    }
}