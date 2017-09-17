using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modeling
{
    class RandomSimpson
    {
        Double a, b;
        MyRandom rand;
        public RandomSimpson(Double a, Double b, UInt32 Rn0 = 1, UInt32 A = 67, UInt32 M = 106897)
        {
            rand = new MyRandom(Rn0, A, M);
            this.a = a / 2;
            this.b = b / 2;
        }

        public Double Next()
        {
            double z = a + (b - a) * rand.Next();
            double y = a + (b - a) * rand.Next();
            return z + y;
        }

    }
}
