using Backend.Application.DTOs.Responses.CaseResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Queries.CaseQueries
{
    public class ReadAllCasesQuery : IRequest<EntityResponse<List<CaseResponse>>>
    {
        public ReadAllCasesQuery()
        {
        }
    }
}
