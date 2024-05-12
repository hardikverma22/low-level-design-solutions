using System.Reflection;
using cache.storage;
using Cache;
public class Cache<Key, Value>
{
    private readonly IStorage<Key, Value> storage;
    private readonly IEvictionPolicy<Key> evictionPolicy;
    public Cache(IStorage<Key, Value> storage, IEvictionPolicy<Key> evictionPolicy)
    {
        this.storage = storage;
        this.evictionPolicy = evictionPolicy;
    }

    public Value? Get(Key key)
    {
        var value = storage.Get(key);
        evictionPolicy.KeyAccessed(key);
        return value;
    }

    public void Put(Key key, Value value)
    {
        try
        {
            storage.Add(key, value);
            evictionPolicy.KeyAccessed(key);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            if (ex is StorageFullException)
            {
                var evictedKey = evictionPolicy.Evict();

                if (evictedKey is null)
                {
                    throw new Exception("Key not found");
                }
                storage.Remove(evictedKey);
                Put(key, value);
            }
        }
    }
}