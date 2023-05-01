using Backend.Application.Commands.OriginDocumentCommands;
using Backend.Application.Commands.ProfileCommands;
using Backend.Domain.SeedWork;

namespace Backend.API.DTOs.Requests.OriginDocumentRequests;

public class DeleteOriginDocumentRequest
{
    public DeleteOriginDocumentCommand ToApplicationRequest(Guid id)
    {
        return new DeleteOriginDocumentCommand(id);
    }
}