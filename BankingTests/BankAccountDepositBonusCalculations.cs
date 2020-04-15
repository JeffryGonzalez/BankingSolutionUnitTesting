using BankingDomain;
using Moq;
using Xunit;

namespace BankingTests
{
    public class BankAccountDepositBonusCalculations
    {
        [Theory]
        [InlineData(100, 42)]
        [InlineData(150, 12)]
        public void DepositUsesTheBonusCalculator(decimal amountToDeposit, decimal expected)
        {
            // Make sure the bonus calculator
            //   -- is given the right arguments(balance, amountOfDeposit)
            //   -- AND the amount returned from it is added to the deposit.

            // Given
            var stubbedBonusCalculator = new Mock<ICalculateAccountBonuses>();
            var account = new BankAccount(stubbedBonusCalculator.Object, null);
            var openingBalance = account.GetBalance();
            stubbedBonusCalculator.Setup(b => b.GetDepositBonusFor(openingBalance, amountToDeposit)).Returns(expected);

            // When
            account.Deposit(amountToDeposit);

            // Then
            Assert.Equal(openingBalance + amountToDeposit + expected, account.GetBalance());
        }
    }
}
