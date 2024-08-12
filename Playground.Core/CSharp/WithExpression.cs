namespace Playground.Core.CSharp;

public static class WithExpression
{
    public record NamedPoint(string Name, int X, int Y);
    
    public static NamedPoint CloneUsingWith(this NamedPoint original, int newX)
    {
        return original with { Name = "copy", X = newX};
    }
}