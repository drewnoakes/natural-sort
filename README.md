[![NaturalSort NuGet version](https://img.shields.io/nuget/v/NaturalSort.svg)](https://www.nuget.org/packages/NaturalSort/)

# NaturalSort

An implementation of `IComparer<string>` that respects integers embedded within strings and sorts them in the way that a human would expect.

```c#
// These strings are ordered according to StringComparer.Ordinal and friends
var strings = new[]
{
    "Item100",
    "Item20",
    "Item3"
};

// Re-order to the 'natural' order, considering integers within strings
Array.Sort(strings, NaturalStringComparer.Ordinal);

// Now the items are:
//
//   "Item3"
//   "Item20"
//   "Item100"
```

I originally posted this code on [Stack Overflow](https://stackoverflow.com/a/41168219/24874). It feels like it could be useful as its own NuGet package.

https://www.nuget.org/packages/NaturalSort/

The implementation has good performance, with no heap allocation during comparison.