using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO
{
    
    class Program
    {
        static UInt32 interval = 1000000;
        static void Main(string[] args)
        {
            Double p1, p2, p3;
            try
            {
                Console.Write("p = ");
                p1 = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine("p = {0}", 0.7);
                p1 = 0.7;
            }
            try
            {
                Console.Write("p2 = ");
                p2 = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine("p = {0}", p1);
                Console.WriteLine("p1 = {0}", 0.7);
                p2 = 0.7;
            }
            try
            {
                Console.Write("p3 = ");
                p3 = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine("p = {0}", p1);
                Console.WriteLine("p1 = {0}", p2);
                Console.WriteLine("p2 = {0}", 0.75);
                p3 = 0.75;
            }

            Console.WriteLine();

            SMO smo = new SMO(p1,p2,p3);
            for(UInt32 i =0; i < interval; i++)
            {
                smo.Next();
            }
            smo.Printf(interval);
            Console.Read();
        }
    }
}
