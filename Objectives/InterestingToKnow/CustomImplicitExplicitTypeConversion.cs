using System;

namespace InterestingToKnow
{
    class Money
    {
        private decimal Amount { get; set; }
        public Money(decimal amount)
        {
            Amount = amount;
        }        
        public static implicit operator decimal(Money money)
        {
            return money.Amount;
        }
        public static explicit operator int(Money money)
        {
            return (int)money.Amount;
        }
    }

    public static class UsingCustomImpExpConversions
    {
       public static void Run()
       {
            var money = new Money(13.56m);
            decimal amount = money;
            int intAmount = (int)money;

            Console.WriteLine($"Amount: {amount}, IntAmount: {intAmount}");
       }
    }    
}