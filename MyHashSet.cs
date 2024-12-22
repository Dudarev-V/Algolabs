using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHashSet
{
    public struct SetEl<K>
    {
        public K key { get; set; }

        public SetEl(K keyin)
        {
            key = keyin;
        }
    }

    public class MyHashSet<K> : MyCollection.IMySet<K>, MyCollection.IExceptions
    {
        private MyHashMap.MyHashMap<K, bool> map;
        //private double loadFactor;
        //private int size;



        public MyHashSet()
        {
            map = new MyHashMap.MyHashMap<K, bool>(16, 0.75);
            //loadFactor = 0.75;
            //size = 0;
        }

        public MyHashSet(MyCollection.IMyCollection<K> c)
        {
            K[] a = c.ToArray();

            map = new MyHashMap.MyHashMap<K, bool>(a.Length, 0.75);

            for (int i = 0; i < a.Length; i++)
            {
                map.Put(a[i], false);
            }
        }

        public MyHashSet(int initialCapacity, double loadFac)
        {
            map = new MyHashMap.MyHashMap<K, bool>(initialCapacity, loadFac);
        }

        public MyHashSet(int initialCapacity)
        {
            map = new MyHashMap.MyHashMap<K, bool>(initialCapacity, 0.75);
        }


        public void Add(K e)
        {
            map.Put(e, false);
        }

        public void AddAll(K[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Add(a[i]);
            }
        }

        public void Clear()
        {
            map = null;
        }

        public bool Contains(object o)
        {
            if (map.ContainsKey(o)) return true;
            return false;
        }

        public bool ContainsAll(MyCollection.IMyCollection<K> c)
        {
            K[] a = c.ToArray();

            for (int i = 0; i < a.Length; i++)
            {
                if (!Contains(a[i])) return false;
            }

            return true;
        }

        public bool IsEmpty()
        {
            if (map.IsEmpty()) return true;
            return false;
        }

        public void Remove(object o)
        {
            map.Remove(o);
        }

        public void RemoveAll(MyCollection.IMyCollection<K> c)
        {
            K[] a = c.ToArray();

            for (int i = 0; i < a.Length; i++)
            {
                Remove(a[i]);
            }
        }

        public void RetainAll(MyCollection.IMyCollection<K> c)
        {
            K[] a = c.ToArray();

            K[] output = map.KeySet(); 

            for (int i = 0; i < output.Length; i++)
            {
                if (!a.Contains<K>(output[i])) map.Remove(output[i]);
            }
        }

        public int Size()
        {
            return map.Size();
        }

        public K[] ToArray()
        {
            K[] output = map.KeySet();

            K[] outarr = new K[output.Length];

            for (int i = 0; i < output.Length; i++)
            {
                outarr[i] = output[i];
            }

            return outarr;
        }

        public K[] ToArray(K[] a)
        {
            if (a == null) return ToArray();

            if (a.Length > map.Size()) throw new Exception("Array longer than internal");

            K[] output = map.KeySet();

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = output[i];
            }

            return a;
        }

        public K First()
        {
            K[] med = map.KeySet();

            if (med.Length != 0)
                return med[0];
            else return default;
        }

        public K Last()
        {
            K[] med = map.KeySet();

            if (med.Length != 0)
                return med[med.Length - 1];
            else return default;
        }

        public K[] HeadSet(K toElem)
        {
            K[] med = map.KeySet();
            MyVector.MyVector<K> extr = new MyVector.MyVector<K>();

            for (int i = 0; i < med.Length; i++)
            {
                extr.Add(med[i]);

                if (toElem.Equals(med[i]))
                {
                    extr.Add(med[i]);
                    break;
                }
            }

            K[] output = new K[extr.Size()];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = extr.Get(i);
            }

            return output;
        }
        public K[] TailSet(K fromElem)
        {
            K[] med = map.KeySet();
            MyVector.MyVector<K> extr = new MyVector.MyVector<K>();

            bool flag = false;

            for (int i = 0; i < med.Length; i++)
            {
                if (fromElem.Equals(med[i])) flag = true;

                if (flag) extr.Add(med[i]);
            }


            K[] output = new K[extr.Size()];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = extr.Get(i);
            }

            return output;
        }

        public K[] SubSet(K fromElem, K toElem)
        {
            K[] med = map.KeySet();
            MyVector.MyVector<K> extr = new MyVector.MyVector<K>();

            bool flag = false;

            for (int i = 0; i < med.Length && !toElem.Equals(med[i]); i++)
            {
                if (fromElem.Equals(med[i])) flag = true;

                if (toElem.Equals(med[i]))
                {
                    extr.Add(med[i]);
                    break;
                }

                if (flag) extr.Add(med[i]);

            }


            K[] output = new K[extr.Size()];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = extr.Get(i);
            }

            return output;
        }

        public void Empty()
        {
            throw new Exception("Set is empty");
        }

        public void OutRange()
        {
            throw new Exception("Index out of range");
        }

        public void SizesNotEquial()
        {
            throw new Exception("Objects' sizes aren't equial");
        }


    }
}





















//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyHashSet
//{
//    public struct SetEl<K, V>
//    {
//        public K key { get; set; }
//        public V value { get; set; }

//        public SetEl(K keyin, V val)
//        {
//            key = keyin;
//            value = val;
//        }
//    }

//    public class MyHashSet<K, V>
//    {
//        private SetEl<K, V>[] map;
//        private double loadFactor;




//        public MyHashSet()
//        {
//            map = new SetEl<K, V>[16];
//            loadFactor = 0.75;
//        }

//        public MyHashSet(K[] a)
//        {
//            loadFactor = 0.75;

//            map = new SetEl<K, V>[a.Length];

//            for (int i = 0; i < a.Length; i++)
//            {
//                map[i].key = a[i];
//            }
//        }

//        public MyHashSet(int initialCapacity, double loadFac)
//        {
//            map = new SetEl<K, V>[initialCapacity];
//            loadFactor = loadFac;
//        }

//        public MyHashSet(int initialCapacity)
//        {
//            map = new SetEl<K, V>[initialCapacity];
//            loadFactor = 0.75;
//        }


//        public void Add();


//    }