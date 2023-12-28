

namespace Utilities.Exceptions;

public class UserAlreadyExistsException : Exception
{
    public static readonly string CUSTOM_MESSAGE = "User already exists";
    public UserAlreadyExistsException() : base(CUSTOM_MESSAGE) { }
}
