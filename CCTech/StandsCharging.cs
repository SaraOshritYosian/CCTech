using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Printing;

using System.Windows.Documents;

namespace CCTech
{

    class StandsCharging
    {
        public const int numberOfStands = 4;
        public bool available = true;
        public StandsCharging()
        {
            available = true;
           
        }
          
    

    public bool GetAvailable()
    {
        return available;

    }
    public void SetAvailable(bool avail)
    {
        available = avail;
    }
}
}

        

     

    