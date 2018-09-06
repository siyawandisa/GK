using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalKinetics
{
    public interface ICoinJar
    {
        decimal TotalAmount { get; }
        void AddCoin(ICoin coin);        
        void Reset();
    }

    public class CoinJar: ICoinJar
    {
        private List<ICoin> coins = new List<ICoin>();
        public decimal TotalAmount { get {return coins.Sum(c => c.Amount);} }

        public CoinJar(){
            coins = new List<ICoin>();
        }

        public void AddCoin(ICoin coin){
            if (coin.Amount < 0.01 || coin.Volume <= 0.00){
                throw new Exception("Invalid coin properties");    
            }

            if ((coins.Sum(c => c.Volume) + coin.Volume) <= 42){
                coins.Add(coin);
            }
            else if (coin.Volume < 42){
                Reset();
                coins.Add(coin);                
            }
            else {
                throw new JarOverflowException("The coin is too large for the jar.");
            }
        }

        public void Reset(){            
            Console.WriteLine("Reseting");
            coins.Clear();
        }
    }

    public interface ICoin
    {
        decimal Amount { get; }
        decimal Volume { get; }
    }

    public class Coin: ICoin
    {
        private decimal amount ;
        private decimal volume ;

        public decimal Amount { get {return amount;} }
        public decimal Volume { get {return volume;} }

        public Coin(decimal amount, decimal volume){
            this.amount = amount;
            this.volume = volume;
        }
    }

    public class JarOverflowException: Exception
    {
        public JarOverflowException()
        {
        }

        public JarOverflowException(string message)
            : base(message)
        {
        }

        public JarOverflowException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}