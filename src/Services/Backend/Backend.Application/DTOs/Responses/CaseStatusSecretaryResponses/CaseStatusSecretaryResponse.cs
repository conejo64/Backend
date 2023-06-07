using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.Responses.CaseStatusSecretaryResponses;

public class CaseStatusSecretaryResponse
{
    public Guid Id { get; }
    public string Description { get; set; }
    public string Status { get; set; }

    public CaseStatusSecretaryResponse(Guid id, string description, string status)
    {
        Id = id;
        Description = description;
        Status = status;
    }

    public static CaseStatusSecretaryResponse FromEntity(CaseStatusSecretary cs)
    {
        return new CaseStatusSecretaryResponse(cs.Id, cs.Description, cs.Status);
    }
}