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

namespace IT_Test_Receive
{

    [TestFixture]
    public class IT_Test_Receive
    {
        private IOutput _fakeOutput = Substitute.For<IOutput>();
        
        private string testString = "ATR423;39045;12932;14000;20151006213456789";

        public ITranspondObject testTos;

        [SetUp]
        public void Setup()
        {
            testTos = new TranspondObject("ATR423", 39045, 12932, 14000,
                new DateTime(2015, 10, 06, 21, 34, 56, 789), _fakeOutput);
        }

        //***********************************************************************TEST OF INPUT*********************************************************************
        // Test transponderReceive
        [Test]
        public void transponderRecieverDataTest()
        {
            IAirmonitor air = Substitute.For<IAirmonitor>();
            ReceiveTranspond uut = new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(),_fakeOutput, air);
            List<string> test = new List<string>();
            test.Add(testString);
            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            air.ReceivedWithAnyArgs(1).ReceiveNewTranspondObject(testTos);
        }

        [Test]
        public void transponderRecieverDataTest2()
        {
            IAirmonitor air = Substitute.For<IAirmonitor>();
            ReceiveTranspond uut = new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);
            List<string> test = new List<string>();
            test.Add(testString);
            test.Add(testString);
            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            air.ReceivedWithAnyArgs(2).ReceiveNewTranspondObject(testTos);
        }

        [Test]
        public void transponderRecieverDataTest_noSendNoReceive()
        {
            IAirmonitor air = Substitute.For<IAirmonitor>();
            ReceiveTranspond uut = new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);
            List<string> test = new List<string>();

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            air.DidNotReceiveWithAnyArgs().ReceiveNewTranspondObject(testTos);

        }

        [Test]
        public void transponderRecieverDataTest_Printed()
        {
            IAirmonitor air = Substitute.For<IAirmonitor>();
            ReceiveTranspond uut = new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);
            List<string> test = new List<string>();

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            Assert.That(_fakeOutput.Received(1), testString);

        }
    }
}
