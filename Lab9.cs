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
        static double Div(double in1, double in2)
        {
            double i = 1;

            while (in2 <= in1)
            {
                in2 *= i;
                i++;
            }

            return i--;
        }

        static double VarIn(string var)
        {
            Console.Write($"{var} = ");
            return Convert.ToDouble(Console.ReadLine());
        }

        static void Exe(ref MyStack.MyStack<string> opsStack, ref MyStack.MyStack<double> digStack, bool mod)
        {
            double sec;

            bool f = true;

            while (digStack.Size() >= 1 && opsStack.Size() > 0 && f)
            {
                string ops = opsStack.Pop();

                switch (ops)
                {
                    case "abs":
                        digStack.Push(Math.Abs(digStack.Pop()));
                        break;
                    case "sqrt":
                        digStack.Push(Math.Sqrt(digStack.Pop()));
                        break;
                    case "sign":
                        digStack.Push(Math.Sign(digStack.Pop()));
                        break;
                    case "sin":
                        digStack.Push(Math.Sin(digStack.Pop()));
                        break;
                    case "cos":
                        digStack.Push(Math.Cos(digStack.Pop()));
                        break;
                    case "tg":
                        digStack.Push(Math.Tan(digStack.Pop()));
                        break;
                    case "ln":
                        digStack.Push(Math.Log(digStack.Pop()));
                        break;
                    case "lg":
                        digStack.Push(Math.Log10(digStack.Pop()));
                        break;
                    case "min":

                        sec = digStack.Pop();
                        digStack.Push(Math.Min(digStack.Pop(), sec));

                        break;
                    case "max":

                        sec = digStack.Pop();
                        digStack.Push(Math.Max(digStack.Pop(), sec));

                        break;
                    case "mod":

                        sec = digStack.Pop();
                        digStack.Push(digStack.Pop() % sec);

                        break;
                    case "div":

                        sec = digStack.Pop();
                        digStack.Push(Div(digStack.Pop(), sec));

                        break;
                    case "exp":

                        digStack.Push(Math.Pow(Math.E, digStack.Pop()));

                        break;
                    case "unfract":
                        digStack.Push(Math.Round(digStack.Pop()));
                        break;
                    case "+":

                        sec = digStack.Pop();
                        digStack.Push(digStack.Pop() + sec);

                        break;
                    case "-":
                        sec = digStack.Pop();
                        digStack.Push(digStack.Pop() - sec);

                        break;
                    case "*":

                        sec = digStack.Pop();
                        digStack.Push(digStack.Pop() * sec);

                        break;
                    case "/":

                        sec = digStack.Pop();
                        digStack.Push(digStack.Pop() / sec);

                        break;
                    case "^":

                        sec = digStack.Pop();
                        digStack.Push(Math.Pow(digStack.Pop(), sec));

                        break;
                    case "(":
                        return;

                    default:
                        break;
                }

                if (!mod) f = false;
            }
        }

        static void RPN(string input, ref MyStack.MyStack<string> opsStack, ref MyStack.MyStack<double> digStack, ref MyArrayList.MyArrayList<Tuple<string, double>> vars, ref MyStack.MyStack<string> opsStackout, ref MyStack.MyStack<double> digStackout)
        {
            //bool unar = false;

            for (int i = 0; i < input.Length; i++)
            {
                //if ((input[i] > 47 && input[i] < 58) || (input[i] == '-' && (input[i++] > 47 && input[i++] < 58)))
                if ((input[i] > 47 && input[i] < 58))
                {
                    string target = Convert.ToString(input[i]);
                    i++;

                    for (; i < input.Length; i++)
                    {
                        if ((input[i] > 47 && input[i] < 58) || input[i] == ',')
                        {
                            target += input[i];
                        }
                        else
                        {
                            i--;
                            break;
                        }
                    }

                    digStack.Push(Convert.ToDouble(target));
                    digStackout.Push(Convert.ToDouble(target));
                    //if (unar)
                    //{
                    //    Exe(ref opsStack, ref digStack, false);
                    //}
                    //unar = false;
                }
                else
                {
                    if ((input[i] > 64 && input[i] < 90) || (input[i] > 96 && input[i] < 123))
                    {
                        string target = "";

                        for (; i < input.Length; i++)
                        {
                            if (!((input[i] > 64 && input[i] < 90) || (input[i] > 96 && input[i] < 123)))
                            {
                                i--;
                                break;
                            }
                            else
                            {
                                target += input[i];
                            }
                        }

                        switch (target)
                        {
                            case "abs":
                                opsStack.Push("abs");
                                opsStackout.Push("abs");
                                break;
                            case "sqrt":
                                opsStack.Push("sqrt");
                                opsStackout.Push("sqrt");
                                break;
                            case "sign":
                                opsStack.Push("sign");
                                opsStackout.Push("sign");
                                break;
                            case "sin":
                                opsStack.Push("sin");
                                opsStackout.Push("sin");
                                break;
                            case "cos":
                                opsStack.Push("cos");
                                opsStackout.Push("cos");
                                break;
                            case "tg":
                                opsStack.Push("tg");
                                opsStackout.Push("tg");
                                break;
                            case "ln":
                                opsStack.Push("ln");
                                opsStackout.Push("ln");
                                break;
                            case "lg":
                                opsStack.Push("lg");
                                opsStackout.Push("lg");
                                break;
                            case "min":
                                opsStack.Push("min");
                                opsStackout.Push("min");
                                break;
                            case "max":
                                opsStack.Push("max");
                                opsStackout.Push("max");
                                break;
                            case "mod":
                                opsStack.Push("mod");
                                opsStackout.Push("mod");
                                break;
                            case "div":
                                opsStack.Push("div");
                                opsStackout.Push("div");
                                break;
                            case "exp":
                                opsStack.Push("exp");
                                opsStackout.Push("exp");
                                break;
                            case "unfract":
                                opsStack.Push("unfract");
                                opsStackout.Push("unfract");
                                break;

                            default:
                                bool unexist = true;

                                for (int j = 0; j < vars.Size() && unexist; j++)
                                {
                                    Tuple<string, double> ex = vars.Get(j);

                                    if (target.Equals(ex.Item1))
                                    {
                                        unexist = false;
                                        digStack.Push(ex.Item2);
                                        digStackout.Push(ex.Item2);
                                    }
                                }

                                if (unexist)
                                {
                                    double varNew = VarIn(target);
                                    Tuple<string, double> var = new Tuple<string, double>(target, varNew);
                                    vars.Add(var);
                                    digStack.Push(varNew);
                                    digStackout.Push(varNew);
                                }
                                break;

                        }


                    }
                    else
                    {
                        switch (input[i])
                        {
                            case '+':
                                opsStackout.Push("+");
                                if (!opsStack.IsEmpty())
                                    while (!(opsStack.Peek().Equals("+") || opsStack.Peek().Equals("-")) && !(opsStack.IsEmpty() || opsStack.Peek().Equals("(")))
                                    {
                                        Exe(ref opsStack, ref digStack, false);
                                    }
                                opsStack.Push("+");
                                break;
                            case '-':
                                opsStackout.Push("-");
                                if (!opsStack.IsEmpty())
                                    while (!(opsStack.Peek().Equals("+") || opsStack.Peek().Equals("-")) && !(opsStack.IsEmpty() || opsStack.Peek().Equals("(")))
                                    {
                                        Exe(ref opsStack, ref digStack, false);
                                    }
                                opsStack.Push("-");
                                break;
                            case '*':
                                opsStackout.Push("*");
                                if (!opsStack.IsEmpty())
                                    while ((opsStack.Peek().Equals("/") || opsStack.Peek().Equals("^") || opsStack.Peek().Equals("*")) && !(opsStack.IsEmpty() || opsStack.Peek().Equals("(")))
                                    {
                                        Exe(ref opsStack, ref digStack, false);
                                    }
                                opsStack.Push("*");
                                break;
                            case '/':
                                opsStackout.Push("/");
                                if (!opsStack.IsEmpty())
                                    while ((opsStack.Peek().Equals("/") || opsStack.Peek().Equals("^")) && !(opsStack.IsEmpty() || opsStack.Peek().Equals("(")))
                                    {
                                        Exe(ref opsStack, ref digStack, false);
                                    }
                                opsStack.Push("/");
                                break;
                            case '^':
                                opsStackout.Push("^");
                                if (!opsStack.IsEmpty())
                                    while (opsStack.Peek().Equals("^") && !(opsStack.IsEmpty() || opsStack.Peek().Equals("(")))
                                    {
                                        Exe(ref opsStack, ref digStack, false);
                                    }
                                opsStack.Push("^");
                                break;
                            case ')':
                                opsStackout.Push(")");
                                Exe(ref opsStack, ref digStack, true);
                                if (!opsStack.Empty())
                                {
                                    if (opsStack.Peek() == "abs" || opsStack.Peek() == "sqrt" || opsStack.Peek() == "sign" || opsStack.Peek() == "sin" || opsStack.Peek() == "cos" || opsStack.Peek() == "tg" || opsStack.Peek() == "ln" || opsStack.Peek() == "lg" || opsStack.Peek() == "^" || opsStack.Peek() == "/" || opsStack.Peek() == "*" || opsStack.Peek() == "min" || opsStack.Peek() == "max" || opsStack.Peek() == "mod" || opsStack.Peek() == "div" || opsStack.Peek() == "unfract" || opsStack.Peek() == "exp")
                                    {
                                        Exe(ref opsStack, ref digStack, false);
                                    }

                                }
                                break;
                            case '(':
                                opsStackout.Push("(");
                                opsStack.Push("(");
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(Math.Sin(3*Math.PI/180));
            MyStack.MyStack<double> digStack = new MyStack.MyStack<double>();
            MyStack.MyStack<string> opsStack = new MyStack.MyStack<string>();

            MyStack.MyStack<double> digStackout = new MyStack.MyStack<double>();
            MyStack.MyStack<string> opsStackout = new MyStack.MyStack<string>();

            MyArrayList.MyArrayList<Tuple<string, double>> vars = new MyArrayList.MyArrayList<Tuple<string, double>>();

            string input = Console.ReadLine();

            RPN(input, ref opsStack, ref digStack, ref vars, ref opsStackout, ref digStackout);

            Console.WriteLine();
            while (opsStackout.Size() != 0)
            {
                Console.Write($"{opsStackout.Pop()} ");
            }
            Console.WriteLine();

            while (digStackout.Size() != 0)
            {
                Console.Write($"{digStackout.Pop()} ");
            }

            Console.WriteLine();
            Console.WriteLine();

            Exe(ref opsStack, ref digStack, true);
            Console.Write($"{digStack.Pop()} ");

            Console.Read();

        }
    }
}