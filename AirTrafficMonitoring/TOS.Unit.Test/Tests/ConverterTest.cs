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
        private Converter uut = new Converter(TransponderReceiverFactory.CreateTransponderDataReceiver());
        [SetUp]
        public void Setup()
        {

        }

        //Test Tag
        [Test]
        public void tagTest() //exact
        {
           TOS xy = uut.convert("ATR423;39045;12932;14000;20151006213456789");
           Assert.That(xy.Tag == "ATR423");
        }

        [Test]
        public void tagLength() //Lenght
        {
            TOS xy = uut.convert("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.Tag.Length, Is.EqualTo(6));
        }

        [Test]
        public void tagContains() //no diff to A-Z, 1-9
        {
            TOS xy = uut.convert("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.Tag.All(char.IsLetterOrDigit));
        }

        //Test X Cord

        [Test]
        public void XCordExact() //Exact
        {
            TOS xy = uut.convert("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.PosistionX == "39045 Meters");
        }

        //Test Y Cord

        [Test]
        public void YCordContains() //Exact
        {
            TOS xy = uut.convert("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.PosistionY == "12932 Meters");
        }

        //Test Altitude
        [Test]
        public void AltitudeIsSame()
        {
            TOS xy = uut.convert("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.Altitude.Contains("14000"));
        }

        //Test Timestamp
        [Test]
        public void TimeStampDay()
        {
            TOS xy = uut.convert("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.TimeStamp.Contains("6."));
        }

        [Test]
        public void TimeStampMonth()
        {
            TOS xy = uut.convert("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.TimeStamp.Contains("oktober"));
        }

        [Test]
        public void TimeStampYear()
        {
            TOS xy = uut.convert("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.TimeStamp.Contains("2015"));
        }

        [Test]
        public void TimeStampHour()
        {
            TOS xy = uut.convert("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.TimeStamp.Contains("21:"));
        }

        [Test]
        public void TimeStampMinute()
        {
            TOS xy = uut.convert("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.TimeStamp.Contains("34:"));
        }

        [Test]
        public void TimeStampSecond()
        {
            TOS xy = uut.convert("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.TimeStamp.Contains("56"));
        }

        [Test]
        public void TimeStampMSec()
        {
            TOS xy = uut.convert("ATR423;39045;12932;14000;20151006213456789");
            Assert.That(xy.TimeStamp.Contains(" 789 miliseconds"));
        }

        //Test transponderReceiverData
        [Test]
        public void bla()
        {
            List<string> test = new List<string>();
            test.Add("TestTag;39045;12932;14000;20151006213456789");
            uut.transponderReceiverData(this,new RawTransponderDataEventArgs(test));

            Assert.That(uut.Converted.Tag == "TestTag");
        }
    }

}
