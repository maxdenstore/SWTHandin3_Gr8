using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ATMSystem;
using ATMSystem.Interfaces;
using Castle.Core.Internal;
using Castle.DynamicProxy.Generators;
using NSubstitute;
using NSubstitute.ClearExtensions;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using TransponderReceiver;


namespace ATM.IT.Test
{
    public class IT_ReceiveTranspond
    {

        [TestFixture]
        public class ITest_RecieveTranspond
        {
            private IAirmonitor _fakeAirmonitor;
            private ITransponderReceiver _fakeTransponderReceiver;
            private IOutput _fakeOutput;
            private ReceiveTranspond _uut;

            private TranspondObject _transpondObjectA;
            private TranspondObject _transpondObjectB;


            [SetUp]
            public void Setup()
            {
                string tag = "ATR423";
                int posX = 39000;
                int posY = 42000;
                int alt = 2000;
                DateTime date = new DateTime(2018, 1, 1, 12, 0, 0);
                _transpondObjectA = new TranspondObject(tag, posX, posY, alt, date, _fakeOutput);

                string tag2 = "ATR423";
                int posX2 = 39000;
                int posY2 = 42000;
                int alt2 = 2000;
                DateTime date2 = new DateTime(2018, 1, 1, 12, 0, 0);
                _transpondObjectB = new TranspondObject(tag2, posX2, posY2, alt2, date2, _fakeOutput);

                _fakeAirmonitor = Substitute.For<IAirmonitor>();
                _fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
                _fakeOutput = Substitute.For<IOutput>();


            }

            [Test]
            public void Test_airspaceIsCalled()
            {
                _uut = new ReceiveTranspond(_fakeTransponderReceiver, _fakeOutput, _fakeAirmonitor);

                List<string> test = new List<string>();
                test.Add("TestTag;39045;12932;14000;20151006213456789");
                _uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));

                _fakeAirmonitor.Received(1).ReceiveNewTranspondObject(Arg.Any<TranspondObject>());
            }

<<<<<<< HEAD
            [Test]
            public void Test_airspaceListEmpty()
            {
                _uut = new ReceiveTranspond(_fakeTransponderReceiver, _fakeOutput, _fakeAirmonitor);

                List<string> test = new List<string>();
                test.Add("TestTag;10000;10000;0;20151006213456789");

                _uut.transponderReceiverData(this, new RawTransponderDataEventArgs(test));
                string teststr = "TestTag";




                _fakeAirmonitor.Received(1).monitorList.Remove(Arg.Any<ITranspondObject>());


                Assert.That(_fakeAirmonitor.monitorList.Exists(x => x.Tag == teststr), Is.False);
            }

=======
>>>>>>> c4c558c8206a80f5356054dc7b3f51794febf859
        }
    }
}
