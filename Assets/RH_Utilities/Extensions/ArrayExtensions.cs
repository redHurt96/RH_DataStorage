using System;
using static UnityEngine.Assertions.Assert;
using static UnityEngine.Random;

namespace RH_Utilities.Extensions
{
    public static class ArrayExtensions
    {
        public static T GetRandom<T>(this T[] array)
        {
            if (array is { Length:0 })
                throw new($"Attempt to get random element from empty array");
            
            return array[Range(0, array.Length)];
        }

        public static T[] ForEach<T>(this T[] array, Action<T> action)
        {
            IsNotNull(array);
            
            foreach (T t in array)
                action(t);

            return array;
        }
    }
}