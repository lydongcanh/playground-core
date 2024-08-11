using FluentAssertions;
using Playground.Core.CSharp;

namespace Playground.UnitTests.CSharp;

public class RangesAndIndicesTests
{
    [Fact]
    public void FindLastElement_ShouldReturnExpectedResult()
    {
        // Arrange
        var array = new[] { 1, 2, 3, 4, 5 };
        
        // Act
        var result = array.FindLastElement();
        
        // Assert
        result.Should().Be(5);
    }

    [Fact]
    public void Slice_ShouldReturnExpectedResult()
    {
        // Arrange
        var array = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        const int startIndex = 2;
        const int endIndex = 5;
        
        // Act
        var result = array.Slice(startIndex, endIndex);
        
        // Assert
        var expectedResult = new[] { 3, 4, 5 };
        result.Should().BeEquivalentTo(expectedResult);
    }
}