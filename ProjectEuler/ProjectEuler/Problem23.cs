using System;

namespace ProjectEuler;

public class Problem23
{
    public static void Solution()
    {
        //sum of all the positive integers which cannot be written as the sum of two abundant numbers.
        List<int> abundant_numbers = [];
        long sum = 0;
        Console.WriteLine("finding abundant numbers...");
        for (int i = 0; i < 28123; i++)
        {
            if (IsAbundant(i))
            {
                abundant_numbers.Add(i);
            }
        }

        Console.WriteLine("summing up...");
        for (int i = 28123; i > 0; i--)
        {
            if (i % 1000 == 0) Console.WriteLine("{0} of thousands", i / 1000);
            foreach (int n in abundant_numbers)
            {
                if (n >= i) continue;
                if (!abundant_numbers.Contains(i - n)) sum += (long)i;
            }
        }

        Console.WriteLine("{0}", sum);
        
        //1381869676639
    }

    static List<int> ProperDivisors(int n)
    {
        List<int> result = new List<int>();
        for (int i = 1; i <= n/2; i++)
        {
            if (n % i == 0) result.Add(i);
        }

        return result;
    }

    static bool IsAbundant(int n)
    {
        int sum = 0;

        foreach (int divisor in ProperDivisors(n))
        {
            sum += divisor;
        }

        return sum > n;
    }
}
