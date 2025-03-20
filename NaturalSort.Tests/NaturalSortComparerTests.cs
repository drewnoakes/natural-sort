// Copyright Drew Noakes. Licensed under the Apache-2.0 license. See the LICENSE file for more details.

using Xunit;

namespace NaturalSort.Tests;

public sealed class NaturalSortComparerTests
{
    [Theory]
    [InlineData("", "")]
    [InlineData(null, null)]
    [InlineData("Hello", "Hello")]
    [InlineData("Hello123", "Hello123")]
    [InlineData("123", "123")]
    [InlineData("123Hello", "123Hello")]
    public void CompareEqual(string? x, string? y)
    {
        Assert.Equal(0, NaturalSortComparer.Ordinal.Compare(x, y));
        Assert.Equal(0, NaturalSortComparer.Ordinal.Compare(y, x));
    }

    [Theory]
    [InlineData("", "Hello")]
    [InlineData(null, "Hello")]
    [InlineData("Hello", "Hello1")]
    [InlineData("Hello123", "Hello124")]
    [InlineData("Hello123", "Hello133")]
    [InlineData("Hello123", "Hello223")]
    [InlineData("123", "124")]
    [InlineData("123", "133")]
    [InlineData("123", "223")]
    [InlineData("123", "1234")]
    [InlineData("123", "2345")]
    [InlineData("0", "1")]
    [InlineData("123Hello", "124Hello")]
    [InlineData("123Hello", "133Hello")]
    [InlineData("123Hello", "223Hello")]
    [InlineData("123Hello", "1234Hello")]
    [InlineData("Hello123A", "Hello123B")]
    public void CompareOrdered(string? x, string? y)
    {
        Assert.Equal(-1, NaturalSortComparer.Ordinal.Compare(x, y));
        Assert.Equal(1, NaturalSortComparer.Ordinal.Compare(y, x));
    }
}
