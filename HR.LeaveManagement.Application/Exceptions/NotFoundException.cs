namespace HR.LeaveManagement.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, int id) : base($"{name} with id {id} was not found.")
    {
    }
}