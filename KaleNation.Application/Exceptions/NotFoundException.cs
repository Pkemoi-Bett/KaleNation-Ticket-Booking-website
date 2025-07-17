namespace KaleNation.Application.Exceptions;

public class NotFoundException : Exception
{
    /// <summary>
    /// Represents an error when a requested entity is not found in the system.
    /// </summary>
    public NotFoundException(string message) : base(message) { }
}
