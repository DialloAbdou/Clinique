using CliniqueDomain.Models;

namespace CliniqueApp.ApplicationServices.Contrats
{
    public interface ISoinApplication
    {
        Task<Soin> AddSoinAsync
            (
                string typeSoin,
                int Durees,
                decimal prix
            );
        Task<IEnumerable<Soin>> GetAllSoinAsync();
     
    }
}
