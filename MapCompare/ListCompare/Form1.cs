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
        public class BaseComp : MyTreeMap.TreeMapComparer<int>
        {
            public override int Compare(int a, int b)
            {
                return a - b;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        static void Gen(ref MyHashMap.MyHashMap<int, int> hashMap, ref MyTreeMap.MyTreeMap<int, int> tree, int size)
        {
            Random rand = new Random(((int)DateTime.Now.Ticks));

            for (int i = 0; i < Math.Pow(10, size) + 2; i++)
            {
                hashMap.Put(i, i);
                tree.Put(i, i);
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
            BaseComp comp = new BaseComp();

            MyHashMap.MyHashMap<int, int> hashMap = new MyHashMap.MyHashMap<int, int>();
            MyTreeMap.MyTreeMap<int, int> tree = new MyTreeMap.MyTreeMap<int, int>(comp);

            int minSize = 1;
            int maxSize = 3;

            double[] hashTime = new double[maxSize + 1];
            double[] treeTime = new double[maxSize + 1];

            hashTime[0] = 0;
            treeTime[0] = 0;

            Stopwatch stopwatch = new Stopwatch();          //счетчик времени

            GraphPane pane = zedGraphControl1.GraphPane;        //иниц. координат

            pane.CurveList.Clear();

            PointPairList HashPoints = new PointPairList();
            PointPairList TreePoints = new PointPairList();

            switch (ChooseBox.SelectedIndex)
            {
                case 0:

                    Gen(ref hashMap, ref tree, maxSize);

                    //tst.Text = Convert.ToString(Array.Size());
                    //tst.Text = "23";

                    for (int t = 0; t < 20; t++)
                    {
                        for (int i = minSize; i <= maxSize; i++)
                        {
                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                hashMap.Get(j);

                                hashTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();
                        }

                        for (int i = minSize; i <= maxSize; i++)
                        {
                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                tree.Get(j);

                                treeTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();
                        }
                    }


                    break;

                case 1:

                    //Gen(ref hashMap, ref List, maxSize);

                    for (int t = 0; t < 20; t++)
                    {
                        for (int i = minSize; i <= maxSize; i++)
                        {
                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                hashMap.Put(j, j);

                                hashTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();
                        }

                        for (int i = minSize; i <= maxSize; i++)
                        {
                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                tree.Put(j, j);

                                treeTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
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
                            Gen(ref hashMap, ref tree, i);

                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                hashMap.Remove(j);

                                hashTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
                            }
                            stopwatch.Stop();
                        }

                        for (int i = minSize; i <= maxSize - 2; i++)
                        {
                            Gen(ref hashMap, ref tree, i);

                            stopwatch.Start();
                            for (int j = 0; j < Math.Pow(10, i); j++)
                            {
                                tree.Remove(j);

                                treeTime[i] += Convert.ToDouble(stopwatch.ElapsedMilliseconds);
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
                hashTime[i] /= 20;
                treeTime[i] /= 20;
            }

            for (int i = 0; i <= maxSize; i++)
            {
                HashPoints.Add(i, hashTime[i]);
                TreePoints.Add(i, treeTime[i]);
            }

            LineItem l0 = pane.AddCurve("Дерево", TreePoints, Color.Blue, SymbolType.None);       //отрисовываем графики
            LineItem L1 = pane.AddCurve("Список", HashPoints, Color.Red, SymbolType.None);

            pane.XAxis.Scale.Min = minSize - 1;
            pane.XAxis.Scale.Max = maxSize;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();







        }
    }
}
