using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumDistribution
{
    public class Distribution
    {
        private string _type;
        private double _sum;
        private List<double> _sums = new List<double>();
        private const string constDistributionProportionality = "проп";
        private const string constDistributionFirst = "перв";
        private const string constDistributionLast = "посл";

        public Distribution(string type, string sum, string sums)
        {
            _type = type;
            if (!double.TryParse(sum, out _sum))
            {
                throw new Exception("Incorect sum: " + sum);
            }
;
            var stringSums = sums.Split(';').ToArray();
            foreach (var el in stringSums)
            {
                if (double.TryParse(el, out double outEl))
                {
                    _sums.Add(outEl);
                }
                else
                {
                    throw new Exception("Incorect sums element: " + el);
                }
            }
        }

        public List<double> GetDistribution()
        {
            List<double> result = new List<double>();
            switch (_type.ToLower())
            {
                case constDistributionProportionality:
                    result = DistributionProportionality(_sums, _sum);
                    break;
                case constDistributionFirst:
                    result = DistributionFirstorLast(_sums, _sum);
                    break;
                case constDistributionLast:
                    result = DistributionFirstorLast(_sums, _sum, true);
                    break;
                default: throw new Exception("Incorect type distribution: " + _type);
            }
            return result;
        }

        public List<double> DistributionProportionality(List<double> sums, double sum)
        {
            var sumsList = sums.Sum();
            var a = Math.Round(sums[0] / sumsList, 2);
            sums = sums.Select(s => s / sumsList).ToList();
            var result = sums.Select(s => Math.Round(s * sum, 2)).ToList();
            if (result.Sum() < sum)
            {
                result[result.IndexOf(result.Last())] += sum - result.Sum();
            }
            return result;
        }

        public List<double> DistributionFirstorLast(List<double> sums, double sum, bool revers = false)
        {
            List<double> result = new List<double>();
            if (revers)
            {
                sums.Reverse();
            }
            foreach (var el in sums)
            {
                if (sum < 0)
                {
                    result.Add(0);
                }
                else
                {
                    result.Add(el);
                }
                sum -= el;
            }
            if (revers)
            {
                result.Reverse();
            }
            return result;
        }
    }
}
