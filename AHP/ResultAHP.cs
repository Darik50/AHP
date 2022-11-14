using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP
{
    internal class ResultAHP
    {
        public string[] goal;
        public Dictionary<string, double> criteriaResult;
        public Dictionary<string, Dictionary<string, double>> altResult;
        public Dictionary<string, double> finalResult;
    }
}
