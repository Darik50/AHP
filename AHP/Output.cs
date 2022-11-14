using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP
{
    internal class Output
    {
        public static void printMatrix(Dictionary<string, double> dict)
        {
            int len = 0;
            foreach (var i in dict)
            {
                if(len < i.Key.Length)
                {
                    len = i.Key.Length;
                }
            }
            foreach (var i in dict)
            {
                Console.WriteLine(i.Key.PadRight(len) + ' ' + Math.Round(i.Value * 100, 3) + "%");
            }
        }
    }
}
