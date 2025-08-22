using CliniqueDomain.Models;
using CliniqueDomain.Tools;
using CliniqueInfrastructure.Contrats;
using CliniqueService.contracts;
using SQLitePCL;

namespace CliniqueService.domainServices
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        /// <summary>
        /// ajout Patient dans repositoryPatient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task<Patient> AddPatientAsync(Patient patient)
        {
         
            var _patient = await _patientRepository.AddPatientAsync(patient);
            return patient;
        }
        /// <summary>
        /// elle renvoie la liste de patients
        /// </summary>
        /// <returns></returns>
        public  async Task<IEnumerable<Patient>> GetAllPatientAsync()
        {
            return await _patientRepository.GetAllPatientAsync();
        }

  
    }
}
