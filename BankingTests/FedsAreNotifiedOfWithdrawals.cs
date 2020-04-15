using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class FedsAreNotifiedOfWithdrawals
    {
        [Fact]
        public void FedsAreNotified()
        {
            // Given
            var fedMock = new Mock<INotifyTheFeds>();
            var account = new BankAccount(null, fedMock.Object);
            // When
            account.Withdraw(5);
            // Then
            
            fedMock.Verify(m => m.Notify(account, 5));


        }
    }

    
}
