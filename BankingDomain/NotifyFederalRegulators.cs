using System;
using System.Collections.Generic;
using System.Text;

namespace BankingDomain
{
    public class NotifyFederalRegulators : INotifyTheFeds
    {
        void INotifyTheFeds.Notify(IGiveFederalRegulatorsAccountInformation bankAccount, decimal amountToWithdraw)
        {
            var balance = bankAccount.GetBalance();
            Console.WriteLine($"An account with a balance of {balance:c} wants to withdraw {amountToWithdraw:c}");
        }
    }
}
