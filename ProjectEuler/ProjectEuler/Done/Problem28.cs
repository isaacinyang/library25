using System;

namespace ProjectEuler;

public class Problem28
{
    public static void Solution()
    {
        List<List<int>> grid = new List<List<int>>();
        int length = 1001;
        List<char> directions = ['r', 'd', 'l', 'u'];
        int x = (length-1)/2;
        int y = (length-1)/2;
        int n = 1;
        int dir = 0;

        if (length % 2 == 0)
        {
            Console.WriteLine("Incorrect length provided!");
            return;
        }

        for (int i = 0; i < length; i++)
        {
            grid.Add([]);
            for (int j = 0; j < length; j++)
            {
                grid[i].Add(0);
            }
        }

        while (grid[0][length - 1] == 0)
        {
            grid[y][x] = n;
            // System.Console.WriteLine("({0},{1}) = {2}", x, y, n);
            n++;

            if (grid[0][length - 1] != 0) continue;
            switch (directions[dir])
            {
                case 'r':
                    x++;
                    if (grid[y+1][x] == 0) dir = (dir+1)%4;
                    break;
                case 'd':
                    y++;
                    if (grid[y][x-1] == 0) dir = (dir+1)%4;
                    break;
                case 'l':
                    x--;
                    if (grid[y-1][x] == 0) dir = (dir+1)%4;
                    break;
                case 'u':
                    y--;
                    if (grid[y][x+1] == 0) dir = (dir+1)%4;
                    break;
            }
        }

        int sum = -grid[(length-1)/2][(length-1)/2];
        for (int i = 0; i < length; i++)
        {
            sum += grid[i][i];
            sum += grid[i][(length-1)-i];
        }

        // foreach (List<int> row in grid)
        // {
        //     foreach (int cell in row)
        //     {
        //         Console.Write(cell+" ");
        //     }
        //     Console.WriteLine("");
        // }
        Console.WriteLine("The sum is {0}", sum);

        //669171001
    }
}
