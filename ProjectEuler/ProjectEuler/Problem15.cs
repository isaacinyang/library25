using System;

namespace ProjectEuler;

public class Problem15
{
    public static List<List<long>> board = Board(20, 20);
    public static void Solution()
    {
        Console.WriteLine("starting...");
        while (board[0][0] == -1)
        {
            for (int y = 0; y < board.Count; y++)
            {
                string row = "";
                for (int x = 0; x < board[0].Count; x++)
                {
                    if (board[y][x] == -1) row += "-|";
                    else row += board[y][x]+"|";
                }
                Console.WriteLine(row);
            }
            
            for (int y = 0; y < board.Count; y++)
            {
                for (int x = 0; x < board[0].Count; x++)
                {
                    if (board[y][x] != -1) continue;

                    if (y < board.Count - 1 && board[y+1][x] != -1 ||
                        x < board[0].Count - 1 && board[y][x+1] != -1) board[y][x] = 0;

                    if (y < board.Count - 1 && board[y+1][x] != -1) {
                        board[y][x] += board[y+1][x];
                        Console.WriteLine("{0}:{1} += {2}", x, y, board[y+1][x]);
                    }
                    if (x < board[0].Count - 1 && board[y][x+1] != -1) {
                        board[y][x] += board[y][x+1];
                        Console.WriteLine("{0}:{1} += {2}", x, y, board[y][x+1]);
                    }
                }
            }

            Console.WriteLine("");
        }

        Console.WriteLine("\n"+board[0][0]);

        //137846528820
    }

    static List<List<long>> Board(int bx, int by)
    {
        List<List<long>> board = new List<List<long>>();

        for (int y = 0; y < by+1; y++)
        {
            board.Add([]);

            for (int x = 0; x < bx+1; x++)
            {
                board[y].Add(-1);
            }
        }

        board[by][bx] = 0;
        board[by][bx-1] = 1;
        board[by-1][bx] = 1;

        return board;
    }
}
