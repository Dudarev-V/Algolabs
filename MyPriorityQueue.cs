using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyPriorityQueue
{
    public abstract class PriorityQueueComparer<T>:IComparer<T>
    {
        public abstract int Compare(T a, T b);
    }

    //public class MainComparer<T> : PriorityQueueComparer<T>
    //{
    //    public override int Compare(T a, T b)
    //    {

    //        return Compare(a, b);
    //    }
    //}

    public class MyPriorityQueue<T>
    {
        private T[] queue;

        private int size;

        PriorityQueueComparer<T> Comparator;


        public MyPriorityQueue()
        {
            queue = new T[11];
            size = 0;
  //          Comparator = new MainComparer<T>();
        }

        public MyPriorityQueue(T[] a)
        {
            size = a.Length;
            queue = new T[size];
  //          Comparator = new MainComparer<T>();
        }

        public MyPriorityQueue(int InitialCapacity)
        {
            size = 0;
            queue = new T[InitialCapacity];
    //        Comparator = new MainComparer<T>();
        }

        public MyPriorityQueue(int InitialCapacity, PriorityQueueComparer<T> Comparator) //наследник
        {
            size = 0;
            queue = new T[InitialCapacity];
            this.Comparator = Comparator;
        }

        public MyPriorityQueue(MyPriorityQueue<T> c)
        {
            queue = c.ToArray();
            size = c.Size();
        }






        public void Add(T e)
        {
            if (size == queue.Length)
            {
                if (size < 64)
                {
                    T[] res = new T[size + 2];

                    for (int i = 0; i < size; i++)
                    {
                        res[i] = queue[i];
                    }

                    res[size] = e;
                    size++;

                    queue = res;
                }
                else
                {
                    T[] res = new T[size + (size) / 2];

                    for (int i = 0; i < size; i++)
                    {
                        res[i] = queue[i];
                    }

                    res[size] = e;
                    size++;

                    queue = res;
                }
            }
            else
            {
                queue[size] = e;
                size++;
            }

            if (size > 1)
            {
                bool flag = true;
                int curr = size - 1;

                for(int i = size - 1; i > 0 && flag;)
                {
                    if (Comparator.Compare(queue[i], queue[i - 1]) > 0)
                    {
                        T res = queue[i];
                        queue[i] = queue[i - 1];
                        queue[i - 1] = res;

                        i--;
                    }
                    else flag = false;
                }
            }


        }

        public void Clear()
        {
            size = 0;
        }

        public bool IsEmpty()
        {
            if (size > 0) return false;
            return true;
        }

        public void Remove(object o)
        {
            for (int i = 0; i < size; i++)
            {
                if (o.Equals(queue[i]))
                {
                    for (int j = i; j < size - 1; j++)
                    {
                        queue[j] = queue[j + 1];
                    }

                    size--;
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
            for (int i = 0; i < size; i++)
            {
                bool flag = false;

                for (int j = 0; j < a.Length; j++)
                {
                    if (a[j].Equals(queue[i])) flag = true;
                }

                if (!flag) Remove(queue[i]);
            }
        }

        public int Size()
        {
            return size;
        }

        public T[] ToArray()
        {
            T[] output = new T[size];

            for (int i = 0; i < size; i++)
            {
                output[i] = queue[i];
            }

            return output;
        }

        public T[] ToArray(T[] a)
        {
            if (a == null) return ToArray();

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = queue[i];
            }

            return a;
        }

        public T Element()
        {
            if (size == 0) throw new Exception("Queue is empty");
            return queue[0];

        }

        public bool Offer(T obj)
        {
            try
            {
                Add(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public T Poll()
        {
            //if (IsEmpty()) return Task.FromResult<T>(null);
            T res = queue[0];
                
            for (int i = 0; i < size - 1; i++)
            {
                queue[i] = queue[i + 1];
            }
            size--;

            return res;
        }
































    }
}


//namespace MyPriorityQueue
//{
//    public class MyPriorityQueue<T> where T : IComparable
//    {
//        private MyHeap.MyHeap<T> queue;

//        private int size;



//        public MyPriorityQueue()
//        {
//            size = 0;
//            //T[] a = new T[1];

//            //queue = new MyHeap.MyHeap<T>(a, true);
//        }

//        public MyPriorityQueue(T[] a)
//        {
//            queue = new MyHeap.MyHeap<T>(a, true);
//            size = a.Length;
//        }

//        public MyPriorityQueue(int InitialCapacity)
//        {
//            size = InitialCapacity;
//            T[] a = new T[size];

//            queue = new MyHeap.MyHeap<T>(a, true);
//        }




//        public void Add(T e)
//        {
//            if (size == queue.Size())
//            {

//            }
//            else
//            {

//            }
//        }


//    }
//}