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
        

        [SetUp]
        public void Setup()
        {

        }

        //***********************************************************************TEST OF INPUT*********************************************************************
        //Test transponderReceive
        [Test]
        public void transponderRecieverDataTest()
        {
            var air = IAirmonitor; 
           air = Substitute.For<AirMonitor>();
            ReceiveTranspond uut =
                new ReceiveTranspond(TransponderReceiverFactory.CreateTransponderDataReceiver(),air);

            Assert.That(air.monitorList.Count,Is.EqualTo(1) );
        }

    }
}
