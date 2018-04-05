using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TransponderReceiver.Unit.Test
{
    [TestFixture]
    public class TransponderReceiverUnitTest
    {

        [SetUp]
        public void setup()
        {

        }

        [Test]
        public void Test1()
        {
            Assert.That(1, Is.EqualTo(1));
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
