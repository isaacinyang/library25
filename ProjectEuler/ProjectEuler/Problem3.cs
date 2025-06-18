using System;

namespace ProjectEuler
{
    class Problem3
    {
        // 

        public static void Solution()
        {
            long number = 600851475143;

            for (long i = 2; i < number; i++)
            {
                while (number % i == 0)
                {
                    number /= i;
                }
            }

            Console.WriteLine(number);
        }
    }
}