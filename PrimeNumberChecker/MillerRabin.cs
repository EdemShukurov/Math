using System;
using PolynomialAlgorithm.Extensions;
using PolynomialAlgorithm.PrimeNumberChecker.Interfaces;

namespace PolynomialAlgorithm.PrimeNumberChecker
{
    /// <summary>
    /// Miller - Rabin test
    /// </summary>
    /// <remarks>
    /// Let n is prime number and n-1 = 2^d, where d is odd. Then for any a, that belongs to Z_n) is perfromed at least one of the following terms:
    /// 1. a^d = 1 (mod n)
    /// 2. r < S, that a^((2^r)*d) = -1 (mod n)
    /// </remarks>
    public class MillerRabin : IPrimeNumberChecker
    {
        public bool IsNumberPrime(long number, byte counter = 4)
        {
            long zero = 0L, one = 1L;

            if((number & one) == zero || number < 2L)             // equals (n % 2L == zero || n < 2L)
            {
                return (number == 2L);
            }

            long s = number - one;

            while ((s & one) == zero)
            {
                s >>= 1;        // equals  s /= 2L;
            }

            Random r = new Random();

            for (byte i = 0; i < counter; i++)
            {                
                long a = r.NextLong(number - one) + one;
                long temp = s;
                long mod = 1;

                for (var j = 0; j < temp; ++j)
                {
                    mod = (mod * a) % number;
                }

                while (temp != number - one && mod != one && mod != number - one)
                {
                    mod = (mod * mod) % number;

                    temp <<= 1;         // equals  temp *= 2L;
                }

                if (mod != number - 1 && (temp & one) == zero) 
                {
                    return false; 
                }
            }

            return true;
        }
    }
}
