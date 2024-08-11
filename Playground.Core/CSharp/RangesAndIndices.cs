namespace Playground.Core.CSharp;

public static class RangesAndIndices
{
    /// <summary>
    /// Returns the last element of an array using the unary expression '^'.
    /// </summary>
    /// <returns></returns>
    public static T FindLastElement<T>(this T[] array)
    {
        return array[^1];
    }

    /// <summary>
    /// Slice an array using the range expression '..'.
    /// </summary>
    public static T[] Slice<T>(this T[] array, int startIndex, int endIndex)
    {
        return array[startIndex..endIndex];
    }
}