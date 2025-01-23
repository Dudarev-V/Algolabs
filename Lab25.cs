using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace Algolabs
{
    class Program
    {
        public class BaseComp : MyTreeMap.TreeMapComparer<int>
        {
            public override int Compare(int a, int b)
            {
                return a - b;
            }
        }

        public class StrComp : MyTreeMap.TreeMapComparer<string>
        {
            public override int Compare(string a, string b)
            {
                MyVector.MyVector<int> used = new MyVector.MyVector<int>();
                bool flag = true;
                int c = 0;
                int minA = 0, minB = 0, wordcountA = 0, wordcountB = 0;
                string target = "";

                while (flag && c < a.Length)
                {
                    minA = a.Length;
                    minB = b.Length;

                    for (int i = 0; i < a.Length; i++)
                    {
                        if (a[i] != ' ' && a[i] != '\n') target += a[i];
                        else
                        {
                            if (minA > target.Length && !used.Contains(target.Length)) minA = target.Length;
                            target = "";
                            wordcountA++;
                        }
                    }

                    target = "";

                    for (int i = 0; i < a.Length; i++)
                    {
                        if (b[i] != ' ' && b[i] != '\n') target += a[i];
                        else
                        {
                            if (minB > target.Length && !used.Contains(target.Length)) minB = target.Length;
                            target = "";
                            wordcountB++;
                        }
                    }

                    if (wordcountA != wordcountB) return wordcountA - wordcountB;

                    wordcountA = 0;
                    wordcountB = 0;
                    target = "";

                    if (minA == minB)
                    {
                        used.Add(minA);
                        used.Add(minB);
                    }
                    else flag = false;

                    c++;
                }
                return minA - minB;
            }
        }

        public class WordComp : MyTreeMap.TreeMapComparer<string>
        {
            public override int Compare(string a, string b)
            {
                return a.Length - b.Length;
            }

        }

        public class ListComp : MyTreeMap.TreeMapComparer<MyArrayList.MyArrayList<string>>
        {
            public override int Compare(MyArrayList.MyArrayList<string> a, MyArrayList.MyArrayList<string> b)
            {
                if (a.Size() != b.Size()) return a.Size() - b.Size();

                WordComp comp = new WordComp();

                for (int i = 0; i < a.Size(); i++)
                {
                    if (comp.Compare(a.Get(i), b.Get(i)) != 0)
                    {
                        return comp.Compare(a.Get(i), b.Get(i));
                    }
                }

                return 0;
            }

        }

        public void ListSort(ref MyArrayList.MyArrayList<string> input)
        {
            WordComp comp = new WordComp();

            for (int i = 0; i < input.Size(); i++)
            {
                for (int j = 0; j < input.Size() - 1; j++)
                {
                    if (comp.Compare(input.Get(j), input.Get(j + 1)) > 0)
                    {
                        string res = input.Get(j);
                        input.Set(j, input.Get(j + 1));
                        input.Set(j + 1, res);
                    }
                }
            }
        }



        static void Main(string[] args)
        {
            WordComp comp = new WordComp();
            ListComp listC = new ListComp();

            MyHashSet.MyHashSet<string> set = new MyHashSet.MyHashSet<string>();
            MyArrayList.MyArrayList<MyArrayList.MyArrayList<string>> wordsByStr = new MyArrayList.MyArrayList<MyArrayList.MyArrayList<string>>();

            StreamReader file = new StreamReader("C:/Users/Ower/source/repos/Algolabs/Algolabs/input-set.txt");

            string input = "42";
            string target = "";
            int c = 0;


            input = file.ReadLine();

            while (!String.IsNullOrEmpty(input))
            {
                MyArrayList.MyArrayList<string> words = new MyArrayList.MyArrayList<string>();

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] != ' ' && input[i] != '\n') target += input[i];
                    else
                    {
                        words.Add(target);
                        target = "";
                    }
                }

                for (int i = 0; i < words.Size(); i++)
                {
                    for (int j = 0; j < words.Size() - 1; j++)
                    {
                        if (comp.Compare(words.Get(j), words.Get(j + 1)) > 0)
                        {
                            string res = words.Get(j);
                            words.Set(j, words.Get(j + 1));
                            words.Set(j + 1, res);
                        }
                    }
                }

                wordsByStr.Add(words);




                set.Add(input);
                c++;
                input = file.ReadLine();
            }

            file.Close();

            //for (int i = 0; i < wordsByStr.Size(); i++)
            //{
            //    for (int j = 0; j < wordsByStr.Get(i).Size(); j++)
            //    {
            //        Console.WriteLine(wordsByStr.Get(i).Get(j));
            //    }
            //}

            for (int i = 0; i < wordsByStr.Size() - 1; i++)
            {
                Console.WriteLine(listC.Compare(wordsByStr.Get(i), wordsByStr.Get(i + 1)));
            }

            Console.WriteLine(listC.Compare(wordsByStr.Get(wordsByStr.Size() - 1), wordsByStr.Get(0)));




            Console.ReadKey();
        }
    }
}