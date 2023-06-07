using Backend.Domain.Interfaces.Services;

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
