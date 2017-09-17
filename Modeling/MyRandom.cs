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
        private int Rn0, Rn, a, m;

        public MyRandom(int R0, int a, int m)
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

        public double Next(out int R)
        {
            Rn = (Rn * a) % m;
            R = Rn;
                      
            return Convert.ToDouble(Rn) / m;
        }

        public bool check()
        {
            if (Rn == Rn0)
                return false;
            return true;
        }


    }
}
