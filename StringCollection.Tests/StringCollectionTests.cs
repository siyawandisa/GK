using System;
using NUnit.Framework;
using GlobalKinetics;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ToString_Multiple_Test()
        {
            var strings = new StringCollection();
            strings.AddString("first");
            var str = strings.ToString();
            Assert.AreEqual("first", str);

            strings.AddString("second");
            str = strings.ToString();
            Assert.AreEqual("first, second", str);
        }

        [Test]
        public void ToString_Empty_Test()
        {
            var strings = new StringCollection();
            var str = strings.ToString();
            Assert.AreEqual(string.Empty, str);
        }
    }
}