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
        public void AddCoin_Success_Tests()
        {
            var coinJar = new CoinJar();            
            Assert.AreEqual(coinJar.TotalAmount, 0.00);

            var c1 = new Coin(1, 10);
            coinJar.AddCoin(c1);
            Assert.AreEqual(coinJar.TotalAmount, 1);
        }

        [Test]
        public void AddCoin_Overflow_Tests()
        {
            var coinJar = new CoinJar();            
            Assert.AreEqual(coinJar.TotalAmount, 0.00);

            var c1 = new Coin(1, 10);
            coinJar.AddCoin(c1);
            Assert.AreEqual(coinJar.TotalAmount, 1);

            var c2 = new Coin(2, 22);
            coinJar.AddCoin(c2);
            Assert.AreEqual(coinJar.TotalAmount, 3);

            var c3 = new Coin(5, 33);
            coinJar.AddCoin(c3);
            Assert.AreEqual(coinJar.TotalAmount, 5);
        }

        [Test]
        public void AddCoin_LargeCoin_Tests()
        {
            var coinJar = new CoinJar();            
            Assert.AreEqual(coinJar.TotalAmount, 0);
 
            var c1 = new Coin(50, 50);
            Assert.Throws<JarOverflowException>( () => coinJar.AddCoin(c1) );//, "The coin is too large for the jar.");
        }               

        [Test]
        public void Reset_Tests()
        {
            var coinJar = new CoinJar();            
            Assert.AreEqual(coinJar.TotalAmount, 0.00);

            var c1 = new Coin(1, 10);
            coinJar.AddCoin(c1);
            
            Assert.AreEqual(coinJar.TotalAmount, 1);

            coinJar.Reset();
            Assert.AreEqual(coinJar.TotalAmount, 0);
        }        
    }
}