using Microsoft.Extensions.Caching.Memory;

namespace Playground.Core.Cache;

public class MemoryCache
{
    private readonly IMemoryCache _memoryCache = new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions());

    public T CacheRandomValueForSeconds<T>(T value, TimeSpan absoluteExpirationRelativeToNow)
    {
        ArgumentNullException.ThrowIfNull(value);
        
        var cacheKey = $"{value.GetType()}-cache-random-value-key";
        if (_memoryCache.TryGetValue(cacheKey, out T? cachedValue) && cachedValue != null)
        {
            return cachedValue;
        }

        _memoryCache.Set(cacheKey, value, absoluteExpirationRelativeToNow);
        return value;
    }
}