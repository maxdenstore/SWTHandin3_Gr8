using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ATMSystem.Interfaces;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ATMSystem.unit.tests.Tests
{
    [TestFixture]
    class DetectSeparation
    {
        private ITranspondObject _fakTranspondObjectA;
        private ITranspondObject _fakTranspondObjectB;
        private IOutput _out;
        private IDetectSepartation _uut;

        [SetUp]
        public void setup()
        {
            _out = Substitute.For<IOutput>();
            _fakTranspondObjectA = Substitute.For<ITranspondObject>();
            _fakTranspondObjectB = Substitute.For<ITranspondObject>();
            _uut = new DetectSepartation(_out);
        }


        [Test]
        public void Detect()
        {
            _fakTranspondObjectA.PosistionX = 1;
            _fakTranspondObjectA.PosistionY = 1;
            _fakTranspondObjectA.Altitude = 200;
     


            _fakTranspondObjectB.PosistionY = 300;
            _fakTranspondObjectB.PosistionX = 20;
            _fakTranspondObjectB.Altitude = 230;

            _uut.detect(_fakTranspondObjectA,_fakTranspondObjectA);

            Assert.That(_uut.Conflict, Is.True);
        }

        [Test]
        public void tagOfSep()
        {
       //     Assert.That(_sep.Tag, Is.EqualTo(_tag));
        }
    }
}
