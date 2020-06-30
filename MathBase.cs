using System.Collections.Generic;
using System.Numerics;

namespace Math
{
    public static class MathBase
    {
        /// <summary>
        /// Greatest Common Divisor (Binary iterative algorithm, that uses bit operations) 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <remarks>
        /// Algorithm:
        /// 1. GCD(0, b) = b; GCD(a, 0) = a; GCD(a, a) = a; 
        /// 2. GCD(1, b) = 1; GCD(a, 1) = 1;
        /// 3. if   a and b are even,             then    GCD(a, b) = 2 * GCD(a/2, b/2);
        /// 4. if   a is even, but b is odd,      then    GCD(a, b) = GCD( a/2, b);
        /// 5. if   a is odd, but b is even,      then    GCD(a, b) = GCD( a, b/2);
        /// 6. if   a and b are odd and b > a,    then    GCD(a, b) = GCD( b - a, b/2); 
        /// 7. if   a and b are odd and b < a,    then    GCD(a, b) = GCD( a - b, b/2); 
        /// </remarks>
        public static long GCD(long a, long b)
        {
            // Algorithm: step 1
            if (a == 0L)
                return b;

            if (b == 0L || a == b)
                return a;

            // Algorithm: step 2
            if (a == 1L || b == 1L)
                return 1L;

            long nod = 1L;
            long tmp;

            while (a != 0L && b != 0L)
            {
                // Algorithm: step 3
                if (((a & 1L) | (b & 1L)) == 0L)        // equals (a % 2L == 0L && b % 2L == 0L)
                {
                    nod <<= 1;          // equals  nod *= 2L;
                    a >>= 1;            // equals  a /= 2L;
                    b >>= 1;            // equals  b /= 2L;
                    continue;
                }

                // Algorithm: step 4
                if (((a & 1L) == 0L) && (b & 1L) != 0L)       // equals (a % 2L == 0L && b % 2L != 0L)
                {
                    a >>= 1;            //equals a /= 2L
                    continue;
                }

                // Algorithm: step 5
                if ((a & 1L) != 0L && ((b & 1L) == 0L))        // equals (a % 2L != 0L && b % 2L == 0L)
                {
                    b >>= 1;            //equals b /= 2L
                    continue;
                }

                // Algorithm: step 6 & 7
                //if (a > b)
                //{
                //    Swap(ref a, ref b);
                //}


                // (a, b) = ((b - a) / 2, a)
                tmp = a;
                a = (b - a) >> 1;       // equals a = (b - a) / 2L;
                b = tmp;
            }

            return nod * (a == 0L ? b : a);
        }

        public static bool IsEven(int a)
        {
            return (a & 1) == 0;
        }

        public static bool IsEven(long a)
        {
            return (a & 1) == 0;
        }

        public static bool IsEven(BigInteger a)
        {
            return (a & 1) == 0;
        }

        /// <summary>
        /// Swap
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }


        /// <summary>
        /// Calculates power of 2.
        /// </summary>
        /// <param name="power">Power to raise in.</param>
        /// <returns>Returns specified power of 2 in the case if power is in the range of
        /// [0, 30]. Otherwise returns 0.</returns>
        public static int Pow2(int power)
        {
            return ((power >= 0) && (power <= 30)) ? (1 << power) : 0;
        }


        /// <summary>
        /// Checks if the specified integer is power of 2.
        /// </summary>
        /// <param name="x">Integer number to check.</param>
        /// <returns>Returns <b>true</b> if the specified number is power of 2.
        /// Otherwise returns <b>false</b>.</returns>        
        public static bool IsPowerOf2(long x)
        {
            return (x > 0) ? ((x & (x - 1)) == 0) : false;
        }

        public static int FindUpperDegreeOf2(int number)
        {
            int degree = 1;
            while (degree < number)
            {
                degree <<= 1;    // equals n*=2;
            }

            return degree;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        /// <remarks>
        /// Algorithm:
        /// 1. if   a is even, but b is odd,      then    GCD(a, b) = GCD( a/2, b );
        /// 2. if   a is odd, but b is even,      then    GCD(a, b) = GCD( a, b/2 );
        /// 3. if   a and b are odd and b > a,    then    GCD(a, b) = GCD( b - a, b/2 ); 
        /// </remarks>
        //public static long Mod(this long number, long module)
        //{
        //    // 
        //    if (number < module)
        //    {
        //        return number;
        //    }

        //    if (number == module)
        //    {
        //        return 0;
        //    }

        //    number -= module;

        //    if (number < module)
        //    {
        //        return number;
        //    }

        //    //
        //    long mod = module << 1;

        //    while (number > mod)
        //    {
        //        mod <<= 1;
        //    }

        //    mod >>= 1;

        //    number -= mod;

        //    if (number < module)
        //    {
        //        return number;
        //    }

        //    mod >>= 2;

        //    if (number - mod < 0)
        //    {
        //        mod <<= 1;
        //    }
        //    else
        //    {
        //        mod >>= 1;
        //    }


        //    while (number < mod)
        //    {
        //        mod >>= 1;
        //    }

        //    number -= mod;

        //    if (number < mod)
        //    {
        //        return number;
        //    }

        //    return number;
        //}
    }
}
