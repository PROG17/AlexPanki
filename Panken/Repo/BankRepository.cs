using Panken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panken.Repo
{
    public static class BankRepository
    {
        private static readonly List<Account> Accounts = new List<Account>();
        private static readonly List<Customer> Customers = new List<Customer>();

        public static void AddCustomer(Customer newCustomer)
        {
            Customers.Add(newCustomer);
        }
        public static void AddAccount(Account newAccount)
        {
            Accounts.Add(newAccount);
        }
        public static List<Customer> GetCustomers()
        {
            return Customers;
        }

        public static List<Account> GetAccounts()
        {
            return Accounts;
        }
        public static Account GetAccount(int id)
        {
            return Accounts.SingleOrDefault(x=>x.Id == id);
        }
    }
}
