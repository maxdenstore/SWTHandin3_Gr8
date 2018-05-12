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
using TranspondObject = ATMSystem.TranspondObject;

namespace ATMSystem.Unit.Tests.Tests
{

        [TestFixture]
        public class VelocityUnitTest
        {
            private IMessureVelocity _vl;
            private IOutput _out;
            [SetUp]
            public void Setup()
            {
                _out = Substitute.For<IOutput>();
                _vl = new MeasureVelocity();
            }

            //****************************************************************************TEST OF VELOCITY********************************************************************************
            [Test]
            public void testVelocity_10m5000m2ms()
            {
                ATMSystem.TranspondObject _old = new ATMSystem.TranspondObject("Test1",0,0,1000,new DateTime(2018,1,1,12,0,0), _out);
                ATMSystem.TranspondObject _new = new ATMSystem.TranspondObject("Test1", 10, 0, 1000, new DateTime(2018, 1, 1, 12, 0, 5), _out);
                _vl.Measure(_old,_new);

                Assert.That(_new.Velocity, Is.EqualTo(2));

            }

            [Test]
            public void testVelocity_0m5000m0ms()
            {
                ATMSystem.TranspondObject _old = new ATMSystem.TranspondObject("Test1", 0, 0, 1000, new DateTime(2018, 1, 1, 12, 0, 0), _out);
                ATMSystem.TranspondObject _new = new ATMSystem.TranspondObject("Test1", 0, 0, 1000, new DateTime(2018, 1, 1, 12, 0, 5), _out);
                _vl.Measure(_old, _new);

                Assert.That(_new.Velocity, Is.EqualTo(0));

            }
        }
    }

