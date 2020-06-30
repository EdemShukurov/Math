using Math.PrimeNumberChecker.Interfaces;


namespace Math
{
    public static class Symbols
    {
        /// <summary>
        /// Legendre's symbol
        /// </summary>
        /// <param name="a"></param>
        /// <param name="p"></param>
        /// <remarks> 
        ///     
        ///     Preliminary GCD(a,p) = 1 and p is odd prime number
        ///  => Fermat's small theorem: a^(p-1) = 1 (mod p)
        ///  => (a^((p-1)/2) - 1) (a^((p-1)/2) + 1) = 0 (mod p)
        ///  => if a is quadratic residue, 
        ///     then  a^((p-1)/2) = (x ^ 2)^((p-1)/2) = x ^ (p-1) = 1 and we return 1
        /// 
        /// </remarks>
        /// <returns></returns>
        public static int Legendre(int a, int p)
        {
            if(a > p)
            {
                a %= p;
            }

            // (0/p) can be seen from the definition to be 0.
            if (a == 0 || a == p)
            {
                return 0;
            }

            // 1 is always a square modulo p, so (1/p) = 1 for all p.
            if (a == 1)
            {
                return 1; 
            }

            // RuleEvalMinusOne: As a consequence of Euler's Criterion, we have that
            // (-1 / p) =
            //          { 1     if p ≡ 1 mod 4
            //          { -1    if p ≡ 3 mod 4
            if (a == p - 1 || a == -1)
            {
                return p % 4 == 1 ? 1 : -1;
            }

            // As a consequence of Gauss's Lemma, we have that
            // (2 / p) =
            //          { 1     if p ≡ ±1 mod 8
            //          { -1    if p ≡ ±3 mod 8
            if (a == 2)
            {
                int r = p % 8;

                return r == 1 || r == 7 ? 1 : -1;
            }

            if(MathBase.IsPowerOf2(a))
            {
                return 1;
            }

            return -1;
        }

        public static int Kronecker_Jacobi(int a, int b, IPrimeNumberChecker primeNumberChecker)
        {
            if (b == 0)
            {
                return System.Math.Abs(a) == 1 ? 1 : 0;
            }

            // a and b are both even
            if (MathBase.IsEven(b) && MathBase.IsEven(a))
            {
                return 0;
            }

            int factor = 1;

            if (b < 0 && a >= 0)
            {
                b = -b;
            }
            else if (b < 0 && a < 0)
            {
                b = -b;
                factor = -1;
            }

            if (b == 1)
            {
                return factor;
            }

            if (b == 2)
            {
                if (MathBase.IsEven(a))
                {
                    return 0;
                }

                int aMod8 = a & 7;

                if ((aMod8 == 1) || aMod8 == 7) return factor; // a = 1, -1 mod 8
                return -factor; // a = 3, -3 mod 8
            }

            a %= b;

            // 0 <= a < b and 0 < b <= MaxInt
            if (a < 0)
            {
                a += b;
            }

            if (a == 0) 
            { 
                return 0;
            }

            if (a == 1) 
            {
                return factor; 
            }

            int[] tab2 = { 0, 1, 0, -1, 0, -1, 0, 1 };

            // (-1)^((a^2-1)/8) == tab2[a & 7]
            int v = 0;
            while (MathBase.IsEven(b))
            {
                v++;
                b >>= 1;
            }

            int k;
            if (MathBase.IsEven(v))
            {
                k = 1;
            }
            else
            {
                k = tab2[a & 7];
            }

            //step3:
            do
            {
                if (a == 0)
                {
                    if (b > 1)
                    {
                        return 0;
                    }
                    else 
                    {
                        return k * factor;
                    }
                }

                v = 0;
                while (MathBase.IsEven(a))
                {
                    v++;
                    a >>= 1;
                }

                if (!MathBase.IsEven(v)) 
                { 
                    k *= tab2[b & 7];       // k *= (-1)**((b*b-1)/8)
                }

                // step4:
                if ((a & b & 2) != 0)
                {
                    k = -k; // k = k*(-1)**((a-1)*(b-1)/4)
                }

                int r = a;
                a = b % r;
                b = r;
                // goto step3;
            }
            while (true);
        }
    }
}
