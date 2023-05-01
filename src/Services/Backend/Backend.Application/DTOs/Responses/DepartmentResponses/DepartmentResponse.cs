using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.Responses.DepartmentResponses
{
    public class DepartmentResponse
    {
        public Guid Id { get; }
        public string Description { get; set; }
        public string Status { get; set; }

        public DepartmentResponse(Guid id, string description, string status)
        {
            Id = id;
            Description = description;
            Status = status;
        }

        public static DepartmentResponse FromEntity(Department department)
        {
            return new DepartmentResponse(department.Id, department.Description, department.Status);
        }
    }
}
