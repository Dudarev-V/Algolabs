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


//sdvaswedc

namespace SortsAlgolabs
{

    public partial class Form1 : Form
    {

        public class ArrayOps<I>
        {

            public I[][] mainArray { get; set; }           //случайный массив

            public I[][] sortedArray0 { get; set; }        //сортированные массивы от каждого метода
            public I[][] sortedArray1 { get; set; }
            public I[][] sortedArray2 { get; set; }
            public I[][] sortedArray3 { get; set; }
            public I[][] sortedArray4 { get; set; }
            public I[][] sortedArray5 { get; set; }

            public ArrayOps(int val, int val1, int val2)
            {
                mainArray = new I[val][];           //случайный массив

                sortedArray0 = new I[val][];        //сортированные массивы от каждого метода
                sortedArray1 = new I[val][];
                sortedArray2 = new I[val][];
                sortedArray3 = new I[val][];
                sortedArray4 = new I[val][];
                sortedArray5 = new I[val][];

                for (int i = 0; i < val2; i++)                               //инициализация подмассивов
                {
                    sortedArray0[i] = new I[Convert.ToInt32(Math.Pow(10, i + 1))];
                    sortedArray1[i] = new I[Convert.ToInt32(Math.Pow(10, i + 1))];
                    sortedArray2[i] = new I[Convert.ToInt32(Math.Pow(10, i + 1))];
                    sortedArray3[i] = new I[Convert.ToInt32(Math.Pow(10, i + 1))];
                    sortedArray4[i] = new I[Convert.ToInt32(Math.Pow(10, i + 1))];
                    sortedArray5[i] = new I[Convert.ToInt32(Math.Pow(10, i + 1))];
                }


            }


        }





        public class IntComparer : MySorts.Comparer<int>
        {
            public override int Compare(int a, int b)
            {
                return a - b;
            }
        }

        public class DoubleComparer : MySorts.Comparer<double>
        {
            public override int Compare(double a, double b)
            {
                return Convert.ToInt32(a - b);
            }
        }

        public class CharComparer : MySorts.Comparer<char>
        {
            public override int Compare(char a, char b)
            {
                return Convert.ToInt32(a) - Convert.ToInt32(b);
            }
        }




        static int val = 3;    // максимальная степень длины массива
        static int val1 = 3;
        static int val2 = 3;

        //int[][] mainArrayint = new int[val][];           //случайный массив

        //int[][] sortedArray0int = new int[val][];        //сортированные массивы от каждого метода
        //int[][] sortedArray1int = new int[val][];
        //int[][] sortedArray2int = new int[val][];
        //int[][] sortedArray3int = new int[val][];
        //int[][] sortedArray4int = new int[val][];
        //int[][] sortedArray5int = new int[val][];

        //double[][] mainArraydouble = new double[val][];           //случайный массив

        //double[][] sortedArray0int = new double[val][];        //сортированные массивы от каждого метода
        //double[][] sortedArray1int = new double[val][];
        //int[][] sortedArray2int = new int[val][];
        //int[][] sortedArray3int = new int[val][];
        //int[][] sortedArray4int = new int[val][];
        //int[][] sortedArray5int = new int[val][];

        //int[][] mainArrayint = new int[val][];           //случайный массив

        //int[][] sortedArray0int = new int[val][];        //сортированные массивы от каждого метода
        //int[][] sortedArray1int = new int[val][];
        //int[][] sortedArray2int = new int[val][];
        //int[][] sortedArray3int = new int[val][];
        //int[][] sortedArray4int = new int[val][];
        //int[][] sortedArray5int = new int[val][];

        static IntComparer IntComparator = new IntComparer();
        static DoubleComparer DoubleComparator = new DoubleComparer();
        static CharComparer CharComparator = new CharComparer();

        public ArrayOps<int> ArrayInt = new ArrayOps<int>(val, val1, val2);
        public ArrayOps<double> ArrayDouble = new ArrayOps<double>(val, val1, val2);
        ArrayOps<char> ArrayChar = new ArrayOps<char>(val, val1, val2);

        int choose = 0;  //выбор для записи в файл

        public Form1()
        {
            InitializeComponent();

            //int[] arr = new int { 1, 7, 3, 8, 2, 6, 9 };

        }


        bool genered = false;


