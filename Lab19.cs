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
        static void Main(string[] args)
        {
            MyHashMap.MyHashMap<string, int> tagMap = new MyHashMap.MyHashMap<string, int>();

            string current, target;
            bool f = false;

            StreamReader file = new StreamReader("C:/Users/Ower/source/repos/Algolabs/Algolabs/input-1.txt");

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

                        for (int j = i + 1, val = i; j < current.Length/* - val*/ && f; j++, i = j)
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

                                    if (tagMap.ContainsKey(target))
                                    {
                                        f = false;

                                        int res = tagMap.Get(target);

                                        tagMap.Remove(target);

                                        tagMap.Put(target, res + 1);
                                    }
                                    else
                                    {
                                        tagMap.Put(target, 1);

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

            MyVector.MyVector<MyHashMap.Entry<string, int>> output = tagMap.EntrySet();

            for (int i = 0; i < output.Size(); i++)
            {
                Console.WriteLine($"{output.Get(i).key} => {output.Get(i).value}");
            }

            Console.ReadKey();

        }
    }
}


