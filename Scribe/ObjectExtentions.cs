using System.Collections.Generic;
using System.Linq;

namespace Scribe
{
    /// <summary>
    /// Extension methods for <see cref="object"/>.
    /// </summary>
    public static class ObjectExtentions
    {
        /// <summary>
        /// Given an <c>object</c>:
        /// 1, if that object is a collection, return that same collection;
        /// 2, if that object is a single collectible object, return a new collection containing it;
        /// 3, if that object is <c>null</c>, return an empty collection.
        /// </summary>
        /// <param name="input">The object in question.</param>
        public static IEnumerable<T> ToEnumerable<T>(this object input)
            => input is null
                ? Enumerable.Empty<T>()
                : input is IEnumerable<T> collection
                    ? collection
                    : Enumerable.Repeat((T)input, 1);
    }
}
