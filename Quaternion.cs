using System;
using MathDotNet = System.Math;


namespace Math
{
    public class Quaternion
    {
        public const double EPSILONE = 1e-03D;

        /// <summary>
        /// An Identity Quaternion.
        /// </summary>
        public static readonly Quaternion Identity = new Quaternion(1, 0, 0, 0);

        /// <summary>
        /// A Quaternion With all elements set to 0;
        /// </summary>
        public static readonly Quaternion Zero = new Quaternion(0, 0, 0, 0);

        /// <summary>
        /// Squared length of quaternion
        /// </summary>
        public double Normalized
        {
            get
            {
                return x * x + y * y + z * z + w * w;
            }
        }

        public readonly double w, x, y, z;

        public Quaternion(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public double Dot(Quaternion quaternion)
        {
            return this.x * quaternion.x + this.y * quaternion.y + this.z * quaternion.z + this.w * quaternion.w;
        }

        public static Quaternion Slerp(Quaternion p, Quaternion q, float time, bool useShortCut = false)
        {
            var cos = p.Dot(q);

            var angle = MathDotNet.Acos(cos);

            if (MathDotNet.Abs(angle) < Quaternion.EPSILONE)
            {
                return p;
            }

            var sin = MathDotNet.Sin(angle);

            var inverseSin = 1f / sin;

            var coeff0 = MathDotNet.Sin((1f - time) * angle) * inverseSin;
            var coeff1 = MathDotNet.Sin(time * angle) * inverseSin;

            if (useShortCut == false || cos >= 0d)
            {
                return p * coeff0 + q * coeff1;
            }

            coeff0 = -coeff0;

            Quaternion temp = p * coeff0 + q * coeff1;

            var factor = 1d / MathDotNet.Sqrt(temp.Normalized);

            return temp * factor;

        }

        /// <summary>
        /// Computes inverse of a quaternion
        /// </summary>
        /// <returns></returns>
        public Quaternion Inverse()
        {
            double norm = Normalized;

            if (norm < 0)
            {
                return Quaternion.Zero;
            }

            var inverseNormalized = 1d / norm;

            return new Quaternion(-x * inverseNormalized, -y * inverseNormalized, -z * inverseNormalized, w * inverseNormalized);
        }

        public static Quaternion MultiplyByScalar(Quaternion p, double scalar)
        {
            return new Quaternion(p.x * scalar, p.y * scalar, p.z * scalar, p.w * scalar);
        }

        public static Quaternion operator *(Quaternion p, double scalar)
        {
            return MultiplyByScalar(p, scalar);
        }

        public static Quaternion operator +(Quaternion left, Quaternion right)
        {
            return Add(left, right);
        }

        public static Quaternion Add(Quaternion left, Quaternion right)
        {
            return new Quaternion(left.x + right.x, left.y + right.y, left.z + right.z, left.w + right.w);
        }

        public static Quaternion operator -(Quaternion left, Quaternion right)
        {
            return Subtract(left, right);
        }

        public static Quaternion Subtract(Quaternion left, Quaternion right)
        {
            return new Quaternion(left.x - right.x, left.y - right.y, left.z - right.z, left.w - right.w);
        }

        public static Quaternion operator *(Quaternion left, Quaternion right)
        {
            return new Quaternion
            (
               x: left.w * right.x + left.x * right.w + left.y * right.z - left.z * right.y,
               y: left.w * right.y + left.y * right.w + left.z * right.x - left.x * right.z,
               z: left.w * right.z + left.z * right.w + left.x * right.y - left.y * right.x,
               w: left.w * right.w - left.x * right.x - left.y * right.y - left.z * right.z
            );
        }

        public static bool operator == (Quaternion left, Quaternion right)
        {
            return (left.x == right.x) && 
                   (left.y == right.y) && 
                   (left.z == right.z) && 
                   (left.w == right.w);
        }

        public static bool operator != (Quaternion left, Quaternion right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            Quaternion temp = obj as Quaternion;
            if (temp == null)
            {
                return false;
            }

            return this == temp;
        }

        public override int GetHashCode()
        {
            return (int)x ^ (int)y ^ (int)z ^ (int)w;
        }

        public override string ToString()
        {
            return string.Format($"Quaternion with x = {x}, y = {y}, z = {z}, w = {w}");
        }

        public static Quaternion TryParse(string text)
        {
            int startPositionToParse = -1;

            for (int i = 0; i < text.Length; i++)
            {
                if(char.IsDigit(text[i]))
                {
                    startPositionToParse = i;
                    break;
                }
            }

            if(startPositionToParse == -1)
            {
                throw new FormatException("Can't parse that text");
            }

            var possibleNumbers = text.Substring(startPositionToParse, text.Length - startPositionToParse).Trim(' ', '(', ')', '<', '>').Split(',');

            try
            {
                Quaternion quaternion = new Quaternion(double.Parse(possibleNumbers[0].Trim()),
                                                       double.Parse(possibleNumbers[1].Trim()),
                                                       double.Parse(possibleNumbers[2].Trim()),
                                                       double.Parse(possibleNumbers[3].Trim()));

                return quaternion;
            }
            catch(Exception ex)
            {
                throw new FormatException("Can't parse that text", ex);
            }
        }
    }
}
