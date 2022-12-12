using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP
{
    //Класс для записи результатов
    internal class ResultAHP
    {
        public string[] goal;
        public Dictionary<string, double> criteriaResult;
        public double os;
        public Dictionary<string, Dictionary<string, double>> altResult;
        public Dictionary<string, double> osAlt;
        public Dictionary<string, double> finalResult;
        public double oos;
    }
}
