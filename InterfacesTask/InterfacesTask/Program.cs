using System;

namespace InterfacesTask
{

    public class BaseDeposit : Deposit
    {
        public decimal Amount { get; }
        public int Period { get; }

        public BaseDeposit(decimal amount, int period)
        {
            Amount = amount;
            Period = period;
        }

        public override decimal Income()
        {
            return Amount * (decimal)0.05 * Period;
        }
    }

    public class SpecialDeposit : Deposit
    {
        public decimal Amount { get; }
        public int Period { get; }

        public SpecialDeposit(decimal amount, int period)
        {
            Amount = amount;
            Period = period;
        }

        public override decimal Income()
        {
            if (Period == 1)
                return Amount * (decimal)0.01;
            else
                return Amount * (decimal)0.01 + Amount * (decimal)0.02 * (Period - 1);
        }
    }

    public class LongDeposit : Deposit
    {
        public decimal Amount { get; }
        public int Period { get; }

        public LongDeposit(decimal amount, int period)
        {
            Amount = amount;
            Period = period;
        }

        public override decimal Income()
        {
            if (Period <= 6)
                return 0;
            else
                return Amount * (decimal)0.15 * (Period - 6);
        }
    }

    class Program
    {
        static void Main()
        {
            var client = new Client();

            Deposit base_deposit = new BaseDeposit(1000m, 12);
            Deposit special_deposit = new SpecialDeposit(1000m, 24);
            Deposit long_deposit = new LongDeposit(1000m, 18);

            Console.WriteLine($"{base_deposit.GetType().Name}: {base_deposit.Income()}");
            Console.WriteLine($"{special_deposit.GetType().Name}: {special_deposit.Income()}");
            Console.WriteLine($"{long_deposit.GetType().Name}: {long_deposit.Income()}");

            client.AddDeposit(base_deposit);
            client.AddDeposit(special_deposit);
            client.AddDeposit(long_deposit);

            Console.WriteLine($"Total income: {client.TotalIncome()}");
            Console.WriteLine($"Max income: {client.MaxIncome()}");
            Console.WriteLine($"Income by number 2: {client.GetIncomeByNumber(2)}");

        }
    }
}