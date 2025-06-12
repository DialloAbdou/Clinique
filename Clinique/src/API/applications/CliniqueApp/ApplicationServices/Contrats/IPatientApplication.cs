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
            string nomMedecin
        );

        Task<IEnumerable<Patient>> GetAllPatientAsync();
  
    }
}
