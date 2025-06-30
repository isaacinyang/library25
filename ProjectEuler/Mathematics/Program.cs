namespace ProjectEuler.Mathematics
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Project on...", 3);
            // solve equations
            List<List<decimal>> orig = [[2, 7, 4], [3, 1, 6], [5, 0, 8]];

            List<List<decimal>> next = MultiplyMatrices(orig, Matrix.InverseMatrix(orig));
            Matrix.Display(next);
        }

        static List<List<decimal>> MultiplyMatrices(List<List<decimal>> matrixA, List<List<decimal>> matrixB)
        {
            List<List<decimal>> result = [];

            if (matrixA[0].Count != matrixB.Count) return null;

            for (int r = 0; r < matrixA.Count; r++)
            {
                result.Add([]);
                for (int c = 0; c < matrixB[0].Count; c++)
                {
                    decimal cell = 0;
                    for (int i = 0; i < matrixA[0].Count; i++)
                    {
                        cell += matrixA[r][i] * matrixB[i][c];
                    }
                    result[r].Add(cell);
                }
            }

            return result;
        }
    }
}