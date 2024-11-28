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

namespace ListCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static void Gen(ref MyArrayList.MyArrayList<int> Array, ref MyLinkedList.MyLinkedList<int> List, int size)
        {
            Random rand = new Random(((int)DateTime.Now.Ticks));

            for (int i = 0; i < Math.Pow(10, size) + 2; i++)
            {
                Array.Add(rand.Next(0, 42));
                List.Add(rand.Next(0, 42));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GraphPane pane = zedGraphControl1.GraphPane;

            pane.Title.Text = "Графики зависимости скорости выполнения от количества операций";
            pane.XAxis.Title.Text = "Операции [количество (степени числа 10)]";
            pane.YAxis.Title.Text = "Скорость выполнения [в миллисекундах]";
        }

        private void ComputeButton_Click(object sender, EventArgs e)
        {
            MyArrayList.MyArrayList<int> Array = new MyArrayList.MyArrayList<int>();
            MyLinkedList.MyLinkedList<int> List = new MyLinkedList.MyLinkedList<int>();

            int minSize = 1;
            int maxSize = 4;

            double[] arrayTime = new double[maxSize + 1];
            double[] listTime = new double[maxSize + 1];

            arrayTime[0] = 0;
            listTime[0] = 0;

            Stopwatch stopwatch = new Stopwatch();          //счетчик времени

            GraphPane pane = zedGraphControl1.GraphPane;        //иниц. координат

            pane.CurveList.Clear();

            PointPairList ArrayPoints = new PointPairList();
            PointPairList ListPoints = new PointPairList();

            switch (ChooseBox.SelectedIndex)
            {
                case 0:

                    Gen(ref Array, ref List, maxSize);

                    tst.Text = Convert.ToString(Array.Size());
                    //tst.Text = "23";

                    for (int t = 0; t < 20; t++)
                    {
                        for (int i = minSize; i <= maxSize; i++)
                        {
                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                Array.Get(j);

                                arrayTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();
                        }

                        for (int i = minSize; i <= maxSize; i++)
                        {
                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                List.Get(j);

                                listTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();
                        }
                    }


                    break;

                case 1:

                    Gen(ref Array, ref List, maxSize);

                    for (int t = 0; t < 20; t++)
                    {
                        for (int i = minSize; i <= maxSize; i++)
                        {
                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                Array.Set(j, 0);

                                arrayTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();
                        }

                        for (int i = minSize; i <= maxSize; i++)
                        {
                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                List.Set(j, 0);

                                listTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();
                        }
                    }

                    break;

                case 2:

                    for (int t = 0; t < 20; t++)
                    {
                        for (int i = minSize; i <= maxSize; i++)
                        {
                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                Array.Add(0);

                                arrayTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();
                        }

                        for (int i = minSize; i <= maxSize; i++)
                        {
                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                List.Add(0);

                                listTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();
                        }
                    }

                    break;

                case 3:

                    int[] a = { 0 };
                    Gen(ref Array, ref List, maxSize);

                    for (int t = 0; t < 20; t++)
                    {
                        for (int i = minSize; i <= maxSize; i++)
                        {
                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                Array.AddAll(j, a);

                                arrayTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();
                        }

                        for (int i = minSize; i <= maxSize; i++)
                        {
                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                List.AddAll(j, a);

                                listTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();
                        }
                    }

                    break;

                case 4:

                    //Gen(ref Array, ref List, maxSize);

                    //tst.Text = Convert.ToString(Array.Size());

                    for (int t = 0; t < 20; t++)
                    {
                        

                        for (int i = minSize; i <= maxSize; i++)
                        {
                            Gen(ref Array, ref List, i);

                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                Array.Remove(0);

                                arrayTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();
                        }

                        for (int i = minSize; i <= maxSize; i++)
                        {
                            Gen(ref Array, ref List, i);

                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                List.Remove(0);

                                listTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();
                        }
                    }

                    break;

                default:
                    break;
            }

            for (int i = 0; i <= maxSize; i++)
            {
                arrayTime[i] /= 20;
                listTime[i] /= 20;
            }

            for (int i = 0; i <= maxSize; i++)
            {
                ArrayPoints.Add(i, arrayTime[i]);
                ListPoints.Add(i, listTime[i]);
            }

            LineItem l0 = pane.AddCurve("Список", ListPoints, Color.Blue, SymbolType.None);       //отрисовываем графики
            LineItem L1 = pane.AddCurve("Массив", ArrayPoints, Color.Red, SymbolType.None);

            pane.XAxis.Scale.Min = minSize - 1;
            pane.XAxis.Scale.Max = maxSize;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();







        }
    }
}
