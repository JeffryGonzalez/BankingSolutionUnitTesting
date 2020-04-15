using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class GoldAccountTests
    {

        [Fact]
        public void GoldAccountsGetABonusOnDeposits()
        {
            // Given
            var account = new BankAccount();
            var originalBalance = account.GetBalance();
            var amountToDeposit = 100M;
            account.AccountType = AccountType.Gold;
            // When
            account.Deposit(amountToDeposit);
            // Then
            Assert.Equal(originalBalance + (amountToDeposit * 1.10M), account.GetBalance());

        }
    }
}
