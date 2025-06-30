namespace ProjectEuler.Mathematics
{
    class Determinant
    {
        public static decimal FindDeterminant(List<List<decimal>> matrix)
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

        static decimal Determinant2x2(List<List<decimal>> matrix)
        {
            decimal result = (matrix[0][0] * matrix[1][1]) - (matrix[1][0] * matrix[0][1]);

            return result;
        }

        static decimal Determinant3x3(List<List<decimal>> matrix)
        {
            decimal result = 0;

            for (int x = 0; x < matrix[0].Count; x++)
            {
                int sign = ((x + 1) % 2) * 2 - 1;

                List<List<decimal>> minor = Matrix.GetMinor(matrix, x, 0);

                decimal minorDet = Determinant2x2(minor) * sign * matrix[0][x];
                // Console.WriteLine("Minor's Determinant: {0}", minorDet);
                result += minorDet;
            }

            return result;
        }
    }
}