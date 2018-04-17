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
        public List<TOS.TOS> monitorList = new List<TOS.TOS>();

        public AirMonitor()
        {
            
        }

        public void ReceiveNewTOS(TOS.TOS NewTOS)
        {
            if (monitorList.Find(x => x.Tag == NewTOS.Tag) != null) //if the tag exsists in the list
            {
                //measue speed etc
            }

            else
            {
                monitorList.Add(NewTOS);
            }
            monitorList[monitorList.Count-1].print();

        }

    }
}