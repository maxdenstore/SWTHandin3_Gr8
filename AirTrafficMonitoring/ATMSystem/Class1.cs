using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using TOS;
using TransponderReceiver;

namespace ATMSystem
{
    public class airMonitor
    {
        TOS.TOS currenTos;

        

        TOS.TransponderReceiver con = new TOS.TransponderReceiver(TransponderReceiverFactory.CreateTransponderDataReceiver());
        List<TOS.TOS> monitorList = new List<TOS.TOS>();
        public airMonitor()
        {
            currenTos = con.Received;
            if (con.Received != null)
            {
                
            }

        }

        public void getEvent()
        {
            
        }


    }
}