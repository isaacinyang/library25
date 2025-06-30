using System;

namespace ProjectEuler;

public class Problem10
{
    static List<bool> primes = [];
    public static void Solution()
    {
        Console.WriteLine("starting...");
        int limit = 2000000;
        for (int i = 0; i < limit; i++)
        {
            primes.Add(true);
        }
        primes[0] = false;

        int sum = 0;

        Console.WriteLine("filtering...");
        for (int i = 2; i < limit; i++)
        {
            if (i % 1000 == 0) Console.WriteLine("Completed {0} thousands out of 2000", i/1000);
            if (i*i < limit)
            {
                for (int n = i * i; n <= limit; n += i)
                {
                    primes[n - 1] = false;
                }
            }
        }

        Console.WriteLine("summing...");
        Console.WriteLine("Primes:");
        for (int n = 0; n < primes.Count; n++)
        {
            if (primes[n]) {
                Console.WriteLine(n+1);
                sum += n+1;
            }
        }

        Console.WriteLine(sum);
        //1179908154
    }
}
