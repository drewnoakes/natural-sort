// Copyright Drew Noakes. Licensed under the Apache-2.0 license. See the LICENSE file for more details.

using System.Collections.Generic;

namespace NaturalSort
{
    /// <summary>
    /// A comparer of strings that preserves the order of numerical substrings.
    /// For example, <c>File2</c> comes before <c>File10</c>, which is the opposite of
    /// usual lexicographical ordering.
    /// </summary>
    /// <remarks>
    /// <see langword="null"/> values are sorted to the start of the collection.
    /// The comparison is case-sensitive.
    /// </remarks>
    public sealed class NaturalSortComparer : IComparer<string?>
    {
        /// <summary>
        /// Gets a singleton instance of this comparer for which non-integer characters are compared ordinally.
        /// </summary>
        public static NaturalSortComparer Ordinal { get; } = new();

        /// <inheritdoc />
        public int Compare(string? x, string? y)
        {
            // sort nulls to the start
            if (x == null)
                return y == null ? 0 : -1;
            if (y == null)
                return 1;

            var ix = 0;
            var iy = 0;

            while (true)
            {
                // sort shorter strings to the start
                if (ix >= x.Length)
                    return iy >= y.Length ? 0 : -1;
                if (iy >= y.Length)
                    return 1;

                var cx = x[ix];
                var cy = y[iy];

                int result;
                if (char.IsDigit(cx) && char.IsDigit(cy))
                    result = CompareInteger(x, y, ref ix, ref iy);
                else
                    result = cx.CompareTo(y[iy]);

                if (result != 0)
                    return result;

                ix++;
                iy++;
            }

            static int CompareInteger(string x, string y, ref int ix, ref int iy)
            {
                var lx = GetNumLength(x, ix);
                var ly = GetNumLength(y, iy);

                // shorter number first (note, doesn't handle leading zeroes)
                if (lx != ly)
                    return lx.CompareTo(ly);

                for (var i = 0; i < lx; i++)
                {
                    var result = x[ix++].CompareTo(y[iy++]);
                    if (result != 0)
                        return result;
                }

                return 0;

                static int GetNumLength(string s, int i)
                {
                    var length = 0;
                    while (i < s.Length && char.IsDigit(s[i++]))
                        length++;
                    return length;
                }
            }
        }
    }
}
