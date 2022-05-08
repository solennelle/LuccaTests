using System;

namespace LuccaDevises.Exceptions
{
public class InvalidFormatException : Exception
{
    public InvalidFormatException()
    {
    }

    public InvalidFormatException(string message)
        : base(message)
    {
    }

    public InvalidFormatException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
}