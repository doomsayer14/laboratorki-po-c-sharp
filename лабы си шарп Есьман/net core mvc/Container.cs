using System;
using System.Collections;
using System.Collections.Generic;
using vyesman8.Models;

namespace WebApplication2
{
    [Serializable]
    public class Container<T> : IEnumerable<T>
    {
        private T[] _items;
        public Container()
        {
            _items = new T[0];
        }

        public int Count()
        {
            return _items.Length;
        }

        public void Add(T newObj)
        {
            T[] _newItems = new T[_items.Length + 1];
            if (_items.Length > 0)
            {
                Array.Copy(_items, _newItems, _items.Length);
            }
            _newItems[_newItems.Length - 1] = newObj;
            _items = _newItems;
        }

        public T this[int index]
        {
            get
            {
                return _items[index];
            }

            set
            {
                _items[index] = value;
            }
        }
        public Boolean remove(int index)
        {
            if (_items == null || index < 0 || index >= _items.Length)
            {
                return false;
            }
            T[] _newItems = new T[_items.Length - 1];
            for (int i = 0, k = 0; i < _items.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }
                _newItems[k++] = _items[i];
            }
            _items = _newItems;
            return true;
        }

        public Boolean remove(T item)
        {
            if (item == null && _items == null)
                return false;

            T[] _newItems = new T[_items.Length - 1];
            for (int i = 0, k = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(item))
                {
                    continue;
                }
                _newItems[k++] = _items[i];
            }
            _items = _newItems;
            return true;
        }

        public T get(int index)
        {
            return _items[index];
        }

        public Boolean removeAll(Container<T> collection)
        {
            if (collection == null && _items == null)
                return false;
            for (int i = 0; i < collection.Count(); i++)
            {
                for (int j = 0; j < _items.Length; j++)
                {
                    if (_items[j].Equals(collection.get(i)))
                    {
                        remove(collection.get(i));
                    }
                }
            }
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            T[] _newItems = new T[_items.Length];
            Array.Copy(_items, _newItems, _items.Length);
            for (int i = 0; i < _items.Length; i++)
            {
                yield return _newItems[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_items).GetEnumerator();
        }
    }

}


