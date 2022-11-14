using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP
{
    internal class DataAHP
    {
        public string[] goal;
        public string[] criteria;
        public string[] alternatives;
        public double[,] pairwise;
        public List<double[,]> pairwiseAlt;
    }
}
