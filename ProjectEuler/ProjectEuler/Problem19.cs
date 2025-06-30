using System;

namespace ProjectEuler;

public class Problem19
{
    public static void Solution()
    {
        //How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
        int year = 1901;
        int month = 1;
        int sunday_count = 0;
        int dayI = 2;

        while (year != 2001)
        {
            Console.WriteLine("Year {0}", year);
            month = 1;
            while (month != 13)
            {
                int days = 31;
                List<int> month30 = [4, 6, 9, 11];

                if (month == 2)
                {
                    if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) days = 29;
                    else days = 28;
                }
                else if (month30.Contains(month)) days = 30;

                for (int i = 0; i < days; i++)
                {
                    dayI = (dayI % 7) + 1;
                    if (dayI == 1) sunday_count++;
                }

                month++;
            }
            year++;
        }

        Console.WriteLine(sunday_count);
        //5218
    }
}
