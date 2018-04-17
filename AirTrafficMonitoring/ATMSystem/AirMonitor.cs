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
        private MeasureVelocity _measureVelocity = new MeasureVelocity();
        public AirMonitor()
        {
            
        }

        public void ReceiveNewTOS(TOS.TOS NewTOS)
        {
            
            if (monitorList.Exists(x => x.Tag == NewTOS.Tag)) //if the tag exsists in the list
            {
                int index = monitorList.FindIndex(x => x.Tag == NewTOS.Tag);
                TOS.TOS old = monitorList[index];
                
                //measue speed
                _measureVelocity.Measure(old,NewTOS);

                monitorList[index] = NewTOS;

                //measure degress
            }

            else
            {
                monitorList.Add(NewTOS);
            }
            monitorList[monitorList.Count-1].print();

        }

    }
}