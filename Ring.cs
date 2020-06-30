using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Math
{
    public class Ring
    {
        public static List<long> GetRingBy(long number)
        {
            var result = new List<long>();

            result.Add(1L);


            long step = 1L, initialIterator = 0L;

            if ((number & step) == initialIterator)    // equals number % 2L == 0L
            {
                step = 2L;
                initialIterator = 3L;
            }
            else
            {
                step = 1L;
                initialIterator = 2L;
            }


            for (long i = initialIterator; i < number; i += step)
            {
                if (StrippedGCD(i, number) == 1L)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        /// <summary>
        /// "Stripped" Greatest Common Divisor (Binary iterative algorithm, that uses bit operations). This method lacks some checks
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <remarks>
        /// Algorithm:
        /// 1. if   a is even, but b is odd,      then    GCD(a, b) = GCD( a/2, b );
        /// 2. if   a is odd, but b is even,      then    GCD(a, b) = GCD( a, b/2 );
        /// 3. if   a and b are odd and b > a,    then    GCD(a, b) = GCD( b - a, b/2 ); 
        /// 4. if   a and b are odd and b < a,    then    GCD(a, b) = GCD( a - b, b/2 ); 
        /// </remarks>
        private static long StrippedGCD(long a, long b)
        {
            long nod = 1L;
            long tmp;

            while (a != 0L && b != 0L)
            {
                // Algorithm: step 1
                if (((a & 1L) == 0L) && (b & 1L) != 0L)       // equals (a % 2L == 0L && b % 2L != 0L)
                {
                    a >>= 1;            //equals a /= 2L
                    continue;
                }

                // Algorithm: step 2
                if ((a & 1L) != 0L && ((b & 1L) == 0L))        // equals (a % 2L != 0L && b % 2L == 0L)
                {
                    b >>= 1;            //equals b /= 2L
                    continue;
                }

                tmp = a;
                a = (b - a) >> 1;       // equals a = (b - a) / 2L;
                b = tmp;
            }

            return nod * b;
        }


        public static List<int> GetRingByPrimeNumber(int primeNumber)
        {
            var ring = new List<int>();
            for (int i = 0; i < primeNumber; i++)
            {
                ring.Add(i);
            }

            return ring;
        }

        public static List<long> GetRingByPrimeNumber(long primeNumber)
        {
            var ring = new List<long>();
            for (long i = 0; i < primeNumber; i++)
            {
                ring.Add(i);
            }

            return ring;
        }

        public static List<BigInteger> GetRingByPrimeNumber(BigInteger primeNumber)
        {
            var ring = new List<BigInteger>();
            for (BigInteger i = 0; i < primeNumber; i++)
            {
                ring.Add(i);
            }

            return ring;
        }
    }
}