namespace ProjectEuler.Mathematics
{
    class Matrix
    {
        static bool matrixValid = true;
        public static List<List<decimal>> CollectInput()
        {
            List<List<decimal>> matrix = InputMatrix();

            if (matrixValid) {
                return matrix;
            }
            else {
                Console.WriteLine("The matrix was invalid.");
                matrixValid = true;
                return CollectInput();
            }
        }

        public static void Display(List<List<decimal>> matrix)
        {
            Console.WriteLine("---------");
            foreach (List<decimal> row in matrix)
            {
                Console.Write("=> ");
                foreach (decimal cell in row)
                {
                    Console.Write($"{Math.Floor(cell*100)/100, 6}|");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("---------");
        }

        static List<List<decimal>> InputMatrix()
        {
            List<List<decimal>> matrix = [];
            int length = 0;
            int height = 0;

            string reply;
            Console.Write("What is the length of the matrix?");
            reply = Console.ReadLine();
            switch (reply)
            {
                case "2":
                    length = 2;
                    break;
                case "3":
                    length = 3;
                    break;
                default:
                    return InputMatrix();
            }

            Console.Write("What is the height of the matrix?");
            reply = Console.ReadLine();
            switch (reply)
            {
                case "2":
                    length = 2;
                    break;
                case "3":
                    length = 3;
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

                if (matrix[matrix.Count - 1].Count != length) {
                    matrixValid = false;
                }
            }

            if (matrix.Count != height) {
                matrixValid = false;
            }

            return matrix;
        }

        public static List<List<decimal>> GetMinor(List<List<decimal>> matrix, int pX, int pY)
        {
            List<List<decimal>> minorFirst = [];
            List<List<decimal>> minor = [];

            int cellX;
            int cellY;
            for (int y = 0; y < matrix.Count; y++)
            {
                minorFirst.Add([]);
                for (int x = 0; x < matrix[0].Count; x++)
                {
                    cellX = x;
                    cellY = y;

                    if (cellX == pX || cellY == pY)
                    {
                        continue;
                    }

                    if (cellX > pX) cellX--;
                    if (cellY > pY) cellY--;

                    minorFirst[cellY].Add(matrix[y][x]);
                }
            }

            foreach (List<decimal> row in minorFirst)
            {
                if (row.Count != 0) minor.Add(row);
            }

            return minor;
        }

        static List<List<decimal>> CofactorMatrix(List<List<decimal>> matrix)
        {
            var result = new List<List<decimal>>();

            for (int r = 0; r < matrix.Count; r++)
            {
                result.Add([]);
                for (int c = 0; c < matrix[0].Count; c++)
                {
                    List<List<decimal>> minor = GetMinor(matrix, c, r);

                    result[r].Add(Determinant.FindDeterminant(minor) * (((r + c) % 2) * -2 + 1));
                }
            }

            return result;
        }

        public static List<List<decimal>> InverseMatrix(List<List<decimal>> matrix)
        {
            List<List<decimal>> resultA = Adjoint(matrix);
            List<List<decimal>> result = [];
            decimal det = Determinant.FindDeterminant(matrix);

            foreach (List<decimal> row in resultA)
            {
                result.Add([]);
                foreach (decimal cell in row)
                {
                    result[result.Count - 1].Add(cell);
                }
            }

            for (int r = 0; r < matrix.Count; r++)
            {
                for (int c = 0; c < matrix[0].Count; c++)
                {
                    result[r][c] /= det;
                }
            }

            return result;
        }

        static List<List<decimal>> TransposeMatrix(List<List<decimal>> matrix)
        {
            var result = new List<List<decimal>>();

            for (int r = 0; r < matrix.Count; r++)
            {
                result.Add([]);
                for (int c = 0; c < matrix[0].Count; c++)
                {
                    result[r].Add(0);
                }
            }

            for (int r = 0; r < matrix.Count; r++)
            {
                for (int c = 0; c < matrix[0].Count; c++)
                {
                    result[c][r] = matrix[r][c];
                }
            }

            return result;
        }

        static List<List<decimal>> Adjoint(List<List<decimal>> matrix)
        {
            return TransposeMatrix(CofactorMatrix(matrix));
        }
    }
}