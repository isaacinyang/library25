using System;

namespace ProjectEuler
{
    class Problem2
    {
        // 

        public static void Solution()
        {
            int total = 0;
            int[] fibonacci = {1, 1};

            while (fibonacci[1] < 4000000)
            {
                int temp = fibonacci[0];
                fibonacci[0] = fibonacci[1];
                fibonacci[1] += temp;

                if (fibonacci[0] % 2 == 0) total += fibonacci[0];
            }

            Console.WriteLine(total);
        }
    }
}