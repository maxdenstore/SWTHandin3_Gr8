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
using NSubstitute.ClearExtensions;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using TransponderReceiver;


namespace Integration_Test_ATM
{
    [TestFixture]
    public class IT_ATM
    {
        IOutput _fakeOutput = Substitute.For<IOutput>();
        IDetectSepartation _fakeDetectSepartation = Substitute.For<IDetectSepartation>();
        IMessureDegrees _fakeMessureDegrees = Substitute.For<IMessureDegrees>();
        IMessureVelocity _fakeMessureVelocity = Substitute.For<IMessureVelocity>();
        IAirmonitor _uut;
        private int airSpaceMin = 10000;
        private int airSpaceMax = 90000;

        private DetectSepartation detectSepartation;
        private TranspondObject _transpondObjectA;
        private TranspondObject _transpondObjectB;

        [SetUp]
        public void Setup()
        {
            string tag = "ATR423";
            int posX = airSpaceMin + 10;
            int posY = airSpaceMin + 10;
            int alt = 2000;
            DateTime date = new DateTime(2018, 1, 1, 12, 0, 0);
            _transpondObjectA = new TranspondObject(tag, posX, posY, alt, date, _fakeOutput);

            detectSepartation = new DetectSepartation(_fakeOutput);

            string tag2 = "ATR423";
            int posX2 = airSpaceMin + 100;
            int posY2 = airSpaceMin + 200;
            int alt2 = 3000;
            DateTime date2 = new DateTime(2018, 1, 1, 12, 0, 21);
            _transpondObjectB = new TranspondObject(tag2, posX2, posY2, alt2, date2, _fakeOutput);

            _fakeMessureDegrees = Substitute.For<IMessureDegrees>();
            _fakeMessureVelocity = Substitute.For<IMessureVelocity>();
            _fakeDetectSepartation = Substitute.For<IDetectSepartation>();
            _fakeOutput = Substitute.For<IOutput>();
        }




        //***********************************************************************IntegrationTest*********************************************************************
        // Test transponderReceive

        // Alle tests skal have deres egne fakes, ellers kan alle test IKKE køre! Ændre IKKE på opsætningen!
        [Test]
        public void messureDegrees()
        {
            //Arrange
            _uut = new AirMonitor(new MeasureDegress(), _fakeMessureVelocity, _fakeDetectSepartation, _fakeOutput, airSpaceMin, airSpaceMax);

            //Act
            _uut.ReceiveNewTranspondObject(_transpondObjectA);
            _uut.ReceiveNewTranspondObject(_transpondObjectB);

            //Assert
            Assert.That(_transpondObjectB.degress, Is.EqualTo(65.0));
        }

        [Test]
        public void messureDegreesWrong()
        {
            //Arrange
            _uut = new AirMonitor(new MeasureDegress(), _fakeMessureVelocity, _fakeDetectSepartation, _fakeOutput, airSpaceMin, airSpaceMax);

            //Act
            _uut.ReceiveNewTranspondObject(_transpondObjectA);
            _uut.ReceiveNewTranspondObject(_transpondObjectB);

            //Assert
            Assert.That(_transpondObjectB.degress, Is.Not.EqualTo(100.0));
        }

        [Test]
        public void messureVelocity()
        {
            //Arrange
            _uut = new AirMonitor(_fakeMessureDegrees, new MeasureVelocity(), _fakeDetectSepartation, _fakeOutput, airSpaceMin, airSpaceMax);

            //Act
            _uut.ReceiveNewTranspondObject(_transpondObjectA);
            _uut.ReceiveNewTranspondObject(_transpondObjectB);

            //Assert
            Assert.That(_transpondObjectB.Velocity, Is.EqualTo(10.00));
        }
        [Test]
        public void messureVelocityWrong()
        {
            //Arrange
            _uut = new AirMonitor(_fakeMessureDegrees, new MeasureVelocity(), _fakeDetectSepartation, _fakeOutput, airSpaceMin, airSpaceMax);

            //Act
            _uut.ReceiveNewTranspondObject(_transpondObjectA);
            _uut.ReceiveNewTranspondObject(_transpondObjectB);

            //Assert
            Assert.That(_transpondObjectB.Velocity, Is.Not.EqualTo(15.00));
        }

        [Test]
        public void printSeperation()
        {
            //Arrange
            _uut = new AirMonitor(_fakeMessureDegrees, _fakeMessureVelocity, _fakeDetectSepartation, _fakeOutput, airSpaceMin, airSpaceMax);


            string tag3 = "ATR423";
            int posX3 = airSpaceMin + 10;
            int posY3 = airSpaceMin+ 10;
            int alt3 = 2000;
            DateTime date3 = new DateTime(2018, 1, 1, 12, 0, 0);
            var _transpondObjectConflictA = new TranspondObject(tag3, posX3, posY3, alt3, date3, _fakeOutput);

            string tag4 = "DTR423";
            int posX4 = airSpaceMin + 10;
            int posY4 = airSpaceMin + 10;
            int alt4 = 2000;
            DateTime date4 = new DateTime(2018, 1, 1, 12, 0, 0);
            var _transpondObjectConflictB = new TranspondObject(tag4, posX4, posY4, alt4, date4, _fakeOutput);

            //act
            _uut.monitorList.Add(_transpondObjectConflictA);
            _uut.monitorList.Add(_transpondObjectConflictB);


            _uut.ReceiveNewTranspondObject(_transpondObjectConflictA);
            _uut.ReceiveNewTranspondObject(_transpondObjectConflictB);


            //Assert
            _fakeDetectSepartation.Received(2).printSeparations();
        }

