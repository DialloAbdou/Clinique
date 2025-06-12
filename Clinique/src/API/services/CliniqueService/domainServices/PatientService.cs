using CliniqueDomain.Models;
using CliniqueInfrastructure.Contrats;
using CliniqueService.contracts;

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
             var nbPatients = await GetNbrPatients();
            if (nbPatients > 10)
            {
                throw new IndexOutOfRangeException($"le service des urgences {nbPatients} admission de patients");
            }
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

        /// <summary>
        /// elle renvoie la maladie du patient
        /// </summary>
        /// <param name="pathologie"></param>
        /// <returns></returns>
        public async Task<Maladie?> GetMaladieByNameAsync(string pathologie)
        {
             return await _patientRepository.GetMaladieByNameAsync(pathologie);
        }

        /// <summary>
        /// elle le medecin du patient
        /// </summary>
        /// <param name="nomMedecin"></param>
        /// <returns></returns>
        public async Task<Medecin?> GetMedecinByNameAsync(string nomMedecin)
        {
            return await _patientRepository.GetMedecinByNameAsync(nomMedecin);
        }

        /// <summary>
        /// le nombre de patient inscrit dans
        /// la base 
        /// </summary>
        /// <returns></returns>
        private async Task< int> GetNbrPatients()
        {
           var _listPatient = await GetAllPatientAsync();
            return _listPatient.Count();
        }
    }
}
