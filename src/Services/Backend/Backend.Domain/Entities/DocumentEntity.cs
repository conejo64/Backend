using Backend.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities
{
    public class DocumentEntity : BaseEntity
    {
        public string Status { get; set; } = CatalogsStatus.Active;
        public Guid? CaseId { get; set; }
        public CaseEntity? CaseEntity { get; set; }
        public string? Document64 { get; set; }
        public string? Document64Name { get; set; }
        public string? DocumentSource { get; set; }
    }
}
