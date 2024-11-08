using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySorts
{
        public abstract class Comparer<T> : IComparer<T>
        {
            public abstract int Compare(T a, T b);
        }

    public class MySorts<T>
    {


        //public class MainComparer : Comparer<T>
        //{
        //    public override int Compare(int a, int b)
        //    {
        //        return a - b;
        //    }
        //}

        static Comparer<T> Comparator;

        public MySorts(Comparer<T> ComparatorIn)
        {
            Comparator = ComparatorIn;
        }











        public T[] BubbleSort(T[] array)        //Пузырь
        {
            int lenght = array.Length;

            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght - 1; j++)
                {
                    if (Comparator.Compare(array[j], array[j + 1]) > 0)
                    {
                        T rev = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = rev;
                    }
                }
            }
            return array;
        }

        public T[] ShakerSort(T[] array)            //Шейкерная
        {
            int lenght = array.Length, left = 0, right = lenght - 1, flag = 1;

            while ((left < right) && flag > 0)
            {
                flag = 0;

                for (int i = left; i < right; i++)
                {
                    if (Comparator.Compare(array[i], array[i + 1]) > 0)
                    {
                        T t = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = t;
                        flag = 1;
                    }
                }

                right--;

                for (int i = right; i > left; i--)
                {
                    if (Comparator.Compare(array[i], array[i + 1]) > 0)
                    {
                        T rev = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = rev;
                        flag = 1;
                    }
                }

                left++;
                if (flag == 0) break;
            }

            return array;
        }


        static void Swap(ref T value1, ref T value2)    //Расческа
        {
            var temp = value1;
            value1 = value2;
            value2 = temp;
        }

        //метод для генерации следующего шага
        static int GetNextStep(int s)
        {
            s = s * 1000 / 1247;
            return s > 1 ? s : 1;
        }

        public T[] CombSort(T[] array)
        {
            var arrayLength = array.Length;
            var currentStep = arrayLength - 1;

            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < array.Length; i++)
                {
                    if (Comparator.Compare(array[i], array[i + currentStep]) > 0)
                    {
                        Swap(ref array[i], ref array[i + currentStep]);
                    }
                }

                currentStep = GetNextStep(currentStep);
            }

            //сортировка пузырьком
            for (var i = 1; i < arrayLength; i++)
            {
                var swapFlag = false;
                for (var j = 0; j < arrayLength - i; j++)
                {
                    if (Comparator.Compare(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }

        public T[] InsertionSort(T[] array)        //Вставки
        {
            int lenght = array.Length;

            for (int i = 1; i < lenght; i++)
                for (int j = i; j > 0 && Comparator.Compare(array[j - 1], array[j]) > 0; j--)
                {
                    T rev = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = rev;
                }

            return array;
        }

        public T[] ShellSort(T[] array)        //Шелл
        {
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (Comparator.Compare(array[j - d], array[j]) > 0))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }

            return array;
        }

        public T[] GnomeSort(T[] array)        //Гномья
        {
            int lenght = array.Length;

            int i = 1, j = 2;

            while (i < lenght)
            {
                if (Comparator.Compare(array[i - 1], array[i]) < 0)
                {
                    i = j;
                    j++;
                }

                else
                {
                    T rev = array[i - 1];
                    array[i - 1] = array[i];
                    array[i] = rev;

                    i--;
                    if (i == 0)
                    {
                        i = j;
                        j++;
                    }
                }
            }

            return array;
        }

        public T[] SelectionSort(T[] array)        //Выбор
        {
            int lenght = array.Length;

            for (int i = 0; i < lenght - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < lenght; j++)
                {
                    if (Comparator.Compare(array[j], array[min]) < 0)
                    {
                        min = j;
                    }
                }

                T rev = array[min];
                array[min] = array[i];
                array[i] = rev;


            }

            return array;
        }

        //Быстрая\\

        public void QuickSort(T[] array, int start, int end)
        {
            int lenght = array.Length;

            if (start >= end) return;

            int pivot = Partition(array, start, end);
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);


        }

        public int Partition(T[] array, int start, int end)
        {
            int marker = start;

            for (int i = start; i < end; i++)
            {
                if (Comparator.Compare(array[i], array[end]) < 0)
                {
                    (array[marker], array[i]) = (array[i], array[marker]);

                    marker++;
                }
            }

            (array[marker], array[end]) = (array[end], array[marker]);

            return marker;
        }

        /////////////

        //Слияние\\

        public T[] MergeSort(T[] array, int low, int high)
        {
            int lenght = array.Length;

            if (low < high)
            {
                var mid = (low + high) / 2;
                MergeSort(array, low, mid);
                MergeSort(array, mid + 1, high);
            }


            return array;
        }

        public void Merge(T[] array, int low, int mid, int high)
        {
            var left = low;
            var right = mid + 1;
            T[] tempArr = new T[high - low + 1];
            var index = 0;

            while ((left <= mid) && (right <= high))
            {
                if (Comparator.Compare(array[left], array[right]) < 0)
                {
                    tempArr[index] = array[left];
                    left++;
                }
                else
                {
                    tempArr[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= mid; i++)
            {
                tempArr[index] = array[i];
                index++;
            }

            for (var i = right; i <= high; i++)
            {
                tempArr[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArr.Length; i++)
            {
                array[low + i] = tempArr[i];
            }
        }

        /////////////

        static int[] BasicCountingSort(int[] array, int k)  //подсчетом--
        {
            var count = new int[k + 1];
            for (var i = 0; i < array.Length; i++)
            {
                count[array[i]]++;
            }

            var index = 0;
            for (var i = 0; i < count.Length; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    array[index] = i;
                    index++;
                }
            }

            return array;
        }

        //static int[] CountingSort(int[] array)      //подсчетом
        //{
        //    //поиск минимального и максимального значений
        //    var min = array[0];
        //    var max = array[0];
        //    foreach (int element in array)
        //    {
        //        if (element > max)
        //        {
        //            max = element;
        //        }
        //        else if (element < min)
        //        {
        //            min = element;
        //        }
        //    }

        //    //поправка
        //    var correctionFactor = min != 0 ? -min : 0;
        //    max += correctionFactor;

        //    var count = new int[max + 1];
        //    for (var i = 0; i < array.Length; i++)
        //    {
        //        count[array[i] + correctionFactor]++;
        //    }

        //    var index = 0;
        //    for (var i = 0; i < count.Length; i++)
        //    {
        //        for (var j = 0; j < count[i]; j++)
        //        {
        //            array[index] = i - correctionFactor;
        //            index++;
        //        }
        //    }

        //    return array;
        //}

        //public static int[] SortL(int[] arr)     //поразрядная
        //{
        //    if (arr == null || arr.Length == 0)
        //        return arr;

        //    int i, j;
        //    var tmp = new int[arr.Length];
        //    for (int shift = sizeof(int) * 8 - 1; shift > -1; --shift)
        //    {
        //        j = 0;
        //        for (i = 0; i < arr.Length; ++i)
        //        {
        //            var move = (arr[i] << shift) >= 0;
        //            if (shift == 0 ? !move : move)
        //                arr[i - j] = arr[i];
        //            else
        //                tmp[j++] = arr[i];
        //        }
        //        Array.Copy(tmp, 0, arr, arr.Length - j, j);
        //    }

        //    return arr;
        //}

        //Битонная\\

        public class GFG
        {
            /* To swap values */
            static void Swap<K>(ref K lhs, ref K rhs)
            {
                K temp;
                temp = lhs;
                lhs = rhs;
                rhs = temp;
            }
            public static void compAndSwap(T[] a, int i, int j, int dir)
            {
                int k;
                //if ((a[i] > a[j]))
                if (Comparator.Compare(a[i], a[j]) > 0)
                    k = 1;
                else
                    k = 0;
                if (dir == k)
                    Swap(ref a[i], ref a[j]);
            }

            /*It recursively sorts a bitonic sequence in ascending order, 
              if dir = 1, and in descending order otherwise (means dir=0). 
              The sequence to be sorted starts at index position low, 
              the parameter cnt is the number of elements to be sorted.*/
            public static void bitonicMerge(T[] a, int low, int cnt, int dir)
            {
                if (cnt > 1)
                {
                    int k = cnt / 2;
                    for (int i = low; i < low + k; i++)
                        compAndSwap(a, i, i + k, dir);
                    bitonicMerge(a, low, k, dir);
                    bitonicMerge(a, low + k, k, dir);
                }
            }

            /* This function first produces a bitonic sequence by recursively 
                sorting its two halves in opposite sorting orders, and then 
                calls bitonicMerge to make them in the same order */
            public static void bitonicSort(T[] a, int low, int cnt, int dir)
            {
                if (cnt > 1)
                {
                    int k = cnt / 2;

                    // sort in ascending order since dir here is 1 
                    bitonicSort(a, low, k, 1);

                    // sort in descending order since dir here is 0 
                    bitonicSort(a, low + k, k, 0);

                    // Will merge whole sequence in ascending order 
                    // since dir=1. 
                    bitonicMerge(a, low, cnt, dir);
                }
            }

            /* Caller of bitonicSort for sorting the entire array of 
               length N in ASCENDING order */
            public static void sort(T[] a, int N, int up)
            {
                bitonicSort(a, 0, N, up);
            }
        }

        /////////////

        //Пирамидальная\\

        public Int32 add2pyramid(T[] arr, Int32 i, Int32 N)
        {
            Int32 imax;
            T buf;
            if ((2 * i + 2) < N)
            {
                if (Comparator.Compare(arr[2 * i + 1], arr[2 * i + 2]) < 0) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (Comparator.Compare(arr[i], arr[imax]) < 0)
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }

        public void PyramidSort(T[] arr, Int32 len)
        {
            //step 1: building the pyramid
            for (Int32 i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, len);
                if (prev_i != i) ++i;
            }

            //step 2: sorting
            T buf;
            for (Int32 k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                Int32 i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(arr, i, k);
                }
            }
        }

        /////////////

        //Деревом\\

        public class TreeNode
        {
            public TreeNode(T data)
            {
                Data = data;
            }

            //данные
            public T Data { get; set; }

            //левая ветка дерева
            public TreeNode Left { get; set; }

            //правая ветка дерева
            public TreeNode Right { get; set; }

            //рекурсивное добавление узла в дерево
            public void Insert(TreeNode node)
            {
                if (Comparator.Compare(node.Data, Data) < 0)
                {
                    if (Left == null)
                    {
                        Left = node;
                    }
                    else
                    {
                        Left.Insert(node);
                    }
                }
                else
                {
                    if (Right == null)
                    {
                        Right = node;
                    }
                    else
                    {
                        Right.Insert(node);
                    }
                }
            }

            //преобразование дерева в отсортированный массив
            public T[] Transform(List<T> elements = null)
            {
                if (elements == null)
                {
                    elements = new List<T>();
                }

                if (Left != null)
                {
                    Left.Transform(elements);
                }

                elements.Add(Data);

                if (Right != null)
                {
                    Right.Transform(elements);
                }

                return elements.ToArray();
            }
        }

        public T[] TreeSort(T[] array)
        {
            var treeNode = new TreeNode(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                treeNode.Insert(new TreeNode(array[i]));
            }

            return treeNode.Transform();
        }

        /////////////



    }
}
