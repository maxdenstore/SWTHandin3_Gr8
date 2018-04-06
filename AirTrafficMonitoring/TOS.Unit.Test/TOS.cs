
using NUnit.Framework;

namespace TOS.Unit.Test
{
    [TestFixture]
    public class TOSTagTest
    {
        [Test]
        public void SendTag6_TagEqualTag()
        {
            string data = "ATR423";
            TOS uut = new TOS(data);

            Assert.That(uut.Tag, Is.EqualTo(data));      
        }

        [Test]
        public void SendTag5_TagEqualTONull()
        {
            string data = "ATR42";
            TOS uut = new TOS(data);

            Assert.That(uut.Tag, Is.Null);
        }

        [Test]
        public void SendTag7_TagEqualTONull()
        {
            string data = "ATR4222";
            TOS uut = new TOS(data);

            Assert.That(uut.Tag, Is.Null);
        }

        [Test]
        public void SendTag6stars_TagEqualTOnull()
        {
            string data = "******";
            TOS uut = new TOS(data);

            Assert.That(uut.Tag, Is.Null);
        }

    }
}
