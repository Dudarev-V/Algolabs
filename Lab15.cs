using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Algolabs
{
    class Program
    {
        //public class MainComparer: MyComparator.Comparer<string>
        //{
        public static /*override*/ int Compare(string a, string b)
        {
            int aC = 0;
            int bC = 0;

            string target = "";

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > 47 && a[i] < 58)
                {
                    target += a[i];
                }
                else
                {
                    if (target.Length == 2) aC++;
                    target = "";
                }
            }

            target = "";

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] > 47 && b[i] < 58)
                {
                    target += b[i];
                }
                else
                {
                    if (target.Length == 2) bC++;
                    target = "";
                }
            }

            return aC - bC;
        }
        //}

        public static int SpaceCounter(string input)
        {
            int c = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ') c++;
            }

            return c;
        }

        static public void Gen()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            StreamWriter file = new StreamWriter("C:/Users/Ower/source/repos/Algolabs/input.txt");

            int size = rand.Next(50, 500);

            string outline;
            int len;

            for (int i = 0; i < size; i++)
            {
                outline = "";

                len = rand.Next(6, 89);
                for (int j = 0; j < len; j++)
                {
                    outline += Convert.ToString(rand.Next(0, 500));
                    outline += " ";
                }

                file.WriteLine(outline);
            }

            file.Close();
        }

        static void Main(string[] args)
        {
            MyArrayDeque.MyArrayDeque<string> deq = new MyArrayDeque.MyArrayDeque<string>();

            //Gen();

            StreamReader file = new StreamReader("C:/Users/Ower/source/repos/Algolabs/input.txt");
            StreamWriter fileout = new StreamWriter("C:/Users/Ower/source/repos/Algolabs/sorted.txt");

            string input = file.ReadLine();

            deq.Add(input);

            input = file.ReadLine();

            while (!String.IsNullOrEmpty(input))
            {
                //Console.WriteLine("sf");

                if (Compare(input, deq.Peek()) > 0) deq.Add(input);
                else deq.AddFirst(input);

                input = file.ReadLine();
            }

            string[] outstring = deq.ToArray();

            for (int i = 0; i < outstring.Length; i++)
            {
                fileout.WriteLine(outstring[i]);
            }

            fileout.Close();

            MyArrayList.MyArrayList<string> res = new MyArrayList.MyArrayList<string>();

            int c;
            string check;

            c = Convert.ToInt32(Console.ReadLine());

            while (deq.Size() != 0)
            {
                check = deq.PollLast();

                if (SpaceCounter(check) <= c) res.Add(check);
            }

            for (int i = 0; i < res.Size(); i++)
            {
                deq.Add(res.Get(i));
            }


            Console.WriteLine(input);





            Console.ReadKey();
        }
    }
}