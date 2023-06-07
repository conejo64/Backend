using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.Responses.ProvinceResponses;

public class ProvinceResponse
{
    public Guid Id { get; }
    public string Description { get; set; }
    public string Status { get; set; }

    public ProvinceResponse(Guid id, string description, string status)
    {
        Id = id;
        Description = description;
        Status = status;
    }

    public static ProvinceResponse FromEntity(Province province)
    {
        return new ProvinceResponse(province.Id, province.Description, province.Status);
    }
}