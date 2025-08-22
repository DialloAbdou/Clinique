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
        Task<IEnumerable<Patient>> GetAllPatients(int medecinId);
        Task<Patient> AddPatientAsync(Patient patient);
       
    }
}
