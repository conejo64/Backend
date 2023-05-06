using Backend.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities
{
    public class Document : BaseEntity
    {
        public string Status { get; set; } = CatalogsStatus.Active;
    }
}
