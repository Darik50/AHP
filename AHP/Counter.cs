using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AHP
{
    internal class Counter
    {
        public static Dictionary<int,double> randomConfirmation = new Dictionary<int, double> 
        {
            {1,0},
            {2,0},
            {3,0.58},
            {4,0.9},
            {5,1.12},
            {6,1.24},
            {7,1.32},
            {8,1.41},
            {9,1.45},
            {10,1.49},
            {11,1.51},
            {12,1.48},
            {13,1.56},
            {14,1.57},
            {15,1.59}
        };
        public static resNvp Count(double[,] pairwise)
        {

            double[] averages = new double[pairwise.GetUpperBound(1) + 1];
            for(int i = 0; i < pairwise.GetUpperBound(1) + 1; i++)
            {
                double[] str = new double[pairwise.GetUpperBound(1) + 1];
                for (int j = 0; j < pairwise.GetUpperBound(0) + 1; j++)
                {
                    str[j] = pairwise[j, i];
                }
                double summ = Summ(str);
                averages[i] = summ;
            }
            double averagesSumm = Summ(averages);
            double[] nvpAverages = new double[pairwise.GetUpperBound(0) + 1];
            for (int i = 0; i < pairwise.GetUpperBound(0) + 1; i++)
            {
                double[] str = new double[pairwise.GetUpperBound(1) + 1];
                for (int j = 0; j < pairwise.GetUpperBound(1) + 1; j++)
                {
                    str[j] = pairwise[i, j] / averages[j];
                }
                double summ = Summ(str);
                double count = str.Length;
                double average = Average(summ, count);
                nvpAverages[i] = average;
            }
            resNvp res = new resNvp();
            res.nvpAverages = nvpAverages;
            res.os = Check(pairwise, nvpAverages);

            if (res.os < 0.10)
            {
                return res;
            }
            else
            {
                Console.WriteLine("Consistency violation");
                return res;
            }
        }
        static double Summ(double[] str)
        {
            double summ = 0;
            for (int i = 0; i < str.Length; i++)
            {
                summ += str[i];
            }
            return summ;
        }
        public static double Check(double[,] pairwise, double[] nvpAverages)
        {
            double[] A = new double[pairwise.GetUpperBound(1) + 1];
            for (int i = 0; i < pairwise.GetUpperBound(0) + 1; i++)
            {
                A[i] = 0;
                for (int j = 0; j < pairwise.GetUpperBound(1) + 1; j++)
                {
                    A[i] += pairwise[j,i];
                }
            }
            for (int i = 0; i < pairwise.GetUpperBound(0) + 1; i++)
            {
                A[i] = A[i] * nvpAverages[i];
            }
            double lim = Summ(A);
            double confirmationIndex = (lim - nvpAverages.Length) / (nvpAverages.Length - 1);
            double resutlConfirmation = confirmationIndex / randomConfirmation[nvpAverages.Length];
            return resutlConfirmation;
        }
        static double Mult(double[] str)
        {
            double mult = 1;
            for(int i = 0; i < str.Length; i++)
            {
                mult += str[i];
            }
            return mult;
        }
        static double Nvp(double summ, double value)
        {
            return value / summ;
        }
        static double Average(double mult, double count)
        {
            return mult / count;
        }
    }
}
