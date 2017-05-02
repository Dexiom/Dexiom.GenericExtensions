using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dexiom.GenericExtensions
{
    public static class GenericExtensions
    {
        public static T With<T>(this T source, Action<T> Method)
        {
            Method(source);
            return source;
        }

        public static bool In<T>(this T source, params T[] Items)
        {
            return Items.Contains(source);
        }

        public static bool NotIn<T>(this T source, params T[] Items)
        {
            return !In(source, Items);
        }

        public static bool IsDefaultForType<T>(this T source)
        {
            return EqualityComparer<T>.Default.Equals(source, default(T));
        }
    }
}
