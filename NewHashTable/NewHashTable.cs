using ChallengeLibrary;
using MyHashTable;
using System.Drawing;

namespace NewHashTable
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    public class NewHashTable<T>: MyHashTable<T> where T: class, IComparable<T>, IComparer<T>, IInit, ICloneable, new()
    {
        
        public string Name { get; set; }
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public void OnCountChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionCountChanged?.Invoke(source, args);
        }

        public void OnReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionReferenceChanged?.Invoke(source, args);
        }

        /// <summary>
        /// Конструктор по заданному размеру
        /// </summary>
        /// <param name="size">Требуемый размер</param>
        /// <param name="name">Имя коллекции</param>
        public NewHashTable(string name, int size = 0) : base(size)
        {
            Name = name;
        }
        
        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="data">Элемент для добавления</param>
        /// <param name="isForChanged">Вызов для изменения элемента или нет</param>
        public override void Add(T data, bool isForChanged)
        {
            base.Add(data, isForChanged);
            // Используется отдельный параметр, идёт ли добавление абсолютно нового элемента
            // или же изменение старого. В соответствии с действие бросаем нужное событие 
            if (isForChanged)
            {
                OnReferenceChanged(this, new CollectionHandlerEventArgs(Name, "Изменение", data));
                return;
            }
            OnCountChanged(this, new CollectionHandlerEventArgs(Name, "Добавление", data));
        }


        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="data">Ключ элемента для удаления</param>
        /// <returns></returns>
        public override bool Remove(T data)
        {
            bool result  = base.Remove(data);
            if (result)
            {
                OnCountChanged(this, new CollectionHandlerEventArgs(Name, "Удаление", data));
            }
            return result;
        }
    }
}