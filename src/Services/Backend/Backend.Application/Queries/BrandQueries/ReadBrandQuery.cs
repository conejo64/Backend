using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.BrandResponses;

namespace Backend.Application.Queries.BrandQueries;

public class ReadBrandQuery : IRequest<EntityResponse<BrandResponse>>
{
    public Guid Id { get; }

    public ReadBrandQuery(Guid id)
    {
        Id= id;
    }
}