using System;

namespace ProjectEuler;

public class PEMath
{
    public static void Solution()
    {
        
    }

    public static List<int> ProperDivisors(int n)
    {
        List<int> divisors = new List<int>();

        for (int i = 1; i <= n/2; i++)
        {
            if (n % i == 0) divisors.Add(i);
        }
        divisors.Add(n);

        return divisors;
    }
}
