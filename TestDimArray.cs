using System;

namespace Math
{
    public static class TestDimArray
    {
        public static int SumOfElements(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                {
                    sum += array[i, j];
                }
            }

            return sum;
        }

        public static int SumOfElements(int[][] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                {
                    sum += array[i][j];
                }
            }

            return sum;
        }

        public static unsafe int UnsafeSumOfElements(int[,] array)
        {
            int sum = 0;

            fixed (int* pi = array)
            {
                for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
                {
                    int baseOfDim = i * (array.GetUpperBound(0) + 1);

                    for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                    {
                        sum += pi[baseOfDim + j];
                    }
                }
            }

            return sum;
        }
    }
}
