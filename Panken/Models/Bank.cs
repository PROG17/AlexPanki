using Panken.Repo;
using Panken.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panken.Models
{
    public static class Bank
    {
        public static void Deposit(TransactionVM transaction)
        {
            var account = BankRepository.GetAccount(transaction.AccountNumber);
            account.Deposit(transaction.Amount);
        }
        public static bool Withraw(TransactionVM transaction)
        {
            var account = BankRepository.GetAccount(transaction.AccountNumber);
            if ((account.Balance - transaction.Amount) > 0)
            {
                 account.Withraw(transaction.Amount);
                return true;
                
            }
            return false;
        }
    }
}
