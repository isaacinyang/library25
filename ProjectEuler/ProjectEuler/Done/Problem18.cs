using System;

namespace ProjectEuler;

public class Problem18
{
    static List<Path> paths = new List<Path>();
    static List<List<int>> triangle = [[]];
    public static void Solution()
    {
        string triangle_text = "75 95 64 17 47 82 18 35 87 10 20 04 82 47 65 19 01 23 75 03 34 88 02 77 73 07 63 67 99 65 04 28 06 16 70 92 41 41 26 56 83 40 80 70 33 41 48 72 33 47 32 37 16 94 29 53 71 44 65 25 43 91 52 97 51 14 70 11 33 28 77 73 17 78 39 68 17 57 91 71 52 38 17 14 91 43 58 50 27 29 48 63 66 04 68 89 53 67 30 73 16 69 87 40 31 04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";
        // triangle_text = "3 7 4 2 4 6 8 5 9 3";

        List<string> numbers = triangle_text.Split(" ").ToList();
        for (int i = 0; i < numbers.Count; i++)
        {
            triangle[triangle.Count - 1].Add(Convert.ToInt32(numbers[i]));
            if (Convert.ToInt32(numbers[i]) < 10) Console.Write(" " + Convert.ToInt32(numbers[i]) + " ");
            else Console.Write(Convert.ToInt32(numbers[i]) + " ");

            if (triangle[triangle.Count - 1].Count == triangle.Count)
            {
                Console.WriteLine("");
                triangle.Add([]);
            }
        }

        paths.Add(new Path(0, 0, triangle[0][0]));

        for (int l = 0; l < triangle.Count-2; l++)
        {
            int pLength = paths.Count;

            for (int p = 0; p < pLength; p++)
            {
                paths[p].Move();
            }
        }

        int max = 0;
        foreach (Path path in paths)
        {
            if (path.value > max) max = path.value;
        }

        Console.WriteLine(max);
        // 1074
    }

    class Path
    {
        public int row;
        public int column;
        public int value;

        public Path(int row, int column, int value)
        {
            this.row = row;
            this.column = column;
            this.value = value;
        }

        public void Move()
        {
            this.row++;
            paths.Add(new Path(this.row, this.column+1, this.value + triangle[this.row][this.column+1]));
            this.value += triangle[this.row][this.column];
        }
    }
}
