using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dexiom.GenericExtensions
{
    public static class GenericExtensions
    {
        public static T With<T>(this T target, Action<T> action)
        {
            action(target);
            return target;
        }

        public static bool In<T>(this T target, params T[] items)
        {
            return items.Contains(target);
        }

        public static bool NotIn<T>(this T target, params T[] items)
        {
            return !In(target, items);
        }

        public static bool IsDefaultForType<T>(this T target)
        {
            return EqualityComparer<T>.Default.Equals(target, default(T));
        }

        public static T Clone<T>(this T target)
        {
            if (!typeof(T).IsSerializable)
                throw new ArgumentException("The type must be serializable.", nameof(target));

            //if null, simply return the default object
            if (ReferenceEquals(target, null))
                return default(T);

            var binaryFormatter = new BinaryFormatter();
            var memoryStream = new MemoryStream();
            using (memoryStream)
            {
                binaryFormatter.Serialize(memoryStream, target);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}
