using System;
using System.Numerics;
using System.Threading.Tasks;


namespace Math.PrimeNumberChecker
{
    /// <summary>
    /// Miller - Rabin test
    /// </summary>
    /// <remarks>
    /// Let n is prime number and n-1 = 2^d, where d is odd. Then for any a, that belongs to Z_n) is perfromed at least one of the following terms:
    /// 1. a^d = 1 (mod n)
    /// 2. r < S, that a^((2^r)*d) = -1 (mod n)
    /// </remarks>
    public static class MillerRabinParallel
    {
        public static bool IsNumberPrime(BigInteger number)
        {
            number.GetDandS(out BigInteger d, out int s);

            int k = (int)BigInteger.Log(number, 2d);

            bool isPrime = true;
            Parallel.For(0, k, (i, state) => 
            {
                var a = BigInteger.ModPow(GetRandBigInt(number - 2), d, number);
                if (a == 1 || a == number - 1)
                {
                    return;
                }

                for (int r = 1; r < s; r++)
                {
                    if (BigInteger.ModPow(a, 2, number) == number - 1)
                    {
                        return;
                    }

                    isPrime = false;
                    state.Break();
                }
            });

            return isPrime;
        }

        /// <summary>
        /// returns a evenly distributed random BigInteger from 1 to N.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static BigInteger GetRandBigInt(BigInteger n)
        {
            Random rand = new Random();
            BigInteger result;

            do
            {
                int length = (int)System.Math.Ceiling(BigInteger.Log(n, 2));
                int numBytes = (int)System.Math.Ceiling(length / 8.0);

                byte[] data = new byte[numBytes];
                rand.NextBytes(data);

                result = new BigInteger(data);
            } 
            while (result >=n || result <= 0);
            
            return result;
        }

        private static void GetDandS(this BigInteger number, out BigInteger d, out int s)
        {
            s = 0;
            d = number - 1;

            while((d & 1) != 1)   // if d is odd, then continue
            {
                d >>= 1;
                s++;
            }
        }
    }
}
