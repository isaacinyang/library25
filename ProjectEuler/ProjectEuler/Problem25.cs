using System;

namespace ProjectEuler;

public class Problem25
{
    public static void Solution()
    {
        List<List<int>> fibonnacci = [];

        for (int n = 0; n < 3; n++)
        {
            List<int> number = [];
            for (int i = 0; i < 999; i++)
            {
                number.Add(0);
            }
            number.Add(-(-n/2));
            fibonnacci.Add(number);
        }

        while (fibonnacci[0][0] == 0)
        {
            fibonnacci[0] = fibonnacci[1];
            fibonnacci[1] = fibonnacci[2];
            for (int i = 0; i < 1000; i++)
            {
                fibonnacci[2][i] = fibonnacci[0][i] + fibonnacci[1][i];
                if (i == 0 && fibonnacci[2][i] > 0) Console.WriteLine("Yahoo!");
                while (fibonnacci[2][i] > 10)
                {
                    fibonnacci[2][i-1]++;
                    fibonnacci[2][i] -= 10;
                }
            }
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(fibonnacci[2][i]);
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