        private void ArrTest_Click(object sender, EventArgs e)
        {
            MySorts.MySorts<int> IntSorts = new MySorts.MySorts<int>(IntComparator);
            MySorts.MySorts<double> DoubleSorts = new MySorts.MySorts<double>(DoubleComparator);
            MySorts.MySorts<char> CharSorts = new MySorts.MySorts<char>(CharComparator);


            label6.Text = "";                   

            if (genered)                                //если массив сгенерен
            {
                

                double[] time0 = new double[val + 1];            //среднее время для каждого размера
                double[] time1 = new double[val + 1];
                double[] time2 = new double[val + 1];
                double[] time3 = new double[val + 1];
                double[] time4 = new double[val + 1];
                double[] time5 = new double[val + 1];


                Stopwatch stopwatch = new Stopwatch();          //счетчик времени

                GraphPane pane = zedGraphControl1.GraphPane;        //иниц. координат

                pane.CurveList.Clear(); 

                PointPairList list5 = new PointPairList();       //пары точек для каждого массива
                PointPairList list0 = new PointPairList();
                PointPairList list1 = new PointPairList();
                PointPairList list2 = new PointPairList();
                PointPairList list3 = new PointPairList();
                PointPairList list4 = new PointPairList();

                time0[0] = 0;
                time1[0] = 0;
                time2[0] = 0;
                time3[0] = 0;
                time4[0] = 0;
                time5[0] = 0;

                int type = Convert.ToInt32(TypeChoose.SelectedIndex);

                switch (type)
                {
                    case 0:
                        if (GroupChoose.SelectedIndex == 0)
                        {
                            for (int m = 0; m < 20; m++)
                            {

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayInt.mainArray[i], ArrayInt.sortedArray0[i], ArrayInt.mainArray[i].Length);

                                    ArrayInt.sortedArray0[i] = IntSorts.BubbleSort(ArrayInt.sortedArray0[i]);

                                    time0[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayInt.mainArray[i], ArrayInt.sortedArray1[i], ArrayInt.mainArray[i].Length);

                                    ArrayInt.sortedArray1[i] = IntSorts.InsertionSort(ArrayInt.sortedArray1[i]);

                                    time1[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayInt.mainArray[i], ArrayInt.sortedArray2[i], ArrayInt.mainArray[i].Length);

                                    ArrayInt.sortedArray2[i] = IntSorts.ShakerSort(ArrayInt.sortedArray2[i]);

                                    time2[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayInt.mainArray[i], ArrayInt.sortedArray3[i], ArrayInt.mainArray[i].Length);

                                    ArrayInt.sortedArray3[i] = IntSorts.GnomeSort(ArrayInt.sortedArray3[i]);

                                    time3[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayInt.mainArray[i], ArrayInt.sortedArray4[i], ArrayInt.mainArray[i].Length);

                                    ArrayInt.sortedArray4[i] = IntSorts.SelectionSort(ArrayInt.sortedArray4[i]);

                                    time4[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                            }

                            for (int i = 1; i < val + 1; i++)         //вычисление среднего времени
                            {
                                time0[i] = time0[i] / 20;
                                time1[i] = time1[i] / 20;
                                time2[i] = time2[i] / 20;
                                time3[i] = time3[i] / 20;
                                time4[i] = time4[i] / 20;
                            }

                            list0.Add(0, time0[0]);
                            list1.Add(0, time1[0]);
                            list2.Add(0, time2[0]);
                            list3.Add(0, time3[0]);
                            list4.Add(0, time4[0]);

                            for (int i = 1; i < val + 1; i++)             //запись в пары точек
                            {
                                list0.Add(i, time0[i]);
                                list1.Add(i, time1[i]);
                                list2.Add(i, time2[i]);
                                list3.Add(i, time3[i]);
                                list4.Add(i, time4[i]);
                            }

                            LineItem l0 = pane.AddCurve("Пузырь", list0, Color.Blue, SymbolType.None);       //отрисовываем графики
                            LineItem L1 = pane.AddCurve("Вставки", list1, Color.Red, SymbolType.None);
                            LineItem L2 = pane.AddCurve("Шейкерная", list2, Color.Green, SymbolType.None);
                            LineItem L3 = pane.AddCurve("Гномья", list3, Color.Yellow, SymbolType.None);
                            LineItem L4 = pane.AddCurve("Выбором", list4, Color.Pink, SymbolType.None);

                            choose = 1;

                            pane.XAxis.Scale.Min = 0;
                            pane.XAxis.Scale.Max = 3;
                        }

                        if (GroupChoose.SelectedIndex == 1)
                        {
                            for (int m = 0; m < 20; m++)
                            {

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayInt.mainArray[i], ArrayInt.sortedArray1[i], ArrayInt.mainArray[i].Length);

                                    ArrayInt.sortedArray1[i] = IntSorts.ShellSort(ArrayInt.sortedArray1[i]);

                                    time1[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayInt.mainArray[i], ArrayInt.sortedArray2[i], ArrayInt.mainArray[i].Length);

                                    ArrayInt.sortedArray2[i] = IntSorts.TreeSort(ArrayInt.sortedArray2[i]);

                                    time2[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();
                            }

                            for (int i = 1; i < val + 1; i++)         //вычисление среднего времени
                            {
                                time0[i] = time0[i] / 20;
                                time1[i] = time1[i] / 20;
                                time2[i] = time2[i] / 20;
                            }


                            list1.Add(0, time1[0]);
                            list2.Add(0, time2[0]);

                            for (int i = 1; i < val + 1; i++)             //запись в пары точек
                            {
                                list1.Add(i, time1[i]);
                                list2.Add(i, time2[i]);
                            }

       //отрисовываем графики
                            LineItem L1 = pane.AddCurve("Шелла", list1, Color.Red, SymbolType.None);
                            LineItem L2 = pane.AddCurve("Деревом", list2, Color.Green, SymbolType.None);

                            pane.XAxis.Scale.Min = 0;
                            pane.XAxis.Scale.Max = 3;

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

                                    Array.Copy(ArrayInt.mainArray[i], ArrayInt.sortedArray0[i], ArrayInt.mainArray[i].Length);

                                    ArrayInt.sortedArray0[i] = IntSorts.CombSort(ArrayInt.sortedArray0[i]);

                                    time0[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val2; i++)
                                {
                                    Array.Copy(ArrayInt.mainArray[i], ArrayInt.sortedArray1[i], ArrayInt.mainArray[i].Length);

                                    IntSorts.PyramidSort(ArrayInt.sortedArray1[i], ArrayInt.sortedArray1[i].Length);

                                    time1[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val2; i++)
                                {
                                    Array.Copy(ArrayInt.mainArray[i], ArrayInt.sortedArray2[i], ArrayInt.mainArray[i].Length);

                                    IntSorts.QuickSort(ArrayInt.sortedArray2[i], 0, ArrayInt.sortedArray2[i].Length - 1);

                                    time2[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val2; i++)
                                {
                                    Array.Copy(ArrayInt.mainArray[i], ArrayInt.sortedArray3[i], ArrayInt.mainArray[i].Length);

                                    ArrayInt.sortedArray3[i] = IntSorts.MergeSort(ArrayInt.sortedArray3[i], 0, ArrayInt.mainArray[i].Length - 1);

                                    time3[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();


                            }

                            for (int i = 1; i < val + 1; i++)         //вычисление среднего времени
                            {
                                time0[i] = time0[i] / 20;
                                time1[i] = time1[i] / 20;
                                time2[i] = time2[i] / 20;
                                time3[i] = time3[i] / 20;
                                time4[i] = time4[i] / 20;
                                time5[i] = time5[i] / 20;
                            }

                            list0.Add(0, time0[0]);
                            list1.Add(0, time1[0]);
                            list2.Add(0, time2[0]);
                            list3.Add(0, time3[0]);

                            for (int i = 1; i < val + 1; i++)             //запись в пары точек
                            {
                                list0.Add(i, time0[i]);
                                list1.Add(i, time1[i]);
                                list2.Add(i, time2[i]);
                                list3.Add(i, time3[i]);
                            }

                            LineItem l0 = pane.AddCurve("Расческой", list0, Color.Blue, SymbolType.None);       //отрисовываем графики
                            LineItem L1 = pane.AddCurve("Пирамидальная", list1, Color.Red, SymbolType.None);
                            LineItem L2 = pane.AddCurve("Быстрая", list2, Color.Green, SymbolType.None);
                            LineItem L3 = pane.AddCurve("Слиянием", list3, Color.Yellow, SymbolType.None);

                            pane.XAxis.Scale.Min = 0;
                            pane.XAxis.Scale.Max = 3;

                            choose = 3;

                        }
                        break;

                        case 1:

                        if (GroupChoose.SelectedIndex == 0)
                        {
                            for (int m = 0; m < 20; m++)
                            {

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayDouble.mainArray[i], ArrayDouble.sortedArray0[i], ArrayDouble.mainArray[i].Length);

                                    ArrayDouble.sortedArray0[i] = DoubleSorts.BubbleSort(ArrayDouble.sortedArray0[i]);

                                    time0[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayDouble.mainArray[i], ArrayDouble.sortedArray1[i], ArrayDouble.mainArray[i].Length);

                                    ArrayDouble.sortedArray1[i] = DoubleSorts.InsertionSort(ArrayDouble.sortedArray1[i]);

                                    time1[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayDouble.mainArray[i], ArrayDouble.sortedArray2[i], ArrayDouble.mainArray[i].Length);

                                    ArrayDouble.sortedArray2[i] = DoubleSorts.ShakerSort(ArrayDouble.sortedArray2[i]);

                                    time2[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayDouble.mainArray[i], ArrayDouble.sortedArray3[i], ArrayDouble.mainArray[i].Length);

                                    ArrayDouble.sortedArray3[i] = DoubleSorts.GnomeSort(ArrayDouble.sortedArray3[i]);

                                    time3[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayDouble.mainArray[i], ArrayDouble.sortedArray4[i], ArrayDouble.mainArray[i].Length);

                                    ArrayDouble.sortedArray4[i] = DoubleSorts.SelectionSort(ArrayDouble.sortedArray4[i]);

                                    time4[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                            }

                            for (int i = 1; i < val + 1; i++)         //вычисление среднего времени
                            {
                                time0[i] = time0[i] / 20;
                                time1[i] = time1[i] / 20;
                                time2[i] = time2[i] / 20;
                                time3[i] = time3[i] / 20;
                                time4[i] = time4[i] / 20;
                            }

                            list0.Add(0, time0[0]);
                            list1.Add(0, time1[0]);
                            list2.Add(0, time2[0]);
                            list3.Add(0, time3[0]);
                            list4.Add(0, time4[0]);

                            for (int i = 1; i < val + 1; i++)             //запись в пары точек
                            {
                                list0.Add(i, time0[i]);
                                list1.Add(i, time1[i]);
                                list2.Add(i, time2[i]);
                                list3.Add(i, time3[i]);
                                list4.Add(i, time4[i]);
                            }

                            LineItem l0 = pane.AddCurve("Пузырь", list0, Color.Blue, SymbolType.None);       //отрисовываем графики
                            LineItem L1 = pane.AddCurve("Вставки", list1, Color.Red, SymbolType.None);
                            LineItem L2 = pane.AddCurve("Шейкерная", list2, Color.Green, SymbolType.None);
                            LineItem L3 = pane.AddCurve("Гномья", list3, Color.Yellow, SymbolType.None);
                            LineItem L4 = pane.AddCurve("Выбором", list4, Color.Pink, SymbolType.None);

                            choose = 1;

                            pane.XAxis.Scale.Min = 0;
                            pane.XAxis.Scale.Max = 3;
                        }

                        if (GroupChoose.SelectedIndex == 1)
                        {
                            for (int m = 0; m < 20; m++)
                            {

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayDouble.mainArray[i], ArrayDouble.sortedArray1[i], ArrayDouble.mainArray[i].Length);

                                    ArrayDouble.sortedArray1[i] = DoubleSorts.ShellSort(ArrayDouble.sortedArray1[i]);

                                    time1[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayDouble.mainArray[i], ArrayDouble.sortedArray2[i], ArrayDouble.mainArray[i].Length);

                                    ArrayDouble.sortedArray2[i] = DoubleSorts.TreeSort(ArrayDouble.sortedArray2[i]);

                                    time2[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();
                            }

                            for (int i = 1; i < val + 1; i++)         //вычисление среднего времени
                            {
                                time0[i] = time0[i] / 20;
                                time1[i] = time1[i] / 20;
                                time2[i] = time2[i] / 20;
                            }


                            list1.Add(0, time1[0]);
                            list2.Add(0, time2[0]);

                            for (int i = 1; i < val + 1; i++)             //запись в пары точек
                            {
                                list1.Add(i, time1[i]);
                                list2.Add(i, time2[i]);
                            }

                            //отрисовываем графики
                            LineItem L1 = pane.AddCurve("Шелла", list1, Color.Red, SymbolType.None);
                            LineItem L2 = pane.AddCurve("Деревом", list2, Color.Green, SymbolType.None);

                            pane.XAxis.Scale.Min = 0;
                            pane.XAxis.Scale.Max = 3;

                            choose = 2;

                        }

                        if (GroupChoose.SelectedIndex == 2)
                        {
                            for (int m = 0; m < 20; m++)
                            {

                                stopwatch.Start();
                                for (int i = 0; i < val2; i++)
                                {
                                    Array.Copy(ArrayDouble.mainArray[i], ArrayDouble.sortedArray0[i], ArrayDouble.mainArray[i].Length);

                                    ArrayDouble.sortedArray0[i] = DoubleSorts.CombSort(ArrayDouble.sortedArray0[i]);

                                    time0[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val2; i++)
                                {
                                    Array.Copy(ArrayDouble.mainArray[i], ArrayDouble.sortedArray1[i], ArrayDouble.mainArray[i].Length);

                                    DoubleSorts.PyramidSort(ArrayDouble.sortedArray1[i], ArrayDouble.sortedArray1[i].Length);

                                    time1[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val2; i++)
                                {
                                    Array.Copy(ArrayDouble.mainArray[i], ArrayDouble.sortedArray2[i], ArrayDouble.mainArray[i].Length);

                                    DoubleSorts.QuickSort(ArrayDouble.sortedArray2[i], 0, ArrayDouble.sortedArray2[i].Length - 1);

                                    time2[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val2; i++)
                                {
                                    Array.Copy(ArrayDouble.mainArray[i], ArrayDouble.sortedArray3[i], ArrayDouble.mainArray[i].Length);

                                    ArrayDouble.sortedArray3[i] = DoubleSorts.MergeSort(ArrayDouble.sortedArray3[i], 0, ArrayDouble.mainArray[i].Length - 1);

                                    time3[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();


                            }

                            for (int i = 1; i < val + 1; i++)         //вычисление среднего времени
                            {
                                time0[i] = time0[i] / 20;
                                time1[i] = time1[i] / 20;
                                time2[i] = time2[i] / 20;
                                time3[i] = time3[i] / 20;
                                time4[i] = time4[i] / 20;
                                time5[i] = time5[i] / 20;
                            }

                            list0.Add(0, time0[0]);
                            list1.Add(0, time1[0]);
                            list2.Add(0, time2[0]);
                            list3.Add(0, time3[0]);

                            for (int i = 1; i < val + 1; i++)             //запись в пары точек
                            {
                                list0.Add(i, time0[i]);
                                list1.Add(i, time1[i]);
                                list2.Add(i, time2[i]);
                                list3.Add(i, time3[i]);
                            }

                            LineItem l0 = pane.AddCurve("Расческой", list0, Color.Blue, SymbolType.None);       //отрисовываем графики
                            LineItem L1 = pane.AddCurve("Пирамидальная", list1, Color.Red, SymbolType.None);
                            LineItem L2 = pane.AddCurve("Быстрая", list2, Color.Green, SymbolType.None);
                            LineItem L3 = pane.AddCurve("Слиянием", list3, Color.Yellow, SymbolType.None);

                            pane.XAxis.Scale.Min = 0;
                            pane.XAxis.Scale.Max = 3;

                            choose = 3;

                        }

                        break;


                        case 2:

                        if (GroupChoose.SelectedIndex == 0)
                        {
                            for (int m = 0; m < 20; m++)
                            {

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayChar.mainArray[i], ArrayChar.sortedArray0[i], ArrayChar.mainArray[i].Length);

                                    ArrayChar.sortedArray0[i] = CharSorts.BubbleSort(ArrayChar.sortedArray0[i]);

                                    time0[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayChar.mainArray[i], ArrayChar.sortedArray1[i], ArrayChar.mainArray[i].Length);

                                    ArrayChar.sortedArray1[i] = CharSorts.InsertionSort(ArrayChar.sortedArray1[i]);

                                    time1[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayChar.mainArray[i], ArrayChar.sortedArray2[i], ArrayChar.mainArray[i].Length);

                                    ArrayChar.sortedArray2[i] = CharSorts.ShakerSort(ArrayChar.sortedArray2[i]);

                                    time2[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayChar.mainArray[i], ArrayChar.sortedArray3[i], ArrayChar.mainArray[i].Length);

                                    ArrayChar.sortedArray3[i] = CharSorts.GnomeSort(ArrayChar.sortedArray3[i]);

                                    time3[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayChar.mainArray[i], ArrayChar.sortedArray4[i], ArrayChar.mainArray[i].Length);

                                    ArrayChar.sortedArray4[i] = CharSorts.SelectionSort(ArrayChar.sortedArray4[i]);

                                    time4[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                            }

                            for (int i = 1; i < val + 1; i++)         //вычисление среднего времени
                            {
                                time0[i] = time0[i] / 20;
                                time1[i] = time1[i] / 20;
                                time2[i] = time2[i] / 20;
                                time3[i] = time3[i] / 20;
                                time4[i] = time4[i] / 20;
                            }

                            list0.Add(0, time0[0]);
                            list1.Add(0, time1[0]);
                            list2.Add(0, time2[0]);
                            list3.Add(0, time3[0]);
                            list4.Add(0, time4[0]);

                            for (int i = 1; i < val + 1; i++)             //запись в пары точек
                            {
                                list0.Add(i, time0[i]);
                                list1.Add(i, time1[i]);
                                list2.Add(i, time2[i]);
                                list3.Add(i, time3[i]);
                                list4.Add(i, time4[i]);
                            }

                            LineItem l0 = pane.AddCurve("Пузырь", list0, Color.Blue, SymbolType.None);       //отрисовываем графики
                            LineItem L1 = pane.AddCurve("Вставки", list1, Color.Red, SymbolType.None);
                            LineItem L2 = pane.AddCurve("Шейкерная", list2, Color.Green, SymbolType.None);
                            LineItem L3 = pane.AddCurve("Гномья", list3, Color.Yellow, SymbolType.None);
                            LineItem L4 = pane.AddCurve("Выбором", list4, Color.Pink, SymbolType.None);

                            choose = 1;

                            pane.XAxis.Scale.Min = 0;
                            pane.XAxis.Scale.Max = 3;
                        }

                        if (GroupChoose.SelectedIndex == 1)
                        {
                            for (int m = 0; m < 20; m++)
                            {

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayChar.mainArray[i], ArrayChar.sortedArray1[i], ArrayChar.mainArray[i].Length);

                                    ArrayChar.sortedArray1[i] = CharSorts.ShellSort(ArrayChar.sortedArray1[i]);

                                    time1[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val1; i++)
                                {
                                    Array.Copy(ArrayChar.mainArray[i], ArrayChar.sortedArray2[i], ArrayChar.mainArray[i].Length);

                                    ArrayChar.sortedArray2[i] = CharSorts.TreeSort(ArrayChar.sortedArray2[i]);

                                    time2[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();
                            }

                            for (int i = 1; i < val + 1; i++)         //вычисление среднего времени
                            {
                                time0[i] = time0[i] / 20;
                                time1[i] = time1[i] / 20;
                                time2[i] = time2[i] / 20;
                            }


                            list1.Add(0, time1[0]);
                            list2.Add(0, time2[0]);

                            for (int i = 1; i < val + 1; i++)             //запись в пары точек
                            {
                                list1.Add(i, time1[i]);
                                list2.Add(i, time2[i]);
                            }

                            //отрисовываем графики
                            LineItem L1 = pane.AddCurve("Шелла", list1, Color.Red, SymbolType.None);
                            LineItem L2 = pane.AddCurve("Деревом", list2, Color.Green, SymbolType.None);

                            pane.XAxis.Scale.Min = 0;
                            pane.XAxis.Scale.Max = 3;

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

                                    Array.Copy(ArrayChar.mainArray[i], ArrayChar.sortedArray0[i], ArrayChar.mainArray[i].Length);

                                    ArrayChar.sortedArray0[i] = CharSorts.CombSort(ArrayChar.sortedArray0[i]);

                                    time0[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val2; i++)
                                {
                                    Array.Copy(ArrayChar.mainArray[i], ArrayChar.sortedArray1[i], ArrayChar.mainArray[i].Length);

                                    CharSorts.PyramidSort(ArrayChar.sortedArray1[i], ArrayChar.sortedArray1[i].Length);

                                    time1[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val2; i++)
                                {
                                    Array.Copy(ArrayChar.mainArray[i], ArrayChar.sortedArray2[i], ArrayChar.mainArray[i].Length);

                                    CharSorts.QuickSort(ArrayChar.sortedArray2[i], 0, ArrayChar.sortedArray2[i].Length - 1);

                                    time2[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();

                                stopwatch.Start();
                                for (int i = 0; i < val2; i++)
                                {
                                    Array.Copy(ArrayChar.mainArray[i], ArrayChar.sortedArray3[i], ArrayChar.mainArray[i].Length);

                                    ArrayChar.sortedArray3[i] = CharSorts.MergeSort(ArrayChar.sortedArray3[i], 0, ArrayChar.mainArray[i].Length - 1);

                                    time3[i + 1] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                                }
                                stopwatch.Stop();


                            }

                            for (int i = 1; i < val + 1; i++)         //вычисление среднего времени
                            {
                                time0[i] = time0[i] / 20;
                                time1[i] = time1[i] / 20;
                                time2[i] = time2[i] / 20;
                                time3[i] = time3[i] / 20;
                                time4[i] = time4[i] / 20;
                                time5[i] = time5[i] / 20;
                            }

                            list0.Add(0, time0[0]);
                            list1.Add(0, time1[0]);
                            list2.Add(0, time2[0]);
                            list3.Add(0, time3[0]);

                            for (int i = 1; i < val + 1; i++)             //запись в пары точек
                            {
                                list0.Add(i, time0[i]);
                                list1.Add(i, time1[i]);
                                list2.Add(i, time2[i]);
                                list3.Add(i, time3[i]);
                            }

                            LineItem l0 = pane.AddCurve("Расческой", list0, Color.Blue, SymbolType.None);       //отрисовываем графики
                            LineItem L1 = pane.AddCurve("Пирамидальная", list1, Color.Red, SymbolType.None);
                            LineItem L2 = pane.AddCurve("Быстрая", list2, Color.Green, SymbolType.None);
                            LineItem L3 = pane.AddCurve("Слиянием", list3, Color.Yellow, SymbolType.None);

                            pane.XAxis.Scale.Min = 0;
                            pane.XAxis.Scale.Max = 3;

                            choose = 3;

                        }

                        break;



















                    default:
                        break;
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
            int type = Convert.ToInt32(TypeChoose.SelectedIndex);


            switch (type)
            {
                case 0:
                    if (ArrGenList.SelectedIndex == 0)          //порядок соответствует группам массивов
                    {
                        for (int i = 1; i < (val + 1); i++)
                        {
                            ArrayInt.mainArray[i - 1] = MyGens.ArrGensInt.MainArrGen(i);
                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayInt.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayInt.mainArray[i][j]);
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
                            ArrayInt.mainArray[i - 1] = MyGens.ArrGensInt.SubArrGen(i);

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayInt.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayInt.mainArray[i][j]);
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
                            ArrayInt.mainArray[i - 1] = MyGens.ArrGensInt.OneSwapArrGen(i);

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayInt.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayInt.mainArray[i][j]);
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
                            ArrayInt.mainArray[i - 1] = MyGens.ArrGensInt.SortForwardArrGen(i);

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayInt.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayInt.mainArray[i][j]);
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
                            ArrayInt.mainArray[i - 1] = MyGens.ArrGensInt.SortBackwardArrGen(i);

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayInt.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayInt.mainArray[i][j]);
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
                            ArrayInt.mainArray[i - 1] = MyGens.ArrGensInt.ReplArrGen(i);

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayInt.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayInt.mainArray[i][j]);
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
                            ArrayInt.mainArray[i - 1] = MyGens.ArrGensInt.RandArrGen(i, Convert.ToInt32(propaBox.Text), Convert.ToInt32(elemBox.Text));

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayInt.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayInt.mainArray[i][j]);
                                richTextBox1.Text += " ";
                            }
                            richTextBox1.Text += "\n";
                        }

                        genered = true;
                        choose = 0;
                    }
                    break;

                case 1:
                    if (ArrGenList.SelectedIndex == 0)          //порядок соответствует группам массивов
                    {
                        for (int i = 1; i < (val + 1); i++)
                        {
                            ArrayDouble.mainArray[i - 1] = MyGens.ArrGensDouble.MainArrGen(i);
                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayDouble.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += ArrayDouble.mainArray[i][j].ToString();
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
                            ArrayDouble.mainArray[i - 1] = MyGens.ArrGensDouble.SubArrGen(i);

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayDouble.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayDouble.mainArray[i][j]);
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
                            ArrayDouble.mainArray[i - 1] = MyGens.ArrGensDouble.OneSwapArrGen(i);

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayDouble.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayDouble.mainArray[i][j]);
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
                            ArrayDouble.mainArray[i - 1] = MyGens.ArrGensDouble.SortForwardArrGen(i);

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayDouble.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayDouble.mainArray[i][j]);
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
                            ArrayDouble.mainArray[i - 1] = MyGens.ArrGensDouble.SortBackwardArrGen(i);

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayDouble.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayDouble.mainArray[i][j]);
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
                            ArrayDouble.mainArray[i - 1] = MyGens.ArrGensDouble.ReplArrGen(i);

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayDouble.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayDouble.mainArray[i][j]);
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
                            ArrayDouble.mainArray[i - 1] = MyGens.ArrGensDouble.RandArrGen(i, Convert.ToInt32(propaBox.Text), Convert.ToDouble(elemBox.Text));

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayDouble.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayDouble.mainArray[i][j]);
                                richTextBox1.Text += " ";
                            }
                            richTextBox1.Text += "\n";
                        }

                        genered = true;
                        choose = 0;
                    }
                    break;

