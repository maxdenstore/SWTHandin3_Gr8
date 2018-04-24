using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMSystem;
using ATMSystem.Interfaces;
using Moq;
using NSubstitute;
using NUnit.Framework;
using TOS;
using TransponderReceiver;

namespace IT_Test_Receive
{

    [TestFixture]
    public class IT_Test_Receive
    {
        private string testString = "ATR423;39045;12932;14000;20151006213456789";
        global::TOS.TOS testTos = new TOS.TOS("ATR423", 39045,12932,14000,
           new DateTime(2015,10,06,21,34,56,789));

        [SetUp]
        public void Setup()
        {

        }

        //***********************************************************************TEST OF INPUT*********************************************************************
        // Test transponderReceive
        [Test]
        public void transponderRecieverDataTest()
        {
            IAirmonitor air = Substitute.For<IAirmonitor>();
            ReceiveTranspond uut = new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);
            List<string> test = new List<string>();
            test.Add(testString);
            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            air.ReceivedWithAnyArgs(1).ReceiveNewTOS(testTos);
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

            air.ReceivedWithAnyArgs(2).ReceiveNewTOS(testTos);
        }

        [Test]
        public void transponderRecieverDataTest_noSendNoReceive()
        {
            IAirmonitor air = Substitute.For<IAirmonitor>();
            ReceiveTranspond uut = new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(), air);
            List<string> test = new List<string>();

            uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

            air.DidNotReceiveWithAnyArgs().ReceiveNewTOS(testTos);

        }
    }
}
