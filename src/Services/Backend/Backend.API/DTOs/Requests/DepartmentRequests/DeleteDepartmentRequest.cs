using Backend.Application.Commands.DepartmentCommands;
using Backend.Domain.SeedWork;

namespace Backend.API.DTOs.Requests.DepartmentRequests;

public class DeleteDepartmentRequest
{
    public DeleteDepartmentCommand ToApplicationRequest(Guid id)
    {
        return new DeleteDepartmentCommand(id);
    }
}