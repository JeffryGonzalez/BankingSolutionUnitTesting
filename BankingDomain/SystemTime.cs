using System;
using System.Collections.Generic;
using System.Text;

namespace BankingDomain
{
    public class SystemTime : ISystemTime
    {
        public DateTime GetCurrent()
        {
            return DateTime.Now; // THE ONLY PLACE IN MY APPLICATION THAT IS ALLOWED TO TOUCH THIS ABOMINATION AGAINST GOD AND NATURE
        }
    }
}
