using FluentAssertions;
using Playground.Core.Cache;

namespace Playground.UnitTests.Cache;

public class MemoryCacheTests
{
    [Fact]
    public void CacheRandomValueForSeconds_WhenCalledMultipleTimes_ShouldReturnCachedValue()
    {
        // Arrange
        var memoryCache = new MemoryCache();
        var expectedCachedValue = Random.Shared.Next();
        var randomValue = Random.Shared.Next();
        
        // Act
        var firstResult = memoryCache.CacheRandomValueForSeconds(expectedCachedValue, TimeSpan.FromMinutes(60));
        var secondResult = memoryCache.CacheRandomValueForSeconds(randomValue, TimeSpan.FromMinutes(60));
        
        // Assert
        firstResult.Should().Be(expectedCachedValue);
        secondResult.Should().Be(expectedCachedValue);
    }
    
    [Fact]
    public async Task CacheRandomValueForSeconds_WhenCacheExpires_ShouldReturnNewValue()
    {
        // Arrange
        var memoryCache = new MemoryCache();
        var expectedCachedValue = Random.Shared.NextInt64();
        var randomValue = Random.Shared.NextInt64();
        
        // Act
        var firstResult = memoryCache.CacheRandomValueForSeconds(expectedCachedValue, TimeSpan.FromSeconds(1));
        var secondResult = memoryCache.CacheRandomValueForSeconds(randomValue, TimeSpan.FromSeconds(60));
        await Task.Delay(1500);
        
        var thirdResult = memoryCache.CacheRandomValueForSeconds(randomValue, TimeSpan.FromSeconds(60));

        // Assert
        firstResult.Should().Be(expectedCachedValue);
        secondResult.Should().Be(expectedCachedValue);
        thirdResult.Should().Be(randomValue);
    }
}