using System;

namespace ProjectEuler;

public class Problem5
{
    public static void Solution()
    {
        int number = 0;
        int factor = 840*3;

        while (number % factor != 0 || !IsDivisibleByAll(number))
        {
            number++;
        }

        Console.WriteLine(number);
    }

    static bool IsDivisibleByAll(int number)
    {
        if (number == 0) return false;
        List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];

        foreach (var n in numbers)
        {
            if (number % n != 0) return false;
        }
        
        return true;
    }
}
