using System;

namespace ProjectEuler;

public class Problem14
{
    static Dictionary<long, int> lengths = [];
    public static void Solution()
    {
        int max_length = 0;
        long starter = 0;

        for (long i = 113382; i < 1000000; i++)
        {
            if (i%1000 == 0) Console.WriteLine("Completed {0}%", Convert.ToDecimal(i*1000/1000000)/10);
            int length = CollatzLength(i);
            lengths.Add(i, length);

            if (length > max_length) {
                max_length = length;
                starter = i;
            }
        }

        Console.WriteLine(starter);
        //837799
    }

    static int CollatzLength(long n)
    {
        int length = 1;
        while (n != 1)
        {
            if (lengths.ContainsKey(n)) return length+lengths[n];
            length++;
            if (n % 2 == 0) n /= 2;
            else n = 3 * n + 1;
            // if(lengths.TryGet(n, out length)) return length;
        }
        return length;
    }
}
