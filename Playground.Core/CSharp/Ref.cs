namespace Playground.Core.CSharp;

/// <summary>
/// In C#, a reference of a value can be returned,
/// and such return values can also be stored inside a variable by the caller.
/// The former characteristic is called ref return and the latter is called ref local.
/// </summary>
public static class Ref
{
    /// <summary>
    /// Method that returns a reference to an array element.
    /// </summary>
    public static ref int FindElement(ref int[] array, int value)
    {
        for (var i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return ref array[i]; // Return the reference to the found element
            }
        }

        throw new InvalidOperationException("Element not found");
    }
}