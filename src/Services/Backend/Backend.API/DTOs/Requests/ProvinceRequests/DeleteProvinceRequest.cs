using Backend.Application.Commands.ProvinceCommands;
using Backend.Domain.SeedWork;

namespace Backend.API.DTOs.Requests.ProvinceRequests;

public class DeleteProvinceRequest
{
    public DeleteProvinceCommand ToApplicationRequest(Guid id)
    {
        return new DeleteProvinceCommand(id);
    }
}