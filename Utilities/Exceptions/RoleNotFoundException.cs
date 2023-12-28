

namespace Utilities.Exceptions;

public class RoleNotFoundException : Exception
{
    public static readonly string CUSTOM_MESSAGE = "Role not found";
    public RoleNotFoundException() : base(CUSTOM_MESSAGE) { }
}
