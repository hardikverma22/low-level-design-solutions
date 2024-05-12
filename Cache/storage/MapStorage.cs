
using cache.exceptions;
using Cache;

namespace cache.storage;
public class MapStorage<TKey, TValue> : IStorage<TKey, TValue>
where TKey : notnull
    //  where Value : class
{
    private readonly Dictionary<TKey, TValue> map;
    private readonly int capacity;
    public MapStorage(int capacity)
    {
        this.capacity = capacity;
        map = new();
    }

    private bool IsStorageFull()
    {
        if (map.Count == capacity) return true;
        return false;
    }

    public void Add(TKey key, TValue value)
    {
        // Implementation here
        if (IsStorageFull())
        {
            throw new StorageFullException($"Storgae Full...");
        }
        map.Add(key, value);
    }

    public TValue Get(TKey key)
    {
        if (map.TryGetValue(key, out TValue? value))
        {
            return value;
        }

        throw new KeyNotFoundException($"{key}:  Key Not Found");
    }

    public void Remove(TKey key)
    {
        if (!map.ContainsKey(key)) throw new StorageException($"{key}:  Key Not Found");
        map.Remove(key);
    }
}