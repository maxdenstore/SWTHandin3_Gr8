using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ATMSystem;
using NUnit;
using NUnit.Framework;
using TOS;
using TransponderReceiver;

namespace ATM.Unit.Test
{

    [TestFixture]
    public class ATM_Unit_Testing
    {
        private string testString = "ATR423;39045;12932;14000;20151006213456789";

        //private static AirMonitor air = new AirMonitor();

        //private ReceiveTranspond uut =
        //    new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);
        //public string tag = "ATR423";
        //public int PosistionX = 39045;
        //public int PosistionY = 12932;
        //public int altitude = 14000;
        //public DateTime DateTime = new DateTime(2015, 10, 6, 21, 34, 56, 789);

        [SetUp]
        public void Setup()
        {

        }


        //***********************************************************************TEST OF DATASET*********************************************************************
        //Test transponderReceiverData
        [Test]
        public void transponderRecieverDataTest()
        {

        AirMonitor air = new AirMonitor();

        ReceiveTranspond uut =
            new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

        List<string> test = new List<string>();
            test.Add(testString);
            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            Assert.That(air.monitorList[air.monitorList.Count - 1].Tag, Is.EqualTo(testString.Substring(0, 6)));
        }

        //Test transponderReceiverData X cord
        [Test]
        public void transponderRecieverDataTestXCord()
        {
            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

            List<string> test = new List<string>();
            test.Add(testString);
            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            Assert.That(air.monitorList[air.monitorList.Count - 1].PosistionX,
                Is.EqualTo((Int32.Parse(testString.Substring(7, 5)))));
        }

        //Test transponderReceiverData Y cord
        [Test]
        public void transponderRecieverDataTestYCord()
        {
            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

            List<string> test = new List<string>();
            test.Add(testString);
            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            Assert.That(air.monitorList[air.monitorList.Count - 1].PosistionY,
                Is.EqualTo((Int32.Parse(testString.Substring(13, 5)))));
        }

        //Test transponderReceiverData altitude
        [Test]
        public void transponderRecieverDataTestAltitude()
        {
            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

            List<string> test = new List<string>();
            test.Add(testString);
            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            Assert.That(air.monitorList[air.monitorList.Count - 1].Altitude,
                Is.EqualTo((Int32.Parse(testString.Substring(19, 5)))));
        }

        //Test transponderReceiverData Datettime
        [Test]
        public void transponderRecieverDataTestTimestamp()
        {

            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

            List<string> test = new List<string>();
            test.Add(testString);
            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            Assert.That(air.monitorList[air.monitorList.Count - 1].TimeStamp,
                Is.EqualTo(DateTime.Parse("2015-10-06 21:34:56.789")));
        }

        //****************************************************TEST IF CONFLICT***********************************************************************'

        //Test if X is +/- 300 and Y is +/-300.
        [Test]
        public void TestXConflicts()
        {
            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

            string Test1xConflict = "DTR423;39000;12932;14000;20151006213456789";
            string Test2xConflict = "ATR423;39299;12933;14001;20151006213456789";

            List<string> test = new List<string>();
            test.Add(Test1xConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            test.Add(Test2xConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));
            Assert.That(air.FlightsInConflic.Exists(x => x.Tag == "ATR423"), Is.True);

        }

        //Test if X is not +/-300 but Y is +/-300.
        [Test]
        public void TestXNoConflictsK()
        {
            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

            string Test1xNoConflict = "DTR423;39000;13000;14000;20151006213456789";
            string Test2xNoConflict = "ATR423;39399;12933;14001;20151006213456789";

            List<string> test = new List<string>();
            test.Add(Test1xNoConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            test.Add(Test2xNoConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));
            Assert.That(air.FlightsInConflic.Exists(x => x.Tag == "ATR423"), Is.False);

        }

        //Test if X is +/- 300 and Y is +/-300. But Alt diff over 5000
        [Test]
        public void TestXAltNotConflictsK()
        {
            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

            string Test1xNoConflict = "DTR423;39000;13000;02000;20151006213456789";
            string Test2xNoConflict = "ATR423;39299;12233;14001;20151006213456789";

            List<string> test = new List<string>();
            test.Add(Test1xNoConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            test.Add(Test2xNoConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));
            Assert.That(air.FlightsInConflic.Exists(x => x.Tag == "ATR423"), Is.False);

        }


        //Test if Y is +/- 300 and X is +/-300.|
        [Test]
        public void TestYConflicts()
        {
            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

            string Test1yConflict = "DTR423;39000;10000;14000;20151006213456789";
            string Test2yConflict = "ATR423;39299;10299;14001;20151006213456789";

            List<string> test = new List<string>();
            test.Add(Test1yConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            test.Add(Test2yConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));
            Assert.That(air.FlightsInConflic.Exists(x => x.Tag == "ATR423"), Is.True);

        }

