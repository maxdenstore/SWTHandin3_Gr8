using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ATMSystem;
using ATMSystem.Interfaces;
using Castle.DynamicProxy.Generators;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using TransponderReceiver;


namespace Integration_Test_ATM
{
    [TestFixture]
    public class IT_ATM
    {

        [SetUp]
        public void Setup()
        {

        }

        private void testsetUp()
        {

        }

        //***********************************************************************IntegrationTest*********************************************************************
        // Test transponderReceive

        // Alle tests skal have deres egne fakes, ellers kan alle test IKKE køre! Ændre IKKE på opsætningen!

        [Test]
        public void messureDegrees()
        {

            IDetectSepartation _fakeDetectSepartation = Substitute.For<IDetectSepartation>();
            IMessureDegrees _fakeMessureDegrees = Substitute.For<IMessureDegrees>();
            IMessureVelocity _fakeMessureVelocity = Substitute.For<IMessureVelocity>();
            IOutput _fakeOutput = Substitute.For<IOutput>();
            IReceive _faceReceive = Substitute.For<IReceive>();
            ISeperation _fakeSeperation = Substitute.For<ISeperation>();
            ITranspondObject _fakeTranspondObject = Substitute.For<ITranspondObject>();
            IAirmonitor _uut;

            TranspondObject _transpondObjectA;
            TranspondObject _transpondObjectB;
            TranspondObject _transpondObjectConflictA;
            TranspondObject _transpondObjectConflictB;

            string tag = "ATR423";
            int posX = 39000;
            int posY = 4200;
            int alt = 2000;
            DateTime date = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectA = new TranspondObject(tag, posX, posY, alt, date, _fakeOutput);

            string tag2 = "ATR423";
            int posX2 = 39000;
            int posY2 = 4200;
            int alt2 = 2000;
            DateTime date2 = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectB = new TranspondObject(tag2, posX2, posY2, alt2, date2, _fakeOutput);

            _uut = new AirMonitor(_fakeMessureDegrees, _fakeMessureVelocity, _fakeDetectSepartation, _fakeOutput);

            testsetUp();
            _uut.ReceiveNewTranspondObject(_transpondObjectA);
            _uut.ReceiveNewTranspondObject(_transpondObjectB);
            _fakeMessureDegrees.Received(1).Measure(Arg.Any<TranspondObject>(), Arg.Any<TranspondObject>());
        }

        [Test]
        public void messureVelocity()
        {

            IDetectSepartation _fakeDetectSepartation = Substitute.For<IDetectSepartation>();
            IMessureDegrees _fakeMessureDegrees = Substitute.For<IMessureDegrees>();
            IMessureVelocity _fakeMessureVelocity = Substitute.For<IMessureVelocity>();
            IOutput _fakeOutput = Substitute.For<IOutput>();
            IReceive _faceReceive = Substitute.For<IReceive>();
            ISeperation _fakeSeperation = Substitute.For<ISeperation>();
            ITranspondObject _fakeTranspondObject = Substitute.For<ITranspondObject>();
            IAirmonitor _uut;

            TranspondObject _transpondObjectA;
            TranspondObject _transpondObjectB;
            TranspondObject _transpondObjectConflictA;
            TranspondObject _transpondObjectConflictB;

            string tag = "ATR423";
            int posX = 39000;
            int posY = 4200;
            int alt = 2000;
            DateTime date = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectA = new TranspondObject(tag, posX, posY, alt, date, _fakeOutput);

            string tag2 = "ATR423";
            int posX2 = 39000;
            int posY2 = 4200;
            int alt2 = 2000;
            DateTime date2 = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectB = new TranspondObject(tag2, posX2, posY2, alt2, date2, _fakeOutput);

            _uut = new AirMonitor(_fakeMessureDegrees, _fakeMessureVelocity, _fakeDetectSepartation, _fakeOutput);

            testsetUp();
            _uut.ReceiveNewTranspondObject(_transpondObjectA);
            _uut.ReceiveNewTranspondObject(_transpondObjectB);
            _fakeMessureVelocity.Received(1).Measure(Arg.Any<TranspondObject>(), Arg.Any<TranspondObject>());
        }

        [Test]
        public void printSeperation()
        {


            IDetectSepartation _fakeDetectSepartation = Substitute.For<IDetectSepartation>();
            IMessureDegrees _fakeMessureDegrees = Substitute.For<IMessureDegrees>();
            IMessureVelocity _fakeMessureVelocity = Substitute.For<IMessureVelocity>();
            IOutput _fakeOutput = Substitute.For<IOutput>();
            IReceive _faceReceive = Substitute.For<IReceive>();
            ISeperation _fakeSeperation = Substitute.For<ISeperation>();
            ITranspondObject _fakeTranspondObject = Substitute.For<ITranspondObject>();
            IAirmonitor _uut;

            TranspondObject _transpondObjectA;
            TranspondObject _transpondObjectB;
            TranspondObject _transpondObjectConflictA;
            TranspondObject _transpondObjectConflictB;

            string tag = "ATR423";
            int posX = 39000;
            int posY = 4200;
            int alt = 2000;
            DateTime date = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectA = new TranspondObject(tag, posX, posY, alt, date, _fakeOutput);

            string tag2 = "ATR423";
            int posX2 = 39000;
            int posY2 = 4200;
            int alt2 = 2000;
            DateTime date2 = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectB = new TranspondObject(tag2, posX2, posY2, alt2, date2, _fakeOutput);

            _uut = new AirMonitor(_fakeMessureDegrees, _fakeMessureVelocity, _fakeDetectSepartation, _fakeOutput);

            testsetUp();
            string tag3 = "ATR423";
            int posX3 = 39000;
            int posY3 = 4200;
            int alt3 = 2000;
            DateTime date3 = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectConflictA = new TranspondObject(tag3, posX3, posY3, alt3, date3, _fakeOutput);

            string tag4 = "DTR423";
            int posX4 = 39000;
            int posY4 = 4200;
            int alt4 = 2000;
            DateTime date4 = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectConflictB = new TranspondObject(tag4, posX4, posY4, alt4, date4, _fakeOutput);

            _uut.monitorList.Add(_transpondObjectConflictA);
            _uut.monitorList.Add(_transpondObjectConflictB);


            _uut.ReceiveNewTranspondObject(_transpondObjectConflictA);
            _uut.ReceiveNewTranspondObject(_transpondObjectConflictB);


            _fakeDetectSepartation.Received(2).printSeparations();
        }

