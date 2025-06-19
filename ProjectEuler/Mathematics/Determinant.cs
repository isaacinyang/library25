namespace ProjectEuler.Mathematics
{
    class Determinant
    {
        static bool matrixValid = true;
        static void CollectInput()
        {
            List<List<int>> matrix = InputMatrix();

            if (matrixValid) {
                int result = Determinant(matrix);

                Console.WriteLine(result);
            }
            else {
                Console.WriteLine("The matrix was invalid.");
                matrixValid = true;
                CollectInput();
            }
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

            Console.Write("Input the values. Each value should seperated by a comma and each row seperated by a semicolon:");
            reply = Console.ReadLine();

            foreach (var row in reply.Split(";"))
            {
                matrix.Add([]);

                foreach (var cell in row.Split(","))
                {
                    matrix[matrix.Count - 1].Add(Convert.ToInt32(cell));
                }

                if (matrix[matrix.Count - 1].Count != size) {
                    matrixValid = false;
                }
            }

            if (matrix.Count != size) {
                matrixValid = false;
            }

            return matrix;
        }
    }
}