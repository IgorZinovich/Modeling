using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO
{
    class SMO
    {
        private Double P1;
        private Double P2;
        private Double P3;
        Request[] list = new Request[3];
        private UInt32 allTimes = 0;
        private UInt32 countExit = 0;
        private UInt32 processed = 0;
        private Double[] stateCount = new Double[8];
        private UInt32 countElement = 0;
        private Random rand = new Random();
        public SMO(Double p1, Double p2, Double p3)
        {

            P1 = p1;
            P2 = p2;
            P3 = p3;
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = null;
            }
            for (int i = 0; i < stateCount.Length; i++)
            {
                stateCount[i] = 0;
            }
        }
        public void Next()
        {
            if (list[0] != null) list[0].newPosition();
            if (list[1] != null) list[1].newPosition();
            if (list[2] != null) list[2].newPosition();
            ResState();
            UInt32[] transitions = GetChance();
            if(list[2] != null)
            {
                if (transitions[2] == 1)
                {
                    allTimes += list[2].Time;
                    countExit++;
                    processed++;
                    list[2] = null;
                }
                else
                {
                  //  list[2].newPosition();
                }
            }
            if (list[1] != null)
            {
              //  list[1].newPosition();
                if(list[2] == null)
                {
                    list[2] = list[1];
                    list[1] = null;
                }
            }
            if(list[0] != null)
            {
                
                if(transitions[1] == 1)
                {
                    if (list[1] != null)
                    {
                        allTimes += list[0].Time;
                        countExit++;
                    }
                    else
                    {
                        if(list[2] == null)
                        {
                            list[2] = list[0];
                        }
                        else
                        {
                            list[1] = list[0];
                        }  
                    }
                    list[0] = null;
                }
                if(list[0] != null)
                {
                 //   list[0].newPosition();
                }
            }

            if(transitions[0] == 1)
            {
                if (list[0] == null)
                {
                    list[0] = new Request();
                   // list[0].newPosition();
                }    
            }
           
        }
        
        private UInt32[] GetChance()
        {
            UInt32[] res = new UInt32[3];
            Double p = rand.NextDouble();
            if(p<P1)
            {
                res[0] = 0;
            }
            else
            {
                res[0] = 1;
            }
            Double p1 = rand.NextDouble();
            if(p1 < P2)
            {
                res[1] = 0;
            }
            else
            {
                res[1] = 1;
            }
            Double p2 = rand.NextDouble();
            if (p2 < P3)
            {
                res[2] = 0;
            }
            else
            {
                res[2] = 1;
            }
            return res;
        }
        private void ResState()
        {
            UInt32 idx = 0;
            UInt32 count = 0;
            if (list[2] != null)
            {
                count++;
                idx += 1;
            }
            if (list[1] != null)
            {
                count++;
                idx += 2;
            }
            if (list[0] != null)
            {
                count++;
                idx += 4;
            }
            stateCount[idx]++;
           // Console.WriteLine(idx);
            countElement += count;
        }

        public void Printf(UInt32 count)
        {
            String str= "";
            for (int i = 0; i < 8; i++)
            {
                
                if(i == 2 || i ==6)
                {
                    continue;
                }
                switch(i)
                {
                    case 0: str = "000";break;
                    case 1: str = "001"; break;
                    case 3: str = "011"; break;
                    case 4: str = "100"; break;
                    case 5: str = "101"; break;
                    case 7: str = "111"; break;
                }
                Console.Write("p");
                Console.Write(str);
                Console.WriteLine(" = {0}", stateCount[i] / Convert.ToDouble(stateCount.Sum()));
            }
            Console.WriteLine("A = {0}, L = {1}, W = {2}", Convert.ToDouble(processed) / Convert.ToDouble(count),
                Convert.ToDouble(countElement)/ Convert.ToDouble(count), Convert.ToDouble(allTimes) / Convert.ToDouble(countExit));
        }
    }
}
