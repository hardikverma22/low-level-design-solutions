namespace Cache;

public interface IEvictionPolicy<Key>
{
    Key? Evict();
    void KeyAccessed(Key key);
}
