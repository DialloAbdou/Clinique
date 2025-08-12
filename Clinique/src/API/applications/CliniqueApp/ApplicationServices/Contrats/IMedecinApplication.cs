using CliniqueDomain.Models;

namespace CliniqueApp.ApplicationServices.Contrats
{
    public interface IMedecinApplication
    {
        Task<Medecin> AddMedecin(string nom, string prenom, string adresse, int age, string? Token);
        Task<IEnumerable<Medecin>> GetAllMedecin();
    }
}
