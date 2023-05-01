using Backend.Application.Queries.ProvinceQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.ProvinceRequests;

public class ReadProvinceRequest
{
    private Guid Id { get; }

    public ReadProvinceRequest(Guid id)
    {
        Id = id;
    }

    public ReadProvinceQuery ToApplicationRequest()
    {
        return new ReadProvinceQuery(Id);
    }
}