using FluentAssertions;
using Playground.Core.CSharp;

namespace Playground.UnitTests.CSharp;

public class RefTests
{
    [Fact]
    public void FindElement_WhenUpdateReturnedElement_ShouldModifyArray()
    {
        // Arrange
        int[] numbers = [1, 2, 3, 4, 5];
        
        // Action
        
        // Find the element with value 3
        ref var refToNumber = ref Ref.FindElement(ref numbers, 3);

        // Update the element directly through the reference
        refToNumber = 10;

        // Assert
        var expectedResult = new[] { 1, 2, 10, 4, 5 };
        numbers.Should().BeEquivalentTo(expectedResult);
    }
}