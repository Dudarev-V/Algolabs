using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//system.garbage

namespace MyArrayList
{
    public class MyArrayList<T>
    {
        //Поля//

        private T[] elementData;

        private int size;

        //Конструкторы//

        public MyArrayList()
        {
            T[] elementData = Array.Empty<T>();

            size = 0;
        }

        public MyArrayList(T[] a)
        {
            size = a.Length;

            T[] elementData = new T[size];

            for (int i = 0; i < size; i++)
            {
                elementData[i] = a[i];
            }
        }

        public MyArrayList(int capacity)
        {
            size = capacity;

            T[] elementData = new T[size];
        }

        //Методы//

        public void Add(T e)
        {
            if (size == 0)
            {
                T[] nw = new T[1];
                size++;

                nw[0] = e;
                elementData = nw;
            }

            else
            {
                if (elementData.Length == size)
                {
                    T[] res = new T[Convert.ToInt32(size * 0.5) + 1];

                    Array.Copy(elementData, res, elementData.Length);

                    res[size] = e;

                    size++;

                    elementData = res;

                }
                else
                {
                    elementData[size] = e;

                    size++;
                }
            }
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
            size = 0;
        }

        public bool Contains(object o)
        {
            bool f = false;

            for(int i = 0; i < size; i++)
            {
                if (o.Equals(elementData[i])) f = true;
            }

            return f;
        }

        public bool ContainsAll(T[] a)
        {
            bool f = true;
            bool fl = false;

            for (int i = 0; i < size; i++)
            {
                fl = false;

                for (int j = 0; j < a.Length; j++)
                {
                    if (a[i].Equals(elementData[j])) fl = true;
                }

                if (fl == false) f = false;
            }
            return f;
        }

        public bool IsEmpty()
        {
            if (size == 0) return true;
            else return false;
        }

        public void Remove(object o)
        {
            for (int i = 0; i < size; i++)
            {
                if (o.Equals(elementData[i]))
                {
                    for (int j = i; j < size - 1; j++)
                    {
                        elementData[j] = elementData[j + 1];
                    }

                    size--;
                }
            }
        }

        public void RemoveAll(T[] a)
        {
            for (int k = 0; k < a.Length; k++)
            {
                for (int i = 0; i < size; i++)
                {
                    if (a[k].Equals(elementData[i]))
                    {
                        for (int j = i; j < size - 1; j++)
                        {
                            elementData[j] = elementData[j + 1];
                        }

                        size--;
                    }
                }
            }
        }

        public void RetainAll(T[] a)
        {
            int newSize = 0;

            for (int k = 0; k < a.Length; k++)
            {
                for (int i = 0; i < size; i++)
                {
                    if (a[k].Equals(elementData[i]))
                    {
                        elementData[newSize] = a[k];

                        newSize++;
                    }
                }
            }

            size = newSize;
        }

        public int Size()
        {
            return size;
        }

        public T[] ToArray()
        {
            T[] newArr = new T[size];

            Array.Copy(elementData, newArr, size);

            return newArr;
        }

        public T[] ToArray(T[] a)
        {
            if (a.Equals(null))
            {
                T[] newArr = new T[a.Length];

                Array.Copy(a, newArr, a.Length);

                return newArr;
            }

            else
            {
                return ToArray();
            }
        }

        public void Add(int index, T e)
        {
            if (index < size && index > -1)
                elementData[index] = e;
            else throw new Exception("Index out of range");
        }

        public void AddAll(int index, T[] a)
        {
            if (index < size && index > -1)
            {
                if(index + a.Length <= size)
                {
                    for(int i = 0; i < a.Length; i++)
                    {
                        elementData[index + i] = a[i];
                    }
                }
                else throw new Exception("Array last symbols out of range");
            }
            else throw new Exception("Index out of range");
        }

        public T Get(int index)
        {
            if (index < size && index > -1) return elementData[index];
            else throw new Exception("Array last symbols out of range");
        }

        public int IndexOf(object o)
        {
            int index = -1;

            for (int i = 0; i < size; i++)
            {
                if (o.Equals(elementData[i]))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public int LastIndexOf(object o)
        {
            int index = -1;

            for (int i = size - 1; i > -1; i--)
            {
                if (o.Equals(elementData[i]))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public T Remove(int index)
        {
            if (index < size && index > -1)
            {
                T get = elementData[index];

                for (int j = index; j < size - 1; j++)
                {
                    elementData[j] = elementData[j + 1];
                }

                size--;

                return get;
            }
            else throw new Exception("Array last symbols out of range"); ;
        }

        public void Set(int index, T e)
        {
            if (index < size && index > -1) elementData[index] = e;
            else throw new Exception("Index out of range");
        }

        public T[] SubList(int fromIndex, int toIndex)
        {
            if (fromIndex < toIndex && fromIndex < size && fromIndex > -1 && toIndex < size && toIndex > -1)
            {
                T[] newArr = new T[toIndex - fromIndex + 1];

                for (int i = 0; i < newArr.Length; i++)
                {
                    newArr[i] = elementData[fromIndex + i];
                }

                return newArr;
            }
            else throw new Exception("Some values out of range");
        }
    }
}
