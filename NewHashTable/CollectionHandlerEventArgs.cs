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
        public object Item { get; set; }

        public CollectionHandlerEventArgs(string collectionName, string changeType, object item)
        {
            CollectionName = collectionName;
            ChangeType=changeType;
            Item=item;
        }
    }
}
