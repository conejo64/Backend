using Backend.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Infrastructure.Services
{
    public class ProrrogationService : IProrrogationService
    {
        public async Task<bool> ProcessProrogation(Guid id, DateTime newDate)
        {

            return true;
        }
    }
}
