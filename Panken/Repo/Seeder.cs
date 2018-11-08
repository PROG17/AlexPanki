using Panken.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Panken.Repo
{
    public class Seeder
    {
        public static void SeedBankData()
        {
            
            var customers = new List<Customer> {
                new Customer
                {
                    Id = 1,
                    Name = "Alexander Arvanitis"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Fredrik Haglund"
                },
                 new Customer
                {
                     Id = 3,
                    Name = "Gustav Cleveman"
                },
                new Customer
                {
                    Id = 4,
                    Name = "Emilie Hagberg"
                },
                 new Customer
                {
                     Id = 5,
                    Name = "Marcus Glans"
                }
              
            };
            var rand = new Random();
            var accountId = 3001;
            foreach (var customer in customers)
            {
                var numberOfAccounts = rand.Next(1, 4);
                for (int i = 0; i < numberOfAccounts; i++)
                {
                    var newAccount = new Account(accountId, customer, rand.Next(0, 100000));
                    customer.Accounts.Add(newAccount);
                    BankRepository.AddAccount(newAccount);
                    accountId++;
                }
                BankRepository.AddCustomer(customer);
                Debug.WriteLine("Customer and accounts added to repo");
            }
        }
    }
}
