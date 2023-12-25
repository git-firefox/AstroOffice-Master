using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Methods
{
    public class PredictionBLL
    {
        public int CalculateAgeCorrect(DateTime birthDate, DateTime now)
        {
            bool flag;
            int year = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month)
            {
                flag = false;
            }
            else
            {
                flag = now.Month != birthDate.Month ? true : now.Day >= birthDate.Day;
            }
            if (!flag)
            {
                year--;
            }
            return year;
        }
    }
}
