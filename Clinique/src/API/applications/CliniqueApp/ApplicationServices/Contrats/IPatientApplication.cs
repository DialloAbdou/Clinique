using CliniqueDomain.Models;
using System.ComponentModel.DataAnnotations.Schema;

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
            int maladieId,
            int medecinId
        );

        Task<IEnumerable<Patient>> GetAllPatients(int medecinId);




    }
}
