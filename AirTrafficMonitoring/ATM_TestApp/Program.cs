using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMSystem;
using TOS;
using TransponderReceiver;

namespace ATM_TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ATMSystem.AirMonitor X = new AirMonitor();
            ReceiveTranspond transpond = new ReceiveTranspond((TransponderReceiverFactory.CreateTransponderDataReceiver()),X);

            string pre = Console.ReadLine();

            if (pre == "New data: ")
            {
                Console.Clear();
            }
            else
                Console.ReadLine();

        }
    }
}
