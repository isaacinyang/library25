using System;

namespace ProjectEuler;

public class Problem20
{
    static List<int> number = [1];
    public static void Solution()
    {
        int power = 100;
        int sum = 0;

        for (int i = 1; i <= power; i++)
        {
            Multiply(i);
            // for (int j = number.Count - 1; j >= 0 ; j--)
            // {
            //     Console.Write(number[j]);
            // }
            Console.WriteLine(i+"!");
        }
        for (int i = number.Count - 1; i >= 0 ; i--)
        {
            sum += number[i];
        }
        Console.WriteLine("");
        Console.WriteLine("The sum of digits in {0}! is {1}", power, sum);

        // 648
    }

    static void Multiply(int n)
    {
        for (int i = 0; i < number.Count; i++)
        {
            number[i] *= n;
        }
        for (int i = 0; i < number.Count; i++)
        {
            while (number[i] >= 10)
            {
                if (i == number.Count - 1) number.Add(0);
                number[i] -= 10;
                number[i+1]++;
            }
        }
    }
}
