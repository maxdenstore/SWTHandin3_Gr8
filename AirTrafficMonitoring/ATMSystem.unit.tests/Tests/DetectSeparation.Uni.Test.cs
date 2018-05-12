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

        //Exptected conflict, Y,X, within 300 & Altitude within 5000

        [Test]
        public void Detect_Conflict_Exptected_True()
        {
            _fakTranspondObjectA.PosistionX = 100;
            _fakTranspondObjectA.PosistionY = 111;
            _fakTranspondObjectA.Altitude = 200;



            _fakTranspondObjectB.PosistionY = 300;
            _fakTranspondObjectB.PosistionX = 20;
            _fakTranspondObjectB.Altitude = 230;



            _uut.detect(_fakTranspondObjectA,_fakTranspondObjectB);

            Assert.That(_uut.Conflict, Is.True);
        }

        //Exptected no conflict, Y,X, within 300 & Altitude not within 5000

        [Test]
        public void Detect_Conflict_Exptected_False()
        {
            _fakTranspondObjectA.PosistionX = 111;
            _fakTranspondObjectA.PosistionY = 1111;
            _fakTranspondObjectA.Altitude = 10000;



            _fakTranspondObjectB.PosistionY = 300;
            _fakTranspondObjectB.PosistionX = 120;
            _fakTranspondObjectB.Altitude = 230;



            _uut.detect(_fakTranspondObjectA, _fakTranspondObjectB);

            Assert.That(_uut.Conflict, Is.False);
        }

        //Exptected no conflict, Y not within 300, X Is within 300 & Altitude within 5000

        [Test]
        public void Detect_ConflictY_Exptected_False()
        {
            _fakTranspondObjectA.PosistionX = 1;
            _fakTranspondObjectA.PosistionY = 300;
            _fakTranspondObjectA.Altitude = 1000;



            _fakTranspondObjectB.PosistionY = 800;
            _fakTranspondObjectB.PosistionX = 20;
            _fakTranspondObjectB.Altitude = 230;



            _uut.detect(_fakTranspondObjectA, _fakTranspondObjectB);

            Assert.That(_uut.Conflict, Is.False);
        }

        //Exptected no conflict, Y within 300, X Is not within 300 & Altitude within 5000

        [Test]
        public void Detect_ConflictX_Exptected_False()
        {
            _fakTranspondObjectA.PosistionX = 100;
            _fakTranspondObjectA.PosistionY = 300;
            _fakTranspondObjectA.Altitude = 500;



            _fakTranspondObjectB.PosistionY = 200;
            _fakTranspondObjectB.PosistionX = 600;
            _fakTranspondObjectB.Altitude = 500;



            _uut.detect(_fakTranspondObjectA, _fakTranspondObjectB);

            Assert.That(_uut.Conflict, Is.False);
        }
    }
}
