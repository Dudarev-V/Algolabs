using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ZedGraph;
using System.IO;

namespace SortsAlgolabs
{
    public partial class Form1 : Form
    {
        public int[] BubbleSort(int[] array)        //Пузырь
        {
            int lenght = array.Length;

            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int rev = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = rev;
                    }
                }
            }
            return array;
        }

        public int[] ShakerSort(int[] array)            //Шейкерная
        {
            int lenght = array.Length, left = 0, right = lenght - 1, flag = 1;

            while((left < right) && flag > 0)
            {
                flag = 0;

                for (int i = left; i < right; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int t = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = t;
                        flag = 1;
                    }
                }

                right--;

                for (int i = right; i > left; i--)
                {
                    if (array[i] > array[i + 1])
                    {
                        int rev = array[i];
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

        //public int[] CombSort(int[] array)      //Расческа
        //{
        //    int lenght = array.Length;

        //    double gap = Convert.ToDouble(lenght) / 1.247;

        //    while (gap > 1)
        //    {
        //        int intagap = Convert.ToInt32(gap);

        //        for (int i = 0, j = intagap; j < lenght; i++, j++)
        //        {
        //            if (array[i] > array[j])
        //            {
        //                int rev = array[i];
        //                array[i] = array[i - 1];
        //                array[i - 1] = rev;
        //            }
        //        }

        //        gap = gap / 1.247;
        //    }

        //    return array;
        //}

        static void Swap(ref int value1, ref int value2)    //Расческа
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

        static int[] CombSort(int[] array)
        {
            var arrayLength = array.Length;
            var currentStep = arrayLength - 1;

            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < array.Length; i++)
                {
                    if (array[i] > array[i + currentStep])
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
                    if (array[j] > array[j + 1])
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

        public int[] InsertionSort(int[] array)        //Вставки
        {
            int lenght = array.Length;

            for (int i = 1; i < lenght; i++)
                for (int j = i; j > 0 && array[j - 1] > array[j]; j--)
                {
                    int rev = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = rev;
                }  
            
            return array;
        }

        public int[] ShellSort(int[] array)        //Шелл
        {
            //int lenght = array.Length;

            //int i, j, step;
            //int tmp;
            //for (step = lenght / 2; step > 0; step /= 2)
            //    for (i = step; i < lenght; i++)
            //    {
            //        tmp = array[i];
            //        for (j = i; j >= step; j -= step)
            //        {
            //            if (tmp < array[j - step])
            //                array[j] = array[j - step];
            //            else break;

            //        }

            //        array[j] = tmp;
            //    }

            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }

            return array;
        }

        public int[] GnomeSort(int[] array)        //Гномья
        {
            int lenght = array.Length;

            int i = 1, j = 2;

            while (i < lenght)
            {
                if(array[i - 1] < array[i])
                {
                    i = j;
                    j++;
                }

                else
                {
                    int rev = array[i - 1];
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

        public int[] SelectionSort(int[] array)        //Выбор
        {
            int lenght = array.Length;

            for (int i = 0; i < lenght - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < lenght; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                        int rev = array[min];
                        array[min] = array[i];
                        array[i] = rev;
                    
                
            }

            return array;
        }

        //Быстрая\\

        public void QuickSort(int[] array, int start, int end)  
        {
            int lenght = array.Length;

            if (start >= end) return;

            int pivot = Partition(array, start, end);
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);

            
        }

        public int Partition(int[] array, int start, int end)
        {
            int marker = start;

            for (int i = start; i < end; i++)
            {
                if (array[i] < array[end])
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

        public int[] MergeSort(int[] array, int low, int high)
        {
            int lenght = array.Length;

            if(low < high)
            {
                var mid = (low + high) / 2;
                MergeSort(array, low, mid);
                MergeSort(array, mid + 1, high);
            }


            return array;
        }

        public void Merge(int[] array, int low, int mid, int high)
        {
            var left = low;
            var right = mid + 1;
            var tempArr = new int[high - low + 1];
            var index = 0;

            while ((left <= mid) && (right <= high))
            {
                if (array[left] < array[right])
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

        static int[] CountingSort(int[] array)      //подсчетом
        {
            //поиск минимального и максимального значений
            var min = array[0];
            var max = array[0];
            foreach (int element in array)
            {
                if (element > max)
                {
                    max = element;
                }
                else if (element < min)
                {
                    min = element;
                }
            }

            //поправка
            var correctionFactor = min != 0 ? -min : 0;
            max += correctionFactor;

            var count = new int[max + 1];
            for (var i = 0; i < array.Length; i++)
            {
                count[array[i] + correctionFactor]++;
            }

            var index = 0;
            for (var i = 0; i < count.Length; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    array[index] = i - correctionFactor;
                    index++;
                }
            }

            return array;
        }

        public static int[] SortL(int[] arr)      //поразрядная
        {
            if (arr == null || arr.Length == 0)
                return arr;

            int i, j;
            var tmp = new int[arr.Length];
            for (int shift = sizeof(int) * 8 - 1; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < arr.Length; ++i)
                {
                    var move = (arr[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        arr[i - j] = arr[i];
                    else
                        tmp[j++] = arr[i];
                }
                Array.Copy(tmp, 0, arr, arr.Length - j, j);
            }

            return arr;
        }

        //Битонная\\

        //static void Swap<T>(ref T lhs, ref T rhs)
        //{
        //    T temp;
        //    temp = lhs;
        //    lhs = rhs;
        //    rhs = temp;
        //}
        //public static void compAndSwap(int[] a, int i, int j, int dir)
        //{
        //    int k;
        //    if ((a[i] > a[j]))
        //        k = 1;
        //    else
        //        k = 0;
        //    if (dir == k)
        //        Swap(ref a[i], ref a[j]);
        //}

        ///*It recursively sorts a bitonic sequence in ascending order, 
        //  if dir = 1, and in descending order otherwise (means dir=0). 
        //  The sequence to be sorted starts at index position low, 
        //  the parameter cnt is the number of elements to be sorted.*/
        //public static void bitonicMerge(int[] a, int low, int cnt, int dir)
        //{
        //    if (cnt > 1)
        //    {
        //        int k = cnt / 2;
        //        for (int i = low; i < low + k; i++)
        //            compAndSwap(a, i, i + k, dir);
        //        bitonicMerge(a, low, k, dir);
        //        bitonicMerge(a, low + k, k, dir);
        //    }
        //}

        ///* This function first produces a bitonic sequence by recursively 
        //    sorting its two halves in opposite sorting orders, and then 
        //    calls bitonicMerge to make them in the same order */
        //public static void bitonicSort(int[] a, int low, int cnt, int dir)
        //{
        //    if (cnt > 1)
        //    {
        //        int k = cnt / 2;

        //        // sort in ascending order since dir here is 1 
        //        bitonicSort(a, low, k, 1);

        //        // sort in descending order since dir here is 0 
        //        bitonicSort(a, low + k, k, 0);

        //        // Will merge whole sequence in ascending order 
        //        // since dir=1. 
        //        bitonicMerge(a, low, cnt, dir);
        //    }
        //}

        ///* Caller of bitonicSort for sorting the entire array of 
        //   length N in ASCENDING order */
        //public static void sort(int[] a, int N, int up)
        //{
        //    bitonicSort(a, 0, N, up);
        //}

        class GFG
        {
            /* To swap values */
            static void Swap<T>(ref T lhs, ref T rhs)
            {
                T temp;
                temp = lhs;
                lhs = rhs;
                rhs = temp;
            }
            public static void compAndSwap(int[] a, int i, int j, int dir)
            {
                int k;
                if ((a[i] > a[j]))
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
            public static void bitonicMerge(int[] a, int low, int cnt, int dir)
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
            public static void bitonicSort(int[] a, int low, int cnt, int dir)
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
            public static void sort(int[] a, int N, int up)
            {
                bitonicSort(a, 0, N, up);
            }
        }

            /////////////

            //Пирамидальная\\

            static Int32 add2pyramid(Int32[] arr, Int32 i, Int32 N)
        {
            Int32 imax;
            Int32 buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] < arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }

        static void PyramidSort(Int32[] arr, Int32 len)
        {
            //step 1: building the pyramid
            for (Int32 i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, len);
                if (prev_i != i) ++i;
            }

            //step 2: sorting
            Int32 buf;
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
            public TreeNode(int data)
            {
                Data = data;
            }

            //данные
            public int Data { get; set; }

            //левая ветка дерева
            public TreeNode Left { get; set; }

            //правая ветка дерева
            public TreeNode Right { get; set; }

            //рекурсивное добавление узла в дерево
            public void Insert(TreeNode node)
            {
                if (node.Data < Data)
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
            public int[] Transform(List<int> elements = null)
            {
                if (elements == null)
                {
                    elements = new List<int>();
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

        private static int[] TreeSort(int[] array)
        {
            var treeNode = new TreeNode(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                treeNode.Insert(new TreeNode(array[i]));
            }

            return treeNode.Transform();
        }

        /////////////





        //#########ArrGen##########//

        public int[] MainArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            int[] array = new int[iter];

            Random rand = new Random(((int)DateTime.Now.Ticks));

            for (int i = 0; i < iter; i++)
            {
                array[i] = rand.Next(0, 1000);      //-42; 42
            }

            return array;
        }

        public int[] OneSwapArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            Random rand = new Random();

            int[] array = SortForwardArrGen(mod);

            bool f = true;
            
            while (f)
            {
                int swapVal = rand.Next(1, iter - 4);
                int newSwapVal = rand.Next(swapVal + 1, iter - 1);

                if (array[swapVal] != array[newSwapVal])
                {
                    int rev = array[swapVal];
                    array[swapVal] = array[newSwapVal];
                    array[newSwapVal] = rev;

                    f = false;
                }
            }
            return array;
        }

        public int[] SortForwardArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            int[] array = new int[iter];

            int current = 0;

            Random rand = new Random();

            for (int i = 0; i < iter; i++)
            {
                if (rand.Next(1, mod * 6) == 2)
                    current++;

                array[i] = current;
            }

            return array;
        }

        public int[] SortBackwardArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            int[] array = new int[iter];

            int current = 0;

            Random rand = new Random();

            for (int i = 0; i < iter; i++)
            {
                if (rand.Next(1, mod * 6) == 2)
                    current--;

                array[i] = current;
            }

            return array;
        }

        public int[] ReplArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            Random rand = new Random();

            int[] array = SortForwardArrGen(mod);

            int count = rand.Next(1, 9);

            bool f = true;

            for (int i = 0; i < count; i++)
            {
                while (f)
                {
                    int swapVal = rand.Next(1, iter - 4);
                    int newSwapVal = rand.Next(swapVal + 1, iter - 1);

                    if (array[swapVal] != array[newSwapVal])
                    {
                        int rev = array[swapVal];
                        array[swapVal] = array[newSwapVal];
                        array[newSwapVal] = rev;

                        f = false;
                    }
                }
            }

            return array;
        }

        public int[] SubArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            Random rand = new Random();

            int[] array = new int[iter];

            int current = 0;

            for (int i = 0; i < iter; i++)
            {
                if (rand.Next(1, mod) == 2)
                    current++;
                if (rand.Next(1, mod * 10) < 11)
                    current = 0;

                array[i] = current;
            }



            return array;
        }

        public int[] RandArrGen(int mod, int propability, int element)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            int[] array = new int[iter];

            Random rand = new Random();

            for (int i = 0; i < iter; i++)
            {
                if (rand.Next(0, 100) <= propability)
                    array[i] = element;
                else
                    array[i] = rand.Next(0, 1000);      
            }

            return array;
        }



        //#########################//

        static int val = 3;    // максимальная степень длины массива
        static int val1 = 3;
        static int val2 = 3;

        int[][] mainArray = new int[val][];           //случайный массив

        int[][] sortedArray0 = new int[val][];        //сортированные массивы от каждого метода
        int[][] sortedArray1 = new int[val][];
        int[][] sortedArray2 = new int[val][];
        int[][] sortedArray3 = new int[val][];
        int[][] sortedArray4 = new int[val][];
        int[][] sortedArray5 = new int[val][];




        int choose = 0;  //выбор для записи в файл

        public Form1()
        {
            InitializeComponent();

            //int[] arr = new int { 1, 7, 3, 8, 2, 6, 9 };


        }


        bool genered = false;


        private void ArrTest_Click(object sender, EventArgs e)
        {
            label6.Text = "";                   

            if (genered)                                //если массив сгенерен
            {
                for(int i = 0; i < val2; i++)                               //инициализация подмассивов
                {
                    sortedArray0[i] = new int[Convert.ToInt32(Math.Pow(10, i + 1))];
                    sortedArray1[i] = new int[Convert.ToInt32(Math.Pow(10, i + 1))];
                    sortedArray2[i] = new int[Convert.ToInt32(Math.Pow(10, i + 1))];
                    sortedArray3[i] = new int[Convert.ToInt32(Math.Pow(10, i + 1))];
                    sortedArray4[i] = new int[Convert.ToInt32(Math.Pow(10, i + 1))];
                    sortedArray5[i] = new int[Convert.ToInt32(Math.Pow(10, i + 1))];
                }

                double[] time0 = new double[val];            //среднее время для каждого размера
                double[] time1 = new double[val];
                double[] time2 = new double[val];
                double[] time3 = new double[val];
                double[] time4 = new double[val];
                double[] time5 = new double[val];


                Stopwatch stopwatch = new Stopwatch();          //счетчик времени

                GraphPane pane = zedGraphControl1.GraphPane;        //иниц. координат

                pane.CurveList.Clear(); 

                PointPairList list5 = new PointPairList();       //пары точек для каждого массива
                PointPairList list0 = new PointPairList();
                PointPairList list1 = new PointPairList();
                PointPairList list2 = new PointPairList();
                PointPairList list3 = new PointPairList();
                PointPairList list4 = new PointPairList();

                if (GroupChoose.SelectedIndex == 0)
                {
                    for (int m = 0; m < 20; m++)
                    {

                            stopwatch.Start();
                            for (int i = 0; i < val1; i++)
                            {
                                Array.Copy(mainArray[i], sortedArray0[i], mainArray[i].Length);

                                sortedArray0[i] = BubbleSort(sortedArray0[i]);

                                time0[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();

                        stopwatch.Start();
                            for (int i = 0; i < val1; i++)
                            {
                                Array.Copy(mainArray[i], sortedArray1[i], mainArray[i].Length);

                                sortedArray1[i] = InsertionSort(sortedArray1[i]);

                                time1[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();

                            stopwatch.Start();
                            for (int i = 0; i < val1; i++)
                            {
                                Array.Copy(mainArray[i], sortedArray2[i], mainArray[i].Length);

                                sortedArray2[i] = ShakerSort(sortedArray2[i]);

                                time2[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();

                            stopwatch.Start();
                            for (int i = 0; i < val1; i++)
                            {
                                Array.Copy(mainArray[i], sortedArray3[i], mainArray[i].Length);

                                sortedArray3[i] = GnomeSort(sortedArray3[i]);

                                time3[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();

                            stopwatch.Start();
                            for (int i = 0; i < val1; i++)
                            {
                                Array.Copy(mainArray[i], sortedArray4[i], mainArray[i].Length);

                                sortedArray4[i] = SelectionSort(sortedArray4[i]);

                                time4[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();

                    }

                    for (int i = 0; i < val; i++)         //вычисление среднего времени
                    {
                        time0[i] = time0[i] / 20;
                        time1[i] = time1[i] / 20;
                        time2[i] = time2[i] / 20;
                        time3[i] = time3[i] / 20;
                        time4[i] = time4[i] / 20;
                    }

                    for (int i = 0; i < val; i++)             //запись в пары точек
                    {
                        list0.Add(i, time0[i]);
                        list1.Add(i, time1[i]);
                        list2.Add(i, time2[i]);
                        list3.Add(i, time3[i]);
                        list4.Add(i, time4[i]);
                    }

                    LineItem l0 = pane.AddCurve("Bubble", list0, Color.Blue, SymbolType.None);       //отрисовываем графики
                    LineItem L1 = pane.AddCurve("Insertion", list1, Color.Red, SymbolType.None);
                    LineItem L2 = pane.AddCurve("Shaker", list2, Color.Green, SymbolType.None);
                    LineItem L3 = pane.AddCurve("Gnome", list3, Color.Yellow, SymbolType.None);
                    LineItem L4 = pane.AddCurve("Selection", list4, Color.Pink, SymbolType.None);

                    choose = 1;

                }

                if (GroupChoose.SelectedIndex == 1)
                {
                    for (int m = 0; m < 20; m++)
                    {

                        stopwatch.Start();
                        for (int i = 0; i < val1; i++)
                        {
                            Array.Copy(mainArray[i], sortedArray0[i], mainArray[i].Length);

                            GFG.sort(sortedArray0[i], sortedArray0[i].Length, 1);

                            time0[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                        }
                        stopwatch.Stop();

                        stopwatch.Start();
                        for (int i = 0; i < val1; i++)
                        {
                            Array.Copy(mainArray[i], sortedArray1[i], mainArray[i].Length);

                            sortedArray1[i] = ShellSort(sortedArray1[i]);

                            time1[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                        }
                        stopwatch.Stop();

                        stopwatch.Start();
                        for (int i = 0; i < val1; i++)
                        {
                            Array.Copy(mainArray[i], sortedArray2[i], mainArray[i].Length);

                            sortedArray2[i] = TreeSort(sortedArray2[i]);

                            time2[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                        }
                        stopwatch.Stop();
                    }

                    for (int i = 0; i < val; i++)         //вычисление среднего времени
                    {
                        time0[i] = time0[i] / 20;
                        time1[i] = time1[i] / 20;
                        time2[i] = time2[i] / 20;
                    }

                    for (int i = 0; i < val; i++)             //запись в пары точек
                    {
                        list0.Add(i, time0[i]);
                        list1.Add(i, time1[i]);
                        list2.Add(i, time2[i]);
                    }

                    LineItem l0 = pane.AddCurve("Bitonic", list0, Color.Blue, SymbolType.None);       //отрисовываем графики
                    LineItem L1 = pane.AddCurve("Shell", list1, Color.Red, SymbolType.None);
                    LineItem L2 = pane.AddCurve("Tree", list2, Color.Green, SymbolType.None);


                    choose = 2;

                }

                if (GroupChoose.SelectedIndex == 2)
                {
                    for (int m = 0; m < 20; m++)
                    {

                        stopwatch.Start();
                        for (int i = 0; i < val2; i++)
                        {
                            //sortedArray0[i] = mainArray[i];

                            Array.Copy(mainArray[i], sortedArray0[i], mainArray[i].Length);

                            sortedArray0[i] = CombSort(sortedArray0[i]);

                            time0[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                        }
                        stopwatch.Stop();

                        stopwatch.Start();
                        for (int i = 0; i < val2; i++)
                        {
                            Array.Copy(mainArray[i], sortedArray1[i], mainArray[i].Length);

                            PyramidSort(sortedArray1[i], sortedArray1[i].Length);

                            time1[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                        }
                        stopwatch.Stop();

                        stopwatch.Start();
                        for (int i = 0; i < val2; i++)
                        {
                            Array.Copy(mainArray[i], sortedArray2[i], mainArray[i].Length);

                            QuickSort(sortedArray2[i], 0, sortedArray2[i].Length - 1);

                            time2[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                        }
                        stopwatch.Stop();

                        stopwatch.Start();
                        for (int i = 0; i < val2; i++)
                        {
                            Array.Copy(mainArray[i], sortedArray3[i], mainArray[i].Length);

                            sortedArray3[i] = MergeSort(sortedArray3[i], 0, mainArray[i].Length - 1);

                            time3[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                        }
                        stopwatch.Stop();

                        stopwatch.Start();
                        for (int i = 0; i < val2; i++)
                        {
                            Array.Copy(mainArray[i], sortedArray4[i], mainArray[i].Length);

                            sortedArray4[i] = CountingSort(sortedArray4[i]);

                            time4[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                        }
                        stopwatch.Stop();

                        stopwatch.Start();
                        for (int i = 0; i < val2; i++)
                        {
                            Array.Copy(mainArray[i], sortedArray5[i], mainArray[i].Length);

                            sortedArray5[i] = SortL(sortedArray5[i]);

                            time5[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                        }
                        stopwatch.Stop();

                    }

                    for (int i = 0; i < val; i++)         //вычисление среднего времени
                    {
                        time0[i] = time0[i] / 20;
                        time1[i] = time1[i] / 20;
                        time2[i] = time2[i] / 20;
                        time3[i] = time3[i] / 20;
                        time4[i] = time4[i] / 20;
                        time5[i] = time5[i] / 20;
                    }

                    for (int i = 0; i < val; i++)             //запись в пары точек
                    {
                        list0.Add(i, time0[i]);
                        list1.Add(i, time1[i]);
                        list2.Add(i, time2[i]);
                        list3.Add(i, time3[i]);
                        list4.Add(i, time4[i]);
                        list5.Add(i, time5[i]);
                    }

                    LineItem l0 = pane.AddCurve("Combine", list0, Color.Blue, SymbolType.None);       //отрисовываем графики
                    LineItem L1 = pane.AddCurve("Pyramid", list1, Color.Red, SymbolType.None);
                    LineItem L2 = pane.AddCurve("Quick", list2, Color.Green, SymbolType.None);
                    LineItem L3 = pane.AddCurve("Merge", list3, Color.Yellow, SymbolType.None);
                    LineItem L4 = pane.AddCurve("Counting", list4, Color.Pink, SymbolType.None);
                    LineItem L5 = pane.AddCurve("Radix", list5, Color.Cyan, SymbolType.None);

                    choose = 3;

                }





            }
            else                  //иначе сообщаем пользователю
            {
                label6.Text = "Сгенерируйте массив";
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void ArrGen_Click(object sender, EventArgs e)   //генерация массивов
        {

            if (ArrGenList.SelectedIndex == 0)          //порядок соответствует группам массивов
            {
                //int[][] mainArray = new int[7][];

                for (int i = 1; i < (val + 1); i++)
                {
                    mainArray[i - 1] = MainArrGen(i);

                }

                for (int i = 0; i < val; i++)
                {
                    for (int j = 0; j < mainArray[i].Length; j++)
                    {
                        richTextBox1.Text += Convert.ToString(mainArray[i][j]);
                        richTextBox1.Text += " ";
                    }
                    richTextBox1.Text += "\n";
                }

                genered = true;
                choose = 0;
            }

            if (ArrGenList.SelectedIndex == 1)
            {

                for (int i = 1; i < (val + 1); i++)
                {
                    mainArray[i - 1] = SubArrGen(i);

                }

                for (int i = 0; i < val; i++)
                {
                    for (int j = 0; j < mainArray[i].Length; j++)
                    {
                        richTextBox1.Text += Convert.ToString(mainArray[i][j]);
                        richTextBox1.Text += " ";
                    }
                    richTextBox1.Text += "\n";
                }

                genered = true;
                choose = 0;
            }

            if (ArrGenList.SelectedIndex == 2)
            {

                for (int i = 1; i < (val + 1); i++)
                {
                    mainArray[i - 1] = OneSwapArrGen(i);

                }

                for (int i = 0; i < val; i++)
                {
                    for (int j = 0; j < mainArray[i].Length; j++)
                    {
                        richTextBox1.Text += Convert.ToString(mainArray[i][j]);
                        richTextBox1.Text += " ";
                    }
                    richTextBox1.Text += "\n";
                }

                genered = true;
                choose = 0;
            }

            if (ArrGenList.SelectedIndex == 3)
            {

                for (int i = 1; i < (val + 1); i++)
                {
                    mainArray[i - 1] = SortForwardArrGen(i);

                }

                for (int i = 0; i < val; i++)
                {
                    for (int j = 0; j < mainArray[i].Length; j++)
                    {
                        richTextBox1.Text += Convert.ToString(mainArray[i][j]);
                        richTextBox1.Text += " ";
                    }
                    richTextBox1.Text += "\n";
                }

                genered = true;
                choose = 0;
            }

            if (ArrGenList.SelectedIndex == 4)
            {

                for (int i = 1; i < (val + 1); i++)
                {
                    mainArray[i - 1] = SortBackwardArrGen(i);

                }

                for (int i = 0; i < val; i++)
                {
                    for (int j = 0; j < mainArray[i].Length; j++)
                    {
                        richTextBox1.Text += Convert.ToString(mainArray[i][j]);
                        richTextBox1.Text += " ";
                    }
                    richTextBox1.Text += "\n";
                }

                genered = true;
                choose = 0;
            }

            if (ArrGenList.SelectedIndex == 5)
            {

                for (int i = 1; i < (val + 1); i++)
                {
                    mainArray[i - 1] = ReplArrGen(i);

                }

                for (int i = 0; i < val; i++)
                {
                    for (int j = 0; j < mainArray[i].Length; j++)
                    {
                        richTextBox1.Text += Convert.ToString(mainArray[i][j]);
                        richTextBox1.Text += " ";
                    }
                    richTextBox1.Text += "\n";
                }

                genered = true;
                choose = 0;
            }

            if (ArrGenList.SelectedIndex == 6)
            {

                for (int i = 1; i < (val + 1); i++)
                {
                    mainArray[i - 1] = RandArrGen(i, Convert.ToInt32(propaBox.Text), Convert.ToInt32(elemBox.Text));

                }

                for (int i = 0; i < val; i++)
                {
                    for (int j = 0; j < mainArray[i].Length; j++)
                    {
                        richTextBox1.Text += Convert.ToString(mainArray[i][j]);
                        richTextBox1.Text += " ";
                    }
                    richTextBox1.Text += "\n";
                }

                genered = true;
                choose = 0;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)        //запись в файл
        {
            StreamWriter file = new StreamWriter("C:/Users/Ower/source/repos/SortsAlgolabs/SortsAlgolabs/TestFile2.txt");

            switch (choose)                                 //зависимость от выбора группы сортировок
            {
                case 1:        

                    file.WriteLine("Array:");

                    for (int i = 0; i < val; i++)
                    {
                        for (int j = 0; j < mainArray[i].Length; j++)
                        {
                            file.Write(Convert.ToString(mainArray[i][j]));
                            file.Write(" ");
                        }
                        file.Write("\n");
                    }

                    file.WriteLine("Bubble:");

                    for (int i = 0; i < val; i++)
                    {
                        for (int j = 0; j < sortedArray0[i].Length; j++)
                        {
                            file.Write(Convert.ToString(sortedArray0[i][j]));
                            file.Write(" ");
                        }

                        file.Write("\n");
                    }

                    file.WriteLine("Insert:");

                    for (int i = 0; i < val; i++)
                    {
                        for (int j = 0; j < sortedArray1[i].Length; j++)
                        {
                            file.Write(Convert.ToString(sortedArray1[i][j]));
                            file.Write(" ");
                        }

                        file.Write("\n");
                    }

                    file.WriteLine("Shaker:");

                    for (int i = 0; i < val; i++)
                    {
                        for (int j = 0; j < sortedArray2[i].Length; j++)
                        {
                            file.Write(Convert.ToString(sortedArray2[i][j]));
                            file.Write(" ");
                        }

                        file.Write("\n");
                    }

                    file.WriteLine("Gnome:");

                    for (int i = 0; i < val; i++)
                    {
                        for (int j = 0; j < sortedArray3[i].Length; j++)
                        {
                            file.Write(Convert.ToString(sortedArray3[i][j]));
                            file.Write(" ");
                        }

                        file.Write("\n");
                    }

                    file.WriteLine("Selection:");

                    for (int i = 0; i < val; i++)
                    {
                        for (int j = 0; j < sortedArray4[i].Length; j++)
                        {
                            file.Write(Convert.ToString(sortedArray4[i][j]));
                            file.Write(" ");
                        }

                        file.Write("\n");
                    }

                    file.Close();

                    break;

                case 2:

                    file.WriteLine("Array:");

                    for (int i = 0; i < val2; i++)
                    {
                        for (int j = 0; j < mainArray[i].Length; j++)
                        {
                            file.Write(Convert.ToString(mainArray[i][j]));
                            file.Write(" ");
                        }
                        file.Write("\n");
                    }

                    file.WriteLine("Bitonic:");

                    for (int i = 0; i < val; i++)
                    {
                        for (int j = 0; j < sortedArray0[i].Length; j++)
                        {
                            file.Write(Convert.ToString(sortedArray0[i][j]));
                            file.Write(" ");
                        }

                        file.Write("\n");
                    }

                    file.WriteLine("Shell:");

                    for (int i = 0; i < val2; i++)
                    {
                        for (int j = 0; j < sortedArray1[i].Length; j++)
                        {
                            file.Write(Convert.ToString(sortedArray1[i][j]));
                            file.Write(" ");
                        }

                        file.Write("\n");
                    }

                    file.WriteLine("Tree:");

                    for (int i = 0; i < val2; i++)
                    {
                        for (int j = 0; j < sortedArray2[i].Length; j++)
                        {
                            file.Write(Convert.ToString(sortedArray2[i][j]));
                            file.Write(" ");
                        }

                        file.Write("\n");
                    }

                    file.Close();

                    break;

                case 3:

                    file.WriteLine("Array:");

                    for (int i = 0; i < val; i++)
                    {
                        for (int j = 0; j < mainArray[i].Length; j++)
                        {
                            file.Write(Convert.ToString(mainArray[i][j]));
                            file.Write(" ");
                        }

                        file.Write("\n");
                    }

                    file.WriteLine("Combination:");

                    for (int i = 0; i < val; i++)
                    {
                        for (int j = 0; j < sortedArray0[i].Length; j++)
                        {
                            file.Write(Convert.ToString(sortedArray0[i][j]));
                            file.Write(" ");
                        }

                        file.Write("\n");
                    }

                    file.WriteLine("Pyramid:");

                    for (int i = 0; i < val; i++)
                    {
                        for (int j = 0; j < sortedArray1[i].Length; j++)
                        {
                            file.Write(Convert.ToString(sortedArray1[i][j]));
                            file.Write(" ");
                        }

                        file.Write("\n");
                    }

                    file.WriteLine("Quick:");

                    for (int i = 0; i < val; i++)
                    {
                        for (int j = 0; j < sortedArray2[i].Length; j++)
                        {
                            file.Write(Convert.ToString(sortedArray2[i][j]));
                            file.Write(" ");
                        }

                        file.Write("\n");
                    }

                    file.WriteLine("Merge:");

                    for (int i = 0; i < val; i++)
                    {
                        for (int j = 0; j < sortedArray3[i].Length; j++)
                        {
                            file.Write(Convert.ToString(sortedArray3[i][j]));
                            file.Write(" ");
                        }

                        file.Write("\n");
                    }

                    file.WriteLine("Counting:");

                    for (int i = 0; i < val; i++)
                    {
                        for (int j = 0; j < sortedArray4[i].Length; j++)
                        {
                            file.Write(Convert.ToString(sortedArray4[i][j]));
                            file.Write(" ");
                        }

                        file.Write("\n");
                    }

                    file.WriteLine("Radix:");

                    for (int i = 0; i < val; i++)
                    {
                        for (int j = 0; j < sortedArray5[i].Length; j++)
                        {
                            file.Write(Convert.ToString(sortedArray5[i][j]));
                            file.Write(" ");
                        }

                        file.Write("\n");
                    }

                    file.Close();

                    break;

                default:

                    file.Close();

                    break;
            }
        }
    }
}




























//if (GroupChoose.SelectedIndex == 0)
//{
//    for (int m = 0; m < 20; m++)
//    {
//        if (GroupChoose.SelectedIndex == 0)
//        {
//            stopwatch.Start();

//            for (int i = 0; i < 4; i++)
//            {
//                sortedArray0[i] = BubbleSort(mainArray[i]);

//                time0[i] += Convert.ToDouble(stopwatch);
//            }

//            for (int i = 0; i < 4; i++)
//            {
//                sortedArray1[i] = InsertionSort(mainArray[i]);

//                time1[i] += Convert.ToDouble(stopwatch);
//            }

//            for (int i = 0; i < 4; i++)
//            {
//                sortedArray2[i] = ShakerSort(mainArray[i]);

//                time2[i] += Convert.ToDouble(stopwatch);
//            }

//            for (int i = 0; i < 4; i++)
//            {
//                sortedArray3[i] = GnomeSort(mainArray[i]);

//                time3[i] += Convert.ToDouble(stopwatch);
//            }

//            for (int i = 0; i < 4; i++)
//            {
//                sortedArray4[i] = SelectionSort(mainArray[i]);

//                time4[i] += Convert.ToDouble(stopwatch);
//            }

//            stopwatch.Stop();
//        }
//    }

//    for (int i = 0; i < 5; i++)         //вычисление среднего времени
//    {
//        time0[i] = time0[i] / 20;
//        time1[i] = time1[i] / 20;
//        time2[i] = time2[i] / 20;
//        time3[i] = time3[i] / 20;
//        time4[i] = time3[i] / 20;
//    }

//    for (int i = 0; i < 5; i++)             //запись в пары точек
//    {
//        list.Add(i, time0[i]);
//        list0.Add(i, time1[i]);
//        list1.Add(i, time2[i]);
//        list2.Add(i, time3[i]);
//        list3.Add(i, time4[i]);
//    }

//    LineItem l0 = pane.AddCurve("Bubble", list, Color.Blue, SymbolType.None);       //отрисовываем графики
//    LineItem L1 = pane.AddCurve("Insertion", list0, Color.Red, SymbolType.None);
//    LineItem L2 = pane.AddCurve("Shaker", list1, Color.Green, SymbolType.None);
//    LineItem L3 = pane.AddCurve("Gnome", list2, Color.Yellow, SymbolType.None);
//    LineItem L4 = pane.AddCurve("Selection", list3, Color.Pink, SymbolType.None);

//    choose = 1;

//}