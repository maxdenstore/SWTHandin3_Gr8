using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMSystem;
using NUnit;
using NUnit.Framework;
using TOS;
using TransponderReceiver;


namespace ATM.Unit.Test
{

    [TestFixture]

    public class ATM_Unit_Testing
    {
        private string testString = "ATR423;39045;12932;14000;20151006213456789";
        private static AirMonitor air = new AirMonitor();
        private ReceiveTranspond uut = new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(),air);
        //public string tag = "ATR423";
        //public int PosistionX = 39045;
        //public int PosistionY = 12932;
        //public int altitude = 14000;
        //public DateTime DateTime = new DateTime(2015, 10, 6, 21, 34, 56, 789);



        [SetUp]
        public void Setup()
        {

        }
        //Test transponderReceiverData
        [Test]
        public void transponderRecieverDataTest()
        {
            List<string> test = new List<string>();
            test.Add(testString);
            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            Assert.That(air.monitorList[air.monitorList.Count-1].Tag, Is.EqualTo(testString.Substring(0,6)));
        }

        //Test transponderReceiverData X cord
        [Test]
        public void transponderRecieverDataTestXCord()
        {
            List<string> test = new List<string>();
            test.Add(testString);
            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            Assert.That(air.monitorList[air.monitorList.Count - 1].PosistionX, Is.EqualTo((Int32.Parse(testString.Substring(7, 5)))));
        }

        //Test transponderReceiverData Y cord
        [Test]
        public void transponderRecieverDataTestYCord()
        {
            List<string> test = new List<string>();
            test.Add(testString);
            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            Assert.That(air.monitorList[air.monitorList.Count - 1].PosistionY, Is.EqualTo((Int32.Parse(testString.Substring(13, 5)))));
        }


        //Test transponderReceiverData altitude
        [Test]
        public void transponderRecieverDataTestAltitude()
        {
            List<string> test = new List<string>();
            test.Add(testString);
            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            Assert.That(air.monitorList[air.monitorList.Count - 1].Altitude, Is.EqualTo((Int32.Parse(testString.Substring(19, 5)))));
        }

        //Test transponderReceiverData Datettime
        [Test]
        public void transponderRecieverDataTestTimestamp()
        {
            List<string> test = new List<string>();
            test.Add(testString);
            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            Assert.That(air.monitorList[air.monitorList.Count - 1].TimeStamp, Is.EqualTo(DateTime.Parse("2015-10-06 21:34:56.789")));
        }

    }


}
