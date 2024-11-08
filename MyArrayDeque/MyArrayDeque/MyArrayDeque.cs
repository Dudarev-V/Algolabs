using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArrayDeque
{
    public class MyArrayDeque<E>
    {
        E[] elements;
        int head;
        int tail;

        public MyArrayDeque()
        {
            elements = new E[16];
            head = -1;
            tail = -1;
        }

        public MyArrayDeque(E[] a)
        {
            elements = new E[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                elements[i] = a[i];
            }

            head = 0;
            tail = a.Length - 1;

        }

        public MyArrayDeque(int numElements)
        {
            elements = new E[numElements];
            head = -1;
            tail = -1;
        }


        public void Add(E e)
        {
            if (tail == -1)
            {
                head = 0;
            }

            if ((tail + 2) >= elements.Length)
            {
                E[] res = elements;
                elements = new E[elements.Length * 2];

                for (int i = 0; i < res.Length; i++)
                {
                    elements[i] = res[i];
                }

                tail++;
                elements[tail] = e;

            }
            else
            {
                tail++;
                elements[tail] = e;
            }


        }

        public void AddAll(E[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Add(a[i]);
            }
        }

        public void Clear()
        {
            tail = -1;
            head = -1;
        }

        public bool Contains(object o)
        {
            for (int i = head; i <= tail; i++)
            {
                if (o.Equals(elements[i])) return true;
            }

            return false;
        }

        public bool ContainsAll(E[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (!Contains(a[i])) return false;
            }

            return true;
        }
        public bool IsEmpty()
        {
            if (Size() == 0) return true;
            return false;
        }

        public void Remove(object o)
        {
            for (int i = head; i <= tail; i++)
            {
                if (o.Equals(elements[i]))
                {
                    for (int j = i; j < tail; j++)
                    {
                        elements[j] = elements[j + 1];
                    }

                    tail--;
                }
            }
        }

        public void RemoveAll(E[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Remove(a[i]);
            }
        }

        public void RetainAll(E[] a)
        {
            bool flag;

            for (int i = head; i <= tail; i++)
            {
                flag = true;

                for (int j = 0; j < a.Length; j++)
                {
                    if (a[j].Equals(elements[i])) flag = false;
                }

                if (flag) Remove(a[i]);

            }
        }

        public int Size()
        {
            if (head > -1) return tail - head + 1;
            return 0;
        }

        public E[] ToArray()
        {
            E[] output = new E[Size()];

            for (int i = head; i <= tail; i++)
            {
                output[i - head] = elements[i];
            }

            return output;
        }

        public E Element()
        {
            if (head > -1) return elements[head];
            throw new Exception("Deque is empty");
        }

        public bool Offer(E obj)
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

        public E Peek()
        {
            if (IsEmpty()) return default(E);

            return Element();
        }

        public E PollFirst()
        {
            if (!IsEmpty())
            {
                E output = elements[head];

                head++;

                return output;

            }
            else return default(E);
        }

        public E PollLast()
        {
            if (!IsEmpty())
            {
                E output = elements[tail];

                tail--;

                return output;

            }
            else return default(E);
        }

        public void AddFirst(E obj)
        {
            if (head < 0)
            {
                Add(obj);
            }
            else
            {
                if (head == 0)
                {
                    Add(elements[tail]);
                    for (int i = tail; i > head; i--)
                    {
                        elements[i] = elements[i - 1];
                    }
                    head++;
                }
                    //Console.WriteLine(head);
                    head--;
                    elements[head] = obj;

            }
        }

        public void AddLast(E obj)
        {
            Add(obj);
        }

        public E GetFirst()
        {
            return Element();
        }

        public E GetLast()
        {
            if (!IsEmpty())
            {
                return elements[tail];
            }
            throw new Exception("Deque is empty");
        }

        public bool OfferFirst(E obj)
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

        public bool OfferLast(E obj)
        {
            return Offer(obj);
        }

        public E Pop()
        {
            if (!IsEmpty())
            {
                E output = elements[head];

                head++;

                return output;
            }
            throw new Exception("Deque is empty");
        }

        public void Push(E obj)
        {
            AddFirst(obj);
        }

        public bool RemoveLastOccurance(E obj)
        {
            bool flag = false;

            for (int i = tail; i >= head && !flag; i--)
            {
                if (obj.Equals(elements[i]))
                {
                    Remove(elements[i]);
                    flag = true;
                }
            }

            return flag;
        }

        public bool RemoveFirstOccurance(E obj)
        {
            bool flag = false;

            for (int i = head; i <= tail && !flag; i--)
            {
                if (obj.Equals(elements[i]))
                {
                    Remove(elements[i]);
                    flag = true;
                }
            }

            return flag;
        }

    }
}
