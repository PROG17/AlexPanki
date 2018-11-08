using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panken.Models
{
    public class Account
    {
        public Account(int id, Customer owner, decimal balance)
        {
            Balance = balance;
            Owner = owner;
            Id = id;
        }
        public int Id { get; set; } 
        public decimal Balance { get; private set; }
        public Customer Owner { get; set; }

        public void Deposit(decimal sum)
        {
            Balance += sum;
        }
        public void Withraw(decimal sum)
        {
            Balance -= sum;
        }


    }
}
