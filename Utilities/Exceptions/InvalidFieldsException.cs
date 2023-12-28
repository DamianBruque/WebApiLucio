

namespace Utilities.Exceptions;

public class InvalidFieldsException : Exception
{
    public static readonly string CUSTOM_MESSAGE = "Invalid fields";
    public InvalidFieldsException() : base(CUSTOM_MESSAGE) { }
}
