namespace Backend.Domain.Interfaces.Services;

public interface IOpenKmService
{
    bool SendOpenKm(List<string> documents, List<string> documentsNames);
}