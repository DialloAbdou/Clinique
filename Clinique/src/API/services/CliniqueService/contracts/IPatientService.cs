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
        Task<Patient> AddPatientAsync (Patient patient);

       // Task<Maladie?> GetMaladieByName(String NomPathologie, int medecinId);
      

    }
}
