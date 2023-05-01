using Backend.Application.Queries.OriginDocumentQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.OriginDocumentRequests;

public class ReadOriginDocumentsRequest : BaseFilterDto
{
    public string? Description { get; set; }

    public ReadOriginDocumentsQuery ToApplicationRequest()
    {
        return new ReadOriginDocumentsQuery(Description, LoadChildren, IsPagingEnabled, Page, PageSize);
    }
}