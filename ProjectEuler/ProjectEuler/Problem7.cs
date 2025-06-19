using System;

namespace ProjectEuler;

public class Problem7
{
    static List<int> primes = [];
    public static void Solution()
    {
        int i = 2;

        while (primes.Count < 10001)
        {
            if (isPrime(i))
            {
                primes.Add(i);
            }
            i++;
        }

        Console.WriteLine(primes[10000]);
        //104743
    }

    static bool isPrime(int n) 
    {
        foreach (var prime in primes)
        {
            if (n % prime == 0) return false;
        }
        return true;
    }
}