        //Test if Y is not +/- 300 but X is +/-300.
        [Test]
        public void TestYNoConflictsK()
        {
            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

            string Test1yNoConflict = "DTR423;39000;13000;14000;20151006213456789";
            string Test2yNoConflict = "ATR423;39299;12233;14001;20151006213456789";

            List<string> test = new List<string>();
            test.Add(Test1yNoConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            test.Add(Test2yNoConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));
            Assert.That(air.FlightsInConflic.Exists(x => x.Tag == "ATR423"), Is.False);

        }

        //Test if Y is +/- 300 and X is +/-300. But Alt diff over 5000
        [Test]
        public void TestYAltNotConflictsK()
        {
            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

            string Test1yNoConflict = "DTR423;39000;13000;02000;20151006213456789";
            string Test2yNoConflict = "ATR423;39299;12233;14001;20151006213456789";

            List<string> test = new List<string>();
            test.Add(Test1yNoConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            test.Add(Test2yNoConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));
            Assert.That(air.FlightsInConflic.Exists(x => x.Tag == "ATR423"), Is.False);

        }

        //****************************************************TEST IF CONFLICT IS OVER***********************************************************************'

        //Test if planes exist after conflict is ended

        [Test]
        public void TestConflictsIsOver()
        {
            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

            //start a conflict Y&X +/-300 & Alt within 5000meters ****************
            string Test1IsConflict = "DTR423;39000;13000;12000;20151006213456789";
            string Test2IsConflict = "ATR423;39299;12933;14001;20151006213456789";

            List<string> test = new List<string>();
            test.Add(Test1IsConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            test.Add(Test2IsConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            //End conflict        ************************************************

            string Test1NoConflict = "DTR423;29000;13000;12000;20151006213456789";
            string Test2NoConflict = "ATR423;39599;15933;02001;20151006213456789";

            List<string> test2 = new List<string>();
            test2.Add(Test1NoConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test2));

            test2.Add(Test2NoConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test2));

            //assert removed from list.

            Assert.That(air.FlightsInConflic.Exists(x => x.Tag == "ATR423"), Is.False);

        }

        //****************************************************TEST THE CONFLICT BOOL GOES TRUE/FALSE ACCORDINGLY***********************************************************************'

        //Test if bool goes true
        [Test]
        public void TestConflictsBoolIsTrue()
        {
            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

            //start a conflict Y&X +/-300 & Alt within 5000meters ****************
            string Test1IsConflict = "DTR423;39000;13000;12000;20151006213456789";
            string Test2IsConflict = "ATR423;39299;12933;14001;20151006213456789";

            List<string> test = new List<string>();
            test.Add(Test1IsConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            test.Add(Test2IsConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            Assert.That(air.Conflict, Is.True);
        }

        //Test if bool is false after raised event of conflict/none conflict
        [Test]
        public void TestConflictsBoolIsFalse()
        {
            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

            //start a conflict Y&X +/-300 & Alt within 5000meters ****************
            string Test1IsConflict = "DTR423;39000;13000;12000;20151006213456789";
            string Test2IsConflict = "ATR423;39299;12933;14001;20151006213456789";

            List<string> test = new List<string>();
            test.Add(Test1IsConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            test.Add(Test2IsConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            //End conflict        ************************************************

            string Test1NoConflict = "DTR423;39000;13000;12000;20151006213456789";
            string Test2NoConflict = "ATR423;39599;15933;02001;20151006213456789";

            List<string> test2 = new List<string>();
            test.Add(Test1NoConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            test.Add(Test2NoConflict);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            //assert bool is false

            Assert.That(air.Conflict, Is.False);

            //TimeTestNoConflict        ************************************************
            //Time diff 1 hour but cords within range should conflict as we do not handle time of occurance
        }



        //****************************************************TEST OF TIME, NO IMPLEMENTATION OF TIME IS CONSIDERED THEREFORE ALLWAYS FALSE IF TIME IS != TIME***********************************************************************'
        [Test]
        public void testTimeNoConflict()
        {
            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

            string Test1Time = "DTR423;39000;13000;12000;20151006203456789";
            string Test2Time = "ATR423;39099;13033;12001;20151006213456789";

            List<string> test = new List<string>();
            test.Add(Test1Time);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            test.Add(Test2Time);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            //assert bool is true

            Assert.That(air.Conflict, Is.True);

        }

        //Time diff 1 hour but cords within range should conflict as we do not handle time of occurance

        [Test]
        public void testTimeDoesConflict()
        {

            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

            //diff only few MS
            string Test1Time = "DTR423;39000;13000;12000;20151006213456700";
            string Test2Time = "ATR423;39099;13033;12001;20151006213456789";

            List<string> test = new List<string>();
            test.Add(Test1Time);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            test.Add(Test2Time);

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            //assert bool is true
            Assert.That(air.Conflict, Is.True);

        }

        //*********************************************************************************TEST OF DEGREES*******************************************************************
        [Test]
        public void testDegrees_227()
        {

            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

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


        //****************************************************************************TEST OF VELOCITY********************************************************************************
        [Test]
        public void testVelocity_216ms()
        {
            AirMonitor air = new AirMonitor();

            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);

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
