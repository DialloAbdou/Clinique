using CliniqueDomain.Models;

namespace CliniqueApp.ApplicationServices.Contrats
{
    public interface IMaladeApplication
    {
        Task<Maladie> AddMaladeAsync(string pathologie);
    }
}
