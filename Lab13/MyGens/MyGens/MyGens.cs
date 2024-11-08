using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGens
{
    public class ArrGensInt
    {
        static public int[] MainArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            int[] array = new int[iter];

            Random rand = new Random(((int)DateTime.Now.Ticks));

            for (int i = 0; i < iter; i++)
            {
                array[i] = rand.Next(0, 1000);
            }

            return array;
        }

        static public int[] OneSwapArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            Random rand = new Random();

            int[] array = SortForwardArrGen(mod);

            bool f = true;

            while (f)
            {
                int swapVal = rand.Next(1, iter - 4);
                int newSwapVal = rand.Next(swapVal + 1, iter - 1);

                if (array[swapVal] != array[newSwapVal])
                {
                    int rev = array[swapVal];
                    array[swapVal] = array[newSwapVal];
                    array[newSwapVal] = rev;

                    f = false;
                }
            }
            return array;
        }

        static public int[] SortForwardArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            int[] array = new int[iter];

            int current = 0;

            Random rand = new Random();

            for (int i = 0; i < iter; i++)
            {
                if (rand.Next(1, mod * 6) == 2)
                    current++;

                array[i] = current;
            }

            return array;
        }

        static public int[] SortBackwardArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            int[] array = new int[iter];

            int current = 0;

            Random rand = new Random();

            for (int i = 0; i < iter; i++)
            {
                if (rand.Next(1, mod * 6) == 2)
                    current--;

                array[i] = current;
            }

            return array;
        }

        static public int[] ReplArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            Random rand = new Random();

            int[] array = SortForwardArrGen(mod);

            int count = rand.Next(1, 9);

            bool f = true;

            for (int i = 0; i < count; i++)
            {
                while (f)
                {
                    int swapVal = rand.Next(1, iter - 4);
                    int newSwapVal = rand.Next(swapVal + 1, iter - 1);

                    if (array[swapVal] != array[newSwapVal])
                    {
                        int rev = array[swapVal];
                        array[swapVal] = array[newSwapVal];
                        array[newSwapVal] = rev;

                        f = false;
                    }
                }
            }

            return array;
        }

        static public int[] SubArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            Random rand = new Random();

            int[] array = new int[iter];

            int current = 0;

            for (int i = 0; i < iter; i++)
            {
                if (rand.Next(1, mod) == 2)
                    current++;
                if (rand.Next(1, mod * 10) < 11)
                    current = 0;

                array[i] = current;
            }



            return array;
        }

        static public int[] RandArrGen(int mod, int propability, int element)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            int[] array = new int[iter];

            Random rand = new Random();

            for (int i = 0; i < iter; i++)
            {
                if (rand.Next(0, 100) <= propability)
                    array[i] = element;
                else
                    array[i] = rand.Next(0, 1000);
            }

            return array;
        }
    }

    public class ArrGensDouble
    {
        static public double[] MainArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            double[] array = new double[iter];

            Random rand = new Random(((int)DateTime.Now.Ticks));

            for (int i = 0; i < iter; i++)
            {
                array[i] = Convert.ToDouble(rand.Next(0, 1000)) + (Convert.ToDouble(rand.Next(0, 1000)) / 1000);
            }

            return array;
        }

        static public double[] OneSwapArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            Random rand = new Random();

            double[] array = SortForwardArrGen(mod);

            bool f = true;

            while (f)
            {
                int swapVal = rand.Next(1, iter - 4);
                int newSwapVal = rand.Next(swapVal + 1, iter - 1);

                if (array[swapVal] != array[newSwapVal])
                {
                    double rev = array[swapVal];
                    array[swapVal] = array[newSwapVal];
                    array[newSwapVal] = rev;

                    f = false;
                }
            }
            return array;
        }

        static public double[] SortForwardArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            double[] array = new double[iter];

            double current = 0;

            Random rand = new Random();

            for (int i = 0; i < iter; i++)
            {
                if (rand.Next(1, mod * 6) == 2)
                    current += 0.5;

                array[i] = current;
            }

            return array;
        }

        static public double[] SortBackwardArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            double[] array = new double[iter];

            double current = 0;

            Random rand = new Random();

            for (int i = 0; i < iter; i++)
            {
                if (rand.Next(1, mod * 6) == 2)
                    current -= 0.5;

                array[i] = current;
            }

            return array;
        }

        static public double[] ReplArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            Random rand = new Random();

            double[] array = SortForwardArrGen(mod);

            int count = rand.Next(1, 9);

            bool f = true;

            for (int i = 0; i < count; i++)
            {
                while (f)
                {
                    int swapVal = rand.Next(1, iter - 4);
                    int newSwapVal = rand.Next(swapVal + 1, iter - 1);

                    if (array[swapVal] != array[newSwapVal])
                    {
                        double rev = array[swapVal];
                        array[swapVal] = array[newSwapVal];
                        array[newSwapVal] = rev;

                        f = false;
                    }
                }
            }

            return array;
        }

        static public double[] SubArrGen(int mod)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            Random rand = new Random();

            double[] array = new double[iter];

            double current = 0;

            for (int i = 0; i < iter; i++)
            {
                if (rand.Next(1, mod) == 2)
                    current += 0.5;
                if (rand.Next(1, mod * 10) < 11)
                    current = 0;

                array[i] = current;
            }



            return array;
        }

        static public double[] RandArrGen(int mod, int propability, double element)
        {
            int iter = Convert.ToInt32(Math.Pow(10, mod));

            double[] array = new double[iter];

            Random rand = new Random();

            for (int i = 0; i < iter; i++)
            {
                if (rand.Next(0, 100) <= propability)
                    array[i] = Convert.ToDouble(element);
                else
                    array[i] = Convert.ToDouble(rand.Next(0, 1000));
            }

            return array;
        }
    }
        public class ArrGensChar
        {
            static public char[] MainArrGen(int mod)
            {
                int iter = Convert.ToInt32(Math.Pow(10, mod));

                char[] array = new char[iter];

                Random rand = new Random(((int)DateTime.Now.Ticks));

                for (int i = 0; i < iter; i++)
                {
                    array[i] = Convert.ToChar(rand.Next(97, 123));
                }

                return array;
            }

            static public char[] OneSwapArrGen(int mod)
            {
                int iter = Convert.ToInt32(Math.Pow(10, mod));

                Random rand = new Random();

                char[] array = SortForwardArrGen(mod);

                bool f = true;

                while (f)
                {
                    int swapVal = rand.Next(1, iter - 4);
                    int newSwapVal = rand.Next(swapVal + 1, iter - 1);

                    if (array[swapVal] != array[newSwapVal])
                    {
                        char rev = array[swapVal];
                        array[swapVal] = array[newSwapVal];
                        array[newSwapVal] = rev;

                        f = false;
                    }
                }
                return array;
            }

            static public char[] SortForwardArrGen(int mod)
            {
                int iter = Convert.ToInt32(Math.Pow(10, mod));

                char[] array = new char[iter];

                char current = 'a';

                Random rand = new Random();

                for (int i = 0; i < iter; i++)
                {
                    if (rand.Next(1, mod * 6) == 2)
                        current = Convert.ToChar(Convert.ToInt32(current) + 1);

                    if (Convert.ToInt32(current) > 122) current = 'a';

                    array[i] = current;

                    
                }

                return array;
            }

            static public char[] SortBackwardArrGen(int mod)
            {
                int iter = Convert.ToInt32(Math.Pow(10, mod));

                char[] array = new char[iter];

                char current = 'z';

                Random rand = new Random();

                for (int i = 0; i < iter; i++)
                {
                    if (rand.Next(1, mod * 6) == 2)
                        current = Convert.ToChar(Convert.ToInt32(current) - 1);

                    if (Convert.ToInt32(current) < 97) current = 'z';
                }

                return array;
            }

            static public char[] ReplArrGen(int mod)
            {
                int iter = Convert.ToInt32(Math.Pow(10, mod));

                Random rand = new Random();

                char[] array = SortForwardArrGen(mod);

                int count = rand.Next(1, 9);

                bool f = true;

                for (int i = 0; i < count; i++)
                {
                    while (f)
                    {
                        int swapVal = rand.Next(1, iter - 4);
                        int newSwapVal = rand.Next(swapVal + 1, iter - 1);

                        if (array[swapVal] != array[newSwapVal])
                        {
                            char rev = array[swapVal];
                            array[swapVal] = array[newSwapVal];
                            array[newSwapVal] = rev;

                            f = false;
                        }
                    }
                }

                return array;
            }

            static public char[] SubArrGen(int mod)
            {
                int iter = Convert.ToInt32(Math.Pow(10, mod));

                Random rand = new Random();

                char[] array = new char[iter];

                char current = 'a';

                for (int i = 0; i < iter; i++)
                {
                    if (rand.Next(1, mod) == 2)
                        current = Convert.ToChar(Convert.ToInt32(current) + 1);

                    if (Convert.ToInt32(current) > 122) current = 'a';
                    if (rand.Next(1, mod * 10) < 11)
                        current = 'a';

                    array[i] = current;
                }



                return array;
            }

            static public char[] RandArrGen(int mod, int propability, char element)
            {
                int iter = Convert.ToInt32(Math.Pow(10, mod));

                char[] array = new char[iter];

                Random rand = new Random();

                for (int i = 0; i < iter; i++)
                {
                    if (rand.Next(0, 100) <= propability)
                        array[i] = element;
                    else
                        array[i] = Convert.ToChar(rand.Next(97, 123));
                }

                return array;
            }
        }
    

}
