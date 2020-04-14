using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountTests
    {
        [Fact]
        public void NewAccountsHaveAppropriateBalance()
        {
            // Write the Code You Wish You Had (WTCYWYH) (Corey Haines)

            BankAccount account = new BankAccount();

            decimal balance = account.GetBalance();

            Assert.Equal(1200M, balance);
        }

        [Fact]
        public void DepositingIncreasesBalance()
        {
            // (Arrange) Given - I have a new account and I have the balance of that account
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;
            // (Act) When I deposit $100.
            account.Deposit(amountToDeposit);
            // (Assert) Then the accounts balance should be the opening balance plus 100.
            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
        }

        [Fact]
        public void WithdrawalsDecreaseBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 100M;
            // (Act) When I deposit $100.
            account.Withdraw(amountToWithdraw);
            // (Assert) Then the accounts balance should be the opening balance plus 100.
            Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
        }
    }
}
