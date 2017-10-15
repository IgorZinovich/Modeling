using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO
{
    class Request
    {
        
        private UInt32 time = 0;
        public UInt32 Time { get { return time; } }

        public void newPosition()
        {
             time++;
        }
    }
}
