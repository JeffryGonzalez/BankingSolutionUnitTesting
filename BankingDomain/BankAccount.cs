﻿using System;

namespace BankingDomain
{
    public class BankAccount
    {
        private decimal balance = 1200;
        private ICalculateAccountBonuses BonusCalculator;

        public BankAccount(ICalculateAccountBonuses bonusCalculator)
        {
            BonusCalculator = bonusCalculator;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            var bonus = 0;
           // decimal bonus = BonusCalculator.GetDepositBonusFor(balance, amountToDeposit);
            balance += amountToDeposit + bonus;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            balance -= amountToWithdraw;
        }
    }
}