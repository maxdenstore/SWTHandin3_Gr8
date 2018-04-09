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


        //Test Timestamp

        //Test transponderReceiverData

    }



}
