using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenderRecognition
{
    public static class EnumerableExtensions
    {
        public static T ArgMax<T>(this IEnumerable<T> source, Func<T, int> selector)
        {
            if (Object.ReferenceEquals(null, source))
                throw new ArgumentNullException("source");

            if (Object.ReferenceEquals(null, selector))
                throw new ArgumentNullException("selector");

            T maxValue = default(T);
            int max = 0;
            Boolean assigned = false;

            foreach (T item in source)
            {
                int v = selector(item);

                if ((v > max) || (!assigned))
                {
                    assigned = true;
                    max = v;
                    maxValue = item;
                }
            }

            return maxValue;
        }
    }
}

