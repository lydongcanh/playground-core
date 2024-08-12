using FluentAssertions;
using Playground.Core.CSharp;

namespace Playground.UnitTests.CSharp;

public class WithExpressionTests
{
    [Fact]
    public void CopyUsingWith_ShouldReturnExpectedResults()
    {
        // Arrange
        var original = new WithExpression.NamedPoint("original", 10, 20);
        
        // Act
        var copy = original.CloneUsingWith(1000);
        
        // Assert
        copy.Should().NotBeNull();
        copy.Name.Should().Be("copy");
        copy.X.Should().Be(1000);
    }
}