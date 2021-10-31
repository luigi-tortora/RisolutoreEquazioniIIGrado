using System;
using System.Collections.Generic;

namespace Risolutore_Equazioni
{
    class Program
    {
        static void Main(string[] args)
        {
            string a;
            string b;
            string c;

            Console.WriteLine("Risolutore di Equazioni di II° Grado");

            Console.WriteLine("Inserire il valore del primo coefficiente: ");
            a = Console.ReadLine();

            Console.WriteLine("Inserire il valore del secondo coefficiente: ");
            b = Console.ReadLine();

            Console.WriteLine("Inserire il valore del terzo coefficiente: ");
            c = Console.ReadLine();

            if (a.Contains('/') || b.Contains('/') || c.Contains('/')) 
            {
                CalcFract(a, b, c);
            } 
            else 
            {
                CalcInt(float.Parse(a), float.Parse(b), float.Parse(c));
            }
        }

        public static void CalcInt(float a, float b, float c)
        {
            float _delta = MathF.Pow(b, 2) - 4*(a*c);

            if (_delta > 0)
            {
                Console.WriteLine("Questa equazione ha due soluzioni.");
            } 
            else if (_delta == 0)
            {
                Console.WriteLine("Questa equazione ha una sola soluzione.");
            }
            else
            {
                Console.WriteLine("Questa equazione non ha soluzioni.");
                return;
            }

            Console.WriteLine("----------------------------");

            float x1 = ((b * -1) + MathF.Sqrt(_delta)) / 2 * a;
            float x2 = ((b * -1) - MathF.Sqrt(_delta)) / 2 * a;

            Console.WriteLine(Convert.ToString(MathF.Round(x1, 1)));
            Console.WriteLine(Convert.ToString(MathF.Round(x2, 1)));
        }

        public static void CalcFract(string a, string b, string c)
        {
            string[] fractA = {};
            string[] fractB = {};
            string[] fractC = {};

            List<int> l1;
            List<int> l2;
            List<int> l3;

            int numA, denA, numB, denB, numC, denC;
            numA = denA = numB = denB = numC = denC = 0;

            // SPLIT FRACTIONS
            if (a.Contains('/'))
            {
                fractA = a.Split('/', 2);

                numA = int.Parse(fractA[0]);
                denA = int.Parse(fractA[1]);
            } 
            else 
            {
                numA = int.Parse(a);
                denA = 1;
            }
            
            if (b.Contains('/'))
            {
                fractB = b.Split('/', 2);

                numB = int.Parse(fractB[0]);
                denB = int.Parse(fractB[1]);
            } 
            else 
            {
                numB = int.Parse(b);
                denB = 1;
            }

            if (c.Contains('/'))
            {
                fractC = c.Split('/', 2);

                numC = int.Parse(fractC[0]);
                denC = int.Parse(fractC[1]);
            } 
            else 
            {
                numC = int.Parse(a);
                denC = 1;
            }

            l1 = DecompositionPrime(denA);
            l2 = DecompositionPrime(denB);
            l3 = DecompositionPrime(denC);
        }

        private static readonly int [] _primeNumbers = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        public static List<int> DecompositionPrime(int x)
        {
            List<int> dividers = new();

            while (x != 1)
            {
                foreach (int primeNumber in _primeNumbers)
                {
                    if (x % primeNumber == 0)
                    {
                        dividers.Add(primeNumber);   
                        x /= primeNumber;

                        break;
                    }
                }
            }

            return dividers;
        }

        public static int CalcoloMCM(int denA, int denB, int denC)
        {
            Dictionary<int, int> potenze = new();

            List<int> kA = DecompositionPrime(denA);
            List<int> kB = DecompositionPrime(denB);
            List<int> kC = DecompositionPrime(denC);

            foreach (int divider in kA)
            {
                if (!potenze.ContainsKey(divider))
                {
                    potenze.Add(divider, 0);
                }
                else
                {
                    continue;
                }
            }

            foreach (int divider in kB)
            {
                if (!potenze.ContainsKey(divider))
                {
                    potenze.Add(divider, 0);
                }
                else
                {
                    continue;
                }
            }

            foreach (int divider in kC)
            {
                if (!potenze.ContainsKey(divider))
                {
                    potenze.Add(divider, 0);
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
