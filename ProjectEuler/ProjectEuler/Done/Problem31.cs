using System;

namespace ProjectEuler;

public class Problem31
{
    public static void Solution()
    {
        int count = 0;

        for (int i1 = 0; i1 <= 200; i1++)
        {
            for (int i2 = 0; i2 <= 100; i2++)
            {
                if (i1 * 1 + i2 * 2 > 200) continue;
                for (int i5 = 0; i5 <= 40; i5++)
                {
                    if (i1 * 1 + i2 * 2 + i5 * 5 > 200) continue;
                    for (int i10 = 0; i10 <= 20; i10++)
                    {
                        if (i1 * 1 + i2 * 2 + i5 * 5 + i10 * 10 > 200) continue;
                        for (int i20 = 0; i20 <= 10; i20++)
                        {
                            if (i1 * 1 + i2 * 2 + i5 * 5 + i10 * 10 + i20 * 20 > 200) continue;
                            for (int i50 = 0; i50 <= 4; i50++)
                            {
                                if (i1 * 1 + i2 * 2 + i5 * 5 + i10 * 10 + i20 * 20 + i50 * 50 > 200) continue;
                                for (int i100 = 0; i100 <= 2; i100++)
                                {
                                    if (i1 * 1 + i2 * 2 + i5 * 5 + i10 * 10 + i20 * 20 + i50 * 50 + i100 * 100 > 200) continue;
                                    for (int i200 = 0; i200 <= 1; i200++)
                                    {
                                        if (i1 * 1 + i2 * 2 + i5 * 5 + i10 * 10 + i20 * 20 + i50 * 50 + i100 * 100 + i200 * 200 != 200) continue;
                                        Console.WriteLine("{0}*$2 + {1}*$1 + {2}*50p + {3}*20p + {4}*10p + {5}*5p + {6}*2p + {7}*1p", i200, i100, i50, i20, i10, i5, i2, i1);
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine("Count: {0}", count);

        //73682
    }
}
