namespace CacheTest;
using Cache;
[TestClass]
public class UnitTest1
{
    private Cache<int, int> cache;


    [TestInitialize]
    public void Setup()
    {
        cache = (new CacheFactory<int, int>()).DefaultCache(3);
    }

    [TestMethod]
    public void testAllCacheMthods()
    {
        cache.Put(1, 1);
        cache.Put(2, 2);

        Assert.AreEqual(1, cache.Get(1));
        // assertEquals(1, cache.get(1)); // Accessing 1 after 2 got inserted which makes 2 the least recently used till now.
        cache.Put(3, 3);
        Assert.AreEqual(3, cache.Get(3));

        // assertEquals(3, cache.get(3));

        // // Now if i try to add any element, the eviction should happen
        // // Also eviction should happen based on LeastRecentlyUsedItem
        // // which is 2 in this case.
        cache.Put(4, 4);

        Assert.ThrowsException<KeyNotFoundException>(() => cache.Get(2));
        // cache.Get(2);
        // This should throw exception "Tried to access non-existing key."
    }

}