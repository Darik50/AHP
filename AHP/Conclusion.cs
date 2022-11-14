using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHP
{
    internal class Conclusion
    {
        public static ResultAHP start(string path)
        {
            DataAHP data = Input.InputData(path);
            ResultAHP result = new ResultAHP();
            result.goal = data.goal;
            double[] nvp = Counter.Count(data.pairwise);
            result.criteriaResult = new Dictionary<string, double>();
            for (int i = 0; i < data.criteria.Length; i++)
            {
                result.criteriaResult.Add(data.criteria[i], nvp[i]);
            }
            result.altResult = new Dictionary<string, Dictionary<string, double>>();
            for (int k = 0; k < data.criteria.Length; k++)
            {
                double[] nvpAlt = Counter.Count(data.pairwiseAlt[k]);
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
            return result;
        }
    }
}
