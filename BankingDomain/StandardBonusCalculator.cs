﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankingDomain
{
    public class StandardBonusCalculator 
    {
        public decimal CalculateBonusUsingStandardAlgorithm(decimal balance, decimal amount)
        {
            // If the balance is above a certain cutoff & the time is before the close of day
            // they get a 10% bonus on deposits. If it is above the cutoff, and after they close
            // of the day, they get 5%
            if(balance > 10000 && DateTime.Now.Hour <= 16)
            {
                return amount * .10M;
            }
            if(balance > 10000)
            {
                return amount * .05M;
            }
            return amount;
        }
    }
}