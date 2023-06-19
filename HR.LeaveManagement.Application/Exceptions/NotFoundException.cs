namespace HR.LeaveManagement.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, int id) : base($"{name} with id {id} was not found.")
    {
    }

    public NotFoundException(string name, string email) : base($"{name} with email {email} was not found.")
    {
    }
}