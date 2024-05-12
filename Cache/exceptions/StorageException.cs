using System;

namespace cache.exceptions;
public class StorageException : Exception
{
    public StorageException(string message) : base(message) { }
}