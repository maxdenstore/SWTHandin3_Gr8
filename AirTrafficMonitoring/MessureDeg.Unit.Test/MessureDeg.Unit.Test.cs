using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMSystem;
using ATMSystem.Interfaces;
using NUnit.Framework;
using TransponderReceiver;


namespace MessureDeg.Unit.Test
{
    public class MessureDegreeTest
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


            //*********************************************************************************TEST OF DEGREES*******************************************************************
            [Test]
            public void testDegrees_227()
            {

                AirMonitor air = new AirMonitor(_md, _vl, _dt);

                ReceiveTranspond uut =
                    new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), _out, air);

                //diff only few MS
                string Test1Deg = "DTR423;39000;13000;12000;20151006213456700";
                string Test2Deg = "DTR423;38099;12033;12001;20151006213456789";

                List<string> test = new List<string>();
                test.Add(Test1Deg);

                uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

                test.Add(Test2Deg);

                uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

                //assert bool is false
                Assert.That(air.monitorList[air.monitorList.Count - 1].degress, Is.EqualTo(227.0));

            }
        }
    }
}