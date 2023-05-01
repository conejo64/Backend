using Backend.Application.Queries.CaseStatusSecretaryQueries;
using Shared.API.DTOs;

namespace Backend.API.DTOs.Requests.CaseStatusSecretaryRequests;

public class ReadCaseStatusSecretaryRequest
{
    private Guid Id { get; }

    public ReadCaseStatusSecretaryRequest(Guid id)
    {
        Id = id;
    }

    public ReadCaseStatusSecretaryQuery ToApplicationRequest()
    {
        return new ReadCaseStatusSecretaryQuery(Id);
    }
}