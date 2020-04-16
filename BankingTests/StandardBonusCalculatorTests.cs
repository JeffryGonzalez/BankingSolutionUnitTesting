using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class StandardBonusCalculatorTests
    {
        // If the balance is above a certain cutoff & the time is before the close of day
        // they get a 10% bonus on deposits. If it is above the cutoff, and after they close
        // of the day, they get 5%. Otherwise nothing
        [Fact]
        public void AboveCutoffAndBeforeClose()
        {
            // This test will pass before 5:pm and fail after
            // var bonusCalculator = new TestingBonusCalculator(isBeforeCutoff: true);
            var fakeSystemTime = new Mock<ISystemTime>();
            var bonusCalculator = new StandardBonusCalculator(fakeSystemTime.Object);
            fakeSystemTime.Setup(f => f.GetCurrent()).Returns(new DateTime(2020, 4, 20, 13, 59, 59));

            var bonus = bonusCalculator.CalculateBonusUsingStandardAlgorithm(10001, 100);

            Assert.Equal(10M, bonus);

        }

        [Fact]
        public void AboveCutoffAfterClose()
        {
            // This test will pass after 5pm and fail before.
            //var bonusCalculator = new TestingBonusCalculator(isBeforeCutoff: false);
            var fakeSystemTime = new Mock<ISystemTime>();
            var bonusCalculator = new StandardBonusCalculator(fakeSystemTime.Object);
            fakeSystemTime.Setup(f => f.GetCurrent()).Returns(new DateTime(2020, 4, 20, 17, 01, 00));


            var bonus = bonusCalculator.CalculateBonusUsingStandardAlgorithm(10001, 100);

            Assert.Equal(5M, bonus);
        }

        [Fact]
        public void BelowCutoffAfterClose()
        {
            // var bonusCalculator = new TestingBonusCalculator(false);
            var fakeSystemTime = new Mock<ISystemTime>();
            var bonusCalculator = new StandardBonusCalculator(fakeSystemTime.Object);
            fakeSystemTime.Setup(f => f.GetCurrent()).Returns(new DateTime(2020, 4, 20, 13, 01, 00));
            

            var bonus = bonusCalculator.CalculateBonusUsingStandardAlgorithm(999, 100);

            Assert.Equal(0, bonus);

            // simulating really creating the account

            // ICalculateAccountBonuses c2 = new StandardBonusCalculator();
            
        }

    }

    //public class TestingBonusCalculator : StandardBonusCalculator
    //{
    //    private bool IsBeforeCutoff;

    //    public TestingBonusCalculator(bool isBeforeCutoff)
    //    {
    //        IsBeforeCutoff = isBeforeCutoff;
    //    }

    //    protected override bool BeforeCutoff()
    //    {
    //        return IsBeforeCutoff;
    //    }
    //}

}
