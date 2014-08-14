using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hatfield.Util
{
    public static class AgeCalculator
    {
        public static int CalculateAge(string birthDate)
        {
            DateTime birthDateTime;

            if(DateTime.TryParse(birthDate, out birthDateTime))
            {
                DateTime nowDateTime = DateTime.Now;
                int age = nowDateTime.Year - birthDateTime.Year;
                if (nowDateTime.Month < birthDateTime.Month || (nowDateTime.Month == birthDateTime.Month && nowDateTime.Day < birthDateTime.Day)) age--;
                return age;
            }
            return 0;
        }

    }
}