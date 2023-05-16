using Backend.Application.DTOs.Responses.CaseResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.DTOs.Responses.DocumentResponses;

namespace Backend.Application.Queries.CaseQueries
{
    public class ReadAttachmentsCaseQuery : IRequest<EntityResponse<List<DocumentResponse>>>
    {
        public Guid Id { get; }

        public ReadAttachmentsCaseQuery(Guid id)
        {
            Id = id;
        }
    }
}