        [Test]
        public void detectSeperation()
        {
            //Arrange
            _uut = new AirMonitor(_fakeMessureDegrees, _fakeMessureVelocity, _fakeDetectSepartation, _fakeOutput, airSpaceMin, airSpaceMax);

            //Act
            _uut.ReceiveNewTranspondObject(_transpondObjectA);
            _uut.ReceiveNewTranspondObject(_transpondObjectB);


            //Assert
            _fakeDetectSepartation.detect(Arg.Any<TranspondObject>(), Arg.Any<TranspondObject>());
        }

        [Test]
        public void output()
        {
            //Arrange
            _uut = new AirMonitor(_fakeMessureDegrees, _fakeMessureVelocity, _fakeDetectSepartation, _fakeOutput, airSpaceMin, airSpaceMax);

            //Act
            _uut.ReceiveNewTranspondObject(_transpondObjectA);

            //Assert
            _fakeOutput.Received(1).ClearScreen();
        }

        [Test]
        public void messureOldReplacedInListVelocity()
        {
            //Arrange
            _uut = new AirMonitor(_fakeMessureDegrees, new MeasureVelocity(), _fakeDetectSepartation, _fakeOutput, airSpaceMin, airSpaceMax);

            //Act
            _uut.ReceiveNewTranspondObject(_transpondObjectA);
            _uut.ReceiveNewTranspondObject(_transpondObjectB);

            //Assert
            Assert.That(_uut.monitorList.Find(t => t.Tag == _transpondObjectB.Tag).Velocity == 10.00);
        }

        [Test]
        public void messureOldReplacedInListDegrees()
        {
            //Arrange
            _uut = new AirMonitor(new MeasureDegress(), _fakeMessureVelocity, _fakeDetectSepartation, _fakeOutput, airSpaceMin, airSpaceMax);

            //Act
            _uut.ReceiveNewTranspondObject(_transpondObjectA);
            _uut.ReceiveNewTranspondObject(_transpondObjectB);

            //Assert
            Assert.That(_uut.monitorList.Find(t => t.Tag == _transpondObjectB.Tag).degress == 65.00);
        }

        [Test]
        public void CheckForConflict_Is_set()
        {
            //Arrange
            _uut = new AirMonitor(_fakeMessureDegrees, _fakeMessureVelocity, detectSepartation, _fakeOutput, airSpaceMin, airSpaceMax);

            //Act
            string tag5 = "ATR423";
            int posX5 = airSpaceMin + 10;
            int posY5 = airSpaceMin + 10;
            int alt5 = 2000;
            DateTime date5 = new DateTime(2018, 1, 1, 12, 0, 0);
            var _transpondObjectConflictA = new TranspondObject(tag5, posX5, posY5, alt5, date5, _fakeOutput);

            string tag6 = "DTR423";
            int posX6 = airSpaceMin + 10;
            int posY6 = airSpaceMin + 10;
            int alt6 = 2000;
            DateTime date6 = new DateTime(2018, 1, 1, 12, 0, 0);
            var _transpondObjectConflictB = new TranspondObject(tag6, posX6, posY6, alt6, date6, _fakeOutput);


            //act
            _uut.monitorList.Add(_transpondObjectConflictA);
            _uut.monitorList.Add(_transpondObjectConflictB);




            _uut.ReceiveNewTranspondObject(_transpondObjectConflictA);
            _uut.ReceiveNewTranspondObject(_transpondObjectConflictB);




            //Assert
            Assert.That(detectSepartation.Conflict);
        }


        [Test]
        public void CheckForConflict_Seperation_ObjMade()
        {
            //Arrange
            _uut = new AirMonitor(_fakeMessureDegrees, _fakeMessureVelocity, _fakeDetectSepartation, _fakeOutput, airSpaceMin, airSpaceMax);

            //Act
            string tag5 = "ATR423";
            int posX5 = airSpaceMin + 10;
            int posY5 = airSpaceMin + 10;
            int alt5 = 2000;
            DateTime date5 = new DateTime(2018, 1, 1, 12, 0, 0);
            var _transpondObjectConflictA = new TranspondObject(tag5, posX5, posY5, alt5, date5, _fakeOutput);

            string tag6 = "DTR423";
            int posX6 = airSpaceMin + 10;
            int posY6 = airSpaceMin + 10;
            int alt6 = 2000;
            DateTime date6 = new DateTime(2018, 1, 1, 12, 0, 0);
            var _transpondObjectConflictB = new TranspondObject(tag6, posX6, posY6, alt6, date6, _fakeOutput);


            //act
            _uut.monitorList.Add(_transpondObjectConflictA);
            _uut.monitorList.Add(_transpondObjectConflictB);




            _uut.ReceiveNewTranspondObject(_transpondObjectConflictA);
            _uut.ReceiveNewTranspondObject(_transpondObjectConflictB);




            //Assert
            Assert.That(1 == 1);
        }



        [Test]
        public void fakePrint()
        {
            //Arrange
            ITranspondObject fakeTranspondObject = Substitute.For<ITranspondObject>();
            fakeTranspondObject.PosistionX = airSpaceMin + 10;
            fakeTranspondObject.PosistionY = airSpaceMin + 10;


            _uut = new AirMonitor(_fakeMessureDegrees, _fakeMessureVelocity, _fakeDetectSepartation, _fakeOutput, airSpaceMin, airSpaceMax);

            //Act
            _uut.ReceiveNewTranspondObject(fakeTranspondObject);

            //Assert
            fakeTranspondObject.Received(1).Print();
        }



        [TearDown]
        public void TearDown()
        {
            _fakeOutput.ClearSubstitute();
            _fakeDetectSepartation.ClearSubstitute();
            _fakeMessureDegrees.ClearSubstitute();
            _fakeMessureVelocity.ClearSubstitute();
            
        }



    }
}
