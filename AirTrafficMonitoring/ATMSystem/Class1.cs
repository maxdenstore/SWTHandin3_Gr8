using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOS;
using TransponderReceiver;

namespace ATMSystem
{
    public class airMonitor
    {

        Converter con = new Converter(TransponderReceiverFactory.CreateTransponderDataReceiver());
        List<TOS.TOS> monitorList = new List<TOS.TOS>();
        public airMonitor()
        {

           con.Converted. 
        }

        public void getEvent()
        {
            while (con.)
            {
                
            }
        }


    }
}
