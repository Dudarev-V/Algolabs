using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
//using MyArrayList;

namespace Algolabs
{
    class Program
    {
        static void Gen()    //генератор текста
        {
            StreamWriter filein = new StreamWriter("C:/Users/Ower/source/repos/Algolabs/Algolabs/input.txt");

            Random rand = new Random();

            int iter = rand.Next(50000, 100000);

            int choose;

            bool line = true;
            bool ipb = true;

            for (int i = 0; i < iter; i++)
            {
                string ip = IPGen();

                choose = rand.Next(1, 1000);

                if (choose < 260) { filein.Write(Convert.ToChar(rand.Next(65, 90))); line = true; ipb = true; }
                if (choose > 250 && choose < 510) { filein.Write(Convert.ToChar(rand.Next(97, 122))); line = true; ipb = true; }
                if (choose > 500 && choose < 810) { filein.Write(Convert.ToChar(rand.Next(49, 61))); line = true; ipb = true; }
                if (choose > 930 && choose < 960 && ipb) { filein.Write(ip); line = true; ipb = false; }
                if (choose > 995 && line) { filein.Write("\n"); line = false; ipb = true; }
            }

            filein.Close();
        }

        static string IPGen()       //генератор адресов
        {
            Random subrand = new Random();

            string ip = "";

            for (int i = 0; i < 3; i++)
            {
                ip += subrand.Next(0, 256);
                ip += ".";
            }

            ip += subrand.Next(0, 255);

            return ip;
        }

        static void Extract(string input, ref MyVector.MyVector<string> vector)  //извлечение подстрок
        {
            string target = "", currNum = "";
            int points = 0;

            for (int i = 0; i < input.Length; i++)
            {                                                   //сложная проверка и выделение
                if (input[i] > 47 && input[i] < 58)
                {
                    currNum += input[i];
                }
                if (input[i] > 57)
                {
                    if (points == 3 && target != "")
                    {
                        if (currNum == "")
                        {
                            currNum = "";
                            target = "";
                            points = 0;
                        }
                        else
                        {
                            if (Convert.ToInt32(currNum) < 256)
                            {
                                target += currNum;
                                Insertion(target, ref vector);
                                currNum = "";
                                target = "";
                            }
                            else
                            {
                                currNum = "";
                                target = "";
                                points = 0;
                            }
                        }
                    }
                    else
                    {
                        currNum = "";
                        target = "";
                        points = 0;
                    }
                }
                if (input[i] == '.' && currNum != "")
                {
                    if (Convert.ToInt32(currNum) < 256)
                    {
                        if (points < 3)
                        {
                            target += currNum;
                            target += ".";
                            points++;
                            currNum = "";
                        }
                        else
                        {
                            currNum = "";
                            target = "";
                            points = 0;
                        }
                    }
                    else
                    {
                        currNum = "";
                        target = "";
                        points = 0;
                    }
                }

            }
        }

        static void Insertion(string input, ref MyVector.MyVector<string> vector)  //вставка в вектор
        {
            bool f = true;

            string[] arrIn = new string[4];
            string[] arrOut = new string[4];

            for (int i = 0, j = 0; i < input.Length; i++)
            {
                if (input[i] == '.') j++;
                else arrIn[j] += input[i];
            }

            for (int i = 0; i < vector.Size(); i++)
            {
                arrOut = new string[4];

                string comp = vector.Get(i);

                for (int j = 0, k = 0; j < comp.Length; j++)
                {
                    if (comp[j] == '.') k++;
                    else arrOut[k] += comp[j];
                }

                for (int j = 0; j < 4; j++)
                {
                    if (arrIn[j].Length == arrOut[j].Length)
                    {
                        for (int k = 0; k < arrIn[j].Length; k++)
                        {
                            if (arrIn[j][k] == arrOut[j][k]) f = false;
                        }
                    }
                }
            }

            if (f) vector.Add(input);
        }
        static void Main(string[] args)
        {
            MyVector.MyVector<string> vecIn = new MyVector.MyVector<string>();

            MyVector.MyVector<string> vecOut = new MyVector.MyVector<string>();

            //Gen();

            StreamReader filein = new StreamReader("C:/Users/Ower/source/repos/Algolabs/Algolabs/input.txt");

            StreamWriter fileout = new StreamWriter("C:/Users/Ower/source/repos/Algolabs/Algolabs/output.txt");

            string input = filein.ReadLine();

            while (input != null)
            {
                vecIn.Add(input);

                input = filein.ReadLine();
            }


            filein.Close();

            for (int i = 0; i < vecIn.Size(); i++)
            {
                Extract(vecIn.Get(i), ref vecOut);
            }

            for (int i = 0; i < vecOut.Size(); i++)
            {
                Console.WriteLine(vecOut.Get(i));
            }

            for (int i = 0; i < vecOut.Size(); i++)
            {
                fileout.WriteLine(vecOut.Get(i));
            }

            fileout.Close();
            Console.ReadLine();

        }
    }
}