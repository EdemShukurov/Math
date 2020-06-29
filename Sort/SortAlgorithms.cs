using System;
using System.Collections.Generic;
using System.Linq;

namespace Math.Sort
{
    public static class SortAlgorithms
    {
        public static void BubbleSort<T>(IList<T> data)
            where T: IComparable<T>
        {
            for (int i = 0; i < data.Count(); i++)
            {
                for (int j = 0; j < data.Count() - i; j++)
                {
                    if(data[j+1].CompareTo(data[j]) < 0)
                    {
                        Swap(data, j, j + 1);
                    }
                }
            }
        }

        public static void ShakerSort<T>(IList<T> data)
            where T : IComparable<T>
        {
            if(data.Count() == 0)
            {
                return;
            }

            int left = 0;
            int right = data.Count() - 1;

            while(left <= right)
            {
                for (int i = right; i > left; i--)
                {
                    if(data[i-1].CompareTo(data[i]) > 0)
                    {
                        Swap(data, i - 1, i);
                    }
                }

                left++;

                for (int i = left; i < right; i++)
                {
                    if (data[i].CompareTo(data[i+1]) > 0)
                    {
                        Swap(data, i, i + 1);
                    }
                }

                right--;
            }
        }

        public static void CombSort<T>(IList<T> data)
           where T : IComparable<T>
        {
            const float decreaseFactor = 1.247f;

            int step = data.Count() - 1;

            while (step >= 1)
            {
                for (int i = 0; i < data.Count(); i++)
                {
                    if (data[i].CompareTo(data[i + step]) > 0)
                    {
                        Swap(data, i, i + step);
                    }
                }

                step = (int)(decreaseFactor / step);
            }

            BubbleSort(data);
        }

        public static void InsertionSort<T>(IList<T> data)
            where T: IComparable<T>
        {
            for (int i = 1; i < data.Count(); i++)
            {
                T x = data[i];
                int j = i;

                while (j > 0 && data[j-1].CompareTo(x) > 0)
                {
                    data[j] = data[j-1];                    
                    j--;
                }

                data[j] = x;
            }
        }

        public static void SelectionSort<T>(IList<T> data)
            where T: IComparable<T>
        {
            int count = data.Count() - 1;
            for (int i = 0; i < data.Count(); i++)
            {
                int minIndex = Min(data, i, count);
                Swap(data, i, minIndex);
            }
        }

        private static int Min<T>(IList<T> data, int leftIndex, int rightIndex)
             where T :IComparable<T>
        {
            return data[leftIndex].CompareTo(data[rightIndex]) < 0 ? leftIndex : rightIndex;
        }

        private static void Swap<T>(IList<T> data, int leftIndex, int rightIndex)
            where T : IComparable<T>
        {
            T tmp = data[leftIndex];
            data[leftIndex] = data[rightIndex];
            data[rightIndex] = tmp;
        }


    }
}
