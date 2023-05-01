using Backend.Application.Commands.BrandCommands;

namespace Backend.API.DTOs.Requests.BrandRequests;

public class CreateBrandRequest
{
    public string Description { get; }

    public CreateBrandRequest(string description)
    {
        Description = description;
    }

    public CreateBrandCommand ToApplicationRequest()
    {
        return new CreateBrandCommand(Description);
    }
}