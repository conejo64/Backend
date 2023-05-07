using Backend.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Infrastructure.Services
{
    public class OpenKmService : IOpenKmService
    {
        public bool SendOpenKm(List<string> documents, List<string> documentsNames)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
