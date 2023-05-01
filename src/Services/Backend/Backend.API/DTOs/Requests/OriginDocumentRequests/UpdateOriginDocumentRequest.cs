using Backend.Application.Commands.OriginDocumentCommands;

namespace Backend.API.DTOs.Requests.OriginDocumentRequests;

public class UpdateOriginDocumentRequest
{
    public string Description { get; }

    public UpdateOriginDocumentRequest(string description)
    {
        Description = description;
    }

    public UpdateOriginDocumentCommand ToApplicationRequest(Guid id)
    {
        return new UpdateOriginDocumentCommand(id, Description);
    }
}