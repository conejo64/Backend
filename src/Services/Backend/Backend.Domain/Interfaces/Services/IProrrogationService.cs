namespace Backend.Domain.Interfaces.Services;

public interface IProrrogationService
{
    Task<bool> ProcessProrogation(Guid id, DateTime newDate);
}