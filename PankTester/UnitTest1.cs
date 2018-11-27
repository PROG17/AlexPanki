using Panken.Models;
using Panken.Repo;
using Panken.ViewModels;
using System;
using Xunit;

namespace PankTester
{
    public class UnitTest1
    {

        [Fact]
        public void VerifyDepositWorks()
        {
            var testAccount = new Account(1, new Customer(), 3000);
            BankRepository.AddAccount(testAccount);
            var account = BankRepository.GetAccount(1);
            var amountToDeposit = 3000;
            var transaction = new DepositWithrawVM { AccountNumber = account.Id, Amount = amountToDeposit };

            var expected = account.Balance + amountToDeposit;


            Bank.Deposit(transaction);
            var actual = BankRepository.GetAccount(1).Balance;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void VerifyInsufficientFundsWorks()
        {
            var testAccount = new Account(4, new Customer(), 7000);
            BankRepository.AddAccount(testAccount);
            var account = BankRepository.GetAccount(4);
            var amountToWithraw = 8000;
            var transaction = new DepositWithrawVM { AccountNumber = account.Id, Amount = amountToWithraw };

            var expected = 7000;


            Bank.Withraw(transaction);
            var actual = BankRepository.GetAccount(4).Balance;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void VerifyWithrawWorks()
        {
            var testAccount = new Account(2, new Customer(), 7000);
            BankRepository.AddAccount(testAccount);
            var account = BankRepository.GetAccount(2);
            var amountToWithraw = 2000;
            var transaction = new DepositWithrawVM { AccountNumber = account.Id, Amount = amountToWithraw };

            var expected = account.Balance - amountToWithraw;


            Bank.Withraw(transaction);
            var actual = BankRepository.GetAccount(2).Balance;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void VerifyNullGuard()
        {
            var testAccount = new Account(3, new Customer(), 1000);
            BankRepository.AddAccount(testAccount);
            var account = BankRepository.GetAccount(3);
            var amountToWithraw = 2000;
            var transaction = new DepositWithrawVM { AccountNumber = account.Id, Amount = amountToWithraw };

            var expected = 1000;


            Bank.Withraw(transaction);
            var actual = BankRepository.GetAccount(3).Balance;
            Assert.Equal(expected, actual);
        }
    }
    
}
