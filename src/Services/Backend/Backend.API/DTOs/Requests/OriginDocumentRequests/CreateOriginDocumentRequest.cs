using Backend.Application.Commands.OriginDocumentCommands;

namespace Backend.API.DTOs.Requests.OriginDocumentRequests;

public class CreateOriginDocumentRequest
{
    public string Description { get; }

    public CreateOriginDocumentRequest(string description)
    {
        Description = description;
    }

    public CreateOriginDocumentCommand ToApplicationRequest()
    {
        return new CreateOriginDocumentCommand(Description);
    }
}