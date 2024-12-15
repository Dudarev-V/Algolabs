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
        public enum Types
        {
            Int,
            Double,
            String
        }

        public struct Varval
        {
            public Types type;
            public string value;
        }

        static void Main(string[] args)
        {
            MyHashMap.MyHashMap<string, Varval> vars = new MyHashMap.MyHashMap<string, Varval>();
            MyVector.MyVector<string> clearVars = new MyVector.MyVector<string>();

            Regex regMain = new Regex(@"(\w+)\s(\w+)\s+=\s+(\S+)\s*");
            Regex correctMain = new Regex(@"\b(int|string|double)\b\s+[A-Za-z]+[A-Za-z0-9]*\s+=\s+\S+\s*");
            Regex regType = new Regex(@"\b(int|string|double)\b");
            Regex regValS = new Regex(@"'\w+'");
            Regex regValI = new Regex(@"\s-?[1-9]\d+");
            Regex regValD = new Regex(@"\s[1-9]\d*|\d+,\d+");
            Regex regWord = new Regex(@"\s+[A-Za-z]+[A-Za-z0-9]*");

            StreamReader file = new StreamReader("C:/Users/Ower/source/repos/Algolabs/Algolabs/inputVar.txt");

            string target = file.ReadLine();

            while (!String.IsNullOrEmpty(target))
            {
                MatchCollection rawVars = regMain.Matches(target);

                for (int i = 0; i < rawVars.Count; i++)
                {

                    target = Convert.ToString(correctMain.Match(Convert.ToString(rawVars[i])));

                    if (!String.IsNullOrEmpty(target))
                    {
                        clearVars.Add(target);
                    }
                    else
                    {
                        Console.WriteLine("Найден неверный тип.");
                    }

                }

                target = file.ReadLine();
            }

            file.Close();


            string correct = "";

            for (int i = 0; i < clearVars.Size(); i++)
            {
                correct = clearVars.Get(i);

                if (Convert.ToString(regType.Match(correct)) == "string")
                {
                    if (String.IsNullOrEmpty(Convert.ToString(regValS.Match(correct))))
                    {
                        clearVars.Remove((int)i);
                        Console.WriteLine($"{correct} - Неверный формат данных.");
                    }
                }

                if (Convert.ToString(regType.Match(correct)) == "int")
                {
                    if (String.IsNullOrEmpty(Convert.ToString(regValI.Match(correct))))
                    {
                        clearVars.Remove((int)i);
                        Console.WriteLine($"{correct} - Неверный формат данных.");
                    }
                }

                if (Convert.ToString(regType.Match(correct)) == "double")
                {
                    if (String.IsNullOrEmpty(Convert.ToString(regValD.Match(correct))))
                    {
                        clearVars.Remove((int)i);
                        Console.WriteLine($"{correct} - Неверный формат данных.");
                    }
                }
            }


            for (int i = 0; i < clearVars.Size(); i++)
            {
                Console.WriteLine(clearVars.Get(i));
            }

            string name;

            for (int i = 0; i < clearVars.Size(); i++)
            {
                //found = true;

                correct = clearVars.Get(i);
                name = Convert.ToString(regWord.Match(correct));
                name = name.Remove(0, 1);


                if (vars.ContainsKey(name))
                {
                    Console.WriteLine($"{name} - переопределено.");
                }

                else
                {
                    Varval input = new Varval();

                    if (Convert.ToString(regType.Match(correct)) == "int")
                    {
                        input.type = Types.Int;
                        input.value = Convert.ToString(regValI.Match(correct));
                    }
                    if (Convert.ToString(regType.Match(correct)) == "double")
                    {
                        input.type = Types.Double;
                        input.value = Convert.ToString(regValD.Match(correct));
                    }
                    if (Convert.ToString(regType.Match(correct)) == "string")
                    {
                        input.type = Types.String;
                        input.value = Convert.ToString(regValS.Match(correct));
                    }

                    vars.Put(name, input);
                }
            }


            Console.ReadKey();

        }
    }
}
