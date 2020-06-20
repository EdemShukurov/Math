using Math.ComplexNumbers;
using System.Collections.Generic;

namespace Math.FFT
{
    public static class FourierTransform
    {
        public static List<int> MultiplicatePolynomials(List<int> A, List<int> B)
        {
            int neededDegree = MathBase.FindUpperDegreeOf2(System.Math.Max(A.Count, B.Count));

            neededDegree <<= 1;        // equals neededDegree *= 2;

            var complexA = ComplexConverter.ConvertToComplexList(A, neededDegree);
            var complexB = ComplexConverter.ConvertToComplexList(B, neededDegree);

            complexA = MakeFFT(complexA);
            complexB = MakeFFT(complexB);

            for (int i = 0; i < neededDegree; i++)
            {
                complexA[i] *= complexB[i];
            }

            return ComplexConverter.ConvertToIntList(MakeInverseFFT(complexA));
        }


        public static List<Complex> MakeFFT(List<Complex> complices)
        {
            // for best accuracy
            var angle = 2 * System.Math.PI / complices.Count;

            //// W_n = e ^ ((i * 2 * PI) / n) 
            Complex wn = new Complex(System.Math.Cos(angle), System.Math.Sin(angle));

            return MakeGenericFFT(complices, wn);
        }

        public static List<Complex> MakeInverseFFT(List<Complex> complices)
        {
            // for best accuracy
            var angle = 2 * System.Math.PI / complices.Count;

            //// W_n = e ^ ((i * 2 * PI) / n) 
            Complex wn = new Complex(System.Math.Cos(angle), -System.Math.Sin(angle));

            complices = MakeGenericFFT(complices, wn);

            for (int i = 0; i < complices.Count; i++)
            {
                complices[i] /= complices.Count;
            }

            return complices;
        }

        private static List<Complex> MakeGenericFFT(List<Complex> complices, Complex wn)
        {
            if (complices.Count == 1)
            {
                return complices;
            }

            // init A_odd and A_even 
            List<Complex> complices_even = new List<Complex>();
            List<Complex> complices_odd = new List<Complex>();

            complices_even.Add(complices[0]);
            complices_odd.Add(complices[1]);

            int halfOfSize = complices.Count >> 1;      // equals to size = complices.Count / 2;

            for (int i = 1; i < halfOfSize; i++)
            {
                var double_i = i << 1;                  // equals to double_i = 2 * i;
                complices_even.Add(complices[double_i]);
                complices_odd.Add(complices[double_i + 1]);
            }

            var double_wn = wn * wn;

            complices_even = MakeGenericFFT(complices_even, double_wn);
            complices_odd = MakeGenericFFT(complices_odd, double_wn);


            // power
            Complex w = new Complex(1d);

            // complices = Complices_even + t * Compices_odd
            for (int i = 0; i < halfOfSize; i++)
            {
                var w_multiply_cB = w * complices_odd[i];

                complices[i] = complices_even[i] + w_multiply_cB;
                complices[i + halfOfSize] = complices_even[i] - w_multiply_cB;
                w *= wn;
            }

            return complices;
        }
    }
}
