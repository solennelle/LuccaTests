using System;

namespace LuccaDevises.Exceptions
{
public class MissingCurrencyException : Exception
{
    public MissingCurrencyException()
    {
    }

    public MissingCurrencyException(string message)
        : base(message)
    {
    }

    public MissingCurrencyException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
}