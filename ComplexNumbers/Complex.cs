using System.Collections.Generic;

namespace Math.ComplexNumbers
{
    public struct Complex
    {
        /// <summary>
        /// Real part of the complex number.
        /// </summary>
        public readonly double Re;

        /// <summary>
        /// Imaginary part of the complex number.
        /// </summary>

        public readonly double Im;

        /// <summary>
        ///  A complex number that represents zero.
        /// </summary>
        public static readonly Complex Zero = new Complex(0, 0);

        /// <summary>
        ///  A complex number that represents one.
        /// </summary>
        public static readonly Complex One = new Complex(1, 0);

        /// <summary>
        ///  A complex number that represents the square root of (-1).
        /// </summary>
        public static readonly Complex I = new Complex(0, 1);


        public double Magnitude
        {
            get
            {
                return System.Math.Sqrt(Re * Re + Im * Im);
            }
        }

        public double Phase
        {
            get
            {
                if (Re != 0d)
                {
                    return System.Math.Atan(Im / Re);
                }
                else if (Im > 0d)
                {
                    return 90d;
                }
                else
                {
                    return -90d;
                }
            }
        }


        public Complex(double real)
        {
            this.Re = real;
            Im = 0d;
        }

        public Complex(double real, double imag)
        {
            this.Re = real;
            this.Im = imag;
        }

        #region Math Operations

        /// <summary>
        /// Adds two complex numbers.
        /// </summary>
        /// <param name="a">An <see cref="Complex"/> instance.</param>
        /// <param name="b">An <see cref="Complex"/> instance.</param>
        /// <returns>Returns new <see cref="Complex"/> instance containing the sum of specified complex numbers.</returns>       
        public static Complex Add(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }

        /// <summary>
        /// Adds two complex numbers.
        /// </summary>
        /// <param name="a">An <see cref="Complex"/> instance.</param>
        /// <param name="b">An <see cref="Complex"/> instance.</param>
        /// <returns>Returns new <see cref="Complex"/> instance containing the sum of specified complex numbers.</returns>       
        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }


        /// <summary>
        /// Subtracts two complex numbers.
        /// </summary>
        /// <param name="a">An <see cref="Complex"/> instance.</param>
        /// <param name="b">An <see cref="Complex"/> instance.</param>
        /// <returns>Returns new <see cref="Complex"/> instance containing the subtraction of specified complex numbers.</returns>       
        public static Complex Subtract(Complex a, Complex b)
        {
            return new Complex(a.Re - b.Re, a.Im - b.Im);
        }

        /// <summary>
        /// Subtracts two complex numbers.
        /// </summary>
        /// <param name="a">An <see cref="Complex"/> instance.</param>
        /// <param name="b">An <see cref="Complex"/> instance.</param>
        /// <returns>Returns new <see cref="Complex"/> instance containing the subtraction of specified complex numbers.</returns>       

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Re - b.Re, a.Im - b.Im);
        }


        /// <summary>
        /// Multiplies two complex numbers.
        /// </summary>
        /// <param name="a">An <see cref="Complex"/> instance.</param>
        /// <param name="b">An <see cref="Complex"/> instance.</param>
        /// <returns>Returns new <see cref="Complex"/> instance containing the multiplication of specified complex numbers</returns>
        public static Complex Multiply(Complex a, Complex b)
        {
            // (x + yi)(u + vi) = (xu – yv) + (xv + yu)i. 
            return new Complex((a.Re * b.Re) - (a.Im * b.Im),
                               (a.Re * b.Im) + (a.Im * b.Re));
        }

        /// <summary>
        /// Multiplies two complex numbers.
        /// </summary>
        /// <param name="a">An <see cref="Complex"/> instance.</param>
        /// <param name="b">An <see cref="Complex"/> instance.</param>
        /// <returns>Returns new <see cref="Complex"/> instance containing the multiplication of specified complex numbers</returns>
        public static Complex operator *(Complex a, Complex b)
        {
            // (x + yi)(u + vi) = (xu – yv) + (xv + yu)i. 
            return new Complex((a.Re * b.Re) - (a.Im * b.Im),
                               (a.Re * b.Im) + (a.Im * b.Re));
        }


        /// <summary>
        /// Divides two complex numbers.
        /// </summary>
        /// <param name="a">An <see cref="Complex"/> instance.</param>
        /// <param name="b">An <see cref="Complex"/> instance.</param>
        /// <returns>Returns new <see cref="Complex"/> instance containing the division of specified complex numbers</returns>

        public static Complex Devide(Complex a, Complex b)
        {
            // (x + yi) / (u + vi) = ( (xu + yv) + (- xv + yu)i ) / (u^2 + v^2). 

            return new Complex((a.Re * b.Re) + (a.Im * b.Im), -(a.Re * b.Im) + (a.Im * b.Re)) /
                               (b.Re * b.Re + b.Im * b.Im);
        }

        /// <summary>
        /// Divides two complex numbers.
        /// </summary>
        /// <param name="a">An <see cref="Complex"/> instance.</param>
        /// <param name="b">An <see cref="Complex"/> instance.</param>
        /// <returns>Returns new <see cref="Complex"/> instance containing the division of specified complex numbers</returns>
        public static Complex operator /(Complex a, Complex b)
        {
            // (x + yi) / (u + vi) = ( (xu + yv) + (- xv + yu)i ) / (u^2 + v^2). 

            return new Complex((a.Re * b.Re) + (a.Im * b.Im), -(a.Re * b.Im) + (a.Im * b.Re)) / 
                               (b.Re * b.Re + b.Im * b.Im);
        }

        /// <summary>
        /// Divides complex number to value.
        /// </summary>
        /// <param name="a">An <see cref="Complex"/> instance.</param>
        /// <param name="value"> number </param>
        /// <returns>Returns new <see cref="Complex"/> instance containing the division of specified complex number and number</returns>

        public static Complex operator /(Complex a, double value)
        {
            return new Complex(a.Re / value, a.Im / value);
        }


        public Complex PowOf2()
        {
            return new Complex((Re * Re) - (Im * Im), 2 * Re * Im);
        }

        #endregion Math Operations

        public static Complex ConvertFromPolarToComplex(double r, double theta)
        {
            return new Complex(r * System.Math.Cos(theta), r * System.Math.Sin(theta));
        }

        public static void IncreaseCapacity(ref List<Complex> complices, int expectedCount)
        {
            var neededCount = expectedCount - complices.Count;

            for (int i = 0; i < neededCount; i++)
            {
                complices.Add(Complex.Zero);
            }
        }

        public int ConvertToInt32()
        {
            return (int)System.Math.Floor(Re + 0.5);
        }

        public long ConvertToInt64()
        {
            return (long)System.Math.Floor(Re + 0.5);
        }

        public override string ToString()
        {
            return Re.ToString() + " " + Im.ToString() + "i";
        }
    }
}
