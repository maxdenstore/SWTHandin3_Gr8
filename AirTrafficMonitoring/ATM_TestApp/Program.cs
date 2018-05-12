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
            int minimumAirpace = 10000;
            int maximumAirspace = 90000;
            IOutput _out = new Output();
            IDetectSepartation _detection = new DetectSepartation(_out);

            AirMonitor x = new AirMonitor(new MeasureDegress(), new MeasureVelocity(), _detection , _out,minimumAirpace,maximumAirspace);
            ReceiveTranspond transpond = new ReceiveTranspond((TransponderReceiverFactory.CreateTransponderDataReceiver()),_out, x);

             Console.ReadLine();

        }
    }
}
