using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Modeling
{
    class MyRandom
    {
        private UInt32 Rn, a, m;

        public MyRandom(UInt32 R0, UInt32 a, UInt32 m)
        {
            this.a = a;
            this.m = m;
            this.Rn = R0;          
        }

        public double Next()
        {
            Rn = (Rn * a) % m;
           
            return Convert.ToDouble(Rn) / m;
        }

        public double Next(out UInt32 R)
        {
            Rn = (Rn * a) % m;
            R = Rn;
                      
            return Convert.ToDouble(Rn) / m;
        }
    }
}
