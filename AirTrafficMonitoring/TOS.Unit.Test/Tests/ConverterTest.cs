using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace TOS.Unit.Test.Tests
{
    [TestFixture]
    class ConverterTest
    {
        private Converter uut = new Converter(TransponderReceiverFactory.CreateTransponderDataReceiver());
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void test1()
        {
           TOS xy = uut.convert("ATR423;39045;12932;14000;20151006213456789");
           Assert.That(xy.Tag == "ATR423");
        }
    }
}
