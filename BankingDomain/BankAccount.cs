using System;


namespace BankingDomain
{
    public enum AccountType {  Standard, Gold };
    public class BankAccount
    {
        private decimal balance = 1200;
        public decimal GetBalance()
        {
            return balance;
        }

        public AccountType AccountType { get; set; } = AccountType.Standard;

        public void Deposit(decimal amountToDeposit)
        {
            decimal bonus = 0;
            if(AccountType == AccountType.Gold)
            {
                bonus = amountToDeposit * .10M;
            }
            balance += amountToDeposit + bonus;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            balance -= amountToWithdraw;
        }
    }
}