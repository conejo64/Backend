using Backend.Application.DTOs.Responses.CaseResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Queries.CaseQueries;

public class ReadCaseQuery : IRequest<EntityResponse<CaseResponse>>
{
    public Guid Id { get; }

    public ReadCaseQuery(Guid id)
    {
        Id = id;
    }
}