using CliniqueDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueInfrastructure.Contrats
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatientAsync();
        Task<Patient> AddPatientAsync(Patient patient);
        Task<Medecin?> GetMedecinById(int medeciId);
        Task<Maladie?> GetMaladieByIdAsync(int maladieId);
        Task<Maladie?> GetMaladieByNameAsync( string pathologie);
    }
}
