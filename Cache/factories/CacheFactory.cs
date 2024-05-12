using cache.storage;

namespace Cache;

public class CacheFactory<Key, Value>
where Key : notnull
    // where Value : class
{
    public Cache<Key, Value> DefaultCache(int capacity)
    {
        return new Cache<Key, Value>(new MapStorage<Key, Value>(capacity), new LRUEviction<Key>());
    }
}
