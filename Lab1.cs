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
        static bool Symmetry(int[,] matrix, int dim)            //проверка на симметричность
        {
            bool target = true;

            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    if (matrix[i, j] != matrix[j, i]) target = false;
                }
            }


            return target;
        }

        static double Compute(int[,] matrix, int dim, int[] vector)        //рассчет по формуле
        {
            int[] intermed = new int[dim];              //промежуточный вектор - результат первого произведения

            for (int i = 0; i < dim; i++)
            {
                intermed[i] = 0;
            }

            for (int i = 0; i < dim; i++)               //первое произведение
            {
                for (int j = 0; j < dim; j++)
                {
                    intermed[i] += vector[j] * matrix[j, i];
                }
            }

            double result = 0;                              //переменная для результата вычислений

            for (int i = 0; i < dim; i++)                               //второе произведение
            {
                result += Convert.ToDouble(intermed[i] * vector[i]);
            }

            result = Math.Sqrt(result);         //извлечение корня

            return result;

        }

        static void Main(string[] args)
        {
            string filepath = @"C:\Users\Ower\source\repos\Algolabs\Algolabs\Testfile1.txt";   //путь файла для удобства в одной переменной
            StreamReader file = new StreamReader(filepath);         //пользуемся классом для файлового в-в

            int dim = Convert.ToInt32(file.ReadLine());         //чтение размерности

            int[,] matrixG = new int[dim, dim];                 //создание и заполнение матрицы тензора в качестве двумерного массива

            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    matrixG[i, j] = Convert.ToInt32(file.ReadLine());
                }
            }

            if (Symmetry(matrixG, dim))                                  //если симметрия отсутствует, сообщаем пользователю
            {

                int[] vector = new int[dim];                            //создание и заполнение вектора

                for (int i = 0; i < dim; i++)
                {
                    vector[i] = Convert.ToInt32(file.ReadLine());
                }

                Console.WriteLine("Ответ: ");                                              //вывод результата пользователю
                Console.WriteLine(Compute(matrixG, dim, vector));

                file.Close();

            }

            else
            {
                Console.WriteLine("Матрица должна быть симметричной");
                file.Close();
            }

            Console.Read();
        }

        //проверено на 2-х, 3-х, 4-х, мерных пространствах
    }
}
