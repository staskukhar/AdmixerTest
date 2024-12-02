using System.Reflection;

namespace HedgehogTest.Core.Exceptions;

public class InvalidColorIndexException : Exception
{
    public InvalidColorIndexException(int colorIndex) : base($"Invalid color index: {colorIndex}")
    {
    }

    public InvalidColorIndexException(string message) : base(message)
    {
    }

    public InvalidColorIndexException(Exception innerException) : base($"Invalid color index: {innerException.Message}", innerException)
    {
    }
}