using System;

namespace ASDLL
{
    public static class Convert2NepaliDate
    {
        public static string GetMonth(short mon)
        {
            string[] strArrays = new string[] { "Baishakh", "Jetha", "Asar", "Saaun", "Bhadau", "Asoj", "Kartik", "Mangsir", "Poush", "Magh", "Falgun", "Chaitra" };
            string[] strArrays1 = strArrays;
            mon = Convert.ToInt16(mon - 1);
            return strArrays1[mon];
        }

        public static NepaliDate GetNepaliDate(DateTime enDate)
        {
            int[] nepaliDateDataArray = NepaliDateDataArray.GetNepaliDateDataArray(enDate.Year);
            int dayOfYear = enDate.DayOfYear;
            int num = nepaliDateDataArray[0];
            int num1 = 9;
            int num2 = nepaliDateDataArray[2];
            int num3 = nepaliDateDataArray[2] - nepaliDateDataArray[1] + 1;
            int num4 = 3;
            while (dayOfYear > num3)
            {
                num3 += nepaliDateDataArray[num4];
                num2 = nepaliDateDataArray[num4];
                num1++;
                if (num1 > 12)
                {
                    num1 -= 12;
                    num++;
                }
                num4++;
            }
            int num5 = num2 - (num3 - dayOfYear);
            NepaliDate nepaliDate = new NepaliDate()
            {
                npDate = string.Format("{0}/{1}/{2}", num, num1, num5),
                npYear = num,
                npMonth = num1,
                npDay = num5,
                npDaysInMonth = num2
            };
            return nepaliDate;
        }
    }
}