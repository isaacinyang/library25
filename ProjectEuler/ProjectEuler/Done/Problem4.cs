using System;

namespace ProjectEuler;

public class Problem4
{
    public static void Solution()
    {
        int palindrome = 0;

        for (int a = 100; a < 1000; a++)
        {
            for (int b = 100; b < 1000; b++)
            {
                if (a * b > palindrome && IsPalindrome(a * b))
                {
                    palindrome = a * b;
                    Console.WriteLine("New palindrome: {0}", palindrome);
                }
            }
        }

        Console.WriteLine(palindrome);
    }

    public static bool IsPalindrome(long n)
    {
        string str = Convert.ToString(n);

        for (int i = 0; i < str.Length / 2; i++)
        {
            if (str[i] != str[str.Length - i - 1]) return false;
        }

        return true;
    }
}
