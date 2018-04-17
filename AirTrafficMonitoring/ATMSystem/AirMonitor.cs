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
    public class airMonitor
    {

        TOS.TransponderReceiver con = new TOS.TransponderReceiver(TransponderReceiverFactory.CreateTransponderDataReceiver());
        List<TOS.TOS> monitorList = new List<TOS.TOS>();
        public airMonitor()
        {

        }

        public void subscribe(TOS.TransponderReceiver m)
        {
            m.recivedEvent += new TOS.TransponderReceiver.TosReceived(m.);
           


        }

    }
}