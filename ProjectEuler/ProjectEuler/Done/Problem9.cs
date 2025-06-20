using System;

namespace ProjectEuler;

public class Problem9
{
    static void Solution()
    {
        Console.WriteLine("Starting...");

        int sum = 1000;
        for (int a = 1; a <= sum; a++)
        {
            for (int b = a+1; b <= sum-a; b++)
            {
                int c = sum-(a+b);

                if (a*a + b*b == c*c) Console.WriteLine("{0} + {1} = {2}. {0}, {1} and {2} are a Pythagorean triplet! Product: {3}", a, b, c, a*b*c);
            }
        }

        // 31875000
    }
}
