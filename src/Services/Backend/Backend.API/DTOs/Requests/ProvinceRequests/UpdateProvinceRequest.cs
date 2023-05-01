using Backend.Application.Commands.ProvinceCommands;

namespace Backend.API.DTOs.Requests.ProvinceRequests;

public class UpdateProvinceRequest
{
    public string Description { get; }

    public UpdateProvinceRequest(string description)
    {
        Description = description;
    }

    public UpdateProvinceCommand ToApplicationRequest(Guid id)
    {
        return new UpdateProvinceCommand(id, Description);
    }
}