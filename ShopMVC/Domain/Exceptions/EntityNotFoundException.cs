namespace Domain.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(object key, string fieldName, string entityName)
        : base($"'{entityName}' with '{fieldName}' = '{key}' not found")
    {
    }
}