using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    public class Element<T>
    {
        public T data { get; set; }
        public Element<T> Nxt { get; set; }
        public Element<T> Prv { get; set; }

        public Element(T data)
        {
            this.data = data;
        }
    }

    public class MyLinkedList<T>
    {
        private Element<T> First;
        private Element<T> Last;
        int size;

        public MyLinkedList()
        {
            First = null;
            Last = null;
            size = -1;
        }

        public MyLinkedList(T[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Add(a[i]);
            }
        }

        public MyLinkedList(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                Add(default(T));
            }
        }


        public void Add(T e)
        {
            //if (size == 0)
            //{
            //    First = new Element<T>(e);
            //    First.Nxt = null;
            //    First.Prv = null;
            //    Last = First;

            //    size = 1;
            //}
            //else
            //{
                Element<T> Nw = new Element<T>(e);
                Nw.Nxt = null;
                Nw.Prv = Last;
                if (size != -1)
                {
                Last.Nxt = Nw;
                }
                Last = Nw;

                size++;
                
                if (size == 0)
                {
                First = Last;
                }
            //}
        }

        public void AddAll(T[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Add(a[i]);
            }
        }

        public void Clear()
        {
            First = null;
            Last = null;
            size = -1;
        }

        public bool Contains(object o)
        {
            if (IsEmpty()) throw new Exception("List is empty");

            bool flag = false;

            Element<T> Search = First;

            while (Search != null)
            {
                if (o.Equals(Search.data)) flag = true;

                Search = Search.Nxt;
            }

            return flag;
        }

        public bool ContainsAll(T[] a)
        {
            bool flag = true;

            for (int i = 0; i < a.Length; i++)
            {
                if (!Contains(a[i])) flag = false;
            }

            return flag;
        }

        public bool IsEmpty()
        {
            if (size == -1) return true;
            return false;
        }

        public void Remove(object o)
        {
            Element<T> Search = First;

            if (size == -1)
            {

            }
            else
            {
                if (size == 0 && o.Equals(First.data))
                {
                    size = -1;
                    First = null;
                    Last = null;

                    //Console.WriteLine("del");
                }
                else
                {
                    while (Search != null)
                    {
                        if (o.Equals(Search.data))
                        {
                            if (Search == First)
                            {
                                First.Nxt.Prv = null;
                                First = First.Nxt;

                                size--;

                                Search = Search.Nxt;
                                continue;
                            }
                            if (Search == Last)
                            {
                                Last.Prv.Nxt = null;
                                Last = Last.Prv;

                                size--;

                                return;
                            }

                            Search.Prv.Nxt = Search.Nxt;
                            Search.Nxt.Prv = Search.Prv;

                            size--;


                        }

                        Search = Search.Nxt;
                    }
                }
            }

        }

        public void RemoveAll(T[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Remove(a[i]);
            }
        }

        public void RetainAll(T[] a)
        {
            Element<T> Search = First;
            bool flag;

            while (Search != null)
            {
                flag = true;

                for (int j = 0; j < a.Length; j++)
                {
                    if (a[j].Equals(Search.data)) flag = false; 
                }

                if (flag) Remove(Search.data);

                Search = Search.Nxt;
            }
        }

        public int Size()
        {
            return size + 1;
        }

        public T[] ToArray()
        {
            T[] output = new T[size];

            Element<T> Chooser = First;

            for (int i = 0; Chooser != null; i++, Chooser = Chooser.Nxt)
            {
                output[i] = Chooser.data;
            }

            return output;
        }

        public T[] ToArray(T[] a)
        {
            if (a.Equals(null)) return ToArray();

            Element<T> Chooser = First;

            for (int i = 0; Chooser != null && i < a.Length; i++, Chooser = Chooser.Nxt)
            {
                a[i] = Chooser.data;
            }

            return a;
        }

        public void Add(int index, T e)
        {
            if (index > size || index < 0) throw new Exception("Index out of range");

            Element<T> Search = First;

            for (int i = 0; i < index; i++)
            {
                Search = Search.Nxt;
            }

            if (Search == Last)
            {
                Add(e);
            }
            else
            {
                Element<T> nw = new Element<T>(e);

                nw.Prv = Search;
                nw.Nxt = Search.Nxt;
                Search.Nxt.Prv = nw;
                Search.Nxt = nw;
            }
        }

        public void AddAll(int index, T[] a)
        {
            if (index > size || index < 0) throw new Exception("Index out of range");

            for (int i = 0; i < a.Length; i++)
            {
                Add(index + i, a[i]);
            }
        }

        public T Get(int index)
        {
            if (index > size || index < 0) throw new Exception("Index out of range");

            T res = default(T);

            Element<T> Search = First;

            for (int i = 0; i < index; i++)
            {
                Search = Search.Nxt;
            }

            res = Search.data;

            return res;
        }

        public int IndexOf(object o)
        {
            Element<T> Search = First;

            for (int i = 0; Search != null; i++, Search = Search.Nxt)
            {
                if (o.Equals(Search.data)) return i;
                Search = Search.Nxt;
            }

            return -1;
        }

        public int LastIndexOf(object o)
        {
            Element<T> Search = Last;

            for (int i = size - 1; Search != null; i--, Search = Search.Prv)
            {
                if (o.Equals(Search.data)) return i;
                Search = Search.Prv;
            }

            return -1;
        }

        public T Remove(int index)
        {
            if (index > size || index < 0) throw new Exception("Index out of range");

            Element<T> Search = First;

            for (int i = 0; i < index; i++)
            {
                Search = Search.Nxt;
            }

            T res = Search.data;
            if (size != 0)
            {
                //if (Search == Last && Search == First)
                //{
                //    if (Search == Last)
                //    {
                //        Last.Prv.Nxt = null;
                //        Last = Last.Prv;
                //    }
                //    else
                //    {
                //        Search.Nxt.Prv = null;
                //        First = First.Nxt;
                //    }
                //}
                //else
                //{
                //    Search.Prv.Nxt = Search.Nxt;
                //    Search.Nxt.Prv = Search.Prv;
                //}

                if (Search == First)
                {
                    First.Nxt.Prv = null;
                    First = First.Nxt;

                    size--;

                    return res;
                }

                if (Search == Last)
                {
                    Last.Prv.Nxt = null;
                    Last = Last.Prv;

                    size--;

                    return res;
                }

                Search.Prv.Nxt = Search.Nxt;
                Search.Nxt.Prv = Search.Prv;

                size--;

                return res;
            }
            else
            {
                Console.WriteLine("del");

                First = null;
                Last = null;
                size = 0;
            }

            size--;

            return res;
        }

        public void Set(int index, T e)
        {
            Element<T> Search = First;

            for (int i = 0; Search != null && i < index; i++, Search = Search.Nxt)
            {
                Search = Search.Nxt;
            }

            Search.data = e;
        }

        public T[]SubList(int fromIndex, int toIndex)
        {
            if ((fromIndex < 0 || fromIndex >= size) || (toIndex < 0 || toIndex >= size)) throw new Exception("Index out of range");

            T[] output = new T[toIndex - fromIndex + 1];

            Element<T> Search = First;

            for (int i = 0; i < fromIndex; i++)
            {
                Search = Search.Nxt;
            }

            for (int i = fromIndex; i <= toIndex; i++)
            {
                output[i - fromIndex] = Search.data;
                Search = Search.Nxt;
            }

            return output;
        }

        public T Element()
        {
            if (IsEmpty()) throw new Exception("List is empty");

            return First.data;
        }

        public bool Offer(T obj)
        {
            try
            {
                Add(obj);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public T Poll()
        {
            if (IsEmpty()) return default(T);

            T output = First.data;

            Remove((int)0);

            return output;
        }

        public void AddFirst(T obj)
        {
            Add(Last.data);

            Element<T> Search = Last;

            while (Search.Prv != null)
            {
                Search.data = Search.Prv.data;
                Search = Search.Prv;
            }

            Set(0, obj);
        }

        public void AddLast(T obj)
        {
            Add(obj);
        }

        public T GetFirst()
        {
            if (IsEmpty()) throw new Exception("List is empty");
            return First.data;
        }

        public T GetLast()
        {
            if (IsEmpty()) throw new Exception("List is empty");
            return Last.data;
        }

        public bool OfferFirst(T obj)
        {
            try
            {
                AddFirst(obj);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public T PollLast()
        {
            T output = Last.data;

            Remove((int)size);

            return output;
        }

        public bool RemoveLastOccurance(object obj)
        {
            bool flag = true;

            Element<T> Search = Last;
            int ind = size;

            while (Search != null && flag)
            {
                if (obj.Equals(Search.data))
                {
                    Remove((int)ind);
                    flag = false;
                }

                ind--;
                Search = Search.Prv;
            }

            return !flag;
        }

        public bool RemoveFirstOccurance(object obj)
        {
            bool flag = true;

            Element<T> Search = First;
            int ind = 0;

            while (Search != null && flag)
            {
                if (obj.Equals(Search.data))
                {
                    Remove((int)ind);
                    flag = false;
                }

                ind++;
                Search = Search.Nxt;
            }

            return !flag;
        }



















    }
}
