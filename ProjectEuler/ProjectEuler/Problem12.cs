using System;

namespace ProjectEuler;

public class Problem12
{
    static Dictionary<long, List<long>> divisors = new Dictionary<long, List<long>>();
    public static void Solution()
    {
        Console.WriteLine(FindTriangleNumber(50));
    }

    static int DivisorCount(long n)
    {
        divisors.Add(n, [n]);
        int count = 1;
        for (long i = 1; i <= n/2; i++)
        {
            if (divisors.ContainsKey(i) && n%i == 0) {
                foreach (var div in divisors[i])
                {
                    if (!divisors[n].Contains(div)) {
                        divisors[n].Add(div);
                        count++;
                    }
                }
            }
        }
        for (long i = 1; i <= n/2; i++)
        {
            if (!divisors[n].Contains(i) && n % i == 0) {
                count++;
                divisors[n].Add(i);
            }
        }

        return count;
    }

    static long FindTriangleNumber(int divisorCount)
    {
        long i = 0;
        long n = 1;
        while (i >= 0)
        {
            i += n;
            n++;

            int d = DivisorCount(i);
            // Console.WriteLine("The {0}th triangle number is {1}; it has {2} divisors.", n-1, i, d);
            // foreach (long div in divisors[i])
            // {
            //     Console.Write("{0} || ", div);
            // }
            // Console.WriteLine("");
            if (d > divisorCount) return i;
        }
        return i;
    }
}
