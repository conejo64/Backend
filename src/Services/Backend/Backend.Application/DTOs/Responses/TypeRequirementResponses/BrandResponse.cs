using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.Responses.TypeRequirementResponses;

public class TypeRequirementResponse
{
    public Guid Id { get; }
    public string Description { get; set; }
    public string Status { get; set; }

    public TypeRequirementResponse(Guid id, string description, string status)
    {
        Id = id;
        Description = description;
        Status = status;
    }

    public static TypeRequirementResponse FromEntity(TypeRequirement type)
    {
        return new TypeRequirementResponse(type.Id, type.Description, type.Status);
    }
}