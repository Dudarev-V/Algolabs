using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVector
{
    public class MyVector<T>
    {

        //

        private T[] elementData;

        private int elementCount;

        private int capacityIncrement;

        //

        public MyVector()
        {
            elementData = new T[10];

            elementCount = 0;

            capacityIncrement = 0;
        }

        public MyVector(int initialCapacity, int capacityIncrementin)
        {
            elementData = new T[initialCapacity];

            elementCount = 0;

            capacityIncrement = capacityIncrementin;

        }

        public MyVector(int initialCapacity)
        {
            elementData = new T[initialCapacity];

            elementCount = 0;

            capacityIncrement = 0;
        }

        public MyVector(T[] a)
        {
            elementCount = a.Length;

            elementData = new T[elementCount];

            for (int i = 0; i < elementCount; i++)
            {
                elementData[i] = a[i];
            }

            capacityIncrement = 0;
        }

        //

        public void Add(T e)
        {
            if (elementData.Length == elementCount)
            {
                if (capacityIncrement > 0)
                {
                    T[] res = new T[elementData.Length + capacityIncrement];

                    Array.Copy(elementData, res, elementData.Length);

                    res[elementCount] = e;

                    elementCount++;

                    elementData = res;
                }
                else
                {
                    T[] res = new T[elementData.Length * 2];

                    Array.Copy(elementData, res, elementData.Length);

                    res[elementCount] = e;

                    elementCount++;

                    elementData = res;
                }

            }
            else
            {
                elementData[elementCount] = e;

                elementCount++;
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
            elementCount = 0;
        }

        public bool Contains(object o)
        {
            bool f = false;

            for (int i = 0; i < elementCount; i++)
            {
                if (o.Equals(elementData[i])) f = true;
            }

            return f;
        }

        public bool ContainsAll(T[] a)
        {
            bool f = true;

            for (int i = 0; i < a.Length; i++)
            {
                if (!Contains(a[i])) f = false;
            }

            return f;
        }

        public bool IsEmpty()
        {
            if (Convert.ToBoolean(elementCount)) return false;
            else return true;
        }

        public void Remove(object o)
        {
            for (int i = 0; i < elementCount; i++)
            {
                if (o.Equals(elementData[i]))
                {
                    for (int j = i; j < elementCount - 1; j++)
                    {
                        elementData[j] = elementData[j + 1];
                    }

                    elementCount--;
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
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < elementCount; j++)
                {
                    if (!a[i].Equals(elementData[j])) Remove(elementData[j]);
                }
            }
        }

        public int Size()
        {
            return elementCount;
        }

        public T[] ToArray()
        {
            T[] output = new T[elementCount];

            Array.Copy(elementData, output, elementCount);

            return output;
        }

        public T[] ToArray(ref T[] a)
        {
            if (a.Equals(null)) return ToArray();
            else
            {
                if (a.Length != elementCount) throw new Exception("Array sizes not equal");
                else
                {
                    Array.Copy(elementData, a, elementCount);
                    return a;
                }
            }
        }

        public void Add(int index, T e)
        {
            if (index < elementCount && index > -1)
                elementData[index] = e;
            else throw new Exception("Index out of range");
        }

        public void AddAll(int index, T[] a)
        {
            if (index < elementCount && index > -1)
            {
                if (index + a.Length - 1 >= elementCount)
                {
                    int rem = 0;

                    for (int i = 0; index + i < elementCount; i++, rem++)
                    {
                        elementData[index + i] = a[i];
                    }

                    for (int i = rem; i < a.Length; i++)
                    {
                        Add(a[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        elementData[index + i] = a[i];
                    }
                }
            }
            else throw new Exception("Index out of range");
        }

        public T Get(int index)
        {
            if (index < elementCount && index > -1) return elementData[index];
            else throw new Exception("Array last symbols out of range");
        }

        public int IndexOf(object o)
        {
            int index = -1;

            for (int i = 0; i < elementCount; i++)
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

            for (int i = elementCount - 1; i > -1; i--)
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
            if (index < elementCount && index > -1)
            {
                T get = elementData[index];

                for (int j = index; j < elementCount - 1; j++)
                {
                    elementData[j] = elementData[j + 1];
                }

                elementCount--;

                return get;
            }
            else throw new Exception("Array last symbols out of range"); ;
        }

        public void Set(int index, T e)
        {
            if (index < elementCount && index > -1) elementData[index] = e;
            else throw new Exception("Index out of range");
        }

        public T[] SubList(int fromIndex, int toIndex)
        {
            if (fromIndex < toIndex && fromIndex < elementCount && fromIndex > -1 && toIndex < elementCount && toIndex > -1)
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

        public T FirstElement()
        {
            if (elementCount == 0) throw new Exception("Vector is empty");
            else return elementData[0];
        }

        public T LastElement()
        {
            if (elementCount == 0) throw new Exception("Vector is empty");
            else return elementData[elementCount - 1];
        }

        public void RemoveElementAt(int pos)
        {
            if (pos < elementCount && pos > -1)
            {
                for (int j = pos; j < elementCount - 1; j++)
                {
                    elementData[j] = elementData[j + 1];
                }

                elementCount--;
            }
            else throw new Exception("Array last symbols out of range"); ;
        }

        public void RemoveRange(int begin, int end)
        {
            if (begin < end && begin < elementCount && begin > -1 && end < elementCount && end > -1)
            {
                for (int i = begin; i <= end; i++)
                {
                    RemoveElementAt(i);
                }
            }
            else throw new Exception("Some values out of range");
        }













    }

}
