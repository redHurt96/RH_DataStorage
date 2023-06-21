using System;
using System.Collections.Generic;
using System.Linq;
using static UnityEngine.Assertions.Assert;

namespace RH_Utilities.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            IsNotNull(source);
            
            foreach (T obj in source)
                action(obj);

            return source;
        }
        
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property) => 
            items
                .GroupBy(property)
                .Select(x => x.First());
    }
}