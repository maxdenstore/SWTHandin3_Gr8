
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TOS.Unit.Test.Tests
{
    [TestFixture]
    public class TOSTest
    {
        public string tag = "ATR423";
        public string PosistionX = "39045 meters";
        public string PosistionY = "12932 meters";
        public string altitude = "14000 meters";
        public string DateTime = "October 6th, 2015, at 21:34:56 and 789 milliseconds";
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
