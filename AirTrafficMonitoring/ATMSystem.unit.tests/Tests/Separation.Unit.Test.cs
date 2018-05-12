using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMSystem.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace ATMSystem.Unit.Tests.Tests
{
    [TestFixture]
    class SeparationUnitTest
    {
        private IOutput _out;
        private Separtation _sep;
        private DateTime _dateTime;
        private string _tag;

        [SetUp]
        public void setup()
        {
            _dateTime = new DateTime(2018, 1, 1, 12, 0, 0);
            _tag = "Test1";
            _out = Substitute.For<IOutput>();
            _sep = new Separtation(_tag,_dateTime,_out);
        }


        [Test]
        public void OccurenceOfSep()
        {
            Assert.That(_sep.Occurence , Is.EqualTo(_dateTime));
        }

        [Test]
        public void tagOfSep()
        {
            Assert.That(_sep.Tag,Is.EqualTo(_tag));
        }
    }
}
