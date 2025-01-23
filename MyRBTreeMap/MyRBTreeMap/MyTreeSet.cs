using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTreeSet
{
    public class MyTreeSet<E>
    {

        private RBTree.RBTree<E> m;


        public MyTreeSet()
        {
            m = new RBTree.RBTree<E>();
        }

        public MyTreeSet(RBTree.RBTree<E> m)
        {
            this.m = m;
        }

        public MyTreeSet(RBTree.TreeMapComparer<E> comp)
        {
            m = new RBTree.RBTree<E>(comp);
        }

        public MyTreeSet(E[] a)
        {
            m = new RBTree.RBTree<E>();

            for (int i = 0; i < a.Length; i++)
            {
                m.Put(a[i]);
            }
        }

        public MyTreeSet(SortedSet<E> s)
        {
            m = new RBTree.RBTree<E>();

            foreach (E v in s)
            {
                m.Put(v);
            }
        }


        public void Add(E e)
        {
            m.Put(e);
        }

        public void AddAll(E[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                m.Put(a[i]);
            }
        }

        public void Clear()
        {
            m.Clear();
        }

        public bool Contains(object o)
        {
            return m.ContainsKey((E)o);
        }

        public bool ContainsAll(E[] a)
        {
            bool flag = true;

            for (int i = 0; i < a.Length; i++)
            {
                if (!m.ContainsKey(a[i])) flag = false;
            }

            return flag;
        }

        public bool IsEmpty()
        {
            return m.IsEmpty();
        }

        public void Remove(object o)
        {
            m.Remove((E)o);
        }

        public void RemoveAll(E[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                m.Remove(a[i]);
            }
        }

        public void RetainAll(E[] a)
        {
            E[] control = m.KeySet();

            for (int i = 0; i < control.Length; i++)
            {
                if (!a.Contains<E>(control[i])) m.Remove(control[i]);
            }


        }

        public int Size()
        {
            return m.Size();
        }

        public E[] ToArray()
        {
            return m.KeySet();
        }

        public E[] ToArray(E[] a)
        {
            if (a == null) return ToArray();

            a = ToArray();

            return a;
        }

        public E First()
        {
            return m.FirstKey();
        }

        public E Last()
        {
            return m.LastKey();
        }

        public E[] Subset(E from, E to)
        {
            MyVector.MyVector<MyTreeMap.TreeNode<E, object>> med = m.SubMap(from, to);

            E[] output = new E[med.Size()]; 

            for (int i = 0; i < med.Size(); i++)
            {
                output[i] = med.Get(i).key;
            }

            return output;
        }

        public E[] Headset(E to)
        {
            MyVector.MyVector<MyTreeMap.TreeNode<E, object>> med = m.HeadMap(to);

            E[] output = new E[med.Size()];

            for (int i = 0; i < med.Size(); i++)
            {
                output[i] = med.Get(i).key;
            }

            return output;
        }

        public E[] Tailset(E from)
        {
            MyVector.MyVector<MyTreeMap.TreeNode<E, object>> med = m.HeadMap(from);

            E[] output = new E[med.Size()];

            for (int i = 0; i < med.Size(); i++)
            {
                output[i] = med.Get(i).key;
            }

            return output;
        }

        public object Ceiling(E obj)
        {
            return m.CeilingKey(obj);
        }

        public object Floor(E obj)
        {
            return m.FloorKey(obj);
        }

        public object Higher(E obj)
        {
            return m.HigherKey(obj);
        }

        public object Lower(E obj)
        {
            return m.LowerKey(obj);
        }






















    }
}
