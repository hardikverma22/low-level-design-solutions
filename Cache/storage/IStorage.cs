namespace cache.storage;
public interface IStorage<Key, Value>
{
    void Add(Key key, Value value);
    void Remove(Key key);
    Value Get(Key key);
}