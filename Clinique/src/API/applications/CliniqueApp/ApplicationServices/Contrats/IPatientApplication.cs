using CliniqueDomain.Models;

namespace CliniqueApp.ApplicationServices.Contrats
{
    public interface IPatientApplication
    {
           Task<Patient> AddPatientAsync
        (
            string nom,
            string prenom,
            string adresse,
            int age,
            string pathologie,
            int medecinId
        );

      //  Task<IEnumerable<Patient>> GetAllPatientAsync();

        Task<Medecin?> GetMedecinById(int medeciId);

        Task<Maladie?> GetMaladieByName(String NomPathologie, int medecinId);


    }
}
