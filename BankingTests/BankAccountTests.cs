using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountTests
    {
        BankAccount Account;
        decimal OpeningBalance;

        public BankAccountTests()
        {
            Account = new BankAccount(new Mock<ICalculateAccountBonuses>().Object,
                new Mock<INotifyTheFeds>().Object);
            OpeningBalance = Account.GetBalance();
        }
        [Fact]
        public void NewAccountsHaveAppropriateBalance()
        {
            // Write the Code You Wish You Had (WTCYWYH) (Corey Haines)

            Assert.Equal(1200M, OpeningBalance);
        }

        [Fact]
        public void DepositingIncreasesBalance()
        {
            // (Arrange) Given - I have a new account and I have the balance of that account
            var amountToDeposit = 100M;
            // (Act) When I deposit $100.
            Account.Deposit(amountToDeposit);
            // (Assert) Then the accounts balance should be the opening balance plus 100.
            Assert.Equal(OpeningBalance + amountToDeposit, Account.GetBalance());
        }

        [Fact]
        public void WithdrawalsDecreaseBalance()
        {
            var amountToWithdraw = 100M;
            // (Act) When I deposit $100.
            Account.Withdraw(amountToWithdraw);
            // (Assert) Then the accounts balance should be the opening balance plus 100.
            Assert.Equal(OpeningBalance - amountToWithdraw, Account.GetBalance());
        }
    }

    public class DummyBonusCalculator : ICalculateAccountBonuses
    {
        public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
        {
            return 0;
        }
    }
}
