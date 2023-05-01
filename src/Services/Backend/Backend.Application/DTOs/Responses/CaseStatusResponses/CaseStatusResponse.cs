using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.Responses.CaseStatusResponses
{
    public class CaseStatusResponse
    {
        public Guid Id { get; }
        public string Description { get; set; }
        public string Status { get; set; }

        public CaseStatusResponse(Guid id, string description, string status)
        {
            Id = id;
            Description = description;
            Status = status;
        }

        public static CaseStatusResponse FromEntity(CaseStatus cs)
        {
            return new CaseStatusResponse(cs.Id, cs.Description, cs.Status);
        }
    }
}
