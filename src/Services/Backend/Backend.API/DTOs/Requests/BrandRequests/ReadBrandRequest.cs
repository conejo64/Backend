using Backend.Application.Queries.BrandQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.BrandRequests;

public class ReadBrandRequest
{
    private Guid Id { get; }

    public ReadBrandRequest(Guid id)
    {
        Id = id;
    }

    public ReadBrandQuery ToApplicationRequest()
    {
        return new ReadBrandQuery(Id);
    }
}