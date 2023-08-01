using Backend.Application.DTOs.Responses.DashboardResponses;
using Backend.Application.DTOs.Responses.ProvinceResponses;
using Backend.Application.Queries.ProvinceQueries;
using Backend.Application.Specifications.CaseSpecs;
using Backend.Application.Specifications.ProvinceSpecs;

namespace Backend.Application.Queries.DashboardQueries;

public class ReadDashboardQueryHandler : IRequestHandler<ReadDashboardQuery, EntityResponse<DashboardResponse>>
{
    private readonly IReadRepository<CaseEntity> _repository;

    public ReadDashboardQueryHandler(IReadRepository<CaseEntity> repository)
    {
        _repository = repository;
    }

    public async Task<EntityResponse<DashboardResponse>> Handle(ReadDashboardQuery query,
        CancellationToken cancellationToken)
    {
        var response = new DashboardResponse();
        var dateLimit = DateTime.Now.AddDays(-7);
        var spec = new CaseSpec();
        var cases = await _repository.ListAsync(spec, cancellationToken);
        var totalCases = cases.Count();
        var totalCasesLast = cases.Where(x => x.CreatedAt >= dateLimit).Count();
        var totalCasesOpened = cases.Count(x => x.CaseStatus!.Description!.ToLower() == "abierto");
        var totalCasesOpenedLast = cases.Count(x => x.CaseStatus!.Description!.ToLower() == "abierto" && x.CreatedAt >= dateLimit);
        var totalCasesClosed = cases.Count(x => x.CaseStatus!.Description!.ToLower() == "cerrado");
        var totalCasesClosedLast = cases.Count(x => x.CaseStatus!.Description!.ToLower() == "cerrado" && x.CreatedAt >= dateLimit);
        response = new DashboardResponse()
        {
            TotalCases = totalCases,
            TotalCasesLast = totalCasesLast,
            TotalCasesOpened = totalCasesOpened,
            TotalCasesOpenedLast = totalCasesOpenedLast,
            TotalCasesClosed = totalCasesClosed,
            TotalCasesClosedLast = totalCasesClosedLast
        };

        return EntityResponse.Success(response);
    }
}