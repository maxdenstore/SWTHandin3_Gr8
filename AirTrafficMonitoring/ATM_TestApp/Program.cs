using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMSystem;
using ATMSystem.Interfaces;
using TransponderReceiver;

namespace ATM_TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IOutput _out = new Output();
            IDetectSepartation _detection = new DetectSepartation(_out);
            ATMSystem.AirMonitor X = new AirMonitor(new MeasureDegress(), new MeasureVelocity(),_detection);
            ReceiveTranspond transpond = new ReceiveTranspond((TransponderReceiverFactory.CreateTransponderDataReceiver()),_out);

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
