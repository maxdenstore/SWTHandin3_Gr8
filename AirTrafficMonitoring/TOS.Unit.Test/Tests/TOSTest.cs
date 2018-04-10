
using System;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TOS.Unit.Test.Tests
{
    [TestFixture]
    public class TOSTest
    {
        public string tag = "ATR423";
        public int PosistionX = 39045;
        public int PosistionY = 12932;
        public int altitude = 14000;

        public DateTime DateTime = new DateTime(2015,10,6,21,34,56,789);
        public ITOS uut;

        [SetUp]
        public void setup()
        {
            uut = new TOS(tag, PosistionX, PosistionY, altitude, DateTime);
            
        }
        [Test]
        public void testTag()
        {
            Assert.That(uut.Tag , Is.EqualTo(tag));
        }
        [Test]
        public void testPosistionX()
        {
            Assert.That(uut.PosistionX, Is.EqualTo(PosistionX));
        }
        [Test]
        public void testPosistionY()
        {
            Assert.That(uut.PosistionY, Is.EqualTo(PosistionY));
        }
        [Test]
        public void testAltitude()
        {
            Assert.That(uut.Altitude, Is.EqualTo(altitude));
        }
        [Test]
        public void testDateTime()
        {
            Assert.That(uut.TimeStamp, Is.EqualTo(DateTime));
        }

    }
}
