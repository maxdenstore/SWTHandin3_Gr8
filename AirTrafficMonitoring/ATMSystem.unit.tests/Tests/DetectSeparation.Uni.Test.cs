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
        public void OccurenceOfSep()
        {
            Assert.That(_sep.Occurence, Is.EqualTo(_dateTime));
        }

        [Test]
        public void tagOfSep()
        {
            Assert.That(_sep.Tag, Is.EqualTo(_tag));
        }
    }
}
