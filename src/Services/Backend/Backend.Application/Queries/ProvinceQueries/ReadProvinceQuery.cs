using Backend.Application.DTOs.Responses.ManagerUserResponses;
using Backend.Application.DTOs.Responses.ProvinceResponses;

namespace Backend.Application.Queries.ProvinceQueries
{
    public class ReadProvinceQuery : IRequest<EntityResponse<ProvinceResponse>>
    {
        public Guid Id { get; }

        public ReadProvinceQuery(Guid id)
        {
            Id= id;
        }
    }
}