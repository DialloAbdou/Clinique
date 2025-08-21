using CliniqueDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueService.contracts
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatientAsync();
        Task<Medecin?> GetMaladieByIdAsync(string nomMedecin);
        Task<Maladie?> GetMaladieByNameAsync(string pathologie);
        Task<Maladie?> GetMaladieByIdAsync(int maladieId);
        Task<Patient> AddPatientAsync (Patient patient);
        Task<Medecin?> GetMedecinById(int medeciId);
        Task<Maladie?> GetMaladieByName(String NomPathologie, int medecinId);

    }
}
