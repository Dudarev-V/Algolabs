using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    public class MyStack<T>: MyVector.MyVector<T>
    {
        //Методы

        public void Push(T item)
        {
            Add(item);
        }

        public T Pop()
        {
            if (IsEmpty()) throw new Exception("Stack is empty");
            else
            {
                T res = LastElement();
                int index = Size() - 1;
                Remove(index);
                return res;
            }
        }

        public T Peek()
        {
            if (IsEmpty()) throw new Exception("Stack is empty");
            else
            {
                return LastElement();
            }
        }

        public T PeekSafe()                               //модификация, дабы не увеличивать проверку в лабах
        {
            T a = 0;

            if (IsEmpty()) return a;
            else
            {
                return LastElement();
            }
        }



        public bool Empty()
        {
            if (IsEmpty()) return true;
            else return false;
        }

        public int Search(T item)
        {
            if (IndexOf(item) == -1)
            {
                return -1;
            }
            else
            {
                bool f = true;
                int pos = 0;

                for (int i = Size() - 1; i > -1 && f; i--)
                {
                    pos++;

                    if (item.Equals(Get(i)))
                    {
                        f = false;
                    }
                }

                return pos;
            }
        }

    }
}
