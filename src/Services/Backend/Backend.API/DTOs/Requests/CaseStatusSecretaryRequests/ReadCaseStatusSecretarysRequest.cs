using Backend.Application.Queries.CaseStatusSecretaryQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.CaseStatusSecretaryRequests;

public class ReadCaseStatusSecretarysRequest : BaseFilterDto
{
    public string? Description { get; set; }

    public ReadCaseStatusSecretarysQuery ToApplicationRequest()
    {
        return new ReadCaseStatusSecretarysQuery(Description, LoadChildren, IsPagingEnabled, Page, PageSize);
    }
}