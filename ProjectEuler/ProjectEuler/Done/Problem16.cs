using System;

namespace ProjectEuler;

public class Problem16
{
    public static void Solution()
    {
        List<int> number = [1];
        int power = 1000;
        int sum = 0;

        Console.WriteLine("starting...");
        for (int i = 0; i < power; i++)
        {
            DoubleNumber(number);
        }

        Console.Write("2^{0} = ", power);
        for (int i = number.Count - 1; i >= 0 ; i--)
        {
            Console.Write(number[i]);
        }
        Console.WriteLine("");

        foreach (int digit in number)
        {
            sum += digit;

        }
        Console.WriteLine(sum);

        //1366
    }

    static List<int> DoubleNumber(List<int> number)
    {
        for (int i = 0; i < number.Count; i++)
        {
            number[i] *= 2;
        }

        for (int i = 0; i < number.Count; i++)
        {
            while (number[i] > 9) {
                if (i == number.Count - 1) number.Add(0);

                number[i] -= 10;
                number[i+1]++;
            }
        }

        return number;
    }
}
