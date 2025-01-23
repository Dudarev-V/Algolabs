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



        static void Main(string[] args)
        {
            MyHashSet.MyHashSet<string> words = new MyHashSet.MyHashSet<string>();
            MyVector.MyVector<string> control = new MyVector.MyVector<string>();

            StreamReader file = new StreamReader("C:/Users/Ower/source/repos/Algolabs/Algolabs/input-set0.txt");

            string input = file.ReadLine();
            string target = "";

            while (!String.IsNullOrEmpty(input))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] != ' ' && input[i] != '\n')
                    {
                        if (!((input[i] > 64 && input[i] < 91) || (input[i] > 96 && input[i] < 122)))
                        {
                            //Console.WriteLine("tst");
                            target = "";
                            while (i < input.Length && input[i] != ' ' && input[i] != '\n')
                            {
                                i++;
                            }
                            continue;
                        }

                        target += input[i];
                    }

                    else
                    {
                        if (!words.Contains(target.ToLower())) control.Add(target);
                        else control.Remove(target);
                        words.Add(target.ToLower());

                        target = "";
                    }
                }

                input = file.ReadLine();
            }

            file.Close();

            //Console.WriteLine("tst");

            for (int i = 0; i < control.Size(); i++)
            {
                Console.WriteLine(control.Get(i));
            }


            Console.ReadKey();
        }
    }
}
