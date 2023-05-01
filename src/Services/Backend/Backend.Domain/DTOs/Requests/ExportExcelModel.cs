using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.DTOs.Requests
{
    public class ExportExcelModel
    {
        public Guid? BrandId { get; set; }
        public Guid? CaseStatusId { get; set; }
        public Guid? DepartmentId { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
    }
}
