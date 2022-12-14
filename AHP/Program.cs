using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP
{
    internal class Program
    {
        public static string path = @"Path";
        static void Main(string[] args)
        {
            ResultAHP res = Conclusion.start(path);
            Console.WriteLine("Вес критериев");
            Output.printMatrix(res.criteriaResult);
            Console.WriteLine("ОС: " + Math.Round(res.os , 3));
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Вес альтернатив");
            Console.WriteLine("--------------------------------------------");
            foreach (var i in res.altResult)
            {
                Console.WriteLine("Вес " + i.Key);
                Output.printMatrix(i.Value);
                Console.WriteLine("ОС: " + Math.Round(res.osAlt[i.Key], 3));
                Console.WriteLine("--------------------------------------------");
            }
            Console.WriteLine("Результаты");
            Output.printMatrix(res.finalResult);
            Console.WriteLine("ОС: " + Math.Round(res.oos, 3));
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Чтобы достичь цели: " + res.goal[0]);
            double a = 0;
            string b = "";
            foreach(var i in res.finalResult)
            {
                if(a < i.Value)
                {
                    a = i.Value;
                    b = i.Key;
                }
            }
            Console.WriteLine(b + " " + Math.Round(a * 100, 3) + "%");
            Console.ReadLine();
        }
    }
}
