using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMSystem;
using ATMSystem.Interfaces;
using NUnit.Framework;
using TransponderReceiver;

namespace MessureVelocity.Unit.Test
{
    public class Velocity_Unit_Test
    {
        [TestFixture]
        public class ATM_Unit_Testing
        {

            private IMessureDegrees _md;
            private IMessureVelocity _vl;
            private IDetectSepartation _dt;
            private IOutput _out;

            [SetUp]
            public void Setup()
            {
                _md = new MeasureDegress();
                _vl = new MeasureVelocity();
                _dt = new DetectSepartation(_out);
            }

            //****************************************************************************TEST OF VELOCITY********************************************************************************
            [Test]
            public void testVelocity_216ms()
            {
                AirMonitor air = new AirMonitor(_md, _vl, _dt);

                ReceiveTranspond uut =
                    new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), _out, air);

                //diff only few MS
                string Test1 = "DTR423;39000;13000;12000;20151006213456700";
                string Test2 = "DTR423;39019;13003;12001;20151006213456789";

                List<string> test = new List<string>();
                test.Add(Test1);

                uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

                test.Add(Test2);

                uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

                //assert bool is false
                Assert.That(air.monitorList[air.monitorList.Count - 1].Velocity, Is.EqualTo(216.0));

            }
        }
    }
}
