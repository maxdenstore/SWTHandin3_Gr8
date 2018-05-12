using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ATMSystem;
using ATMSystem.Interfaces;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;


namespace Integration_Test_ATM
{
    public class IT_ATM
    {
        private string testString = "ATR423;39045;12932;14000;20151006213456789";

        [SetUp]
        public void Setup()
        {

        }

        //***********************************************************************TEST OF INPUT*********************************************************************
        // Test transponderReceive
        [Test]
        public void transponderRecieverDataTest()
        {
            ITranspondObject stubTos = Substitute.For<ITranspondObject>();
            IDetectSepartation stubDetect = Substitute.For<IDetectSepartation>();
            IOutput _out = new Output();
            AirMonitor air = new AirMonitor(new MeasureDegress(), new MeasureVelocity(),stubDetect,_out);
            ReceiveTranspond uut = new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(),_out, air);
            List<string> test = new List<string>();
            test.Add(testString);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

        }

    }
}
