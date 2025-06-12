using CliniqueDomain.Models;
using CliniqueInfrastructure.Contrats;
using CliniqueService.contracts;

namespace CliniqueService.domainServices
{
    public class SoinService : ISoinService
    {
        private ISoinRepository _soinRepository;
        public SoinService(ISoinRepository soinRepository)
        {
            _soinRepository = soinRepository;
        }
        public async Task<Soin> AddSoinAsync(Soin soin)
        {
            return await _soinRepository.AddSoinAsync(soin);
        }

        public Task<IEnumerable<Soin>> GetAllSoinAsync()
        {
            return _soinRepository.GetAllSoinAsync();
        }
    }
}
