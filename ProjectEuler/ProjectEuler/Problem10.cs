using System;

namespace ProjectEuler;

public class Problem10b
{
    static List<bool> primes = [];
    public static void Solution()
    {
        Console.WriteLine("starting...");
        for (int i = 0; i < 2000000; i++)
        {
            primes.Add(true);
        }
        primes[0] = false;

        int sum = 0;

        Console.WriteLine("filtering...");
        for (int i = 2; i <= 2000000; i++)
        {
            if (i % 1000 == 0) Console.WriteLine("Completed {0} thousands out of 2000", i/1000);
            for (int n = i*2; n <= primes.Count; n+=i)
            {
                primes[n-1] = false;
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
