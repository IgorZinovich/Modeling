using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeling
{
    class Functions
    {
        public static double GetMedian(List<Double> list)
        {
            return list.Sum() / Convert.ToDouble(list.Count);
        }

        public static double GetDisp(List<Double> list)
        {
            Double mx = GetMedian(list);
            Double dx = 0;
            foreach (var iter in list)
            {
                dx += Math.Pow(iter - mx, 2);
            }
            dx /= list.Count - 1;
            return dx;
        }

        public static double GetRMS(List<Double> list)
        {
            return Math.Sqrt(GetDisp(list));
        }
    }
}
