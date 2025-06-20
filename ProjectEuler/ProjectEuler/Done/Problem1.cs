using System;

namespace ProjectEuler
{
    class Problem1
    {
        // 

        public static void Solution()
        {
            int total = 0;

            for (int n = 1; n < 1000; n++)
            {
                if (n % 3 == 0 || n % 5 == 0)
                {
                    total += n;
                }
            }

            Console.WriteLine(total);
        }
    }
}