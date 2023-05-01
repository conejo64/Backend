using Backend.Application.Commands.ProvinceCommands;

namespace Backend.API.DTOs.Requests.ProvinceRequests;

public class CreateProvinceRequest
{
    public string Description { get; }

    public CreateProvinceRequest(string description)
    {
        Description = description;
    }

    public CreateProvinceCommand ToApplicationRequest()
    {
        return new CreateProvinceCommand(Description);
    }
}