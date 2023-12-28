

namespace Utilities.Exceptions;

public class DatabaseQueryErrorException : Exception
{
    public DatabaseQueryErrorException(string dbErrorString) : base($"Error en la consulta a la base de datos:\n{dbErrorString}")
    {
    }
}
