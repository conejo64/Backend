using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.Responses.BrandResponses
{
    public class BrandResponse
    {
        public Guid Id { get; }
        public string Description { get; set; }
        public string Status { get; set; }

        public BrandResponse(Guid id, string description, string status)
        {
            Id = id;
            Description = description;
            Status = status;
        }

        public static BrandResponse FromEntity(Brand brand)
        {
            return new BrandResponse(brand.Id, brand.Description, brand.Status);
        }
    }
}
