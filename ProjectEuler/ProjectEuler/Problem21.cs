using System;

namespace ProjectEuler;

public class Problem21
{
    static Dictionary<int, List<int>> divisorDictionary = new Dictionary<int, List<int>>();
    static Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
    public static void Solution()
    {
        Console.WriteLine("creating divisor dictionary...");
        int sum = 0;

        for (int i = 1; i < 100000; i++)
        {
            divisorDictionary.Add(i, []);
        }
        for (int i = 1; i < 100000; i++)
        {
            for (int n = i; n < 10000; n += i)
            {
                divisorDictionary[n].Add(i);
            }
        }
        Console.WriteLine("finding amicable numbers...");
        for (int i = 2; i < 10000; i++)
        {
            int j = FindDValue(i);
            Console.WriteLine((i, j));
            // if (j >)
            if (IsAmicable(i, j)) sum += i + j;
        }

        Console.WriteLine(sum);
        //80568
    }

    static int FindDValue(int n)
    {
        int d = 0;

        foreach (int divisor in divisorDictionary[n])
        {
            if (n == divisor) continue;
            d += divisor;
        }

        return d;
    }

    static bool IsAmicable(int a, int b)
    {
        return (FindDValue(a) == b && FindDValue(b) == a);
    }

    static List<int> ProperDivisors(int n)
    {
        List<int> divisors = new List<int>();
        if (dictionary.ContainsKey(n)) divisors = dictionary[n];

        for (int i = 1; i <= n/2; i++)
        {
            if (dictionary[n].Contains(i)) continue;
            if (n % i == 0) divisors.Add(i);
        }
        divisors.Add(n);

        for (int i = n; i < 10000; i+=n)
        {
            if (!dictionary.ContainsKey(i)) dictionary[i] = [];
            foreach (int divisor in divisors)
            {
                if (dictionary[i].Contains(divisor)) continue;
                dictionary[i].Add(divisor);
            }
        }
        return divisors;
    }
}
