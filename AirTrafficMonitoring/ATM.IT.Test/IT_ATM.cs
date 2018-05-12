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
        private string testString = "ATR423;39045;12932;14000;20151006213456789";

        private IDetectSepartation _fakeDetectSepartation = Substitute.For<IDetectSepartation>();
        private IMessureDegrees _fakeMessureDegrees = Substitute.For<IMessureDegrees>();
        private IMessureVelocity _fakeMessureVelocity = Substitute.For<IMessureVelocity>();
        private IOutput _fakeOutput = Substitute.For<IOutput>();
        private IReceive _faceReceive = Substitute.For<IReceive>();
        private ISeperation _fakeSeperation = Substitute.For<ISeperation>();
        private ITranspondObject _fakeTranspondObject = Substitute.For<ITranspondObject>();
        private IAirmonitor _uut;

        private TranspondObject _transpondObjectA;
        private TranspondObject _transpondObjectB;
        private TranspondObject _transpondObjectConflictA;
        private TranspondObject _transpondObjectConflictB;


        [SetUp]
        public void Setup()
        {
            testsetUp();
        }

        private void testsetUp()
        {
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
        }

        //***********************************************************************IntegrationTest*********************************************************************
        // Test transponderReceive

        [Test]
        public void messureDegrees()
        {
            testsetUp();
            _uut.ReceiveNewTranspondObject(_transpondObjectA);
            _uut.ReceiveNewTranspondObject(_transpondObjectB);
            _fakeMessureDegrees.Received(1).Measure(Arg.Any<TranspondObject>(), Arg.Any<TranspondObject>());
        }

        [Test]
        public void messureVelocity()
        {
            testsetUp();
            _uut.ReceiveNewTranspondObject(_transpondObjectA);
            _uut.ReceiveNewTranspondObject(_transpondObjectB);
            _fakeMessureVelocity.Received(1).Measure(Arg.Any<TranspondObject>(), Arg.Any<TranspondObject>());
        }

        [Test]
        public void printSeperation()
        {
            testsetUp();
            string tag = "ATR423";
            int posX = 39000;
            int posY = 4200;
            int alt = 2000;
            DateTime date = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectConflictA = new TranspondObject(tag, posX, posY, alt, date, _fakeOutput);

            string tag2 = "DTR423";
            int posX2 = 39000;
            int posY2 = 4200;
            int alt2 = 2000;
            DateTime date2 = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectConflictB = new TranspondObject(tag2, posX2, posY2, alt2, date2, _fakeOutput);

            _uut.monitorList.Add(_transpondObjectConflictA);
            _uut.monitorList.Add(_transpondObjectConflictB);


            _uut.ReceiveNewTranspondObject(_transpondObjectConflictA);
            _uut.ReceiveNewTranspondObject(_transpondObjectConflictB);


            _fakeDetectSepartation.Received(2).printSeparations();
        }

        [Test]
        public void detectSeperation()
        {
            testsetUp();
            _uut.ReceiveNewTranspondObject(_transpondObjectA);
            _uut.ReceiveNewTranspondObject(_transpondObjectB);
            _fakeDetectSepartation.detect(Arg.Any<TranspondObject>(), Arg.Any<TranspondObject>());
        }

        [Test]
        public void output()
        {
            testsetUp();
            _uut.ReceiveNewTranspondObject(_transpondObjectA);
            _fakeOutput.Received(1).ClearScreen();
        }

        [Test]
        public void fakePrint()
        {
            testsetUp();
            _uut.ReceiveNewTranspondObject(_fakeTranspondObject);
            _fakeTranspondObject.Received(1).Print();
        }
    }
}
