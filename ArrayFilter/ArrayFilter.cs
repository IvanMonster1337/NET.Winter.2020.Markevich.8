﻿using System;

namespace ArrayFilter
{
    public static class ArrayFilter
    {
        /// <summary>Filters the array by predicate.</summary>
        /// <param name="arr">The array to filter.</param>
        /// <param name="predicate">The predicate container.</param>
        /// <returns>The filtered array.</returns>
        /// <exception cref="ArgumentNullException">arr - Array is null.
        /// or
        /// predicate - The filter is null.</exception>
        /// <exception cref="ArgumentException">Array is empty.</exception>
        public static int[] FilterBy(this int[] arr, IPredicate predicate)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr), "Array is null.");
            }

            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "The filter is null");
            }

            int[] result = new int[arr.Length];
            int resultIndex = 0;
            int buf;
            for (int i = 0; i < arr.Length; i++)
            {
                buf = arr[i];
                if (predicate.Predicate(buf))
                {
                    result[resultIndex] = buf;
                    resultIndex++;
                }
            }

            Array.Resize(ref result, resultIndex);
            return result;
        }
    }
}
