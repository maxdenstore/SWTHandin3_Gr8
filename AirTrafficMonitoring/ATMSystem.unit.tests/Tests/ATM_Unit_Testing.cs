using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ATMSystem;
using ATMSystem.Interfaces;
using NSubstitute;
using NUnit;
using NUnit.Framework;
using TransponderReceiver;
using TranspondObject = ATMSystem.TranspondObject;

namespace ATMSystem.Unit.Tests.Tests
{

    [TestFixture]
    public class AirMonitorUnitTest
    {
        private IMessureDegrees _fakeMessureDegrees;
        private IMessureVelocity _fakeMessureVelocity;
        private IOutput _fakeOutput;
        private IDetectSepartation _fakeDetectSepartation;

        private ITranspondObject _fakeTranspondObject;

        private int airspaceMin = 10000;
        private int airspaceMax = 90000;

        [SetUp]
        public void Setup()
        {
            _fakeTranspondObject = Substitute.For<ITranspondObject>();
            _fakeDetectSepartation = Substitute.For<IDetectSepartation>();
            _fakeMessureDegrees = Substitute.For<IMessureDegrees>();
            _fakeMessureVelocity = Substitute.For<IMessureVelocity>();
            _fakeOutput = Substitute.For<IOutput>();

            _fakeTranspondObject.Tag = "test";
            _fakeTranspondObject.PosistionX = 15000;
            _fakeTranspondObject.PosistionY = 15000;


        }

        [Test]
        public void TestList_nothing_assert0()
        {
            //arrange
            AirMonitor air;
            ATMSystem.ReceiveTranspond uut;


            //act
            setAir(out air, out uut);

            //assert
            Assert.That(air.monitorList.Count, Is.EqualTo(0));
            
        }

        [Test]
        public void TestList_plus1_assert1()
        {
            //arrange
            AirMonitor air;
            ATMSystem.ReceiveTranspond uut;
            setAir(out air, out uut);

            //act

            air.ReceiveNewTranspondObject(_fakeTranspondObject);

            //assert
            Assert.That(air.monitorList.Count, Is.EqualTo(1));

        }


        [Test]
        public void TestList_tagExsists_assertNoMore()
        {
            //arrange
            AirMonitor air;
            ATMSystem.ReceiveTranspond uut;
            setAir(out air, out uut);
            _fakeTranspondObject.Tag = "SameTag";

            //act

            air.ReceiveNewTranspondObject(_fakeTranspondObject);
            air.ReceiveNewTranspondObject(_fakeTranspondObject);

            //assert
            Assert.That(air.monitorList.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestList_tagnew_asserplus1()
        {
            //arrange
            AirMonitor air;
            ATMSystem.ReceiveTranspond uut;
            setAir(out air, out uut);
            ITranspondObject _fake2 = Substitute.For<ITranspondObject>();
            _fake2.Tag = "Tag2";
            _fake2.PosistionX = 20000;
            _fake2.PosistionY = 20000;
            _fakeTranspondObject.Tag = "Tag1";

            //act
            air.ReceiveNewTranspondObject(_fakeTranspondObject);
            air.ReceiveNewTranspondObject(_fake2);

            //assert
            Assert.That(air.monitorList.Count, Is.EqualTo(2));

        }

        [Test]
        public void TestList_OutOfBorderby1_assert0()
        {
            //arrange
            AirMonitor air;
            ATMSystem.ReceiveTranspond uut;
            setAir(out air, out uut);
            ITranspondObject _fakeOutOfBord = Substitute.For<ITranspondObject>();
            _fakeOutOfBord.PosistionX = 9999;
            _fakeOutOfBord.PosistionY = 10000;

            //act

            air.ReceiveNewTranspondObject(_fakeOutOfBord);

            //assert
            Assert.That(air.monitorList.Count, Is.EqualTo(0));

        }

        [Test]
        public void TestList_OutOfBorderby0_assert1()
        {
            //arrange
            AirMonitor air;
            ATMSystem.ReceiveTranspond uut;
            setAir(out air, out uut);
            ITranspondObject _fakeOutOfBord = Substitute.For<ITranspondObject>();
            _fakeOutOfBord.PosistionX = 10000;
            _fakeOutOfBord.PosistionY = 10000;

            //act

            air.ReceiveNewTranspondObject(_fakeOutOfBord);

            //assert
            Assert.That(air.monitorList.Count, Is.EqualTo(1));

        }

        private void setAir(out AirMonitor air, out ATMSystem.ReceiveTranspond uut)
        {
            air = new AirMonitor(_fakeMessureDegrees, _fakeMessureVelocity, _fakeDetectSepartation, _fakeOutput, airspaceMin,airspaceMax);
            uut = new ATMSystem.ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), _fakeOutput, air);
        }
    }
}
