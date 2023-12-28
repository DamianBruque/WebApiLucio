

namespace Utilities.Exceptions;

public class UserNotFoundException : Exception
{
    public static readonly string CUSTOM_MESSAGE = "User not found";
    public UserNotFoundException() : base(CUSTOM_MESSAGE) { }
}
