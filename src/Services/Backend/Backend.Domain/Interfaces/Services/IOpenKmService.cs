using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Interfaces.Services
{
    public interface IOpenKmService
    {
        bool SendOpenKm(List<string> documents, List<string> documentsNames);
    }
}
