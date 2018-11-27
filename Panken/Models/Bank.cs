﻿using Panken.Repo;
using Panken.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panken.Models
{
    public static class Bank
    {
        public static bool Deposit(DepositWithrawVM transaction)
        {
            var account = BankRepository.GetAccount(transaction.AccountNumber);
            if (account != null)
            {
                account.Deposit(transaction.Amount);
                return true;
            }
            return false;
        }
        public static bool Withraw(DepositWithrawVM transaction)
        {
            var account = BankRepository.GetAccount(transaction.AccountNumber);
            if ((account.Balance - transaction.Amount) >= 0)
            {
                 account.Withraw(transaction.Amount);
                return true;
                
            }
            return false;
        }
        public static bool AccountExists(int accountId)
        {
            return BankRepository.GetAccount(accountId) != null;
        }
    }
}
