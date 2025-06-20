using System;

namespace ProjectEuler;

public class Problem6
{
    public static void Solution()
    {
        int sumOfSquares = 0;
        int squareOfSum = 0;

        Console.WriteLine("Started");

        for (int i = 1; i <= 100; i++)
        {
            sumOfSquares += i*i;
            squareOfSum += i;
        }

        squareOfSum *= squareOfSum;

        Console.WriteLine(squareOfSum-sumOfSquares);
    }
}
