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
        public struct Complex           //структура комплексных чисел
        {
            public double real;     //вещественная
            public double im;       //мнимая

            public Complex(double r, double i)   //конструктор     
            {
                real = r;
                im = i;
            }

            public static Complex operator +(Complex first, Complex second)    //сложение
            {
                Complex number = new Complex();

                number.real = first.real + second.real;
                number.im = first.im + second.im;

                return number;
            }

            public static Complex operator -(Complex first, Complex second)    //вычитание
            {
                Complex number = new Complex();

                number.real = first.real - second.real;
                number.im = first.im - second.im;

                return number;
            }

            public static Complex operator *(Complex first, Complex second)    //умножение
            {
                Complex number = new Complex();

                number.real = first.real * second.real - first.im * second.im;
                number.im = first.real * second.im - second.real * first.im;

                return number;
            }

            public static Complex operator /(Complex first, Complex second)    //деление
            {
                Complex number = new Complex();

                number.real = (first.real * second.real + first.im * second.im) / (Math.Pow(second.real, 2) + Math.Pow(second.im, 2));
                number.im = (second.real * first.im - first.real * second.im) / (Math.Pow(second.real, 2) + Math.Pow(second.im, 2));

                return number;
            }

            public static double Module(Complex num)    //модуль
            {
                return Math.Sqrt(Math.Pow(num.real, 2) + Math.Pow(num.im, 2));
            }


            public static double Arg(Complex num)       //аргумент
            {
                if (num.real > 0) return Math.Atan(num.im / num.real);
                if (num.real < 0 && num.im >= 0) return Math.PI + Math.Atan(num.im / num.real);
                if (num.real < 0 && num.im < 0) return -Math.PI + Math.Atan(num.im / num.real);
                if (num.real == 0 && num.im > 0) return Math.PI / 2;
                if (num.real == 0 && num.im < 0) return -Math.PI / 2;

                return 0;
            }

            public static double GetReal(Complex num)   //получение вещественной части
            {
                return num.real;
            }

            public static double GetIm(Complex num)     //получение мнимой части
            {
                return num.im;
            }

            public static void ComplexPrint(Complex num)     //вывод числа
            {
                Console.Clear();

                Console.WriteLine("Вещественное число:");
                Console.WriteLine();

                Console.WriteLine($"{num.real} + ({num.im})i");

                Console.ReadLine();
            }

        }

        public static Complex DataIn(Complex num)       //ввод числа
        {
            Console.Clear();

            Console.WriteLine("Введите новое комплексное число (сначала вещественную, потом мнимую часть):");

            num.real = Convert.ToDouble(Console.ReadLine());
            num.im = Convert.ToDouble(Console.ReadLine());

            Console.ReadLine();

            return num;
        }


        static void Main(string[] args)
        {
            Complex num = new Complex(0d, 0d);      //создаем нулевое число

            bool qcheck = true;                     //проверка выхода

            while (qcheck)                          //бесконечный цикл с опциями
            {
                Console.Clear();

                Console.WriteLine("Выберите действие:");
                Console.WriteLine("");
                Console.WriteLine("1. Введение числа");
                Console.WriteLine("2. Сложение");
                Console.WriteLine("3. Вычитание");
                Console.WriteLine("4. Умножение");
                Console.WriteLine("5. Деление");
                Console.WriteLine("6. Нахождение модуля");
                Console.WriteLine("7. Нахождение аргумента");
                Console.WriteLine("8. Вывод вещественной части");
                Console.WriteLine("9. Вывод мнимой части");
                Console.WriteLine("10. Вывод числа");
                Console.WriteLine("Q. Завершение работы");
                Console.WriteLine("");

                switch (Console.ReadLine())                     //варианты соответствуют списку
                {
                    case "1":
                        num = DataIn(num);
                        break;

                    case "2":
                        Console.Clear();

                        Complex newnum0 = new Complex();        //при небходимости создаются переменные структуры

                        Console.WriteLine("Введите новое комплексное число (сначала вещественную, потом мнимую часть):");

                        newnum0.real = Convert.ToDouble(Console.ReadLine());
                        newnum0.im = Convert.ToDouble(Console.ReadLine());

                        Console.Write($"({newnum0.real} + ({newnum0.im})i) + ({num.real} + ({num.im})i) = ");
                        num = num + newnum0;

                        Console.WriteLine($"{num.real} + ({num.im})i");



                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();

                        Complex newnum1 = new Complex();

                        Console.WriteLine("Введите новое комплексное число (сначала вещественную, потом мнимую часть):");

                        newnum1.real = Convert.ToDouble(Console.ReadLine());
                        newnum1.im = Convert.ToDouble(Console.ReadLine());

                        Console.Write($"({newnum1.real} + ({newnum1.im})i) - ({num.real} + ({num.im})i) = ");
                        num = num - newnum1;

                        Console.WriteLine($"{num.real} + ({num.im})i");


                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Clear();

                        Complex newnum2 = new Complex();

                        Console.WriteLine("Введите новое комплексное число (сначала вещественную, потом мнимую часть):");

                        newnum2.real = Convert.ToDouble(Console.ReadLine());
                        newnum2.im = Convert.ToDouble(Console.ReadLine());

                        Console.Write($"({newnum2.real} + ({newnum2.im})i) * ({num.real} + ({num.im})i) = ");
                        num = num * newnum2;

                        Console.WriteLine($"{num.real} + ({num.im})i");


                        Console.ReadLine();
                        break;

                    case "5":
                        Console.Clear();

                        Complex newnum3 = new Complex();

                        Console.WriteLine("Введите новое комплексное число (сначала вещественную, потом мнимую часть):");

                        newnum3.real = Convert.ToDouble(Console.ReadLine());
                        newnum3.im = Convert.ToDouble(Console.ReadLine());

                        Console.Write($"({newnum3.real} + ({newnum3.im})i) / ({num.real} + ({num.im})i) = ");
                        num = num / newnum3;

                        Console.WriteLine($"{num.real} + ({num.im})i");


                        Console.ReadLine();
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine($"Модуль: {Complex.Module(num)}");

                        Console.ReadLine();
                        break;

                    case "7":
                        Console.Clear();
                        Console.WriteLine($"Аргумент: {Complex.Arg(num)}");

                        Console.ReadLine();
                        break;

                    case "8":
                        Console.Clear();
                        Console.WriteLine($"Вещественная часть: {Complex.GetReal(num)}");

                        Console.ReadLine();
                        break;

                    case "9":
                        Console.Clear();
                        Console.WriteLine($"Мнимая часть: {Complex.GetIm(num)}");

                        Console.ReadLine();
                        break;

                    case "10":
                        Complex.ComplexPrint(num);
                        break;

                    case "q":
                        qcheck = false;
                        break;

                    case "Q":
                        qcheck = false;
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }


            }



        }
    }
}