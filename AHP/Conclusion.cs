using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP
{
    //Класс для вычисления окончательных результатов на основе полученных весов
    internal class Conclusion
    {
        //Таблица значений СС
        public static Dictionary<int, double> randomConfirmation = new Dictionary<int, double>
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
        //Запись итоговых результатов в поля класса ResultAHP
        public static ResultAHP start(string path)
        {
            DataAHP data = Input.InputData(path);
            ResultAHP result = new ResultAHP();
            result.goal = data.goal;
            resNvp nvpAll = Counter.Count(data.pairwise);
            double[] nvp = nvpAll.nvpAverages;
            result.os = nvpAll.os;
            result.criteriaResult = new Dictionary<string, double>();
            for (int i = 0; i < data.criteria.Length; i++)
            {
                result.criteriaResult.Add(data.criteria[i], nvp[i]);
            }
            result.altResult = new Dictionary<string, Dictionary<string, double>>();
            result.osAlt = new Dictionary<string, double>();
            for (int k = 0; k < data.criteria.Length; k++)
            {
                resNvp nvpAllAlt = Counter.Count(data.pairwiseAlt[k]);
                double[] nvpAlt = nvpAllAlt.nvpAverages;
                result.osAlt.Add(data.criteria[k], nvpAllAlt.os);
                result.altResult.Add(data.criteria[k], new Dictionary<string, double>());
                for (int i = 0; i < data.alternatives.Length; i++)
                {
                    result.altResult[data.criteria[k]].Add(data.alternatives[i], nvpAlt[i]);
                }
            }
            result.finalResult = new Dictionary<string, double>();
            for(int i = 0; i < data.alternatives.Length; i++)
            {
                double w = 0;
                for (int j = 0; j < result.altResult.Count; j++)
                {
                    w += result.altResult[data.criteria[j]][data.alternatives[i]] * result.criteriaResult[data.criteria[j]];
                }
                result.finalResult.Add(data.alternatives[i], w);
            }
            double ois = 0;
            foreach (var i in result.osAlt)
            {
                ois += i.Value * result.criteriaResult[i.Key];
            }
            result.oos = ois / randomConfirmation[result.criteriaResult.Count];
            return result;
        }
    }
}
