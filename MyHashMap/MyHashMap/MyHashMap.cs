using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHashMap
{
    public struct Entry<K, V>
    {
        public K key { get; set; }
        public V value { get; set; }
    }

    public class MyHashMap<K, V>
    {
        private MyLinkedList.MyLinkedList<Entry<K, V>>[] table;
        private int size;
        private double loadFactor;
        private int elSize = 0;


        public MyHashMap()
        {
            table = new MyLinkedList.MyLinkedList<Entry<K, V>>[16];
            size = 16;
            loadFactor = 0.75;
        }

        public MyHashMap(int initialCapacity)
        {
            table = new MyLinkedList.MyLinkedList<Entry<K, V>>[initialCapacity];
            size = initialCapacity;
            loadFactor = 0.75;
        }

        public MyHashMap(int initialCapacity, double loadFactor)
        {
            table = new MyLinkedList.MyLinkedList<Entry<K, V>>[initialCapacity];
            size = initialCapacity;
            this.loadFactor = loadFactor;
        }


        public void Clear()
        {
            for (int i = 0; i < size; i++)
            {
                table[i] = null;
            }

            size = 0;
        }

        public bool ContainsKey(object key)
        {
            if (IsEmpty()) throw new Exception("Map is empty");

            bool flag = false;

            for (int i = 0; i < size; i++)
            {
                if (!(table[i] is null))
                {
                    for (int j = 0; j < table[i].Size(); j++)
                    {
                        if (key.Equals(table[i].Get(j).key)) flag = true;
                    }
                }
            }

            return flag;
        }

        public bool ContainsValue(object value)
        {
            if (IsEmpty()) throw new Exception("Map is empty");

            bool flag = false;

            for (int i = 0; i < size; i++)
            {
                if (!(table[i] is null))
                {
                    for (int j = 0; j < table[i].Size(); j++)
                    {
                        if (value.Equals(table[i].Get(j).value)) flag = true;
                    }
                }
            }

            return flag;
        }

        public MyVector.MyVector<Entry<K, V>> EntrySet()            //???
        {
            MyVector.MyVector<Entry<K, V>> output = new MyVector.MyVector<Entry<K, V>>();

            for (int i = 0; i < size; i++)
            {
                if (!(table[i] is null))
                {
                    for (int j = 0; j < table[i].Size(); j++)
                    {
                        output.Add(table[i].Get(j));
                    }
                }
            }

            return output;
        }

        public V Get(object key)
        {
            if (IsEmpty()) throw new Exception("Map is empty");

            for (int i = 0; i < size; i++)
            {
                if (!(table[i] is null))
                {
                    for (int j = 0; j < table[i].Size(); j++)
                    {
                        if (key.Equals(table[i].Get(j).key)) return table[i].Get(j).value;
                    }
                }
            }

            return default(V);
        }

        public bool IsEmpty()
        {
            if (size == 0) return true;
            else return false;
        }

        public MyVector.MyVector<K> KeySet()
        {
            if (IsEmpty()) throw new Exception("Map is empty");

            MyVector.MyVector<K> output = new MyVector.MyVector<K>();

            for (int i = 0; i < size; i++)
            {
                if (!(table[i] is null))
                {
                    for (int j = 0; j < table[i].Size(); j++)
                    {
                        output.Add(table[i].Get(j).key);
                    }
                }
            }

            return output;
        }

        public void Put(K key, V value)
        {
            if (elSize > (size / 100 * loadFactor))
            {
                MyVector.MyVector<Entry<K, V>> res = EntrySet();

                table = new MyLinkedList.MyLinkedList<Entry<K, V>>[size * 2];
                size *= 2;

                for (int i = 0; i < res.Size(); i++)
                {
                    Put(res.Get(i).key, res.Get(i).value);
                }
            }



            int code = Math.Abs(key.GetHashCode());

            int index = code % table.Count(); //бакет

            Entry<K, V> input = new Entry<K, V>();

            input.value = value;
            input.key = key;

            if (table[index] is null)
            {
                MyLinkedList.MyLinkedList<Entry<K, V>> elem = new MyLinkedList.MyLinkedList<Entry<K, V>>();

                elem.Add(input);

                table[index] = elem;

                elSize++;
            }
            
            else
            {
                for (int i = 0; i < table[index].Size(); i++)
                {
                    if (key.Equals(table[index].Get((int)i).key))
                    {
                        table[index].Set((int)i, input);

                        return;
                    }
                }

                table[index].Add(input);

                elSize++;
            }
        }

        public void Remove(object key)
        {
            if (IsEmpty()) throw new Exception("Map is empty");

            for (int i = 0; i < size; i++)
            {
                if (!(table[i] is null))
                {
                    for (int j = 0; j < table[i].Size(); j++)
                    {
                        if (key.Equals(table[i].Get(j).key))
                        {
                            table[i].Remove((int)j);
                            j--;
                            elSize--;
                        }
                    }
                }
            }
        }

        public int Size()
        {
            return elSize;
        }

    }
}
