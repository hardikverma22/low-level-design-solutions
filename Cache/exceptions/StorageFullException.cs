namespace Cache;

public class StorageFullException : Exception
{
    public StorageFullException(string? message) : base(message)
    {
    }
}
