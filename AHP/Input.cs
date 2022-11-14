using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AHP
{
    internal class Input
    {
        public static string path = @"D:\Darik\Парх\Курсач\Ввод.txt";
        public static DataAHP InputData (string path)
        {
            DataAHP data = new DataAHP();
            string[] lines = System.IO.File.ReadAllLines(path);
            int o = 0;
            if (lines[o] == "Цель:")
            {
                o++;
                data.goal = lines[o].Split(' ');
                o++;
                if (lines[o] == "Критерии:")
                {
                    o++;
                    data.criteria = lines[o].Split(' ');
                    o++;
                    if (lines[o] == "Альтернативы:")
                    {
                        o++;
                        data.alternatives = lines[o].Split(' ');
                        o++;
                        if (lines[o] == "Матрица критериев:")
                        {
                            o++;
                            data.pairwise = new double[data.criteria.Length, data.criteria.Length];
                            for(int i = 0; i < data.criteria.Length; i++)
                            {
                                string[] linMat = lines[o + i].Split(' ');                                
                                for (int j = 0; j < linMat.Length; j++)
                                {
                                    data.pairwise[i, j] = Convert.ToDouble(linMat[j].Replace('.', ','));
                                }
                            }
                            o += data.criteria.Length;
                            data.pairwiseAlt = new List<double[,]>();
                            for(int k = 0; k < data.criteria.Length; k++)
                            {
                                if (lines[o] == "Матрица альтернатив:")
                                {
                                    o++;
                                    double[,] matrixAlt = new double[data.alternatives.Length, data.alternatives.Length];
                                    for (int i = 0; i < data.alternatives.Length; i++)
                                    {
                                        string[] linMat = lines[o + i].Split(' ');
                                        for (int j = 0; j < linMat.Length; j++)
                                        {
                                            matrixAlt[i, j] = Convert.ToDouble(linMat[j].Replace('.', ','));
                                        }
                                    }
                                    data.pairwiseAlt.Add(matrixAlt);
                                    o += data.alternatives.Length;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input data");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input data");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input data");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Invalid input data");
                Console.ReadLine();
                Environment.Exit(0);
            }
            return data;
        }

    }
}
