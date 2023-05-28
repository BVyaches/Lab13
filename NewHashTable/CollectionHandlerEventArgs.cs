using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHashTable
{
    public class CollectionHandlerEventArgs: System.EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public object Source { get; set; }

        public CollectionHandlerEventArgs(string collectionName, string changeType, object source)
        {
            CollectionName = collectionName;
            ChangeType=changeType;
            Source=source;
        }
    }
}