        [Test]
        public void detectSeperation()
        {

            IDetectSepartation _fakeDetectSepartation = Substitute.For<IDetectSepartation>();
            IMessureDegrees _fakeMessureDegrees = Substitute.For<IMessureDegrees>();
            IMessureVelocity _fakeMessureVelocity = Substitute.For<IMessureVelocity>();
            IOutput _fakeOutput = Substitute.For<IOutput>();
            IReceive _faceReceive = Substitute.For<IReceive>();
            ISeperation _fakeSeperation = Substitute.For<ISeperation>();
            ITranspondObject _fakeTranspondObject = Substitute.For<ITranspondObject>();
            IAirmonitor _uut;

            TranspondObject _transpondObjectA;
            TranspondObject _transpondObjectB;
            TranspondObject _transpondObjectConflictA;
            TranspondObject _transpondObjectConflictB;

            string tag = "ATR423";
            int posX = 39000;
            int posY = 4200;
            int alt = 2000;
            DateTime date = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectA = new TranspondObject(tag, posX, posY, alt, date, _fakeOutput);

            string tag2 = "ATR423";
            int posX2 = 39000;
            int posY2 = 4200;
            int alt2 = 2000;
            DateTime date2 = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectB = new TranspondObject(tag2, posX2, posY2, alt2, date2, _fakeOutput);

            _uut = new AirMonitor(_fakeMessureDegrees, _fakeMessureVelocity, _fakeDetectSepartation, _fakeOutput);
            testsetUp();
            _uut.ReceiveNewTranspondObject(_transpondObjectA);
            _uut.ReceiveNewTranspondObject(_transpondObjectB);
            _fakeDetectSepartation.detect(Arg.Any<TranspondObject>(), Arg.Any<TranspondObject>());
        }

        [Test]
        public void output()
        {

            IDetectSepartation _fakeDetectSepartation = Substitute.For<IDetectSepartation>();
            IMessureDegrees _fakeMessureDegrees = Substitute.For<IMessureDegrees>();
            IMessureVelocity _fakeMessureVelocity = Substitute.For<IMessureVelocity>();
            IOutput _fakeOutput = Substitute.For<IOutput>();
            IReceive _faceReceive = Substitute.For<IReceive>();
            ISeperation _fakeSeperation = Substitute.For<ISeperation>();
            ITranspondObject _fakeTranspondObject = Substitute.For<ITranspondObject>();
            IAirmonitor _uut;

            TranspondObject _transpondObjectA;
            TranspondObject _transpondObjectB;
            TranspondObject _transpondObjectConflictA;
            TranspondObject _transpondObjectConflictB;

            string tag = "ATR423";
            int posX = 39000;
            int posY = 4200;
            int alt = 2000;
            DateTime date = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectA = new TranspondObject(tag, posX, posY, alt, date, _fakeOutput);

            string tag2 = "ATR423";
            int posX2 = 39000;
            int posY2 = 4200;
            int alt2 = 2000;
            DateTime date2 = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectB = new TranspondObject(tag2, posX2, posY2, alt2, date2, _fakeOutput);

            _uut = new AirMonitor(_fakeMessureDegrees, _fakeMessureVelocity, _fakeDetectSepartation, _fakeOutput);
            testsetUp();
            _uut.ReceiveNewTranspondObject(_transpondObjectA);
            _fakeOutput.Received(1).ClearScreen();
        }

        [Test]
        public void fakePrint()
        {

            IDetectSepartation _fakeDetectSepartation = Substitute.For<IDetectSepartation>();
            IMessureDegrees _fakeMessureDegrees = Substitute.For<IMessureDegrees>();
            IMessureVelocity _fakeMessureVelocity = Substitute.For<IMessureVelocity>();
            IOutput _fakeOutput = Substitute.For<IOutput>();
            IReceive _faceReceive = Substitute.For<IReceive>();
            ISeperation _fakeSeperation = Substitute.For<ISeperation>();
            ITranspondObject _fakeTranspondObject = Substitute.For<ITranspondObject>();
            IAirmonitor _uut;

            TranspondObject _transpondObjectA;
            TranspondObject _transpondObjectB;
            TranspondObject _transpondObjectConflictA;
            TranspondObject _transpondObjectConflictB;

            string tag = "ATR423";
            int posX = 39000;
            int posY = 4200;
            int alt = 2000;
            DateTime date = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectA = new TranspondObject(tag, posX, posY, alt, date, _fakeOutput);

            string tag2 = "ATR423";
            int posX2 = 39000;
            int posY2 = 4200;
            int alt2 = 2000;
            DateTime date2 = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectB = new TranspondObject(tag2, posX2, posY2, alt2, date2, _fakeOutput);

            _uut = new AirMonitor(_fakeMessureDegrees, _fakeMessureVelocity, _fakeDetectSepartation, _fakeOutput);
            testsetUp();
            _uut.ReceiveNewTranspondObject(_fakeTranspondObject);
            _fakeTranspondObject.Received(1).Print();
        }
    }
}
