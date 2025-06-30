using System;

namespace ProjectEuler;

public class Problem34
{
    public static void Solution()
    {
        int total = 0;
        List<int> factorials = [];
        for (int i = 0; i < 10; i++)
        {
            factorials.Add(Factorial(i));
            Console.WriteLine("{0}! = {1}", i, factorials[i]);
        }
        for (int i = 3; i < 9999999; i++)
        {
            int sum = 0;
            int n = i;

            while (n >= 10)
            {
                sum += factorials[n % 10];
                n /= 10;
            }
            sum += factorials[n];

            if (sum == i) 
            {
                total += i;
                Console.WriteLine("\t{0} == {1}", i, sum);
            }
        }

        Console.WriteLine("Total: {0}", total);
        //11547
    }

    static int Factorial(int n)
    {
        int value = 1;

        if (n == 0) return value;

        value = n * Factorial(n - 1);
        return value;
    }
}
