using System.Collections.Generic;

namespace Math.ComplexNumbers
{
    public static class ComplexExtension
    {
        public static List<Complex> MultiplyBy(this List<Complex> A, List<Complex> B)
        {
            for (int i = 0; i < A.Count; i++)
            {
                A[i] *= B[i];
            }

            return A;
        }
    }
}
