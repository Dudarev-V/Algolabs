using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVector;

namespace MyHeap
{
    public class MyHeap<T> where T: IComparable
    {

        private MyVector<T> array;
        private int sizeH;
        private bool type;

        public MyHeap(T[] arr, bool typeIn)
        {
            array = new MyVector<T>(arr.Length);
            sizeH = 0;
            type = typeIn;

            for (int i = 0; i < arr.Length; i++)
            {
                Add(arr[i]);   
            }

            //Rebuild();
        }

        public int Size()
        {
            return sizeH;
        }

        public void Add(T e)
        {
            array.Add(e);
            sizeH++;

            int i = sizeH - 1;

            int current = (i - 1) / 2;

            if (type)
                while (i > 0 && (array.Get(current).CompareTo(array.Get(i)) < 0))   //пока ноый элмент больше родителя, меняем местами
                {
                    T res = array.Get(current);
                    array.Set(current, array.Get(i));
                    array.Set(i, res);

                    i = current;

                    current = (i - 1) / 2;
                }
            else
                while (i > 0 && (array.Get(current).CompareTo(array.Get(i)) > 0))   //пока ноый элмент больше родителя, меняем местами
                {
                    T res = array.Get(current);
                    array.Set(current, array.Get(i));
                    array.Set(i, res);

                    i = current;

                    current = (i - 1) / 2;
                }



        }
        //20 15 11 6 9 7 8 1 3 5

        public T GetRoot()
        {
            if (!array.IsEmpty())
                return array.Get(0);
            else throw new Exception ("Heap is empty");
        }

        public void GetArr()
        {
            for (int i = 0; i < sizeH; i++)
            {
                Console.WriteLine(array.Get(i));
            }
        }

        public T ExemptRoot()
        {
            if (!array.IsEmpty())
            {
                T res = array.Get(0);
                array.Remove((int)0);
                sizeH--;

                Rebuild();

                //GetArr();

                return res;
            }
            else throw new Exception("Heap is empty");
        }

        public void Rebuild()
        {
            int leftChild;
            int rightChild;
            int largestChild;

            int i = 0;
            
            if (type)
            for (;i < array.Size();)
            {
                leftChild = 2 * i + 1;
                rightChild = 2 * i + 2;
                largestChild = i;

                if (leftChild < sizeH)
                {
                    if (array.Get(leftChild).CompareTo(array.Get(largestChild)) > 0)
                    largestChild = leftChild;
                }

                if (rightChild < sizeH)
                {
                    if (array.Get(leftChild).CompareTo(array.Get(largestChild)) > 0)
                    largestChild = rightChild;
                }

                    if (largestChild == i)
                    {
                        i++;
                        continue;
                    }

                    T res = array.Get(i);
                    array.Set(i, array.Get(largestChild));
                    array.Set(largestChild, res);
                    //i = largestChild;
                    i++;
            }
            else
            for (; i < array.Size() ; )
            {
                leftChild = 2 * i + 1;
                rightChild = 2 * i + 2;
                largestChild = i;

                if (leftChild < sizeH)
                {
                    if (array.Get(leftChild).CompareTo(array.Get(largestChild)) < 0)
                    largestChild = leftChild;
                }

                if (rightChild < sizeH)
                {
                    if (array.Get(leftChild).CompareTo(array.Get(largestChild)) < 0)
                    largestChild = rightChild;
                }

                    if (largestChild == i)
                    {
                        i++;
                        continue;
                    }

                    T res = array.Get(i);
                    array.Set(i, array.Get(largestChild));
                    array.Set(largestChild, res);
                    //i = largestChild;
                    i++;
            }
        }

        public MyHeap<T> Merge(MyHeap<T> input)
        {
            MyHeap<T> output = new MyHeap<T>(array.ToArray(), type);

            for (int i = 0; i < input.Size(); i++)
            {
                output.Add(input.ExemptRoot());
            }

            return output;
        }

        public void SetKey(int index, T e)
        {
            if (index < array.Size() && index > -1)
            {
                array.Set(index, e);

                Rebuild();
            }
            else throw new Exception("Index out of range");
        }



    }

}
