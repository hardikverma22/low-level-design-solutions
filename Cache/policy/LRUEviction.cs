namespace Cache;

public class LRUEviction<Key> : IEvictionPolicy<Key> where Key : notnull
{
    private Dictionary<Key, LinkedListNode<Key>> map;
    private LinkedList<Key> linkedList;

    public LRUEviction()
    {
        linkedList = new();
        map = new();
    }

    public Key? Evict()
    {
        var last = linkedList.Last;
        if (last != null)
        {
            map.Remove(last.Value);
            linkedList.RemoveLast();
            return last.Value;
        }
        return default;
    }

    public void KeyAccessed(Key key)
    {
        if (map.ContainsKey(key))
        {
            linkedList.Remove(key);
            linkedList.AddFirst(key);
        }
        else
        {
            var node = new LinkedListNode<Key>(key);
            map.Add(key, node);
            linkedList.AddLast(node);
        }
    }
}
