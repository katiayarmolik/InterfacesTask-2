using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterfacesTask
{
    public class Client : IEnumerable<Deposit>
    {
        private readonly Deposit[] deposits;

        public Client()
        {
            this.deposits = new Deposit[10];
        }

        public bool AddDeposit(Deposit deposit)
        {
            int index = Array.IndexOf(this.deposits, null);
            if (index != -1)
            {
                this.deposits[index] = deposit;
            }

            return index != -1;
        }

        public decimal TotalIncome() => this.deposits.Where(x => x != null)
                                                     .Sum(x => x.Income());

        public decimal MaxIncome() => this.deposits.Where(x => x != null)
                                                   .Max(x => x.Income());

        public decimal GetIncomeByNumber(int number)
        {
            if (this.deposits[number - 1] != null)
            {
                return this.deposits[number - 1].Income();
            }
            else return 0;
        }

        public IEnumerator<Deposit> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.deposits.GetEnumerator();
        }

        public void SortDeposits()
        {
            Array.Sort(this.deposits);
            Array.Reverse(this.deposits);
        }
    }
}
