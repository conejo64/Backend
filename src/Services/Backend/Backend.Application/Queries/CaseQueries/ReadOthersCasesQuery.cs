using Backend.Application.DTOs.Responses.CaseResponses;
using Shared.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Queries.CaseQueries;

public class ReadOthersCasesQuery : BaseFilter, IRequest<EntityResponse<GetEntitiesResponse<CaseResponse>>>
{
    public Guid UserId { get; set; }
    public Guid? OriginDocumentId { get; set; }
    public Guid? CaseStatusId { get; set; }
    public Guid? DepartmentId { get; set; }
    public DateTime? InitialDate { get; set; }
    public DateTime? FinalDate { get; set; }


    public ReadOthersCasesQuery(Guid userId, Guid? originDocumentId, Guid? caseStatusId, Guid? departmentId, DateTime? initialDate, DateTime? finalDate, bool loadChildren,
        bool isPagingEnabled, int page, int pageSize)
    {
        UserId = userId;
        OriginDocumentId =  originDocumentId;
        CaseStatusId = caseStatusId;
        DepartmentId = departmentId;
        InitialDate = initialDate;
        FinalDate = finalDate;
        LoadChildren = loadChildren;
        IsPagingEnabled = isPagingEnabled;
        Page = page;
        PageSize = pageSize;
    }
}