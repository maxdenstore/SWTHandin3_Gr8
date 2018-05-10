using System;
using ATMSystem;
using ATMSystem.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace TranspondObject.Unit.Test
{
    [TestFixture]
    public class TransponderObjectTest
    {
        private string tag = "ATR423";
        private int PosistionX = 39045;
        private int PosistionY = 12932;
        private int altitude = 14000;

        private DateTime DateTime = new DateTime(2015,10,6,21,34,56,789);
        private ITranspondObject uut;
        private IOutput Output;

        [SetUp]
        public void setup()
        {
            Output = Substitute.For<IOutput>();
            uut = new ATMSystem.TranspondObject(tag,PosistionX,PosistionY,altitude,DateTime,Output);
            
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
