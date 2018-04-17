using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TOS;
using TransponderReceiver;

namespace ATMSystem
{
    public class AirMonitor
    {
        List<TOS.TOS> monitorList = new List<TOS.TOS>();

        public AirMonitor()
        {
            
        }

        public void ReceiveNewTOS(TOS.TOS NewTOS)
        {
            monitorList.Add(NewTOS);
        }

    }
}