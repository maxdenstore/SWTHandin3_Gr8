using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMSystem;
using ATMSystem.Interfaces;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;


namespace ATMSystem.Unit.Tests.Tests
{
    public class MessureDegreeTest
    {


        [TestFixture]
        public class MeasureDegreesUnitTest
        {
            private IMessureDegrees _degrees;
            private IOutput _out;
            [SetUp]
            public void Setup()
            {
                _out = Substitute.For<IOutput>();
                _degrees = new MeasureDegress();
            }


            //*********************************************************************************TEST OF DEGREES*******************************************************************
            [Test]
            public void testDegrees_straightForward_0Degress()
            {
                ATMSystem.TranspondObject _old = new ATMSystem.TranspondObject("Test1", 0, 0, 1000, new DateTime(2018, 1, 1, 12, 0, 0), _out);
                ATMSystem.TranspondObject _new = new ATMSystem.TranspondObject("Test1", 10, 0, 1000, new DateTime(2018, 1, 1, 12, 0, 0), _out);
                _degrees.Measure(_old, _new);

                Assert.That(_new.degress, Is.EqualTo(0));
            }

            [Test]
            public void testDegrees_straightback_180Degress()
            {
                ATMSystem.TranspondObject _old = new ATMSystem.TranspondObject("Test1", 0, 0, 1000, new DateTime(2018, 1, 1, 12, 0, 0), _out);
                ATMSystem.TranspondObject _new = new ATMSystem.TranspondObject("Test1", -10, 0, 1000, new DateTime(2018, 1, 1, 12, 0, 0), _out);
                _degrees.Measure(_old, _new);

                Assert.That(_new.degress, Is.EqualTo(180));
            }

            [Test]
            public void testDegrees_straightRight_90Degress()
            {
                ATMSystem.TranspondObject _old = new ATMSystem.TranspondObject("Test1", 0, 0, 1000, new DateTime(2018, 1, 1, 12, 0, 0), _out);
                ATMSystem.TranspondObject _new = new ATMSystem.TranspondObject("Test1", 0, 5, 1000, new DateTime(2018, 1, 1, 12, 0, 0), _out);
                _degrees.Measure(_old, _new);

                Assert.That(_new.degress, Is.EqualTo(90));
            }

            [Test]
            public void testDegrees_straightLeft_270Degress()
            {
                ATMSystem.TranspondObject _old = new ATMSystem.TranspondObject("Test1", 0, 0, 1000, new DateTime(2018, 1, 1, 12, 0, 0), _out);
                ATMSystem.TranspondObject _new = new ATMSystem.TranspondObject("Test1", 0, -5, 1000, new DateTime(2018, 1, 1, 12, 0, 0), _out);
                _degrees.Measure(_old, _new);

                Assert.That(_new.degress, Is.EqualTo(270));
            }
        }
    }
}