using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace TOS.Unit.Test.Tests
{
    [TestFixture]
    class ConverterTest
    {
        private ReceiveTranspond uut = new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver());
        public string tag = "ATR423";
        public int PosistionX = 39045;
        public int PosistionY = 12932;
        public int altitude = 14000;
        public DateTime DateTime = new DateTime(2015, 10, 6, 21, 34, 56, 789);
        [SetUp]
        public void Setup()
        {

        }

        //Test Tag
        [Test]
        public void tagTest() //exact
        {
           TOS xy = uut.receive("ATR423;39045;12932;14000;20151006213456789");
           Assert.That(xy.Tag == "ATR423");
        }

        [Test]
        public void tagLength() //Lenght
        {
            TOS xy = uut.receive("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.Tag.Length, Is.EqualTo(6));
        }

        [Test]
        public void tagContains() //no diff to A-Z, 1-9
        {
            TOS xy = uut.receive("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.Tag.All(char.IsLetterOrDigit));
        }

        //Test X Cord

        [Test]
        public void XCordExact() //Exact
        {
            TOS xy = uut.receive("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.PosistionX == 39045);
        }

        //Test Y Cord

        [Test]
        public void YCordContains() //Exact
        {
            TOS xy = uut.receive("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.PosistionY == 12932);
        }

        //Test Altitude
        [Test]
        public void AltitudeIsSame()
        {
            TOS xy = uut.receive("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.Altitude == 14000);
        }

        //Test Timestamp
        [Test]
        public void TimeStampDay()
        {
            TOS xy = uut.receive("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.TimeStamp.Day == 6);
        }

        [Test]
        public void TimeStampMonth()
        {
            TOS xy = uut.receive("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.TimeStamp.Month == 10);
        }

        [Test]
        public void TimeStampYear()
        {
            TOS xy = uut.receive("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.TimeStamp.Year == 2015);
        }

        [Test]
        public void TimeStampHour()
        {
            TOS xy = uut.receive("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.TimeStamp.Hour == 21);
        }

        [Test]
        public void TimeStampMinute()
        {
            TOS xy = uut.receive("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.TimeStamp.Minute == 34);
        }

        [Test]
        public void TimeStampSecond()
        {
            TOS xy = uut.receive("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.TimeStamp.Second == 56);
        }

        [Test]
        public void TimeStampMSec()
        {
            TOS xy = uut.receive("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.TimeStamp.Millisecond == 789);
        }

        //Test transponderReceiverData
        [Test]
        public void transponderRecieverDataTest()
        {
            List<string> test = new List<string>();
            test.Add("TestTag;39045;12932;14000;20151006213456789");
            uut.transponderReceiverData(this,new RawTransponderDataEventArgs(test));

            Assert.That(uut.Received.Tag == "TestTag");
        }
    }

}
