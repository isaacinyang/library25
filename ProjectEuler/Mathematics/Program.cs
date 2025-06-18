namespace ProjectEuler.Mathematics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> matrix = InputMatrix();

            int result = Determinant(matrix);

            Console.WriteLine(result);
        }

        static int Determinant(List<List<int>> matrix)
        {
            switch (matrix.Count)
            {
                case 2:
                    return Determinant2x2(matrix);
                case 3:
                    return Determinant3x3(matrix);
                default:
                    return -1;
            }
        }

        static int Determinant2x2(List<List<int>> matrix)
        {
            int result = (matrix[0][0] * matrix[1][1]) - (matrix[1][0] * matrix[0][1]);

            return result;
        }

        static int Determinant3x3(List<List<int>> matrix)
        {
            int result = 0;

            for (int x = 0; x < matrix[0].Count; x++)
            {
                int sign = ((x + 1) % 2) * 2 - 1;

                List<List<int>> minor = GetMinor(matrix, x, 0);

                int minorDet = Determinant2x2(minor) * sign * matrix[0][x];
                // Console.WriteLine("Minor's Determinant: {0}", minorDet);
                result += minorDet;
            }

            return result;
        }

        static List<List<int>> GetMinor(List<List<int>> matrix, int pX, int pY)
        {
            List<List<int>> minor = [];

            int cellX;
            int cellY;
            for (int y = 0; y < matrix.Count; y++)
            {
                minor.Add([]);
                for (int x = 0; x < matrix[0].Count; x++)
                {
                    cellX = x;
                    cellY = y;

                    if (cellX == pX || cellY == pY)
                    {
                        // Console.WriteLine("Skipping this cell ({0},{1})", cellX, cellY);
                        continue;
                    }

                    if (cellX > pX) cellX--;
                    if (cellY > pY) cellY--;

                    // Console.WriteLine("Cell x: {0}, Cell y: {1}; Point x: {2}, Point y: {3}", x, y, pX, pY);
                    minor[cellY].Add(matrix[y][x]);
                }
            }

            return minor;
        }

        static List<List<int>> InputMatrix()
        {
            List<List<int>> matrix = [];
            int size = 0;

            Console.Write("What is the length of the matrix?");
            string reply = Console.ReadLine();

            switch (reply)
            {
                case "2":
                    size = 2;
                    break;
                case "3":
                    size = 3;
                    break;
                default:
                    return InputMatrix();
            }

            for (int y = 0; y < size; y++)
            {
                matrix.Add([]);
                for (int x = 0; x < size; x++)
                {
                    Console.Write("Input the value of row {0}, column {1}: ", y, x);
                    reply = Console.ReadLine();

                    int value = Convert.ToInt32(reply);
                    matrix[y].Add(value);
                }
            }

            return matrix;
        }
    }
}