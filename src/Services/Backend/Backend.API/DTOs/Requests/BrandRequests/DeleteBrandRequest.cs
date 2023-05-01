using Backend.Application.Commands.BrandCommands;
using Backend.Domain.SeedWork;

namespace Backend.API.DTOs.Requests.BrandRequests;

public class DeleteBrandRequest
{
    public DeleteBrandCommand ToApplicationRequest(Guid id)
    {
        return new DeleteBrandCommand(id);
    }
}