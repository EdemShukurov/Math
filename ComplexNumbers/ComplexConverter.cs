using System;
using System.Collections.Generic;
using System.Text;

namespace Math.ComplexNumbers
{
    public static class ComplexConverter
    {
        public static List<Complex> ConvertToComplexList(List<int> list, int length)
        {
            var complexList = new List<Complex>();

            for (int i = 0; i < list.Count; i++)
            {
                complexList.Add(new Complex(list[i], 0d));
            }

            for (int i = 0; i < length - list.Count; i++)
            {
                complexList.Add(Complex.Zero);
            }

            return complexList;
        }


        public static List<Complex> ConvertToComplexList(List<long> list, int length)
        {
            var complexList = new List<Complex>();

            for (int i = 0; i < list.Count; i++)
            {
                complexList.Add(new Complex(list[i], 0d));
            }

            for (int i = 0; i < length - list.Count; i++)
            {
                complexList.Add(Complex.Zero);
            }

            return complexList;
        }

        public static List<int> ConvertToIntList(List<Complex> complexList)
        {
            var result = new List<int>();

            for (int i = 0; i < complexList.Count; i++)
            {
                result.Add(complexList[i].ConvertToInt32());
            }

            return result;
        }

        public static List<long> ConvertToLongList(List<Complex> complexList)
        {
            var result = new List<long>();

            for (int i = 0; i < complexList.Count; i++)
            {
                result.Add(complexList[i].ConvertToInt64());
            }

            return result;
        }

    }
}
