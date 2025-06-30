using System;

namespace ProjectEuler;

public class Problem29
{
    public static void Solution()
    {
        List<long> powers = new List<long>();
        long limit = 5;

        for (long a = 2; a <= 5; a++)
        {
            for (long b = 2; b <= 5; b++)
            {
                long power = Convert.ToInt64(Math.Pow(a, b));
                if (!powers.Contains(power))
                {
                    powers.Add(power);
                }
            }
        }

        Console.WriteLine(powers.Count);
    }
}
