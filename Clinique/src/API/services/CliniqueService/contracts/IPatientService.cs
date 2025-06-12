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
        Task<Medecin?> GetMedecinByNameAsync(string nomMedecin);
        Task<Maladie?> GetMaladieByNameAsync(string pathologie);
        Task<Patient> AddPatientAsync (Patient patient);
     
    }
}
