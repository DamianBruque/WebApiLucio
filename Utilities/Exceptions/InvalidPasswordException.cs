

namespace Utilities.Exceptions;

public class InvalidPasswordException : Exception
{
    public static readonly string CUSTOM_MESSAGE = "Invalid password";
    public InvalidPasswordException() : base(CUSTOM_MESSAGE) { }
}
