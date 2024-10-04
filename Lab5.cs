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
        static void Gen()
        {
            StreamWriter filein = new StreamWriter("C:/Users/Ower/source/repos/Algolabs/Algolabs/input.txt");

            Random rand = new Random();

            int iter = rand.Next(50000, 100000);

            int choose;

            bool line = true;

            for (int i = 0; i < iter; i++)
            {
                string tagin = TagGen();

                choose = rand.Next(1, 1000);

                if (choose < 260) { filein.Write(Convert.ToChar(rand.Next(65, 90))); line = true; }
                if (choose > 250 && choose < 510) { filein.Write(Convert.ToChar(rand.Next(97, 122))); line = true; }
                if (choose > 500 && choose < 810) { filein.Write(Convert.ToChar(rand.Next(48, 61))); line = true; }
                if (choose > 930 && choose < 960) { filein.Write(tagin); line = true; }
                if (choose > 995 && line) { filein.Write("\n"); line = false; }
            }

            filein.Close();
        }

        static string TagGen()
        {
            Random subrand = new Random();

            string tag = "<";

            int choose = subrand.Next(1, 5);

            if (choose == 1) tag += "/";

            choose = subrand.Next(1, 3);

            if (choose == 1) tag += Convert.ToChar(subrand.Next(65, 90));
            else tag += Convert.ToChar(subrand.Next(97, 122));

            int iter = subrand.Next(1, 9);

            for (int i = 0; i < iter; i++)
            {
                choose = subrand.Next(1, 4);

                if (choose == 1) tag += Convert.ToChar(subrand.Next(65, 90));
                if (choose == 2) tag += Convert.ToChar(subrand.Next(97, 122));
                if (choose == 3) tag += Convert.ToChar(subrand.Next(48, 57));
            }

            tag += ">";

            return tag;
        }

        static void Main(string[] args)
        {
            MyArrayList.MyArrayList<string> tagList = new MyArrayList.MyArrayList<string>();

            //Gen();

            StreamReader file = new StreamReader("C:/Users/Ower/source/repos/Algolabs/Algolabs/input.txt");

            string current, target;

            bool f = false;

            current = file.ReadLine();

            while (current != null)
            {
                for (int i = 0; i < current.Length - 2; i++)
                {
                    target = "";

                    if (current[i] == '<' && (current[i + 1] > 62 || (current[i + 1] == '/' && current[i + 2] > 62)))
                    {
                        f = true;

                        target += '<';

                        for (int j = i + 1, val = i; j < current.Length - val && f; j++, i = j)
                        {
                            if (current[j] == '<')
                            {
                                i--;

                                f = false;
                            }
                            else
                            {
                                if (current[j] != '>') target += current[j];
                                else
                                {
                                    target += current[j];

                                    if (tagList.Contains(target)) f = false;
                                    else
                                    {
                                        tagList.Add(target);
                                        f = false;
                                    }
                                }
                            }
                        }
                    }
                }

                current = file.ReadLine();
            }

            file.Close();

            for (int i = 0; i < tagList.Size(); i++)
                Console.WriteLine(tagList.Get(i));

            Console.ReadLine();

        }
    }
}