                case 2:
                    if (ArrGenList.SelectedIndex == 0)          //порядок соответствует группам массивов
                    {
                        for (int i = 1; i < (val + 1); i++)
                        {
                            ArrayChar.mainArray[i - 1] = MyGens.ArrGensChar.MainArrGen(i);
                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayChar.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayChar.mainArray[i][j]);
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
                            ArrayChar.mainArray[i - 1] = MyGens.ArrGensChar.SubArrGen(i);

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayChar.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayChar.mainArray[i][j]);
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
                            ArrayChar.mainArray[i - 1] = MyGens.ArrGensChar.OneSwapArrGen(i);

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayChar.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayChar.mainArray[i][j]);
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
                            ArrayChar.mainArray[i - 1] = MyGens.ArrGensChar.SortForwardArrGen(i);

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayChar.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayChar.mainArray[i][j]);
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
                            ArrayChar.mainArray[i - 1] = MyGens.ArrGensChar.SortBackwardArrGen(i);

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayChar.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayChar.mainArray[i][j]);
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
                            ArrayChar.mainArray[i - 1] = MyGens.ArrGensChar.ReplArrGen(i);

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayChar.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayChar.mainArray[i][j]);
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
                            ArrayChar.mainArray[i - 1] = MyGens.ArrGensChar.RandArrGen(i, Convert.ToInt32(propaBox.Text), Convert.ToChar(elemBox.Text));

                        }

                        for (int i = 0; i < val; i++)
                        {
                            for (int j = 0; j < ArrayChar.mainArray[i].Length; j++)
                            {
                                richTextBox1.Text += Convert.ToString(ArrayChar.mainArray[i][j]);
                                richTextBox1.Text += " ";
                            }
                            richTextBox1.Text += "\n";
                        }

                        genered = true;
                        choose = 0;
                    }
                    break;





                default:
                    break;
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
            //StreamWriter file = new StreamWriter("C:/Users/Ower/source/repos/SortsAlgolabs/SortsAlgolabs/TestFile2.txt");

            //switch (choose)                                 //зависимость от выбора группы сортировок
            //{
            //    case 1:

            //        file.WriteLine("Array:");

            //        for (int i = 0; i < val; i++)
            //        {
            //            for (int j = 0; j < mainArray[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(mainArray[i][j]));
            //                file.Write(" ");
            //            }
            //            file.Write("\n");
            //        }

            //        file.WriteLine("Bubble:");

            //        for (int i = 0; i < val; i++)
            //        {
            //            for (int j = 0; j < sortedArray0[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(sortedArray0[i][j]));
            //                file.Write(" ");
            //            }

            //            file.Write("\n");
            //        }

            //        file.WriteLine("Insert:");

            //        for (int i = 0; i < val; i++)
            //        {
            //            for (int j = 0; j < sortedArray1[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(sortedArray1[i][j]));
            //                file.Write(" ");
            //            }

            //            file.Write("\n");
            //        }

            //        file.WriteLine("Shaker:");

            //        for (int i = 0; i < val; i++)
            //        {
            //            for (int j = 0; j < sortedArray2[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(sortedArray2[i][j]));
            //                file.Write(" ");
            //            }

            //            file.Write("\n");
            //        }

            //        file.WriteLine("Gnome:");

            //        for (int i = 0; i < val; i++)
            //        {
            //            for (int j = 0; j < sortedArray3[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(sortedArray3[i][j]));
            //                file.Write(" ");
            //            }

            //            file.Write("\n");
            //        }

            //        file.WriteLine("Selection:");

            //        for (int i = 0; i < val; i++)
            //        {
            //            for (int j = 0; j < sortedArray4[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(sortedArray4[i][j]));
            //                file.Write(" ");
            //            }

            //            file.Write("\n");
            //        }

            //        file.Close();

            //        break;

            //    case 2:

            //        file.WriteLine("Array:");

            //        for (int i = 0; i < val2; i++)
            //        {
            //            for (int j = 0; j < mainArray[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(mainArray[i][j]));
            //                file.Write(" ");
            //            }
            //            file.Write("\n");
            //        }

            //        file.WriteLine("Bitonic:");

            //        for (int i = 0; i < val; i++)
            //        {
            //            for (int j = 0; j < sortedArray0[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(sortedArray0[i][j]));
            //                file.Write(" ");
            //            }

            //            file.Write("\n");
            //        }

            //        file.WriteLine("Shell:");

            //        for (int i = 0; i < val2; i++)
            //        {
            //            for (int j = 0; j < sortedArray1[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(sortedArray1[i][j]));
            //                file.Write(" ");
            //            }

            //            file.Write("\n");
            //        }

            //        file.WriteLine("Tree:");

            //        for (int i = 0; i < val2; i++)
            //        {
            //            for (int j = 0; j < sortedArray2[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(sortedArray2[i][j]));
            //                file.Write(" ");
            //            }

            //            file.Write("\n");
            //        }

            //        file.Close();

            //        break;

            //    case 3:

            //        file.WriteLine("Array:");

            //        for (int i = 0; i < val; i++)
            //        {
            //            for (int j = 0; j < mainArray[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(mainArray[i][j]));
            //                file.Write(" ");
            //            }

            //            file.Write("\n");
            //        }

            //        file.WriteLine("Combination:");

            //        for (int i = 0; i < val; i++)
            //        {
            //            for (int j = 0; j < sortedArray0[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(sortedArray0[i][j]));
            //                file.Write(" ");
            //            }

            //            file.Write("\n");
            //        }

            //        file.WriteLine("Pyramid:");

            //        for (int i = 0; i < val; i++)
            //        {
            //            for (int j = 0; j < sortedArray1[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(sortedArray1[i][j]));
            //                file.Write(" ");
            //            }

            //            file.Write("\n");
            //        }

            //        file.WriteLine("Quick:");

            //        for (int i = 0; i < val; i++)
            //        {
            //            for (int j = 0; j < sortedArray2[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(sortedArray2[i][j]));
            //                file.Write(" ");
            //            }

            //            file.Write("\n");
            //        }

            //        file.WriteLine("Merge:");

            //        for (int i = 0; i < val; i++)
            //        {
            //            for (int j = 0; j < sortedArray3[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(sortedArray3[i][j]));
            //                file.Write(" ");
            //            }

            //            file.Write("\n");
            //        }

            //        file.WriteLine("Counting:");

            //        for (int i = 0; i < val; i++)
            //        {
            //            for (int j = 0; j < sortedArray4[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(sortedArray4[i][j]));
            //                file.Write(" ");
            //            }

            //            file.Write("\n");
            //        }

            //        file.WriteLine("Radix:");

            //        for (int i = 0; i < val; i++)
            //        {
            //            for (int j = 0; j < sortedArray5[i].Length; j++)
            //            {
            //                file.Write(Convert.ToString(sortedArray5[i][j]));
            //                file.Write(" ");
            //            }

            //            file.Write("\n");
            //        }

            //        file.Close();

            //        break;

            //    default:

            //        file.Close();

            //        break;
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GraphPane pane = zedGraphControl1.GraphPane;

            pane.Title.Text = "Графики зависимости скорости сортировок от размера массива";
            pane.XAxis.Title.Text = "Размер массива [в элементах (степени числа 10)]";
            pane.YAxis.Title.Text = "Скорость выполнения [в миллисекундах]";
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