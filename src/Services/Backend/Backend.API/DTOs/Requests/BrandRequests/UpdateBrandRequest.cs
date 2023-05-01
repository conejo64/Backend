using Backend.Application.Commands.BrandCommands;

namespace Backend.API.DTOs.Requests.BrandRequests;

public class UpdateBrandRequest
{
    public string Description { get; }

    public UpdateBrandRequest(string description)
    {
        Description = description;
    }

    public UpdateBrandCommand ToApplicationRequest(Guid id)
    {
        return new UpdateBrandCommand(id, Description);
    }
}