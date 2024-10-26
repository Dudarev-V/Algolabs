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


        public class Application
        {
            public int prior { get; }
            public int num { get; }
            public int iter { get; }


            public Application(int iter, int num)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());

                prior = rand.Next(1, 6);
                this.num = num;
                this.iter = iter;
            }

        }

        public class MainComparer : MyPriorityQueue.PriorityQueueComparer<Application>
        {
            public override int Compare(Application a, Application b)
            {

                return a.prior - b.prior;
            }
        }





        static void Main(string[] args)
        {

            int iterfin = Convert.ToInt32(Console.ReadLine());
            int iter = 1;


            MainComparer Comparator = new MainComparer();
            MyPriorityQueue.MyPriorityQueue<Application> appl = new MyPriorityQueue.MyPriorityQueue<Application>(3, Comparator);

            Random randIter = new Random();

            int num = 1;

            StreamWriter file = new StreamWriter("C:/Users/Ower/source/repos/Algolabs/log.txt");

            int time = 0;
            int max = 0;

            for (int i = 1; i <= iterfin; i++)
            {
                int r = randIter.Next(1, 11);

                for (int j = 1; j <= r; j++)
                {

                    Application applic = new Application(iter, num);

                    appl.Add(applic);

                    file.WriteLine($"ADD {num} {applic.prior} {iter}");

                    if (time - applic.num > max) max = time - applic.num;



                    num++;
                    time++;

                }


                Application applicRem = appl.Poll();
                time++;


                file.WriteLine($"REMOVE {applicRem.num} {applicRem.prior} {applicRem.iter}");

                iter++;
            }


            while (!appl.IsEmpty())
            {
                Application applic = appl.Poll();
                time++;


                file.WriteLine($"REMOVE {applic.num} {applic.prior} {applic.iter}");

                if (time - applic.num > max) max = time - applic.num;


                iter++;
            }

            Console.WriteLine($"Максимальное время: {time}");

            file.Close();


            Console.ReadKey();


        }
    }
}