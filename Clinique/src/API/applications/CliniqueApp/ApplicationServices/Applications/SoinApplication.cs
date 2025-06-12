using CliniqueApp.ApplicationServices.Contrats;
using CliniqueDomain.Models;
using CliniqueService.contracts;
using CliniqueService.domainServices;

namespace CliniqueApp.ApplicationServices.Applications
{
    public class SoinApplication : ISoinApplication
    {
        private ISoinService _soinService;
        public SoinApplication(ISoinService soinService)
        {
            _soinService =soinService;
        }
        public async Task<Soin> AddSoinAsync(string typeSoin, int Durees, decimal prix)
        {
            return await _soinService.AddSoinAsync
                        (
                         new Soin
                            {
                              TypeSoin = typeSoin,
                              Durees = Durees,
                              prix = prix 
                            }
                        );
        }

        public async Task<IEnumerable<Soin>> GetAllSoinAsync()
        {
            return await _soinService.GetAllSoinAsync();
        }
    }
}
