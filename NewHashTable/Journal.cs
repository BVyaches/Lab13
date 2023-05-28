using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHashTable
{
    public class JournalEntry
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public string SourceString { get; set; }
        public JournalEntry(string collectionName, string changeType, string sourceString)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            SourceString = sourceString;
        }

        public override string ToString()
        {
            return $"{ChangeType} в коллекции {CollectionName}: {SourceString}\n";
        }
    }

    public class Journal
    {
        public List<JournalEntry> JournalData { get; set; }
        public Journal() 
        {
            JournalData = new List<JournalEntry>();
        }

        public void CollectionCountChanged(object source, CollectionHandlerEventArgs e)
        {
            JournalEntry je = new(e.CollectionName, e.ChangeType, e.Source.ToString());
            JournalData.Add(je);
        }

        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs e)
        {
            JournalEntry je = new(e.CollectionName, e.ChangeType, e.Source.ToString());
            JournalData.Add(je);
        }

        public override string ToString()
        {
            string result = "";
            foreach (JournalEntry je in JournalData)
            {
                result += je.ToString();
            }
            return result;
        }
    }
}
